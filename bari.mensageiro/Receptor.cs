using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Collections.Generic;
using System.Text;

namespace bari.mensageiro
{
    public class Receptor
    {
        public Receptor()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "testequeue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var msg = Encoding.UTF8.GetString(body);

                    var o = Newtonsoft.Json.JsonConvert.DeserializeObject<Operacao>(msg);

                    Console.WriteLine(string.Format($"{o.TimeStamp} - {o.Id} - {o.Mensagem}"));
                };

                channel.BasicConsume(queue: "testequeue",
                                     autoAck: true,
                                     consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}