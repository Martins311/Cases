using System;
using System.Collections.Generic;
using System.Text;

namespace transacao
{
    public class Credito : TransacaoDePagamento
    {
        public Credito()
        {
            MaximoDeParcelas = 12;
        }

        public bool ValidaTransacao()
        {
            return Parcelas <= 12;
        }
    }
}
