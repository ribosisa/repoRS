using System;

using System.Collections.Generic;
using System.Linq;

namespace Movie4Allnamespace.Menu
{
    public static class MenuUtilizador
    {
        public static void MenuUtiliz(UtilizadorComum utilizador, Movie4ALL movie4ALL)
        {
            MenuGeral.ColorUser(utilizador.Id);

            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Alugar Show");
            Console.WriteLine("2. Avaliar Show");
            Console.WriteLine("3. Gerir Informação de Cartão");
            Console.WriteLine("4. Verificar Histórico de Alugueres");
            Console.WriteLine("5. Verificar Histórico de Avaliações");
            Console.WriteLine("6. Mostrar Shows");
            Console.WriteLine("7. Sair");
            Console.WriteLine();
            string opcaoUtiliz = Console.ReadLine();

            switch (opcaoUtiliz)
            {
                case "1":
                    AlugarShow(utilizador, movie4ALL);
                    break;

                case "2":
                    Avaliar(utilizador, movie4ALL);
                    break;

                case "3":
                    GerirCartao(utilizador);
                    break;

                case "4":
                    MostraAlugueres(utilizador);
                    break;

                case "5":
                    HistoricoAvaliacao(utilizador);
                    break;

                case "6":
                    MenuGeral.MostrarShows(utilizador.Id, movie4ALL.Shows);
                    break;

                case "7":
                    return;
            }
        }

        public static void AlugarShow(UtilizadorComum utilizador, Movie4ALL movie4ALL)
        {
            MenuGeral.MostrarShows(utilizador.Id, movie4ALL.Shows);
            var show = MenuGeral.ConsultaShow(movie4ALL.Shows);
            if (show == null)
            { 
                Console.WriteLine("Show inexistente"); 
                return; 
            }
            Aluguer aluguer = new Aluguer { ShowAlugado = show };
            aluguer.Valor = ConsultaPrecario(movie4ALL.Precos, aluguer).PeriodoDias * ConsultaPrecario(movie4ALL.Precos, aluguer).Preco;
            aluguer.DataFim = DateTime.Now.AddDays(ConsultaPrecario(movie4ALL.Precos, aluguer).PeriodoDias);
            if (show.TipoShow == "serie")
            { //O valor do Aluguer é referente ao valor * período * num episodios
                aluguer.DataFim = DateTime.Now.AddDays(MenuGeral.NumEpisodios(show));
                aluguer.Valor = aluguer.Valor * MenuGeral.NumEpisodios(show);
            }

            utilizador.Alugueres.Add(aluguer);
            Console.WriteLine($"O Alguer de {aluguer.ShowAlugado.Titulo} expira em {aluguer.DataFim}");
            Console.WriteLine($"Tem um valor de {aluguer.Valor}");
            aluguer.IdAluguer = utilizador.Alugueres.LastIndexOf(aluguer); //Id que é incrementado com o valor do indíce da Lista onde se encontra
        }

        private static Precario ConsultaPrecario(List<Precario> precarios, Aluguer aluguer)
        {
            return precarios.LastOrDefault(p => p.TipoShow == aluguer.ShowAlugado.TipoShow);
        }

        public static void MostraAlugueres(UtilizadorComum utilizador)
        {
            MenuGeral.ColorUser(utilizador.Id);
            Console.WriteLine("Histórico de Alugueres");
            foreach (var a in utilizador.Alugueres)
            {
                Console.WriteLine($"ID: {a.IdAluguer} |Titulo: {a.ShowAlugado.Titulo} | Metodo de Pagamento: {a.MetodoPagamento} | Valor: {a.Valor} | Data de Aluguer: {a.Data} | Data de Fim: {a.DataFim} |");
            }
        }

        // De acordo com o DER o utilizador pode avaliar qualquer show, independentemente de o ter alugado ou não.
        // Por falta de tempo e devido a ser um detalhe que não está claramente definido, assim ficou.
        public static void Avaliar(UtilizadorComum utilizador, Movie4ALL movie4ALL)
        {
            MenuGeral.MostrarShows(utilizador.Id, movie4ALL.Shows);
            var show = MenuGeral.ConsultaShow(movie4ALL.Shows);
            if (show == null)
            {
                Console.WriteLine("Show inexistente");
                return;
            }
            var avaliacao = new Avaliacao { ShowAvaliado = show };
            bool avalia1 = true;
            if (UpdateAvaliacao(show, utilizador.ListadeAvaliacao) != null)
            {
                avaliacao = utilizador.ListadeAvaliacao.FirstOrDefault(e => e.ShowAvaliado == show);
                Console.WriteLine("Já existe uma avaliação a este filme, vamos alterá-la? Sim/nao");
                string novaAvaliacao = Console.ReadLine();
                if (novaAvaliacao.ToLower() == "nao")
                    return;
                if (novaAvaliacao.ToLower() == "sim")
                {
                    do
                    {
                        Console.WriteLine($"Em quantas estrelas (0 a 5) avalia {show.Titulo}? ");
                        avaliacao.Stars = MenuGeral.CheckNum();
                        if (avaliacao.Stars > 5 || avaliacao.Stars < 0)
                        {
                            Console.WriteLine("Avaliação fora dos parâmetros");
                            avalia1 = false;

                        }
                    } while (!avalia1);
                    avaliacao.DataUpdate = DateTime.Now;
                    Console.WriteLine($"Insira uma pequena descrição.");
                    avaliacao.Descricao = Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Não percebi a sua opção, presumo que não queira alterar, vamos voltar ao Menu");
                    return;
                }
            }

            do
            {
                Console.WriteLine($"Em quantas estrelas (0 a 5) avalia {show.Titulo}? ");
                avaliacao.Stars = MenuGeral.CheckNum();
                if(avaliacao.Stars > 5 || avaliacao.Stars < 0)
                {
                    Console.WriteLine("Avaliação fora dos parâmetros");
                    avalia1 = false;
                }
            } while (!avalia1);
            avaliacao.DataCriacao = DateTime.Now;
            Console.WriteLine($"Insira uma pequena descrição.");
            avaliacao.Descricao = Console.ReadLine();
            utilizador.ListadeAvaliacao.Add(avaliacao);
        }

        public static Avaliacao UpdateAvaliacao(Show show, List<Avaliacao> avaliacoes)
        {
            Avaliacao avaliacao = avaliacoes.FirstOrDefault(e => e.ShowAvaliado == show);
            return avaliacao;
        }

        public static void HistoricoAvaliacao(UtilizadorComum utilizador)
        {
            MenuGeral.ColorUser(utilizador.Id);
            Console.WriteLine("Histórico de Avaliações");
            foreach (var a in utilizador.ListadeAvaliacao)
            {
                Console.WriteLine($"NºEstrelas: {a.Stars} |Titulo: {a.ShowAvaliado.Titulo} | Data da 1ª Avaliacão: {a.DataCriacao} | Data da ultima Avaliação: {a.DataUpdate} | Descrição: {a.Descricao} |");
            }
        }

        public static void GerirCartao(UtilizadorComum utilizador)
        {
            if (utilizador.CartaoCredito != null)
            {
                Console.WriteLine("Já existe cartão associado");
                Console.WriteLine($"Nome: {utilizador.CartaoCredito.Nome}");
                Console.WriteLine($"Número: {utilizador.CartaoCredito.Numero}");
                return;
            }
            utilizador.CartaoCredito = new Cartao();
            Console.WriteLine("Digite os dados do cartão seguidos de Enter: Nome, Número, Mês(num), Ano, CVC");
            utilizador.CartaoCredito.Nome = Console.ReadLine();
            utilizador.CartaoCredito.Numero = long.Parse(Console.ReadLine());
            utilizador.CartaoCredito.Mes = MenuGeral.CheckNum();
            utilizador.CartaoCredito.Ano = MenuGeral.CheckNum();
            utilizador.CartaoCredito.CVC = MenuGeral.CheckNum();

            Console.WriteLine("Cartão gravado");
        }
    }
}