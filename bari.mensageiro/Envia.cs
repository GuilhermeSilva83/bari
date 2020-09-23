using Newtonsoft.Json;

using RabbitMQ.Client;

using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace bari.mensageiro
{
    public class Envia
    {
        private Timer timer = new Timer() { Interval = 5000, Enabled = true, AutoReset = true };


        public Envia()
        {



        }

        public void Ativar()
        {
            timer.Elapsed += T_Elapsed;

            while (timer.Enabled)
            {
                System.Threading.Thread.Sleep(100);
            }
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            var json = JsonConvert.SerializeObject(new Operacao("servico mensageiro 1", "Olá Mundo - Hello World"));
            Executa(json);
        }


        public void Executa(string message)
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

                Console.WriteLine("Enviando: " + message);

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                                     routingKey: "testequeue",
                                                     basicProperties: null,
                                                     body: body);
            }
        }

    }
}
