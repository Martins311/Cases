using System;
using System.Collections.Generic;
using System.Text;
using Case.TorneioDeLutas.DBZ.App.Domain.Entities;
using Xunit;


namespace Case.TorneioDeLutas.DBZ.Teste
{
    public class NamekuseijinTeste
    {
        [Fact(DisplayName = "Dado que um lutador ser um Namekuseijin" +
            "Quando absorver outro Namekuseijin" +
            "Deve retornar um novo Namekuseijin")]

        public void DeveAbsorverUmOutroNamekuseijin()
        {
            //Arrange
            var namekuseijin = new Namekuseijin("Piccolo", 1_000, 100);
            var outroNamekuseijin = new Namekuseijin("Dende", 500, 100);
            var novaForcaEsperada = (ulong)500_000;
            var novoKiEsperado = (ulong)100_000;

            //Act
            var novoNamekuseijin = namekuseijin.AbsorverOutroNamekuseijin(outroNamekuseijin);

            //Assert
            Assert.Equal(novaForcaEsperada, novoNamekuseijin.Forca);
            Assert.Equal(novoKiEsperado, novoNamekuseijin.Chi);

        }

    }
}