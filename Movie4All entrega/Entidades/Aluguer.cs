using System;

namespace Movie4Allnamespace
{
    public class Aluguer
    {
        public int IdAluguer { get; set; }
        public decimal Valor { get; set; }
        public string MetodoPagamento { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataFim { get; set; }
        public Show ShowAlugado { get; set; }

        public Aluguer()
        {
            MetodoPagamento = "Cartao";
            Data = DateTime.Now;
            DataFim = DateTime.Now.AddDays(7);
        }
    }
}