using Case.TorneioDeLutas.DBZ.App.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Case.TorneioDeLutas.DBZ.Test.Mocs
{
    public class TorneioTestData : IEnumerable<object[]>
    {
        //syntactic sugar
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { MockListaDeLutadores(7) };
            yield return new object[] { MockListaDeLutadores(9) };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public static IList<Lutador> MockListaDeLutadores(int quantidade)
        {
            var lutadores = new List<Lutador>();

            for(var index = 0; index < quantidade; index++)
            {
                var lutador = new Lutador($"{index}", (ulong)index, (ulong)index);
                lutadores.Add(lutador);
            }
            return lutadores;
        }


    }
}

