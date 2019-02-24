using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Case.TorneioDeLutas.DBZ.App.Domain.Enums;
using Case.TorneioDeLutas.DBZ.App.Domain;

namespace Case.TorneioDeLutas.DBZ.Test
{
    public class SaiyajinTest
    {
        [Theory(DisplayName = "Dado que o lutador seja um Saiyajin" +
                            "quando calcular o poder de luta " +
                            "entao  deve retornar" +
                            "o poder de luta considerando " +
                            "o nivel de super saiyajin")]
        [InlineData((ulong)10_000_000, (ulong)10_000, (ulong)1_000, NivelSuperSaiyajinEnum.NIVEL_0)]
        [InlineData((ulong)10_000_000_000, (ulong)10_000, (ulong)1_000, NivelSuperSaiyajinEnum.NIVEL_1)]
        [InlineData((ulong)10_000_000_000_000, (ulong)10_000, (ulong)1_000, NivelSuperSaiyajinEnum.NIVEL_2)]
        [InlineData((ulong)10_000_000_000_000_000, (ulong)10_000, (ulong)1_000, NivelSuperSaiyajinEnum.NIVEL_3)]
        public void DeveCalcularOPoderDeLutaDeUmSaiyajin(ulong poderDeLutaEsperado, ulong forca, ulong chi, NivelSuperSaiyajinEnum nivelSuperSaiyajin)
        {
                       

            var saiyajin = new Saiyajin("goku", forca, chi, nivelSuperSaiyajin);

            //Act 
            var poderDeLutaCalculado = saiyajin.CalcularPoderDeLuta();

            //Assert 
            Assert.Equal(poderDeLutaEsperado, poderDeLutaCalculado);

        }
    }
}
