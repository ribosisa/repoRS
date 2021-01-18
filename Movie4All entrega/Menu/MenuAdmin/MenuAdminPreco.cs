using System;
using System.Linq;

namespace Movie4Allnamespace.Menu
{
    public static partial class MenuAdmin
    {
        public static class MenuAdminPreco
        {
            public static void AlterarInfoPreco(Movie4ALL movie4ALL)
            {
                MenuGeral.ColorUser("admin");

                var preco = new Precario();
                do
                {
                    Console.WriteLine("De que tipo de Show quer alterar o preço? \"Serie\"\\\"Filme\"\\\"Documentario\"");
                    preco.TipoShow = Console.ReadLine();
                    if (!(preco.TipoShow.ToLower() == "serie" || preco.TipoShow.ToLower() == "filme" || preco.TipoShow.ToLower() == "documentario"))
                        Console.WriteLine("Tipo de Show Inexistente");
                } while (!(preco.TipoShow.ToLower() == "serie" || preco.TipoShow.ToLower() == "filme" || preco.TipoShow.ToLower() == "documentario"));

                Console.WriteLine("Qual o preço? e por quantos dias? (Separado de Enter)");
                bool erro = true;

                do
                {
                    try
                    {
                        preco.Preco = decimal.Parse(Console.ReadLine());
                        erro = false;
                    }
                    catch (FormatException) { Console.WriteLine("Erro de formato, repita o número"); }
                } while (erro);
                preco.PeriodoDias = MenuGeral.CheckNum();
                preco.DataInicio = DateTime.Now;
                if (movie4ALL.Precos.FirstOrDefault(e => e.TipoShow == preco.TipoShow) != null)
                    movie4ALL.Precos.LastOrDefault(e => e.TipoShow == preco.TipoShow).DataFim = DateTime.Now;
                preco.DataFim = DateTime.MaxValue;
                movie4ALL.Precos.Add(preco);
                preco.IdPreco = movie4ALL.Precos.LastIndexOf(preco);
            }
        }
    }
}