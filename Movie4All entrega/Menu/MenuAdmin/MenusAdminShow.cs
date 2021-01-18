using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Movie4Allnamespace.Menu
{
    public static partial class MenuAdmin
    {
        public static class MenusAdminShow
        {
            public static void MenuAlterarShow(Movie4ALL movie4ALL)
            {
                MenuGeral.ColorUser("admin");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Criar Show");
                Console.WriteLine("2. Alterar Informação de Show");
                Console.WriteLine("3. Apagar Show");
                Console.WriteLine("4. Mostrar Shows");
                Console.WriteLine("5. Importar Lista Shows");

                string opcaoAdmin = Console.ReadLine();
                switch (opcaoAdmin)
                {
                    case "1":
                        CriarShow(movie4ALL);
                        break;

                    case "2":
                        AlterarInfoShow(movie4ALL.Shows);
                        break;

                    case "3":
                        ApagarShow(movie4ALL.Shows);
                        break;

                    case "4":
                        MenuGeral.MostrarShows("admin", movie4ALL.Shows);
                        break;

                    case "5":
                        Console.WriteLine("Coloque o ficheiro CSV na pasta Temp e de seguida escreva o nome do ficheiro (inclua o .csv)");
                        string fichCsv = Console.ReadLine();
                        Menu.CSV.IntegraListaShows(movie4ALL, fichCsv);
                        break;

                    default:
                        Console.WriteLine("Opção Inexistente");
                        Thread.Sleep(500);
                        MenuAlterarShow(movie4ALL);
                        break;
                }
            }
            public static void CriarShow(Movie4ALL movie4ALL)
            {
                MenuGeral.ColorUser("admin");
                System.Console.WriteLine("Qual o Tipo de show? Filme, Serie, Documentario");
                var tiposhow = Console.ReadLine();
                if (tiposhow.ToLower() == "filme")
                {
                    var filme = new Filme();
                    filme.CriaShow();
                    movie4ALL.Shows.Add(filme);
                    filme.IdShow = movie4ALL.Shows.LastIndexOf(filme);
                }
                else if (tiposhow.ToLower() == "serie")
                {
                    var serie = new Serie();
                    serie.CriaShow();
                    movie4ALL.Shows.Add(serie);
                    serie.IdShow = movie4ALL.Shows.LastIndexOf(serie);
                }
                else if (tiposhow.ToLower() == "documentario")
                {
                    var documentario = new Documentario();
                    documentario.CriaShow();
                    movie4ALL.Shows.Add(documentario);
                    documentario.IdShow = movie4ALL.Shows.LastIndexOf(documentario);
                }
                else
                    Console.WriteLine("Tipo de show inexistente");
            }
            public static void ApagarShow(List<Show> shows)
            {
                MenuGeral.MostrarShows("admin", shows);
                Console.WriteLine("Qual o Id do show que quer apagar?");
                int showID = MenuGeral.CheckNum();
                var showly = shows.FirstOrDefault(e => e.IdShow == showID);

                if (showly == null)
                {
                    Console.WriteLine("Show não existente");
                    return;
                }

                shows.Remove(showly);
                foreach (Show sh in shows)
                {
                    if (sh.IdShow > showID)
                        sh.IdShow = sh.IdShow - 1;
                }
            }

            public static void AlterarInfoShow(List<Show> shows)
            {
                MenuGeral.ColorUser("admin");
                System.Console.WriteLine("Qual Id do show?");
                int showID = MenuGeral.CheckNum();

                UpdateShow(showID, shows);
            }



            public static void UpdateShow(int showID, List<Show> shows)
            {
                MenuGeral.ColorUser("admin");
                var showly = shows.FirstOrDefault(e => e.IdShow == showID);

                if (showly == null)
                {
                    Console.WriteLine("Show inexistente");
                    return;
                }
                Console.WriteLine("Quer mudar o Titulo? s/n");
                string stringOpcao = Console.ReadLine();
                if (stringOpcao.ToLower() == "s")
                {
                    Console.WriteLine("Titulo?");
                    string Titulo = Console.ReadLine();
                    showly.Titulo = Titulo;
                }
                Console.WriteLine("Quer mudar o Ano? s/n");
                stringOpcao = Console.ReadLine();
                if (stringOpcao.ToLower() == "s")
                {
                    Console.WriteLine("Ano?");

                    showly.Ano = MenuGeral.CheckNum();
                }
                Console.WriteLine("Quer mudar o Código do País? s/n");
                stringOpcao = Console.ReadLine();
                if (stringOpcao.ToLower() == "s")
                {
                    Console.WriteLine("Código?");
                    var CodPais = Console.ReadLine();
                    showly.CodPais = CodPais;
                }
            }
        }
    }
}