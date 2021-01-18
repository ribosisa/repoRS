using CaçaAoTesouro.Interfaces;
using System;

namespace CaçaAoTesouro.Veiculos
{
    public class Tanque : Veiculo, IElement
    {
        public Tanque()
        {
        }

        public Tanque(string nome, ConsoleColor cor)
        {
            Nome = nome;
            Cor = cor;
            Nomenclatura = "T";
            QuantidadeMov = 1;
        }
    }
}