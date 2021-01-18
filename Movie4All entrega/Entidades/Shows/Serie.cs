using System;
using System.Collections.Generic;

namespace Movie4Allnamespace
{
    public class Serie : Show
    {
        public Serie()
        {
            ListaTemporadas = new List<Temporada>();
            TipoShow = "serie";
            ListaAtores = new List<Ator>();
        }

        public override void CriaShow()
        {
            Console.WriteLine("Qual o Título?");
            Titulo = Console.ReadLine();
            Console.WriteLine("Qual o Ano?");
            Ano = Menu.MenuGeral.CheckNum();
            Console.WriteLine("Qual o Pais de Origem (código)?");
            CodPais = Console.ReadLine();
            Console.WriteLine("Quantas temporadas tem?");
            int numTemp, numEpi;
            numTemp = Menu.MenuGeral.CheckNum();

            string nomeTemp, nomeEpi;
            for (int i = 1; i <= numTemp; i++)
            {
                Menu.MenuGeral.ColorUser("admin");
                Console.WriteLine($"Qual o nome da Temporada {i}?");
                nomeTemp = Console.ReadLine();
                var temporada = new Temporada { Nome = nomeTemp, Numero = i, IdTemp = i };
                ListaTemporadas.Add(temporada);
                Console.WriteLine($"Quantos episódios tem a Temporada {i}?");
                numEpi = Menu.MenuGeral.CheckNum();
                for (int j = 1; j <= numEpi; j++)
                {
                    Console.WriteLine($"Qual o nome do Episodio {j} da Temporada {i}?");
                    nomeEpi = Console.ReadLine();
                    var episodio = new Episodio { Nome = nomeEpi, Numero = j, IdTemp = i };
                    temporada.ListaEpisodios.Add(episodio);
                }
            }
        }
    }
}