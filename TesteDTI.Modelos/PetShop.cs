using System;
using System.Collections.Generic;
using System.Text;
using TesteDTI.Enumeradores;

namespace TesteDTI.Modelos
{
    public class PetShop
    {
        public PetShop(TipoPetShop tipoPetShop, double distanciaKm)
        {
            TipoPetShop = tipoPetShop;
            DistanciaKm = distanciaKm;
        }

        public TipoPetShop TipoPetShop { get; set; }

        public double DistanciaKm { get; set; }

        public decimal ValorCaoGrande { get; set; }

        public decimal ValorCaoPequeno { get; set; }

        public decimal TotalCaoGrande { get; set; }

        public decimal TotalCaoPequeno { get; set; }

        public decimal PrecoTotal => TotalCaoGrande + TotalCaoPequeno;

    }
}
