using LogManager;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;

namespace InstantMessagingModule
{
    /// <summary>
    /// MQ客户端
    /// </summary>
    /// <typeparam name="T">消息实体</typeparam>
    public class MessageQueueClient<T> where T : MessageBasic
    {
        #region 字段/属性
        /// <summary>
        /// MQ服务器地址，默认端口
        /// </summary>
        private static readonly string hostName = DBManager.DBReader.GetTopLeft("LocalDB", "SELECT PARAM_VALUE FROM dbo.SYS_ENV_PARAM WHERE PARAM_CODE = 'MQ_IP'").ToString();
        /// <summary>
        /// MQ服务登录名
        /// </summary>
        private static readonly string userName = "KNRT_RX";
        /// <summary>
        /// MQ服务密码
        /// </summary>
        private static readonly string password = "KNRT_RX";
        /// <summary>
        /// QM交换机名
        /// </summary>
        public string ExchangeName { get; set; } = "KNRT_RX_Exchange";
        /// <summary>
        /// QM交换机类型
        /// </summary>
        public string ExchangeType { get; set; } = "topic";
        /// <summary>
        /// QM路由键
        /// </summary>
        public string RoutingKey { get; set; } = "KNRT.RX.PUB";
        /// <summary>
        /// QM绑定键
        /// </summary>
        public string BindingKey { get; set; } = "KNRT.RX.*";
        /// <summary>
        /// 队列名
        /// </summary>
        private string queueName { get; set; } = "KNRT.RX." + Guid.NewGuid();
        /// <summary>
        /// 事件处理
        /// </summary>
        private Action<T> _messageHandler = delegate { };
        /// <summary>
        /// 懒加载创建MQ连接
        /// </summary>
        private static readonly Lazy<IConnection> Lazy = new Lazy<IConnection>(() =>
                {
                    try
                    {
                        const ushort heartbeat = 60;
                        var f = new ConnectionFactory
                        {
                            HostName = hostName,
                            UserName = userName,
                            Password = password,
                            RequestedHeartbeat = heartbeat, //心跳超时时间
                            AutomaticRecoveryEnabled = true //自动重连
                        };
                        var conn = f.CreateConnection();
                        conn.ConnectionShutdown += (o, e) =>
                        {
                            Logger.Info("MQ CONNECTION SHUTDOWN");
                        };
                        return conn;
                    }
                    catch (Exception e)
                    {
                        Logger.Fatal(e.ToString());
                        return null;
                    }
                });
        /// <summary>
        /// 获取MQ连接
        /// </summary>
        public static IConnection GetMqConnection => Lazy.Value;
        #endregion

        #region 构造函数
        /// <summary>
        /// 默认的MQ业务模块
        /// </summary>
        public MessageQueueClient()
        {
            ReceiveMessagesByMQ();
        }
        /// <summary>
        /// 指定MQ业务模块
        /// </summary>
        /// <param name="businessName"></param>
        public MessageQueueClient(MQBusinessType businessName)
        {
            ExchangeName = $"KNRT_{businessName}_Exchange";
            RoutingKey = $"KNRT.{businessName}.PUB";
            BindingKey = $"KNRT.{businessName}.*";
            queueName = $"KNRT.{businessName}.{Guid.NewGuid()}";
            ReceiveMessagesByMQ();
        }
        #endregion

        /// <summary>
        /// 通过MQ接受消息
        /// </summary>
        private void ReceiveMessagesByMQ()
        {
            try
            {
                if (GetMqConnection == null)
                {
                    new Exception($"{nameof(ReceiveMessagesByMQ)}未获取到MQ连接！");
                }
                var channel = GetMqConnection.CreateModel();
                //设置交换器的类型
                channel.ExchangeDeclare(ExchangeName, ExchangeType, true);
                channel.QueueDeclare(queueName, true, false, true, null);
                //绑定消息队列，交换器，routingkey
                channel.QueueBind(queueName, ExchangeName, BindingKey);
                var consumer = new EventingBasicConsumer(channel); //创建事件驱动的消费者类型
                consumer.Received += ConsumerReceived;

                channel.BasicQos(0, 1, false); //一次只获取一个消息进行消费
                channel.BasicConsume(queueName, true, consumer);
            }
            catch (Exception e)
            {
                Logger.Fatal(e.ToString());
            }
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
                Logger.Fatal(ex.ToString());
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
                if (GetMqConnection == null)
                {
                    new Exception($"{nameof(SendMessageByMQ)}：未获取到MQ连接！");
                }
                var channel = GetMqConnection.CreateModel();
                channel.ExchangeDeclare(ExchangeName, ExchangeType, true);
                var msg = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(msg);
                //发送信息
                channel.BasicPublish(ExchangeName, RoutingKey, null, body);
                channel.Close();
            }
            catch (Exception e)
            {
                Logger.Fatal(e.ToString());
            }
        }
    }
}
