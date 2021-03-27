using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingModule.BType
{
    /// <summary>
    ///  MQ 客户端
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MQClient<T> where T : class
    {
        private static Dictionary<int, IConnection> _connectionCache = MQManager.ConnCache;
        private static Dictionary<int, List<IModel>> _channelCache = MQManager.ChannelCache;
        private static int _connectionHash;
        #region 字段/属性
        /// <summary>
        /// 连接实体
        /// </summary>
        private readonly ConnectionModel _connectionModel = new ConnectionModel();

        /// <summary>
        /// QM交换机名
        /// </summary>
        public string ExchangeName { get; set; } = "OTHE_MODI_MOPR_AAA_REPLY";
        /// <summary>
        /// 是否创建交换器, 默认false
        /// </summary>
        public bool IsCreateExchange { get; set; } = false;
        /// <summary>
        /// QM交换机类型
        /// </summary>
        public string ExchangeType { get; set; } = "fanout";
        /// <summary>
        /// QM路由键
        /// </summary>
        public string RoutingKey { get; set; } = "X.PUB";
        /// <summary>
        /// QM绑定键
        /// </summary>
        public string BindingKey { get; set; } = "X.*";
        /// <summary>
        /// 队列名
        /// </summary>
        private string queueName { get; set; } = "X.HYT" + Guid.NewGuid();
        /// <summary>
        /// 连接名
        /// </summary>
        private string connName { get; set; } = "HYT";
        /// <summary>
        /// 重新获取连接时间间隔，单位mm
        /// </summary>
        public int ReconnectGap { get; set; } = 5000;



        /// <summary>
        /// 事件处理
        /// </summary>
        private Action<T> _messageHandler = delegate { };
        /// <summary>
        /// 懒加载创建MQ连接
        /// </summary>
        private Lazy<IConnection> ConnectionLazy;
        /// <summary>
        /// 获取MQ连接
        /// </summary>
        public IConnection GetMqConnection => ConnectionLazy.Value;
        #endregion

        #region 构造函数
        /// <summary>
        /// 使用默认的MQ 连接实体
        /// </summary>
        public MQClient()
        {
            InitConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionModel">连接实体</param>
        public MQClient(ConnectionModel connectionModel)
        {
            _connectionModel = connectionModel;
            InitConnection();
        }

        #endregion
        #region 私有方法
        /// <summary>
        /// 初始化MQ连接
        /// </summary>
        private void InitConnection()
        {
            ConnectionLazy = new Lazy<IConnection>(() =>
            {
                try
                {
                    MQManager.SemaphoreSlim.Wait();
                    _connectionHash = _connectionModel.GetHash();
                    bool flag = _connectionCache.TryGetValue(_connectionHash, out var connection);

                    if (flag)
                    {
                        MQManager.SemaphoreSlim.Release();
                        return connection;
                    }
                    const ushort heartbeat = 60;
                    var f = new ConnectionFactory
                    {
                        HostName = _connectionModel.HostName,
                        UserName = _connectionModel.UserName,
                        Password = _connectionModel.Password,
                        Port = _connectionModel.Port,
                        VirtualHost = _connectionModel.VirtualHost,
                        RequestedHeartbeat = heartbeat, //心跳超时时间
                        AutomaticRecoveryEnabled = true //自动重连
                    };
                    var conn = f.CreateConnection(connName);
                    conn.ConnectionShutdown += (o, e) => RemoveAllMessageProcess();
                    _connectionCache.Add(_connectionHash, conn);
                    MQManager.SemaphoreSlim.Release();
                    return conn;
                }
                catch (Exception)
                {
                    return null;
                }
            });
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        private void ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {
            try
            {
                var body = e.Body;
                T msg = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(body));
                _messageHandler?.Invoke(msg);
            }
            catch (Exception ex)
            {
                throw new Exception("MQ处理消息失败", ex);
            }
        }
        #endregion

        #region 公共方法

        /// <summary>
        /// 开始接收消息
        /// </summary>
        public void BeginReceiveMessages()
        {
            Task.Run(async () =>
            {
                try
                {
                    if (GetMqConnection == null)
                    {
                        throw new Exception($"{nameof(BeginReceiveMessages)}未获取到MQ连接！");
                    }
                    var channel = GetMqConnection.CreateModel();
                    var flag = _channelCache.TryGetValue(_connectionHash, out var channelList);
                    if (flag)
                    {
                        channelList.Add(channel);
                    }
                    _channelCache.Add(_connectionHash, new List<IModel>() { channel });

                    if (IsCreateExchange)
                    {
                        //声明交换器并设置交换器的类型
                        channel.ExchangeDeclare(ExchangeName, ExchangeType, true);
                    }
                    channel.QueueDeclare(queueName, true, false, true, null);
                    //绑定消息队列，交换器，routingkey
                    channel.QueueBind(queueName, ExchangeName, BindingKey);


                    var consumer = new EventingBasicConsumer(channel); //创建事件驱动的消费者类型
                    consumer.Received += ConsumerReceived;

                    channel.BasicQos(0, 1, false); //一次只获取一个消息进行消费
                    channel.BasicConsume(queueName, true, consumer);
                }
                catch (Exception)
                {
                    await Task.Delay(ReconnectGap);
                    //throw new Exception("MQ获取消息失败", e);
                    //Console.WriteLine(DateTime.Now.ToString() + "重新获取MQ连接");
                    InitConnection();
                    BeginReceiveMessages();
                }
            });


        }

        /// <summary>
        /// 添加消息处理事件，不建议直接用拉姆达表达式
        /// </summary>
        /// <param name="proc"></param>
        public void AddMessageProcess(Action<T> proc)
        {
            if (!_messageHandler.GetInvocationList().Any(del => del.Method.Name == proc.Method.Name))
            {
                _messageHandler += proc;
            }
        }
        /// <summary>
        /// 移除消息处理事件
        /// </summary>
        /// <param name="proc"></param>
        public void RemoveMessageProcess(Action<T> proc)
        {
            _messageHandler -= proc;
        }
        /// <summary>
        /// 移除全部消息处理事件
        /// </summary>
        /// <param name="proc"></param>
        public void RemoveAllMessageProcess()
        {
            _messageHandler = delegate { };
        }

        /// <summary>
        /// 通过MQ发送消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageByMQ(T message)
        {
            try
            {
                if (GetMqConnection == null)
                {
                    InitConnection();
                    throw new Exception($"{nameof(SendMessageByMQ)}：未获取到 MQ 连接！");
                }
                var channel = GetMqConnection.CreateModel();
                if (IsCreateExchange)
                {
                    channel.ExchangeDeclare(ExchangeName, ExchangeType, true);
                }
                var msg = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(msg);
                //发送信息
                channel.BasicPublish(ExchangeName, RoutingKey, null, body);
                channel.Close();
            }
            catch (Exception e)
            {
                throw new Exception("MQ 发送消息失败！", e);
            }
        }

        /// <summary>
        /// 关闭 MQ 连接
        /// </summary>
        //public static void CloseConnection()
        //{
        //    bool flag = _connectionCache.TryGetValue(_connectionHash, out var connection);
        //    if (flag)
        //    {
        //        connection.Dispose();
        //    }
        //}
        #endregion

    }
}
