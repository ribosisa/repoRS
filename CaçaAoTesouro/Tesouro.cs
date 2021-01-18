using CaçaAoTesouro.Interfaces;
using System;

namespace CaçaAoTesouro
{
    public class Tesouro : IElement
    {
        public void Display()
        {
            Console.Write("$");
        }
    }
}