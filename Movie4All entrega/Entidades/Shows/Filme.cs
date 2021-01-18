using System;
using System.Collections.Generic;

namespace Movie4Allnamespace
{
    public class Filme : Show
    {
        public Filme()
        {
            TipoShow = "filme";
            ListaAtores = new List<Ator>();
        }

        public override void CriaShow()
        {
            Console.WriteLine("Qual o Título?");
            Titulo = Console.ReadLine();
            Console.WriteLine("Qual o Ano?");
            Ano = Menu.MenuGeral.CheckNum();
            Console.WriteLine("Qual o Pais de Origem (código)?");
            CodPais = Console.ReadLine();
        }
    }
}