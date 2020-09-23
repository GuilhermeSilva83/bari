using RabbitMQ.Client;
using System.Timers;
using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace bari.mensageiro
{
    class Program
    {

        private static Receptor receptor;

        private static Envia e;

        static void Main(string[] args)
        {

            Action a = new Action(() =>
            {
                e = new Envia();
                e.Ativar();
            });


            /* descomente a linha abaixo caso queira receber mensagem dentro desse mesmo servico */

            //Action b = new Action(() =>
            //{
            //    receptor = new Receptor();
            //});
            //Task.WaitAll(Task.Factory.StartNew(b), Task.Factory.StartNew(a) );

            /* comente abaixo caso descomente acima */

            Task.Factory.StartNew(a);



            Console.WriteLine("Tecle [ENTER] para sair.");
            Console.ReadKey();
        }

    }
}