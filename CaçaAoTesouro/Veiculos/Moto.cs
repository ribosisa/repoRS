using CaçaAoTesouro.Interfaces;
using System;

namespace CaçaAoTesouro.Veiculos
{
    public class Moto : Veiculo, IElement
    {
        public Moto()
        {
        }

        public Moto(string nome, ConsoleColor cor) : this()
        {
            Cor = cor;
            Nome = nome;
            Nomenclatura = "M";
            QuantidadeMov = 2;
        }
    }
}