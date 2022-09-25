using System;
using System.Data.SqlClient;

namespace PONG_AdocaoAnimais
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Conexao conexao = new Conexao();

            SqlConnection sqlConnection = conexao.ConectarBanco();

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
                int opcPessoa;

                do
                {
                    Console.WriteLine("\nMenu Pessoa\n");
                    Console.WriteLine("Digite a opção desejada:\n1-Cadastrar\n2-Editar cadastro existente\n3-Consultar Cadastro" +
                        "\n4-Menu Inicial\n5-Menu Animal");
                    opcPessoa = int.Parse(Console.ReadLine());

                    switch (opcPessoa)
                    {
                        case 1:
                            pessoa.CadastrarPessoa(sqlConnection);
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

                int opcAnimal;

                do
                {
                    Console.WriteLine("Menu Animal\n");
                    Console.WriteLine("Digite a opção desejada:\n1-Cadastrar\n2-Editar cadastro existente\n3-Consultar Cadastro" +
                        "\n4-Efetuar Adoções\n5-Menu Inicial\n6-Menu Pessoa");
                    opcAnimal = int.Parse(Console.ReadLine());

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



