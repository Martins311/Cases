using System;
using System.Collections.Generic;
using System.Text;

namespace Case.TorneioDeLutas.DBZ.App.Domain
{
    public class Lutador
    {
        //campos - variaveis privadas 
        
        //construtor 
        public Lutador(string nome, ulong forca, ulong chi)
        {
            //Single Failure Point (Unico Ponto de Falha)
            this.Nome = nome;
            this.Forca = forca;
            this.Chi = chi;
        }

        //propriedades public
        
        //nome 
        //forca 
        //chi 
        public string Nome { get; }
        public ulong Forca { get; }
        public ulong Chi { get; }


        //metodos 
        public virtual ulong CalcularPoderDeLuta()
        {
            return this.Forca * this.Chi;
        }
    }
}
