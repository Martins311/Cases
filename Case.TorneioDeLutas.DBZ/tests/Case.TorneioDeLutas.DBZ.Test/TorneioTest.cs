using Case.TorneioDeLutas.DBZ.App.Domain;
using Case.TorneioDeLutas.DBZ.App.Handlers;
using Case.TorneioDeLutas.DBZ.Test.Mocs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Case.TorneioDeLutas.DBZ.Test
{
    public class TorneioTest
    {
        [Theory(DisplayName = "Dado que a lsita de lutadores nao tenha" +
                            "8 lutadores, quando criar um torneio" +
                            "entao, deve lancar um Argument Exception")]
        [ClassData(typeof(TorneioTestData))]
        public void DeveLancarUmArgumentException(IList<Lutador> lutadores)
        {
            Assert.Throws<ArgumentException>(() => new Torneio(lutadores));
        }

        [Theory(DisplayName =   "Dado que lista de lutadores contenha uma quantidade valida " +
                                "de lutadores quando preparar as batalhas," +
                                "entao, deve retornar uma lista de batalhas")]
        [InlineData(8,4)]
        [InlineData(4,2)]
        [InlineData(2,1)]
        public void DeveRetornarUmaListaComQuatroBatalhas(int quantidadeDeLutadores, int quantidadeDeBatalhasEsperadas)
        {            
            var lutadores = TorneioTestData.MockListaDeLutadores(quantidadeDeLutadores);
                        
            var batalhas = Torneio.PrepararBatalhas(lutadores);

            Assert.Equal(quantidadeDeBatalhasEsperadas, batalhas.Count);
        }

        [Fact(DisplayName = "Dado uma lista de lutadores que contenha o Mr.Satan" +
                            "Quando executar o torneio," +
                            "Entao, deve retornar o Mr.Satan como vencedor do torneio ")]
        public void DeveRetornarOMrSatanComoVencedorDoTorneio()
        {
            var mrSatan = new Lutador("Mr.Satan", 1, 1);
            var lutadores = TorneioTestData.MockListaDeLutadores(7);
            lutadores.Add(mrSatan);

            var torneio = new Torneio(lutadores);

            var vencedor = torneio.ExecutarTorneio();

            Assert.Equal(mrSatan, vencedor);
        }

        [Fact(DisplayName ="Dado que a lista de lutadores nao contenha o Mr.Satan" +
                            "quando executar o torneio" +
                            "entao, deve retornar o lutador mais forte como vencedor")]
        public void DeveRetornarOLutadorMaisForteComoVencedorDoTorneio()
        {
            var vencedorEsperado = new Lutador("Goku", 10_000, 100);
            var lutadores = TorneioTestData.MockListaDeLutadores(7);
            lutadores.Add(vencedorEsperado);

            var torneio = new Torneio(lutadores);

            var vencedor = torneio.ExecutarTorneio();

            Assert.Equal(vencedorEsperado, vencedor);
        }
    }
}
