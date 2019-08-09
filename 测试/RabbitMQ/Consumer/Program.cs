using System;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Consumer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var factory = new ConnectionFactory { HostName = "192.168.1.178", UserName = "KNRT", Password = "000000" };
            var factory = new ConnectionFactory { HostName = "101.201.142.93", UserName = "knrt", Password = "knrt" };
            //var queueName = "MyQueue" + DateTime.Now.Second;
            var queueName = "KNRT.RX." + Guid.NewGuid();
            var exchangeName = "KNRT_RX_Exchange";
            var exchangeType = "topic";//topic、fanout
            var routingKey = "KNRT.RX.*";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //设置交换器的类型
                    channel.ExchangeDeclare(exchangeName, exchangeType);
                    //var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueDeclare(queueName, false, false, true, null);
                    //绑定消息队列，交换器，routingkey
                    channel.QueueBind(queueName, exchangeName, routingKey);
                    var properties = channel.CreateBasicProperties();
                    //队列持久化
                    properties.DeliveryMode = 2;
                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume(queueName, true, consumer);

                    Console.WriteLine("waiting for message.");
                    Task.Factory.StartNew(() =>
                    {
                        while (true)
                        {
                            var message = Console.ReadLine();
                            var body = Encoding.UTF8.GetBytes($"{message}");
                            //发送信息
                            channel.BasicPublish(exchangeName, routingKey, properties, body);
                        }
                    });
                    while (true)
                    {
                        var ea = consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Received {0}", message + "__" + queueName);

                    }

                }
            }
        }
    }
}
