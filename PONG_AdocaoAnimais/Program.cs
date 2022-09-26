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
            Animal animal = new Animal();
            Familia familia = new Familia();
            Pessoa pessoa = new Pessoa();   

            MenuInicial();

            void MenuInicial()
            {
                Console.WriteLine("\nMenu Inicial\n");
                Console.WriteLine("Digite a opção desejada:\n1-Menu Pessoa\n2-Menu Animal");
                int opcInicial = int.Parse(Console.ReadLine());

                while (opcInicial != 1 && opcInicial != 2)
                {
                    Console.WriteLine("\nDigite uma opção válida!");
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
                        case 2:
                            pessoa.EditarPessoa(sqlConnection);
                            break;
                        case 3:
                            pessoa.ConsultarPessoa(sqlConnection);
                            break;
                        case 4:
                            MenuInicial();
                            break;
                        case 5:
                            MenuAnimal();
                            break;
                    }
                } while (opcPessoa > 0 && opcPessoa < 6);
            }

            void MenuAnimal()
            {
                int opcAnimal;

                do
                {
                    Console.WriteLine("\nMenu Animal\n");
                    Console.WriteLine("Digite a opção desejada:\n1-Cadastrar Animal\n2-Editar Animal\n3-Consultar Animal" +
                        "\n4-Cadastrar Familia\n5-Consultar Familia\n6-Editar Familia\n7-Adoção\n8-Menu Inicial\n9-Menu Pessoa");
                    opcAnimal = int.Parse(Console.ReadLine());

                    switch (opcAnimal)
                    {
                        case 1:
                            animal.CadastrarAnimal(sqlConnection, familia);
                            break;
                        case 2:
                            animal.EditarAnimal(sqlConnection, familia);
                            break;
                        case 3:
                            animal.ConsultarAnimal(sqlConnection);
                            break;
                        case 4:
                            familia.CadastrarFamilia(sqlConnection);
                            break;
                        case 5:
                            familia.ConsultarFamilia(sqlConnection);
                            break;
                        case 6:
                            familia.EditarFamilia(sqlConnection);
                            break;
                        case 7:
                            Adocao();
                            break;
                        case 8:
                            MenuInicial();
                            break;
                        case 9:
                            MenuPessoa();
                            break;
                    }

                } while (opcAnimal > 0 && opcAnimal < 10);
            }

            void Adocao()
            {
               
                int opcAdocao;
                do
                {
                    Console.WriteLine("Menu Adocao\n");
                    Console.WriteLine("Digite a opção desejada:\n1-Efetuar Adoçao\n2-Consultar Adoçao\n3-Menu Inicial" +
                        "\n4-Menu Pessoa\n5-Menu Animal");
                    opcAdocao = int.Parse(Console.ReadLine());

                    switch (opcAdocao)
                    {
                        case 1:
                            animal.AdotarAnimal(sqlConnection, pessoa);
                            break;
                        case 2:
                            animal.ConsultarAdocao(sqlConnection, pessoa);
                            break;
                        case 3:
                            MenuInicial();
                            break;
                        case 4:
                            MenuPessoa();
                            break;
                        case 5:
                            MenuAnimal();
                            break;
                    }

                } while (opcAdocao > 0 && opcAdocao < 6);
            }
        }
    }
}