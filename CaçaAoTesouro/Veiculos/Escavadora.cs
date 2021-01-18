using CaçaAoTesouro.Interfaces;
using System;

namespace CaçaAoTesouro.Veiculos
{
  
    public class Escavadora : Veiculo, IElement
    {
        public Escavadora()
        {
            Nomenclatura = "E";
        }

        public Escavadora(string nome, ConsoleColor cor) : this()
        {
            Cor = cor;
            Nome = nome;
            Nomenclatura = "E";
            QuantidadeMov = 1;
        }
    }
}