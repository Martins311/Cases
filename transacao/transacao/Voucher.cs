using System;
using System.Collections.Generic;
using System.Text;

namespace transacao
{
    public class Voucher : TransacaoDePagamento
    {
        public Voucher()
        {
            MaximoDeParcelas = 1;
        }
    }
}
