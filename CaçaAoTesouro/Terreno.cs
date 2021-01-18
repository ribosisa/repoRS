using CaçaAoTesouro.Interfaces;
using System;

namespace CaçaAoTesouro
{
    public class Terreno
    {
        public int XPos;
        public int YPos;

        public int _numLinhas;
        public int _numColunas;
        private IElement[,] terreno;
        private Random rnd;

        public Terreno(int numLinhas, int numColunas)

        {
            _numLinhas = numLinhas;
            _numColunas = numColunas;

            terreno = new IElement[_numLinhas, _numColunas];
        }

        public IElement[,] GetTerreno()
        {
            return terreno;
        }

        public void DisplayTerreno()
        {
            for (int i = 0; i < _numLinhas; i++)
            {
                Console.WriteLine();

                for (int j = 0; j < _numColunas; j++)
                {
                    var elem = terreno[i, j];
                    if (elem == null)
                        Console.Write(".");
                    else
                        elem.Display();
                }
            }
            Console.WriteLine();
        }

        public void SetTesouro(Tesouro tesouro)
        {
            rnd = new Random();
            terreno[rnd.Next(1, _numLinhas - 1), rnd.Next(1, _numColunas - 1)] = tesouro;
        }

        public void SetParede()
        {
            for (int j = 0; j < _numColunas; j++)
            {
                terreno[0, j] = new Parede();
                terreno[_numLinhas - 1, j] = new Parede();
            }
            for (int i = 0; i < _numLinhas; i++)
            {
                terreno[i, 0] = new Parede();
                terreno[i, _numColunas - 1] = new Parede();
            }
        }
    }
}