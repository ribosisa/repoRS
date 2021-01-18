using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Movie4Allnamespace.Menu
{
    public static class MenuGeral
    {
        public static void IncializaMenu(Movie4ALL movie4ALL)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Bem Vindo ao Movie4All!");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("Escolha uma opção");
            Console.WriteLine("1. Novo Utilizador - Registar");
            Console.WriteLine("2. Utilizador existente - Login");
            string opcao;
            opcao = Console.ReadLine();
            
            OpcaoUtiliz(opcao, movie4ALL);
        }

        private static void OpcaoUtiliz(string opcao, Movie4ALL movie4ALL)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Bem Vindo ao Movie4All!");
            Console.ResetColor();
            Console.WriteLine();
            switch (opcao)
            {
                case "1":

                    string[] word;
                    string user, user1;

                    Console.WriteLine("Escolha um username");
                    do
                    {
                        user = Console.ReadLine();
                        Console.WriteLine("......");
                        Thread.Sleep(1500);
                        if (movie4ALL.UtilizadorComums.Exists(u => u.Id.Contains(user.ToLower())))
                            Console.WriteLine("Utilizador já existente, utilize outro username");
                    } while (movie4ALL.UtilizadorComums.Exists(u => u.Id.Contains(user.ToLower())));

                    do
                    {
                        Console.WriteLine("Escreva agora nome, email, NIF e telemovel separados por vírgulas");

                        user1 = Console.ReadLine();
                        word = user1.Split(',');
                    } while (word.Length != 4);
                    var utilizador = new UtilizadorComum
                    {
                        Id = user,
                        Nome = word[0],
                        Email = word[1],
                        NumFiscal = CheckNumString(word[2]),
                        Telemovel = CheckNumString(word[3])
                    };

                    CriaUtilizador(utilizador, movie4ALL.UtilizadorComums);
                    OpcaoUtiliz("2", movie4ALL);
                    break;

                case "2":
                    Console.WriteLine("Escreve o seu username");
                    string utilizadorId = Console.ReadLine();
                    string sair;
                    if (movie4ALL.UtilizadorComums.Exists(u => u.Id.Contains(utilizadorId.ToLower())))
                    {
                        do
                        {
                            var utilizadorProv = movie4ALL.UtilizadorComums.FirstOrDefault(e => e.Id == utilizadorId);
                            MenuUtilizador.MenuUtiliz(utilizadorProv, movie4ALL);
                            Console.WriteLine("Deseja Sair? Sim/Nao");
                            sair = Console.ReadLine();
                            Console.Clear();
                        } while (sair.ToLower() != "sim");
                    }
                    else if (utilizadorId == "admin")
                    {
                        do
                        {
                            Menu.MenuAdmin.MenuAdministrador(movie4ALL);
                            Console.WriteLine("Deseja Sair? Sim/Nao");
                            sair = Console.ReadLine();
                            Console.Clear();
                        } while (sair.ToLower() != "sim");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Utilizador Não existente");
                        IncializaMenu(movie4ALL);
                    }
                    break;

                default:
                    Console.WriteLine("Opção Inválida, Adeus");
                    IncializaMenu(movie4ALL);
                    break;
            }
        }


        public static void ColorUser(string utilizador) //Colorir o cabeçalho do Utilizador
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Utilizador: {utilizador}");
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void CriaUtilizador(UtilizadorComum utilizador, List<UtilizadorComum> utilizadores)
        {
            utilizadores.Add(utilizador);
        }


        public static void MostrarShows(string utilizador, List<Show> shows)
        {
            MenuGeral.ColorUser(utilizador);
            Console.WriteLine("Lista de Shows");
            foreach (var show in shows)
            {
                Console.Write($"ID: {show.IdShow} | {show.TipoShow} | Titulo: {show.Titulo} | Ano: {show.Ano} | País: {show.CodPais} | ");
                if (show.TipoShow == "serie")
                    Console.Write($" Num Temporadas: {show.ListaTemporadas.Count} | NumEpisodios: {NumEpisodios(show)} |");
                Console.WriteLine();
            }
        }

        public static Show ConsultaShow(List<Show> shows)
        {
            System.Console.WriteLine("Qual Id do show?");
            var showID = MenuGeral.CheckNum();
            
            return shows.FirstOrDefault(s => s.IdShow == showID);
        }

        public static int NumEpisodios(Show show)
        {
            var numEpisodios = 0;
            foreach (var temp in show.ListaTemporadas)
            {
                foreach (var epi in temp.ListaEpisodios)
                    numEpisodios++;
            }
            return numEpisodios;
        }

        public static int CheckNum()
        {
            bool erro = true;
            int num = 0;
            do
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                    erro = false;
                }
                catch (FormatException) { Console.WriteLine("Erro de formato, repita o número"); }
            } while (erro);
            return num;
        }

        public static int CheckNumString(string check)
        {
            bool erro = true;
            int num = 0;
            do
            {
                try
                {
                    num = int.Parse(check);
                    erro = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro de formato, repita o número");
                    check = Console.ReadLine();
                }
            } while (erro);
            return num;
        }
    }
}