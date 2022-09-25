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
                        case 3: pessoa.ConsultarPessoa(sqlConnection);
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
                Animal animal = new Animal();
                Familia familia = new Familia();
                int opcAnimal;

                do
                {
                    Console.WriteLine("\nMenu Animal\n");
                    Console.WriteLine("Digite a opção desejada:\n1-Cadastrar Animal\n2-Editar Animal\n3-Consultar Animal" +
                        "\n4-Cadastrar Familia\n5-Consultar Familias Existentes\n6-Adoção\n7-Menu Inicial\n8-Menu Pessoa");
                    opcAnimal = int.Parse(Console.ReadLine());

                    switch (opcAnimal)
                    {
                        case 1: animal.CadastrarAnimal(sqlConnection);
                            break;
                        case 2: animal.EditarAnimal(sqlConnection);
                            break;
                        case 3: animal.ConsultarAnimal(sqlConnection); 
                            break;
                        case 4:familia.CadastrarFamilia(sqlConnection);
                            break;
                        case 5:
                            familia.ConsultarFamilia(sqlConnection);
                            break;
                        case 6: //EfetuarAdocao(); 
                            break;
                        case 7:
                            MenuInicial();
                            break;
                        case 8:
                            MenuPessoa();
                            break;
                       
                    }
                } while (opcAnimal > 0 && opcAnimal < 9);
            }
        }
    }
}



