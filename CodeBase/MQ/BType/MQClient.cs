using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstantMessagingModule.BType
{
    /// <summary>
    ///  MQ 客户端
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MQClient<T> : MQClientBase where T : class
    {

        public MQClient() : base()
        {

        }

        public MQClient(ConnectionModel connectionModel) : base(connectionModel)
        {
        }
        /// <summary>
        /// 事件处理
        /// </summary>
        protected new Action<T> _messageHandler = delegate { };
        /// <summary>
        /// 处理消息
        /// </summary>
        protected override void ConsumerReceived(object sender, BasicDeliverEventArgs e)
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
        /// 通过MQ发送消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageByMQ(T message)
        {
            try
            {
                if (MqConnection == null)
                {
                    InitConnection();
                    throw new Exception($"{nameof(SendMessageByMQ)}：未获取到 MQ 连接！");
                }
                if (channel == null)
                {
                    channel = MqConnection.CreateModel();
                }
                if (IsCreateExchange)
                {
                    channel.ExchangeDeclare(ExchangeName, ExchangeType, true);
                }
                var msg = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(msg);
                //发送信息
                channel.BasicPublish(ExchangeName, RoutingKey, null, body);
            }
            catch (Exception e)
            {
                throw new Exception("MQ 发送消息失败！", e);
            }
        }
    }


    /// <summary>
    /// mq client 基类
    /// 用于接收纯字符串的消息，不需要反序列化
    /// </summary>
    public class MQClientBase
    {
        protected static Dictionary<int, IConnection> _connectionCache = MQManager.ConnCache;
        protected static List<MQClientBase> _clientCache = MQManager.ClientCache;
        protected static int _connectionHash;
        #region 字段/属性
        /// <summary>
        /// 连接实体
        /// </summary>
        protected readonly ConnectionModel _connectionModel = new ConnectionModel();

        /// <summary>
        /// QM交换机名
        /// </summary>
        public string ExchangeName { get; set; } = "ExchangeDefaultName";
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
        public string QueueName { get; set; } = "X.HYT_" + Guid.NewGuid();
        /// <summary>
        /// 连接名
        /// </summary>
        protected string connName { get; set; } = "HYT";
        /// <summary>
        /// 每个mq client 使用唯一的信道
        /// </summary>
        protected IModel channel { get; set; }

        /// <summary>
        /// 重新获取连接时间间隔，单位mm
        /// </summary>
        public int ReconnectGap { get; set; } = 5000;
        /// <summary>
        /// 重连次数
        /// </summary>
        protected ThreadLocal<int> _reconnectCount = new ThreadLocal<int>(() => 0);
        /// <summary>
        /// 最大重连次数
        /// </summary>
        protected const int MAXRECONNECTCOUNT = 0;
        /// <summary>
        /// 事件处理
        /// </summary>
        protected Action<string> _messageHandler = delegate { };
        /// <summary>
        /// 懒加载创建MQ连接
        /// </summary>
        protected Lazy<IConnection> ConnectionLazy;
        /// <summary>
        /// 获取MQ连接
        /// </summary>
        public IConnection MqConnection => ConnectionLazy.Value;
        #endregion

        #region 构造函数
        /// <summary>
        /// 使用默认的MQ 连接实体
        /// </summary>
        public MQClientBase()
        {
            InitConnection();
            _clientCache.Add(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionModel">连接实体</param>
        public MQClientBase(ConnectionModel connectionModel)
        {
            _connectionModel = connectionModel;
            InitConnection();
            _clientCache.Add(this);
        }

        #endregion
        #region 私有方法
        /// <summary>
        /// 初始化MQ连接
        /// </summary>
        protected void InitConnection()
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
                    return conn;
                }
                catch (Exception e)
                {
                    return null;
                }
                finally
                {
                    MQManager.SemaphoreSlim.Release();
                }
            });
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        protected virtual void ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {
            try
            {
                var body = e.Body;
                var msg = Encoding.UTF8.GetString(body);
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
                    if (MqConnection == null)
                    {
                        throw new Exception($"{nameof(BeginReceiveMessages)}未获取到MQ连接！");
                    }
                    if (channel == null)
                    {
                        channel = MqConnection.CreateModel();
                    }

                    if (IsCreateExchange)
                    {
                        //声明交换器并设置交换器的类型
                        channel.ExchangeDeclare(ExchangeName, ExchangeType, true);
                    }
                    channel.QueueDeclare(QueueName, true, false, true, null);
                    var consumer = new EventingBasicConsumer(channel); //创建事件驱动的消费者类型
                    consumer.Received += ConsumerReceived;

                    channel.BasicQos(0, 1, false); //一次只获取一个消息进行消费
                    channel.BasicConsume(QueueName, true, consumer);
                    //绑定消息队列，交换器，routingkey
                    // 绑定交换器要在绑定消费者后面执行，如果交换器不存在，则队列会自动删除。如果放在前面，队列不删除
                    channel.QueueBind(QueueName, ExchangeName, BindingKey);
                }
                catch (Exception e)
                {
                    _reconnectCount.Value++;
                    if (_reconnectCount.Value <= MAXRECONNECTCOUNT)
                    {
                        await Task.Delay(ReconnectGap);
                        InitConnection();
                        BeginReceiveMessages();
                    }
                    else
                        throw new Exception("MQ 初始化失败！", e);
                }
            });


        }

        /// <summary>
        /// 添加消息处理事件，不建议直接用拉姆达表达式
        /// </summary>
        /// <param name="proc"></param>
        public void AddMessageProcess(Action<string> proc)
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
        public void RemoveMessageProcess(Action<string> proc)
        {
            _messageHandler -= proc;
        }
        /// <summary>
        /// 移除全部消息处理事件
        /// </summary>
        public void RemoveAllMessageProcess()
        {
            _messageHandler = delegate { };
        }

        /// <summary>
        /// 通过MQ发送消息
        /// </summary>
        /// <param name="message"></param>
        public void SendMessageByMQ(string message)
        {
            try
            {
                if (MqConnection == null)
                {
                    InitConnection();
                    if (MqConnection == null)
                    {
                        throw new Exception($"{nameof(SendMessageByMQ)}：未获取到 MQ 连接！");
                    }
                }
                if (channel == null)
                {
                    channel = MqConnection.CreateModel();
                }
                if (IsCreateExchange)
                {
                    channel.ExchangeDeclare(ExchangeName, ExchangeType, true);
                }
                var body = Encoding.UTF8.GetBytes(message);
                //发送信息
                channel.BasicPublish(ExchangeName, RoutingKey, null, body);
            }
            catch (Exception e)
            {
                throw new Exception("MQ 发送消息失败！", e);
            }
        }
        #endregion
    }
}
