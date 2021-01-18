using System;
using System.Collections.Generic;

namespace Movie4Allnamespace
{
    public class Documentario : Show

    {
        public Documentario()
        {
            TipoShow = "documentario";
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