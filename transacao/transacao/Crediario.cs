using System;
using System.Collections.Generic;
using System.Text;

namespace transacao
{
    public class Crediario : TransacaoDePagamento
    {
        public Crediario(double valor, int parcelas)
        {
            Parcelas = parcelas;
            MaximoDeParcelas = 24;
            ValorDaTransacao = valor + (valor * Taxa);
        }
        
        public bool ValidaTransacao()
        {
            return Parcelas <= 24;
        }
        
       public double Taxa = 0.015;
    }
}
