using CaçaAoTesouro.Interfaces;
using System;
using System.Collections.Generic;

namespace CaçaAoTesouro.Veiculos
{
    public abstract class Veiculo : IElement
    {
        public Random rnd;
        public string Nome;
        public string Nomenclatura;

        public int XPos { get; set; }
        public int YPos { get; set; }
        public ConsoleColor Cor { get; set; }

        public int QuantidadeMov;

        public void Display()
        {
            Console.ForegroundColor = Cor;
            Console.Write(Nomenclatura);
            Console.ResetColor();
        }

        public int[,] QualADirecao()
        {
            rnd = new Random();
            int direcao = rnd.Next(1, 5);
            int[,] sentido = new int[2, 2];
            switch (direcao)
            {
                case 1:
                    sentido[1, 0] = -1; //N
                    break;

                case 2:
                    sentido[0, 1] = 1;  //E
                    break;

                case 3:
                    sentido[1, 0] = 1; //S;
                    break;

                case 4:
                    sentido[0, 1] = -1; // W;
                    break;

                default:
                    break;
            }

            return sentido;
        }

        public bool VerificaVeiculo(IElement[,] terreno, Veiculo motinha, int[,] sentido, List<Veiculo> veiculos)

        {
            bool teste = true; ;
            if (sentido[0, 1] != 0) // E W
            {
                if (terreno[motinha.YPos, motinha.XPos + sentido[0, 1] * QuantidadeMov] is Veiculo veiculo)
                {
                    if (motinha is Tanque)
                    {
                        veiculos.Remove(veiculo);
                        teste = true;
                    }
                    else teste = false;
                }
            }
            else if (sentido[1, 0] != 0) //S N
            {
                if (terreno[motinha.YPos + sentido[1, 0] * QuantidadeMov, motinha.XPos] is Veiculo veiculo)
                {
                    if (motinha is Tanque)
                    {
                        veiculos.Remove(veiculo);
                        teste = true;
                    }
                    else teste = false;
                }
            }

            return teste;
        }
        public void SetVeiculo(IElement[,] terreno, Veiculo motinha)
        {
            rnd = new Random();
            do
            {
                YPos = rnd.Next(1, terreno.GetLength(0) - 1);
                XPos = rnd.Next(1, terreno.GetLength(1) - 1);
            } while (terreno[YPos, XPos] != null);
             
            terreno[YPos, XPos] = motinha;
        }

        public void Move(IElement[,] terreno, Veiculo motinha, int[,] sentido)
        {
            terreno[YPos, XPos] = null;
            XPos = XPos + sentido[0, 1] * QuantidadeMov;
            YPos = YPos + sentido[1, 0] * QuantidadeMov;
            terreno[YPos, XPos] = motinha;
        }

        public bool MoveVeiculo(IElement[,] terreno, Veiculo motinha, Tesouro tesouro, List<Veiculo> veiculos)
        {
            bool teste = false;
            rnd = new Random();
            int[,] sentido = QualADirecao();
            if (VerificaParede(terreno, motinha, sentido) == true)
            {
                if (VerificaTesouro(terreno, motinha, sentido, tesouro) == true)
                {
                    if (VerificaVeiculo(terreno, motinha, sentido, veiculos) == true)
                    {
                        Move(terreno, motinha, sentido);
                    }
                }
                else if (VerificaTesouro(terreno, motinha, sentido, tesouro) == false)
                {
                    Move(terreno, motinha, sentido);
                    teste = true;
                    return teste;
                }
            }
            return teste;
        }

        public bool VerificaParede(IElement[,] terreno, Veiculo motinha, int[,] sentido)

        {
            bool teste = true; ;
            if (sentido[0, 1] > 0) // E
            {
                if (motinha.XPos + sentido[0, 1] * QuantidadeMov >= terreno.GetLength(1) - 1)
                {
                    if (motinha is Escavadora)
                    {
                        terreno[YPos, XPos] = null;
                        XPos = 1;
                        terreno[YPos, XPos] = motinha;
                    }
                    teste = false;
                }
            }
            else if (sentido[0, 1] < 0) //W
            {
                if (motinha.XPos + sentido[0, 1] * QuantidadeMov <= 0)
                {
                    if (motinha is Escavadora)
                    {
                        terreno[YPos, XPos] = null;
                        XPos = terreno.GetLength(1) - 2;
                        terreno[YPos, XPos] = motinha;
                    }
                    teste = false;
                }
            }
            if (sentido[1, 0] > 0) // S
            {
                if (motinha.YPos + sentido[1, 0] * QuantidadeMov >= terreno.GetLength(0) - 1)
                {
                    if (motinha is Escavadora)
                    {
                        terreno[YPos, XPos] = null;
                        YPos = 1;
                        terreno[YPos, XPos] = motinha;
                    }
                    teste = false;
                }
            }
            else if (sentido[1, 0] < 0) // N
            {
                if (motinha.YPos + sentido[1, 0] * QuantidadeMov <= 0)
                {
                    if (motinha is Escavadora)
                    {
                        terreno[YPos, XPos] = null;
                        YPos = terreno.GetLength(0) - 2;
                        terreno[YPos, XPos] = motinha;
                    }
                    teste = false;
                }
            }

            return teste;
        }

        public bool VerificaTesouro(IElement[,] terreno, Veiculo motinha, int[,] sentido, Tesouro tesouro)

        {
            bool teste = true; ;
            if (sentido[0, 1] != 0) //E W
            {
                if (terreno[motinha.YPos, motinha.XPos + sentido[0, 1] * QuantidadeMov] == tesouro)
                    teste = false;
            }
            else if (sentido[1, 0] != 0) //S N
            {
                if (terreno[motinha.YPos + sentido[1, 0] * QuantidadeMov, motinha.XPos] == tesouro)
                    teste = false;
            }
            return teste;
        }
    }
}