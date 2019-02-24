using System;
using System.Collections.Generic;
using System.Text;

namespace transacao
{
    public class Debito : TransacaoDePagamento
    {
        public Debito()
        {
            MaximoDeParcelas = 1;
        }

    }
}
