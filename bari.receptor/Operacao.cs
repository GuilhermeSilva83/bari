using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace bari.receptor
{
    public class Operacao
    {
        public string Mensagem { get; set; }
        public string Servico { get; set; }

        public DateTime TimeStamp { get; set; }

        public Guid Id { get; set; }
    }
}
