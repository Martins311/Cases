using Case.TorneioDeLutas.DBZ.App.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Case.TorneioDeLutas.DBZ.App.Domain.Entities;

namespace Case.TorneioDeLutas.DBZ.App.Handlers
{
    public class Batalha
    {
        private const int MAXIMO_DE_LUTADORES = 2;

        public Batalha(IList<Lutador> lutadores)
        {
            if (lutadores.Count != 2)
            {
                throw new ArgumentException("A lista de lutadores deve ter somente 2 lutadores");
            }
            this.Lutadores = lutadores;
        }

        public IList<Lutador> Lutadores { get; }

        public Lutador ExecutarBatalha()
        {
            var primeiroLutador = this.Lutadores.First();
            var segundoLutador = this.Lutadores.Last();

            //solucao com if classico
            //if(primeiroLutador.GetType() == typeof(Namekuseijin) && segundoLutador.GetType() == typeof(Namekuseijin))
            //{
            //    var primeiroLutadorNamekuseijin = (Namekuseijin)primeiroLutador;
            //    var novoLutador = primeiroLutadorNamekuseijin.AbsorverOutroNamekuseijin(segundoLutador as Namekuseijin);
            //    return novoLutador;
            //}

            //solucao com patter matching 
            if(primeiroLutador is Namekuseijin primeiroLutadorNamekuseijin &&
                segundoLutador is Namekuseijin segundoLutadorNamekuseijin)
            {
                var novoLutador = primeiroLutadorNamekuseijin.AbsorverOutroNamekuseijin(segundoLutadorNamekuseijin);
                return novoLutador;
            }

            var poderDeLutaDoPrimeiroLutador = primeiroLutador.CalcularPoderDeLuta();
            var poderDeLutaDoSegundoLutador = segundoLutador.CalcularPoderDeLuta();

            if(poderDeLutaDoPrimeiroLutador > poderDeLutaDoSegundoLutador)
            {
                return primeiroLutador;
            }

            return segundoLutador;
        }
    }
}
