using System;
using System.Collections.Generic;
using System.Text;

namespace transacao
{
    public class TransacaoDePagamento : Transacao
    {
        
        public int Parcelas { get; set; }

        public int MaximoDeParcelas { get; set; }

    }
}
