using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie4Allnamespace.Menu
{
    public static partial class MenuAdmin
    {
        public static class MenuAdminAtor
        {
            public static void MenuAlterarAtor(Movie4ALL movie4ALL)
            {
                Menu.MenuGeral.ColorUser("admin");

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Criar Ator");
                Console.WriteLine("2. Atribuir Ator a Show");
                Console.WriteLine("3. Apagar Ator de Show");
                Console.WriteLine("4. Mostrar Atores");

                string opcaoAdmin = Console.ReadLine();
                switch (opcaoAdmin)
                {
                    case "1":
                        CriarAtor(movie4ALL);
                        break;

                    case "2":
                        AtribuirAtor(movie4ALL);
                        break;

                    case "3":
                        ApagarAtor(movie4ALL);
                        break;

                    case "4":
                        MostrarAtores(movie4ALL.ListaAtoresGeral);
                        break;
                }
            }

            public static void CriarAtor(Movie4ALL movie4ALL)
            {
                MenuGeral.ColorUser("admin");
                var ator = new Ator();

                Console.WriteLine("Qual o Nome do Ator?");
                ator.Nome = Console.ReadLine();
                Console.WriteLine("Qual o Género do Ator? (M/F)");
                ator.Genero = Console.ReadLine();
                Console.WriteLine("Qual o Nickname do Ator?");
                ator.Nickname = Console.ReadLine();
                movie4ALL.ListaAtoresGeral.Add(ator);
            }

            public static void AtribuirAtor(Movie4ALL movie4ALL)
            {
                MostrarAtores(movie4ALL.ListaAtoresGeral);
                var ator = ConsultaAtor(movie4ALL.ListaAtoresGeral);
                if (ator == null)
                {
                    Console.WriteLine("Ator inexistente, volte ao menu");
                    return;
                }
                MenuGeral.MostrarShows("admin", movie4ALL.Shows);
                var showly = MenuGeral.ConsultaShow(movie4ALL.Shows);
                if (showly == null)
                {
                    Console.WriteLine("Filme inexistente, volte ao menu");
                    return;
                }
                if (showly.ListaAtores.Contains(ator))
                {
                    Console.WriteLine("Esse ator já foi atribuído a esse Show");
                    return;
                }
                showly.ListaAtores.Add(ator);
            }

            public static void ApagarAtor(Movie4ALL movie4ALL)
            {
                MenuGeral.ColorUser("admin");
                var ator = ConsultaAtor(movie4ALL.ListaAtoresGeral);
                if (ator == null)
                {
                    Console.WriteLine("Ator inexistente, volte ao menu");
                    return;
                }
                var showly = MenuGeral.ConsultaShow(movie4ALL.Shows);
                if (showly == null)
                {
                    Console.WriteLine("Filme inexistente, volte ao menu");
                    return;
                }
                showly.ListaAtores.Remove(ator);
            }

            public static void MostrarAtores(List<Ator> ators)
            {
                MenuGeral.ColorUser("admin");
                if (ators == null)
                    return;
                Console.WriteLine("Lista de Atores na Movie4ALL");
                foreach (var ator in ators)
                {
                    Console.WriteLine($"Nome:{ator.Nome} | Nickname:{ator.Nickname} | Género:{ator.Genero} | ");
                }
            }

            public static Ator ConsultaAtor(List<Ator> ators)
            {
                System.Console.WriteLine("Qual o nickname do ator?");
                var nicknameator = Console.ReadLine();
                return ators.FirstOrDefault(a => a.Nickname == nicknameator);
            }

        }
    }
}