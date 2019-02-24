using Case.TorneioDeLutas.DBZ.App.Domain;
using System;
using Xunit;

namespace Case.TorneioDeLutas.DBZ.Test
{
    public class LutadorTest
    {
        [Fact(DisplayName = "Dado que eu tenha um lutador " +
            "quando eu calcular o poder de luta," +
            " entao deve retornar seu poder de luta")]
        public void DeveCalcularOPoderDeLuta()
        {
            

            
            var forca = (ulong)10_000;
            var chi = (ulong)100;
            var poderDeLutaExperado = (ulong)1_000_000;

            var lutador = new Lutador("Jhon Doe", forca, chi);

            //Act 
            var poderDaLutaCalculado = lutador.CalcularPoderDeLuta();

            Assert.Equal(poderDeLutaExperado, poderDaLutaCalculado);

            //dado
            //quando
            //entao

        }
    }
}
