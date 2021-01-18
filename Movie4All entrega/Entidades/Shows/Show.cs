using System.Collections.Generic;

namespace Movie4Allnamespace
{
    public class Show
    {
        public string Titulo { get; set; }
        public string TipoShow { get; set; }
        public int Ano { get; set; }
        public int IdShow { get; set; }
        public string CodPais { get; set; }
        public List<Ator> ListaAtores { get; set; }
        public List<Temporada> ListaTemporadas { get; set; }

        public Show()
        {
            ListaAtores = new List<Ator>();
        }

        public virtual void CriaShow()
        {
        }
    }
}