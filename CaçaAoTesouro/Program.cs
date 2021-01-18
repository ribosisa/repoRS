using CaçaAoTesouro.Veiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CaçaAoTesouro
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int numLinhas = 10;
            int numColunas = 20;
            bool cacou = false;
            var terreno = new Terreno(numLinhas, numColunas);
            var tesouro = new Tesouro();

            var motinha = new Moto("Motinha", ConsoleColor.Red);
            var motinha2 = new Moto("Motinha2", ConsoleColor.Green);
            var motinha3 = new Moto("Motinha3", ConsoleColor.Blue);
            var trator = new Escavadora("EscavaEscava", ConsoleColor.DarkYellow);

            var veiculos = new List<Veiculo> { motinha, motinha2, motinha3, trator, new Escavadora("Escavadora", ConsoleColor.Cyan) };

            veiculos.Add(new Tanque("CutxiTanque", ConsoleColor.Yellow));
            veiculos.Add(new Tanque("Tanquezorro", ConsoleColor.White));

            terreno.SetParede();
            terreno.SetTesouro(tesouro);
            foreach (var v in veiculos)
            {
                v.SetVeiculo(terreno.GetTerreno(), v);
            }
            terreno.DisplayTerreno();

            Thread.Sleep(2000);
            string winner = "";
            while (!cacou)
            {
                Console.Clear();
                foreach (var v in veiculos.ToList())
                {
                    cacou = v.MoveVeiculo(terreno.GetTerreno(), v, tesouro, veiculos);

                    if (cacou == true)
                    {
                        winner = v.Nome;
                        break;
                    }
                }
                terreno.DisplayTerreno();
                Thread.Sleep(500);
            }
            Console.WriteLine("Fim da Caça, {0} venceu", winner);
            Console.WriteLine("Winner Winner, Chicken Dinner");
        }
    }
}