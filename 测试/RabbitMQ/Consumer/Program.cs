using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
    internal class Program
    {
        static string input = "";
        private static void Main(string[] args)
        {
            //var factory = new ConnectionFactory { HostName = "192.168.1.178", UserName = "KNRT", Password = "000000" };
            var factory = new ConnectionFactory
            {
                HostName = "47.93.156.92",
                UserName = "guest",
                Password = "guest",
                Port = 5676,
                VirtualHost = "/",
                RequestedHeartbeat = TimeSpan.FromSeconds(60.0), //心跳超时时间
                AutomaticRecoveryEnabled = true //自动重连
            };
            //var queueName = "MyQueue" + DateTime.Now.Second;
            var queueName = "1TestQueue";
            var exchangeName = "1TestEx";
            var exchangeType = "topic";//topic、fanout
            var routingKey = "KNRT.RX.*";
            var conn = factory.CreateConnection();
            var channel = conn.CreateModel();

            var q1 = "1TestQueue";
            var q2 = "2TestQueue";
            var q3 = "3TestQueue";
            channel.QueueDeclare(q1, false, false, false, null);
            channel.QueueDeclare(q2, false, false, false, null);
            channel.QueueDeclare(q3, false, false, false, null);
            //绑定消息队列，交换器，routingkey
            channel.QueueBind(q1, exchangeName, "");
            channel.QueueBind(q2, exchangeName, "");
            channel.QueueBind(q3, exchangeName, "");

            // 测试 一个消费者注册多个队列，并根据需要，有选择性的接收某个队列的消息
            var consumer1 = new EventingBasicConsumer(channel); //创建事件驱动的消费者类型
            consumer1.Received += ConsumerReceived;
            consumer1.Shutdown += (_s, _e) => Console.WriteLine("Shutdown");
            consumer1.Registered += (_s, _e) => Console.WriteLine("Registered");
            consumer1.Unregistered += (_s, _e) => Console.WriteLine("Unregistered");
            //var consumer2 = new EventingBasicConsumer(channel); //创建事件驱动的消费者类型
            //consumer2.Received += ConsumerReceived;
            //var consumer3 = new EventingBasicConsumer(channel); //创建事件驱动的消费者类型
            //consumer3.Received += ConsumerReceived;
            channel.BasicQos(0, 1, false); //一次只获取一个消息进行消费
            //channel.BasicConsume(q1, true, "1", consumer1);
            //channel.BasicConsume(q2, true, "2", consumer1);
            //channel.BasicConsume(q3, true, "3", consumer1);

            while (true)
            {
                input = Console.ReadLine();
                if (input == "1")
                {
                    if (!consumer1.ConsumerTags.Contains("1"))
                        channel.BasicConsume(q1, false, "1", consumer1);// 接受队列1的消息需要显示的确认收到消息
                    if (consumer1.ConsumerTags.Contains("2"))
                        channel.BasicCancel("2");
                    if (consumer1.ConsumerTags.Contains("3"))
                        channel.BasicCancel("3");


                }
                else if (input == "2")
                {
                    if (consumer1.ConsumerTags.Contains("1"))
                        channel.BasicCancel("1");
                    if (!consumer1.ConsumerTags.Contains("2"))
                        channel.BasicConsume(q2, true, "2", consumer1);
                    if (consumer1.ConsumerTags.Contains("3"))
                        channel.BasicCancel("3");
                }
                else if (input == "3")
                {
                    if (consumer1.ConsumerTags.Contains("1"))
                        channel.BasicCancel("1");
                    if (consumer1.ConsumerTags.Contains("2"))
                        channel.BasicCancel("2");
                    if (!consumer1.ConsumerTags.Contains("3"))
                        channel.BasicConsume(q3, true, "3", consumer1);

                }
                else if (input == "t")
                    Console.WriteLine(string.Join(", ", consumer1.ConsumerTags));
                else if (input == "q")
                {
                    channel.QueueDeclare("new TestQueue", false, false, true, null);
                    channel.QueueBind("new TestQueue", exchangeName, "");
                }
                else if (input == "c")
                    conn.Dispose();
            }
            void ConsumerReceived(object sender, BasicDeliverEventArgs e)
            {
                try
                {
                    var csm = sender as EventingBasicConsumer;
                    var body = e.Body;
                    var msg = Encoding.UTF8.GetString(body.ToArray());
                    Console.WriteLine($"{e.ConsumerTag}______{msg}");
                    if (e.ConsumerTag == "1")
                        csm.Model.BasicAck(e.DeliveryTag, false);// 队列1的消息需要确认收到
                }
                catch (Exception ex)
                {
                    throw new Exception("MQ处理消息失败", ex);
                }
            }
            //using (var connection = factory.CreateConnection())
            //{
            //    using (var channel = connection.CreateModel())
            //    {
            //        //设置交换器的类型
            //        //channel.ExchangeDeclare(exchangeName, exchangeType);
            //        //var queueName = channel.QueueDeclare().QueueName;
            //        channel.QueueDeclare(queueName, false, false, true, null);
            //        //绑定消息队列，交换器，routingkey
            //        channel.QueueBind(queueName, exchangeName, routingKey);
            //        var properties = channel.CreateBasicProperties();
            //        //队列持久化
            //        properties.DeliveryMode = 2;
            //        var consumer = new QueueingBasicConsumer(channel);
            //        channel.BasicConsume(queueName, true, consumer);

            //        Console.WriteLine("waiting for message.");
            //        Task.Factory.StartNew(() =>
            //        {
            //            while (true)
            //            {
            //                var message = Console.ReadLine();
            //                var body = Encoding.UTF8.GetBytes($"{message}");
            //                //发送信息
            //                channel.BasicPublish(exchangeName, routingKey, properties, body);
            //            }
            //        });
            //        while (true)
            //        {
            //            var ea = consumer.Queue.Dequeue();

            //            var body = ea.Body;
            //            var message = Encoding.UTF8.GetString(body);
            //            Console.WriteLine("Received {0}", message + "__" + queueName);

            //        }

            //    }
            //}
        }


    }
}
