using System;

namespace CRUD_Series
{
    class Program
    {
       
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcao();

            while (opcaoUsuario != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                }
                opcaoUsuario = ObterOpcao();
            }

        }
        private static void ListarSeries()
        {
            Console.WriteLine("\n Listar séries");

            var lista = repositorio.Lista();
            if (lista.Count == 0) { Console.WriteLine("\nNão há séries cadastradas!\n"); }

            foreach (var serie in lista)
            {
                Console.WriteLine($"ID - {serie.retornaId()}; Nome - {serie.retornaTitulo()}");
            }

        }
        private static void InserirSerie()
        {
            // Cadastro do gênero
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.WriteLine("\n Digite um numero dentre as opções acima!:");
            int entradaGenero = 0;
            while (int.TryParse(Console.ReadLine(), out entradaGenero) != true)
            {
                { Console.WriteLine("Digite apenas numeros!\n"); }
            }

            // Cadastro do titulo
            Console.WriteLine("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            // Cadastro do ano da série
            Console.WriteLine("Digite o ano de inicio da serie:");
            int entradaAno = 0;
            while (int.TryParse(Console.ReadLine(), out entradaAno) != true)
            {
                { Console.WriteLine("Digite apenas numeros!\n"); }
            }

            //Cadastro da descrição da serie
            Console.WriteLine("Digite a descrição da serie\n");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
                                        );
            repositorio.Insere(novaSerie);


        }
        private static void AtualizarSerie()
        {

            Console.WriteLine("Digite o id da série");
            
            int indiceSerie = 0;
            while (int.TryParse(Console.ReadLine(), out indiceSerie) != true)
            {
                { Console.WriteLine("Digite apenas numeros!\n"); }
            }

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite numero do gênero entre as opções acima : ");
            int entradaGenero = 0;
            while (int.TryParse(Console.ReadLine(), out entradaGenero) != true)
            {
                { Console.WriteLine("Digite apenas numeros!\n"); }
            }
            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Digite o ano de inicio da serie:");
            int entradaAno = 0;
            while (int.TryParse(Console.ReadLine(), out entradaAno) != true)
            {
                { Console.WriteLine("Digite apenas numeros!\n"); }
            }
            Console.WriteLine("Digite a descrição da serie\n");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            ano: entradaAno
                                            );

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série");
            int indiceSerie;
            while (int.TryParse(Console.ReadLine(), out indiceSerie) != true)
            {
                { Console.WriteLine("Digite apenas numeros!\n"); }
            }

            
            object serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);



        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série");
            int indiceSerie;
            while (int.TryParse(Console.ReadLine(), out indiceSerie) != true)
            {
                { Console.WriteLine("Digite apenas numeros!\n"); }
            }
            repositorio.Exclui(indiceSerie);

        }

        private static string ObterOpcao()
        {
            Console.WriteLine("\n Bem vindo ao nosso mini sistema de series, no que posso ajudar\n");
            Console.WriteLine("Informe a opção desejada\n");
            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir nova serie");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Vizualizar séries");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair \n");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}

