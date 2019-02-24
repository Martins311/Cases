using System;
using System.Collections.Generic;
using System.Text;

namespace transacao
{
    public class TransacaoDeEstorno : Transacao
    {
        public TransacaoDePagamento TransacaoDePagamento  { get;}

         public TransacaoDeEstorno(TransacaoDePagamento transacao)
        {
            TransacaoDePagamento = transacao;
        }

        
    }
}
