using System;
using System.Threading;

namespace Movie4Allnamespace.Menu
{
    public static partial class MenuAdmin
    {
        public static void MenuAdministrador(Movie4ALL movie4ALL)

        {
            MenuGeral.ColorUser("admin");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Criar/Alterar Informação de Shows");
            Console.WriteLine("2. Criar/Alterar Informação de Atores");
            Console.WriteLine("3. Alterar Informação de Preço");

            string opcaoAdmin = Console.ReadLine();
            switch (opcaoAdmin)
            {
                case "1":
                    MenusAdminShow.MenuAlterarShow(movie4ALL);
                    break;

                case "2":
                    MenuAdminAtor.MenuAlterarAtor(movie4ALL);
                    break;

                case "3":
                    MenuAdminPreco.AlterarInfoPreco(movie4ALL);
                    break;

                default:
                    Console.WriteLine("Opção Inexistente");
                    Thread.Sleep(500);
                    MenuAdministrador(movie4ALL);
                    break;
            }
        }
    }
}