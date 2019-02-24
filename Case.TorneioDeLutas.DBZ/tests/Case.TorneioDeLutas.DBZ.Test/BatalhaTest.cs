using Case.TorneioDeLutas.DBZ.App.Domain;
using Case.TorneioDeLutas.DBZ.App.Domain.Entities;
using Case.TorneioDeLutas.DBZ.App.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Case.TorneioDeLutas.DBZ.Teste
{
    public class BatalhaTeste
    {
        [Fact(DisplayName = "Dado que a lista de lutadores não tenha 2 lutadores" +
            "Quando criar uma batalha" +
            "Então, deve lançar uma Argument Exeption")]
        public void DeveLancarUmaArgumentException()
        {
            var lutadores = new List<Lutador>();
            lutadores.Add(new Lutador("Freeza", 10_000, 100));
            lutadores.Add(new Lutador("Paikuhan", 10_000, 1_000));
            lutadores.Add(new Lutador("Cpt. Ginyu", 10_000, 1_000));


            Assert.Throws<ArgumentException>(() => new Batalha(lutadores));
        }
        [Fact (DisplayName ="Dado que o primeiro lutador tenha " +
                        "um poder de luta maior que o segundo lutador" +
                        "quando batanhar, entao, deve retornar o " +
                        "primeiro lutador como vencedor da batalha")]

        public void DeveRetornarOPrimeiroLutadorVencedor()
        {
            var vencedorEsperado = new Lutador("Gohan", 10_000, 1_000);
            var lutadorPerdedor = new Lutador("Picolo", 10_000, 100);

            var lutadores = new List<Lutador>();
            lutadores.Add(vencedorEsperado);
            lutadores.Add(lutadorPerdedor);

            var batalha = new Batalha(lutadores);

            //Act 
            var vencedorDaBatalha = batalha.ExecutarBatalha();

            //Assert
            Assert.Equal(vencedorEsperado, vencedorDaBatalha);
        }


        [Fact(DisplayName = "Dado que o segundo lutador tenha " +
                        "um poder de luta maior que o primeiro lutador" +
                        "quando batanhar, entao, deve retornar o " +
                        "segundo lutador como vencedor da batalha")]

        public void DeveRetornarOSegundoLutadorVencedor()
        {
            var primeiroLutador = new Lutador("Picolo", 10_000, 100);
            var segundoLutador = new Lutador("Gohan", 10_000, 1_000);

            var lutadores = new List<Lutador>();
            lutadores.Add(primeiroLutador);
            lutadores.Add(segundoLutador);
            

            var batalha = new Batalha(lutadores);

            //Act 
            var vencedorDaBatalha = batalha.ExecutarBatalha();

            //Assert
            Assert.Equal(segundoLutador, vencedorDaBatalha);
        }

        [Fact(DisplayName = "Dado que ambos os lutadores sajam Namekuseijins" +
                            "quando batalharem, entao, o primeiro lutador deve absorver" +
                            "o segundo lutador")]
        public void DeveAbsorverOSegundoLutadorERetornarOVencedor()
        {
            //Falso Positivo

            var primeiroLutador = new Namekuseijin("Picolo", 10_000, 100);
            var segundoLutador = new Namekuseijin("Dende", 1_000, 100);

            var novoLutadorEsperado = primeiroLutador.AbsorverOutroNamekuseijin(segundoLutador);

            var lutadores = new List<Lutador>();
            lutadores.Add(primeiroLutador);
            lutadores.Add(segundoLutador);

            var batalha = new Batalha(lutadores);

            //Act            
            var vencedorDaBatalha = batalha.ExecutarBatalha();

            //Assert 
            Assert.IsType<Namekuseijin>(vencedorDaBatalha);
            Assert.Equal(novoLutadorEsperado.Forca, vencedorDaBatalha.Forca);
            Assert.Equal(novoLutadorEsperado.Chi, vencedorDaBatalha.Chi);
        }
    }
}