using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteDTI.Comum;
using TesteDTI.Enumeradores;
using TesteDTI.Modelos;

namespace TesteDTI
{
    public static class ProgramHelper
    {
       
        public static DadosEntrada TratarEntrada(this string entrada)
        {
            DateTime data;
            int qtdCaesGrandes;
            int qtdCaesPequenos;

            var valoresEntrada = entrada.Split(" ");


            if (valoresEntrada.ToList().Count != 3)
            {
                throw new RegraDeNegocioException("Valores informados estão num formato incorreto, certifique-se de separa-los por espaço. Ex. 08/02/2019 5 8");
            }
           
            var resultadoData = DateTime.TryParse(valoresEntrada[0], out data);

            if (!resultadoData)
            {
                throw new RegraDeNegocioException("Informações de data inválidas, certifique-se de informa-la no padrão dd/MM/aaaa");
            }

            var resultadoCaesPequenos = int.TryParse(valoresEntrada[1], out qtdCaesPequenos);

            if (!resultadoCaesPequenos)
            {
                throw new RegraDeNegocioException("Informações de quantidade de cães pequenos inválidas, certifique-se de informar valores inteiros");
            }

            var resultadoCaesGrandes = int.TryParse(valoresEntrada[2], out qtdCaesGrandes);

            if (!resultadoCaesGrandes)
            {
                throw new RegraDeNegocioException("Informações de quantidade de cães grandes inválidas, certifique-se de informar valores inteiros");
            }

            return new DadosEntrada()
            {
                Data = data,
                QuantidadeCaesGrandes = qtdCaesGrandes,
                QuantidadeCaesPequenos = qtdCaesPequenos
            };
        }

        public static string TratarTipoPetShopEnum(this TipoPetShop tipoPetShop)
        {
            if (tipoPetShop == TipoPetShop.MeuCaninoFeliz)
            {
                return "Meu Canino Feliz";
            }
            else if (tipoPetShop == TipoPetShop.VaiRex)
            {
                return "Vai Rex";
            }
            else if (tipoPetShop == TipoPetShop.ChowChawgas)
            {
                return "ChowChawgas";
            }
            else
            {
                return "Indefinido";
            }


        }
    }
}
