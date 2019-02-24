using Case.TorneioDeLutas.DBZ.App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Case.TorneioDeLutas.DBZ.App.Domain
{
    public class Saiyajin : Lutador
    {
        public Saiyajin(string nome, ulong forca, ulong chi, NivelSuperSaiyajinEnum nivelSuperSaiyajin) 
            : base(nome, forca, chi)
        {
            this.NivelSuperSaiyajin = nivelSuperSaiyajin;
        }

        public NivelSuperSaiyajinEnum NivelSuperSaiyajin { get; set; }

        public override ulong CalcularPoderDeLuta()
        {            
            var poderDeLuta = (ulong)(this.Forca * (Math.Pow(this.Chi,(int)NivelSuperSaiyajin)));
            return poderDeLuta;
            
        }

    }
}
