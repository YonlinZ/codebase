using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "101.201.142.93", UserName = "knrt", Password = "knrt" };
            //var factory = new ConnectionFactory { HostName = "192.168.1.178", UserName = "KNRT", Password = "000000" };
            //var factory = new ConnectionFactory { HostName = "localhost", UserName = "zyl", Password = "000000" };
            var queueName = "KNRT.RX." + Guid.NewGuid();
            var exchangeName = "KNRT_RX_Exchange";
            var exchangeType = "topic";//topic、fanout
            var routingKey = "KNRT.RX.PUB";
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //设置交换器的类型
                    channel.ExchangeDeclare(exchangeName, exchangeType);
                    //var queueName = channel.QueueDeclare().QueueName;
                    //channel.QueueDeclare(queueName, false, false, true, null);
                    ////绑定消息队列，交换器，routingkey
                    //channel.QueueBind(queueName, exchangeName, routingKey);
                    //var properties = channel.CreateBasicProperties();
                    //队列持久化
                    //properties.DeliveryMode = 2;
                    Console.WriteLine("输入消息，回车发送：");
                    while (true)
                    {
                        var message = Console.ReadLine();
                        if (message != "--")
                        {
                            var body = Encoding.UTF8.GetBytes($"{message}");
                            //发送信息
                            channel.BasicPublish(exchangeName, routingKey, null, body);
                        }
                        else
                        {
                            //channel.QueueDelete(queueName);
                            break;
                        }

                    }

                }
            }


        }
    }
}
