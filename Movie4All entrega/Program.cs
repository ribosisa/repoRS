using System;
using System.Collections.Generic;
using Movie4Allnamespace;
using System.Text.Json;
using System.IO;

namespace Movie4Allnamespace
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Movie4ALL movie4All;
            var options = new JsonSerializerOptions() { WriteIndented = true };
            string json = string.Empty;
            //List<UtilizadorComum> utilizadores = new List<UtilizadorComum>();
            //List<Show> shows = new List<Show>();

            if (File.Exists(@"c:\temp\movieRS.json"))
            {
                json = File.ReadAllText(@"c:\temp\movieRS.json");
                movie4All = JsonSerializer.Deserialize<Movie4ALL>(json);
            }
            else
            {
                movie4All = new Movie4ALL();

                InicializaDados(movie4All);
            }

            Menu.MenuGeral.IncializaMenu(movie4All);

            json = JsonSerializer.Serialize(movie4All, options);
            File.WriteAllText(@"c:\temp\movieRS.json", json);
        }

        static void InicializaDados(Movie4ALL movie4All)
        {
            var precoSerie = new Precario { DataInicio = DateTime.Now, IdPreco = 0, TipoShow = "serie", Preco = 0.5M, PeriodoDias = 1, DataFim = DateTime.MaxValue };
            var precoFilme = new Precario { DataInicio = DateTime.Now, IdPreco = 1, TipoShow = "filme", Preco = 1, PeriodoDias = 1, DataFim = DateTime.MaxValue };
            var precoDoc = new Precario { DataInicio = DateTime.Now, IdPreco = 2, TipoShow = "documentario", Preco = 1, PeriodoDias = 3, DataFim = DateTime.MaxValue };
            movie4All.Precos.AddRange(new List<Precario> { precoSerie, precoFilme, precoDoc });

            var user = new UtilizadorComum("Ricardo", 217311118, 964111111, "ribosisa@gmail.com", "ribosisa");
            movie4All.UtilizadorComums.Add(user);

            var ator = new Ator { Nickname = "Pitt", Genero = "M", Nome = "Brad Pitt" };
            movie4All.ListaAtoresGeral.Add(ator);

            var serie = new Serie { Titulo = "Friends", Ano = 1998, CodPais = "US", TipoShow = "serie", IdShow = 0 };
            movie4All.Shows.Add(serie);
            var temporada = new Temporada { IdTemp = 1, Nome = "Season 1", Numero = 1 };
            serie.ListaTemporadas.Add(temporada);
            var episodio = new Episodio { Numero = 1, IdTemp = 1, Nome = "The One Where Monica Gets a Roommate", Data = (DateTime.Today.AddYears(-22).AddDays(-18)) };
            temporada.ListaEpisodios.Add(episodio);
            var aluguer = new Aluguer { ShowAlugado = serie, Data = DateTime.Now, IdAluguer = 0, DataFim = DateTime.Now.AddDays(3), MetodoPagamento = "Cartao", Valor = 1.50M };
            user.Alugueres.Add(aluguer);

            serie.ListaAtores.Add(ator);

            Menu.CSV.IntegraListaShows(movie4All, "moviesRS.csv");
        }
    }
}