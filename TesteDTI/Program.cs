using System;
using System.Collections.Generic;
using TesteDTI.Comum;
using TesteDTI.Enumeradores;
using TesteDTI.Modelos;
using TesteDTI.Servicos;

namespace TesteDTI
{
    class Program
    {
        static void Main(string[] args)
        {
            var scape = 1;
            while (scape != 0)
            {
                try
                {
                    Console.WriteLine("------------------------------Teste DTI - CANIL------------------------------");
                    Console.WriteLine(" Insira data, quantidade de cães grandes e quantidade de cães pequenos para obter o melhor petShop! :) (tecle 0 para sair)");

                    var entrada = Console.ReadLine();

                    if (entrada != "0")
                    {
                        //Valida a entrada de dados inserida pelo usuário e preenche o respectivo objeto
                        var dadosEntrada = entrada.TratarEntrada();

                        //Intancia os 3 petshops necessários
                        #region Intancia petshops
                        var petShops = new List<PetShop>();
                        var petShopsServico = new PetShopServico();
                        petShops.Add(new PetShop(TipoPetShop.MeuCaninoFeliz, 2));
                        petShops.Add(new PetShop(TipoPetShop.VaiRex, 1.7));
                        petShops.Add(new PetShop(TipoPetShop.ChowChawgas, 0.8));
                        #endregion

                        var petShop = petShopsServico.ObterMelhorPetShop(petShops, dadosEntrada.Data, dadosEntrada.QuantidadeCaesPequenos, dadosEntrada.QuantidadeCaesGrandes);

                        Console.WriteLine(" PetShop: " + petShop.TipoPetShop.TratarTipoPetShopEnum() + ", valor: R$" + petShop.PrecoTotal);
                        Console.ReadKey();
                       
                    }
                    else
                    {
                        scape = 0;
                    }
                }
                catch (RegraDeNegocioException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("Houve um erro inesperado ! :(");
                    Console.ReadKey();
                }
            }

        }
    }
}
