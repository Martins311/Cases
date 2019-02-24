using System;
using System.Collections.Generic;
using System.Text;

namespace Case.TorneioDeLutas.DBZ.App.Domain.Entities
{
    public class Namekuseijin : Lutador
    {
        public Namekuseijin(string nome, ulong forca, ulong chi) : base(nome, forca, chi)
        {
        }

        public Namekuseijin AbsorverOutroNamekuseijin(Namekuseijin outroNamekuseijin)
        {
            var forca = this.Forca * outroNamekuseijin.Forca;
            var chi = this.Chi * outroNamekuseijin.Chi * 10;

            var novoNamekuseijin = new Namekuseijin(this.Nome, forca, chi);
            return novoNamekuseijin;
        }
    }
}
