using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace bari.mensageiro
{
    public class Operacao
    {
        public string Mensagem { get; set; }
        public string Servico { get; set; }

        public DateTime TimeStamp { get; set; }

        public Guid Id { get; set; }

        public Operacao(string servico, string mensagem)
        {
            this.Id = Guid.NewGuid();
            this.TimeStamp = DateTime.Now;
            this.Servico = servico;
            this.Mensagem = mensagem;
        }
    }
}
