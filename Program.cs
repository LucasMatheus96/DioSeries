using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
           while (opcaoUsuario.ToUpper() != "X"){
               
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
                   // VisualizarSerie();
                   break;
                   
                   case "C":
                    Console.Clear();
                   break;

                   default:
                   throw new ArgumentOutOfRangeException();
                                  }
                           
           }
           opcaoUsuario= ObterOpcaoUsuario();
        }

		private static  void AtualizarSerie(){
			System.Console.WriteLine("Atualizando sua serie: ");
			ListarSeries();
			System.Console.WriteLine();
			System.Console.WriteLine("informe o id da serie que deseja atualizar");
			int indice = int.Parse(Console.ReadLine());
			foreach(int i in Enum.GetValues(typeof(Genero))){
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}

			 System.Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();
            System.Console.WriteLine("Digite o ano do inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();
            
			Serie atualizaEntidade = new Serie(id: indice,
			genero:(Genero)entradaGenero,
			titulo:entradaTitulo,
			descricao:entradaDescricao,
			ano: entradaAno);

			repositorio.Atualiza(indice,atualizaEntidade);
		
		}
		private static void ExcluirSerie(){
			Console.WriteLine("Excluir Series:");

			ListarSeries();

			Console.WriteLine("Informe o numero da serie que deseja excluir");
			int indice = int.Parse(Console.ReadLine());
			foreach (var lista in repositorio.Lista()){
						if(lista.Id == indice){
							lista.Excluir();
						}

							}
			

		}
        private static void ListarSeries(){
            Console.WriteLine("Listar Series: ");

            var lista = repositorio.Lista();

            if (lista.Count ==  0 ){
                Console.WriteLine("Nenhuma serie cadastrada!");
                return  ;
            }

            foreach(var serie in lista) {
               
            }
        }

         private static void InserirSerie(){
            Console.WriteLine("Inserir nova Serie: ");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();
            System.Console.WriteLine("Digite o ano do inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();
            
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano:entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
            }
        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            System.Console.WriteLine("DIO SERIES A SEU DISPOR!!!");
            System.Console.WriteLine("Informe a opção desejada: ");
            System.Console.WriteLine("1 - Listar Series");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("C - limpar Tela");
            System.Console.WriteLine("X - sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();


            return opcaoUsuario;
        }
    }
}
