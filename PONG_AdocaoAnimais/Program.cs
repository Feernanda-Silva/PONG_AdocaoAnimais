using System;

namespace PONG_AdocaoAnimais
{
    internal class Program
    {
        static void Main(string[] args)

        {   Conexao conexao = new Conexao();
            conexao.ConectarBanco(); 

            MenuInicial();

            void MenuInicial()
            {
                Console.WriteLine("Menu Inicial\n");
                Console.WriteLine("Digite a opção desejada:\n1-Menu Pessoa\n2-Menu Animal");
                int opcInicial = int.Parse(Console.ReadLine());

                while (opcInicial != 1 && opcInicial != 2)
                {
                    Console.WriteLine("Digite uma opção válida!");
                    opcInicial = int.Parse(Console.ReadLine());
                }

                if (opcInicial == 1)
                {
                    MenuPessoa();
                }

                else
                {
                    MenuAnimal();
                }
            }

            void MenuPessoa()
            {
                Pessoa pessoa = new Pessoa();
                Console.WriteLine("Menu Pessoa\n");
                Console.WriteLine("Digite a opção desejada:\n1-Cadastrar\n2-Editar cadastro existente\n3-Consultar Cadastro" +
                    "\n4-Menu Inicial\n5-Menu Animal");
                int opcPessoa = int.Parse(Console.ReadLine());


                do
                {
                    switch (opcPessoa)
                    {
                        case 1: pessoa.CadastrarPessoa();
                            break;
                        case 2: //Editar()
                            break;
                        case 3: //Consultar
                            break;
                        case 4:
                            MenuInicial();
                            break;
                        case 5:
                            MenuAnimal();
                            break;
                    }
                } while (opcPessoa > 0 && opcPessoa < 5);
            }

            void MenuAnimal()
            {
                Console.WriteLine("Menu Animal\n");
                Console.WriteLine("Digite a opção desejada:\n1-Cadastrar\n2-Editar cadastro existente\n3-Consultar Cadastro" +
                    "\n4-Efetuar Adoções\n5-Menu Inicial\n6-Menu Pessoa");
                int opcAnimal = int.Parse(Console.ReadLine());

                do
                {

                    switch (opcAnimal)
                    {
                        case 1: //CadastrarAnimal();
                            break;
                        case 2: //EditarAnimal();
                            break;
                        case 3: //ConsultarAnimal(); 
                            break;
                        case 4: //EfetuarAdoção(); 
                            break;
                        case 5:
                            MenuInicial();
                            break;
                        case 6:
                            MenuPessoa();
                            break;
                    }
                } while (opcAnimal > 0 && opcAnimal < 6);
            }
        }
    }
}



