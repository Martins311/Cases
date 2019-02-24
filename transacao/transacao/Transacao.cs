using System;
using System.Collections.Generic;
using System.Text;

namespace transacao
{
    public class Transacao
    {
        public Transacao()
        {
            Random IdDacompra = new Random();
            this.Id = IdDacompra.Next(10000000, 99999999);
        }
        public virtual double ValorDaTransacao { get; set; }
        public int Id { get; }
        public virtual bool Autorizacao()
        {
            Random ConfirmacaoDoBanco = new Random();
            return ConfirmacaoDoBanco.Next(100) < 90 ? true : false;
        }
    }
}
