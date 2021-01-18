using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Movie4Allnamespace.Menu
{
    public static class CSV
    {
        public static void IntegraListaShows(Movie4ALL movie4ALL, string moviesCsv)
        {
            if (ConvertShow(moviesCsv) == null)
            {
                Console.WriteLine("Escolha outra opção.");
                return;
            }
            movie4ALL.Shows.AddRange(ConvertShow(moviesCsv));
            movie4ALL.Shows.ForEach(s => s.IdShow = movie4ALL.Shows.LastIndexOf(s));
        }

        public static List<Show> ConvertShow(string moviesCsv)
        {
            try
            {
                List<Show> showsCsv = File.ReadAllLines($"C:\\Temp\\{moviesCsv}")
                                               .Skip(1)
                                               .Select(s => ShowFromCsv(s))
                                               .ToList();
                return showsCsv;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("O ficheiro não existe.");
                return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public static Show ShowFromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            try
            {
                switch (values[3])
                {
                    case "serie":
                        Serie serie = new Serie
                        {
                            Titulo = values[0],
                            Ano = Convert.ToInt32(values[1]),
                            CodPais = values[2],
                            TipoShow = values[3]
                        };
                        return serie;

                    case "filme":
                        Filme filme = new Filme
                        {
                            Titulo = values[0],
                            Ano = Convert.ToInt32(values[1]),
                            CodPais = values[2],
                            TipoShow = values[3]
                        };
                        return filme;

                    case "documentario":
                        Documentario doc = new Documentario
                        {
                            Titulo = values[0],
                            Ano = Convert.ToInt32(values[1]),
                            CodPais = values[2],
                            TipoShow = values[3]
                        };
                        return doc;

                    default:
                        Console.WriteLine("Erro de tipo de show");
                        return null;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Erro! Nem todos os campos estão preenchidos");
                return null;
            }
        }
    }
}