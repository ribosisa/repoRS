using System.Collections.Generic;

namespace Movie4Allnamespace
{
    public class Temporada
    {
        public string Nome { get; set; }
        public int Numero { get; set; }
        public int IdTemp { get; set; }

        public List<Episodio> ListaEpisodios { get; set; }

        public Temporada()
        {
            ListaEpisodios = new List<Episodio>();
        }
    }
}