using System.Collections.Generic;

namespace Movie4Allnamespace
{
    public class Utilizador
    {
        public int Telemovel { get; set; }
        public int NumFiscal { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Id { get; set; }

        public List<Show> Shows { get; set; }

        public List<Aluguer> Alugueres { get; set; }

        public List<Avaliacao> ListadeAvaliacao { get; set; }
        public Cartao CartaoCredito { get; set; }

        public Utilizador()
        {
            Alugueres = new List<Aluguer>();
            ListadeAvaliacao = new List<Avaliacao>();
        }
    }

    public class UtilizadorAdmin : Utilizador
    {
        public UtilizadorAdmin()
        {
            Id = "admin";
        }
    }

    public class UtilizadorComum : Utilizador
    {
        public UtilizadorComum()
        {
            Alugueres = new List<Aluguer>();
            ListadeAvaliacao = new List<Avaliacao>();
        }

        public UtilizadorComum(string nome, int numFiscal, int telemovel, string email, string id)
        {
            Nome = nome;
            NumFiscal = numFiscal;
            Telemovel = telemovel;
            Email = email;
            Id = id;
            Alugueres = new List<Aluguer>();
        }
    }
}