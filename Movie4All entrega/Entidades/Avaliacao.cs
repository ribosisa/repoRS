using System;

namespace Movie4Allnamespace
{
    public class Avaliacao
    {
        public Show ShowAvaliado { get; set; }
        public string Descricao { get; set; }
        public int Stars { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUpdate { get; set; }

        public Avaliacao()
        {
        }
    }
}