using Case.TorneioDeLutas.DBZ.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("Case.TorneioDeLutas.DBZ.Test")]
namespace Case.TorneioDeLutas.DBZ.App.Handlers
{
    public class Torneio
    {
        public Torneio(IList<Lutador> lutadores)
        {
            if(lutadores.Count != 8)
            {
                throw new ArgumentException("A lista de lutadores deve ter somente 8 lutadores");
            }
            this.Lutadores = lutadores;
        }

        //O torneio acontece em 3 chaves, sendo a primeira com 4 batalhas, 
        //a segunda deve ter 2 batalhas e a terceira, apenas 1 batalha

        //Lista de batalhas iniciais
        public IList<Lutador> Lutadores { get; set; }

        //Executar Batalhas
        public Lutador ExecutarTorneio()
        {
            foreach(var lutador in this.Lutadores)
            {
                if (lutador.Nome.Equals("Mr.Satan"))
                {
                    return lutador;
                }
            }

            var primeiraChave = PrepararBatalhas(this.Lutadores);
            var vencedorDaPrimeiraChave = ExecutarBatalhas(primeiraChave);

            var segundaChave = PrepararBatalhas(vencedorDaPrimeiraChave);
            var vencedorDaSegundaChave = ExecutarBatalhas(segundaChave);

            var batalhaFinal = PrepararBatalhas(vencedorDaSegundaChave);
            var vencedor = ExecutarBatalhas(batalhaFinal);

            return vencedor.First();
            
        }


        //Preparar Batalhas
        internal static IList<Batalha> PrepararBatalhas(IList<Lutador> lutadores)
        {
            var batalhas = new List<Batalha>();
            var limite = lutadores.Count / 2;

            for(var index = 0; index < limite; index++)
            {
                var lutadoresDaBatalha = new List<Lutador>();
                lutadoresDaBatalha.Add(lutadores[index]);
                lutadoresDaBatalha.Add(lutadores[index + limite]);

                var batalha = new Batalha(lutadoresDaBatalha);
                batalhas.Add(batalha);
            }

            return batalhas;
        }

        internal static IList<Lutador> ExecutarBatalhas(IList<Batalha> batalhas)
        {
            var vencedorDasBatalhas = new List<Lutador>();

            foreach(var batalha in batalhas)
            {
                var vencedor = batalha.ExecutarBatalha();
                vencedorDasBatalhas.Add(vencedor);
            }
            return vencedorDasBatalhas;
        }
    }
}
