using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteDTI.Comum;
using TesteDTI.Enumeradores;
using TesteDTI.Modelos;

namespace TesteDTI.Servicos
{
    public class PetShopServico
    {
        
        public PetShop ObterMelhorPetShop(List<PetShop> petShops, DateTime data, int qtdCaesPequenos, int qtdCaesGrandes)
        {
            foreach (var petShop in petShops)
            {
                PreencherValores(petShop, data, qtdCaesPequenos, qtdCaesGrandes);
            }

            return AvaliarMelhorPetShop(petShops);
        }

        public PetShop PreencherValores(PetShop PetShop, DateTime data, int qtdCaesPequenos, int qtdCaesGrandes)
        {
            if (PetShop.TipoPetShop == TipoPetShop.MeuCaninoFeliz)
            {
                if (data.FimDeSemana())
                {
                    PetShop.ValorCaoGrande = Convert.ToDecimal(40 + (40 * 0.2));
                    PetShop.ValorCaoPequeno = Convert.ToDecimal(20 + (20 * 0.2));
                }
                else
                {
                    PetShop.ValorCaoGrande = 40;
                    PetShop.ValorCaoPequeno = 20;
                }
            }
            else if (PetShop.TipoPetShop == TipoPetShop.VaiRex)
            {
                if (data.FimDeSemana())
                {
                    PetShop.ValorCaoGrande = 55;
                    PetShop.ValorCaoPequeno = 20;
                }
                else
                {
                    PetShop.ValorCaoGrande = 50;
                    PetShop.ValorCaoPequeno = 15;
                }
            }

            else if (PetShop.TipoPetShop == TipoPetShop.ChowChawgas)
            {
                PetShop.ValorCaoGrande = 45;
                PetShop.ValorCaoPequeno = 30;

            }
            else
            {
                throw new RegraDeNegocioException("Não foi possivel encontra o Canil informado.");
            }

            return CalcularTotal(PetShop, qtdCaesPequenos, qtdCaesGrandes);
        }

        public PetShop CalcularTotal(PetShop PetShop, int qtdCaesPequenos, int qtdCaesGrandes)
        {
            PetShop.TotalCaoGrande = PetShop.ValorCaoGrande * qtdCaesGrandes;
            PetShop.TotalCaoPequeno = PetShop.ValorCaoPequeno * qtdCaesPequenos;

            return PetShop;
        }

        public PetShop AvaliarMelhorPetShop(List<PetShop> petShops)
        {
            var melhorPetShop = petShops
                .Where(o=> o.PrecoTotal == petShops
                .Min(x=>x.PrecoTotal))
                .ToList();

            if (melhorPetShop.Count > 1)
            {
                return melhorPetShop
                    .FirstOrDefault(o => o.DistanciaKm == melhorPetShop
                    .Min(x => x.DistanciaKm));
            }

            return melhorPetShop.FirstOrDefault();
        }
    }
}
