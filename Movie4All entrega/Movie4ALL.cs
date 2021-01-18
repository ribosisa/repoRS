using System.Collections.Generic;

namespace Movie4Allnamespace
{
    public class Movie4ALL
    {
        public List<Show> Shows { get; set; }

        public List<UtilizadorComum> UtilizadorComums { get; set; }

        public List<Ator> ListaAtoresGeral { get; set; }
        public List<Precario> Precos { get; set; }

        public Movie4ALL()
        {
            UtilizadorComums = new List<UtilizadorComum>();
            Shows = new List<Show>();
            ListaAtoresGeral = new List<Ator>();
            Precos = new List<Precario>();
        }
    }
}