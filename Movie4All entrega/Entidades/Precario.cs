using System;

namespace Movie4Allnamespace
{
    public class Precario
    {
        public int IdPreco { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int PeriodoDias { get; set; }
        public string TipoShow { get; set; }

        public Precario()
        {
        }
    }
}