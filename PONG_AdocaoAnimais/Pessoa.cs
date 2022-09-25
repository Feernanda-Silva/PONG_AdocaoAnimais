﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONG_AdocaoAnimais
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Endereco endereco { get; set; }
        public Endereco cod_Endereco { get; set; }

        public Pessoa()
        {

        }

        public void CadastrarPessoa(SqlConnection sqlConnection)
        {
            this.endereco = new Endereco();

            Console.WriteLine("Nome: ");
            this.Nome = Console.ReadLine();

            Console.WriteLine("Cpf: ");
            this.Cpf = Console.ReadLine();
            //Tratamento: SELECT para ver se existe um cadastro com esse CPF.

            Console.WriteLine("Sexo(M/F): ");
            this.Sexo = char.Parse(Console.ReadLine());

            Console.WriteLine("Data de Nascimento: ");
            this.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Telefone: ");
            this.Telefone = Console.ReadLine();

            int codigo_endereco = endereco.CadastrarEndereco(sqlConnection);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Pessoa(Nome, CPF, Sexo, Data_Nascimento, Telefone, Cod_Endereco) VALUES(@Nome, @CPF, @Sexo, @Data_Nascimento,@Telefone, @Cod_Endereco);";
            cmd.Parameters.AddWithValue("@Nome", System.Data.SqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.VarChar).Value = Cpf;
            cmd.Parameters.AddWithValue("@Sexo", System.Data.SqlDbType.VarChar).Value = Sexo;
            cmd.Parameters.AddWithValue("@Data_Nascimento", System.Data.SqlDbType.DateTime).Value = DataNascimento;
            cmd.Parameters.AddWithValue("@Telefone", System.Data.SqlDbType.VarChar).Value = Telefone;
            cmd.Parameters.AddWithValue("@Cod_Endereco", System.Data.SqlDbType.Int).Value = codigo_endereco;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();
        }

        public void ConsultarPessoa(SqlConnection sqlConnection)
        {
            Console.WriteLine("\nDigite o CPF: ");
            string Cpf = Console.ReadLine();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Pessoa.Nome, Pessoa.CPF, Pessoa.Sexo, Pessoa.Data_Nascimento, Pessoa.Telefone, Endereco.Logradouro," +
                "Endereco.Bairro, Endereco.Numero, Endereco.Complemento, Endereco.CEP, Endereco.Cidade, Endereco.UF FROM Pessoa, Endereco " +
                "WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF = @CPF";

            cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.VarChar).Value = Cpf;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Nome: {0}", reader.GetString(0));
                    Console.WriteLine("CPF: {0}", reader.GetString(1));
                    Console.WriteLine("Sexo: {0}", reader.GetString(2));
                    Console.WriteLine("Data Nascimento: {0}", reader.GetDateTime(3));
                    Console.WriteLine("Telefone: {0}", reader.GetString(4));
                    Console.WriteLine("Logradouro: {0}", reader.GetString(5));
                    Console.WriteLine("Bairro: {0}", reader.GetString(6));
                    Console.WriteLine("Numero: {0}", reader.GetInt32(7));
                    Console.WriteLine("Complemento: {0}", reader.GetString(8));
                    Console.WriteLine("CEP: {0}", reader.GetInt32(9));
                    Console.WriteLine("Cidade: {0}", reader.GetString(10));
                    Console.WriteLine("UF: {0}", reader.GetString(11));

                }
            }
        }
        public void EditarPessoa(SqlConnection sqlConnection)
        {
            
            Console.WriteLine("\nDigite o CPF para localizar o Cadastro : ");
            string cpf = Console.ReadLine();
            int opc;

            // Fazer um SELECT para ver se existe o cadastro 
            do
            { 

                Console.WriteLine("\nDigite o número do campo que deseja editar: ");
                Console.WriteLine("1-Nome: ");
                Console.WriteLine("2-Sexo: ");
                Console.WriteLine("3-Data Nascimento: ");
                Console.WriteLine("4-Telefone:  ");
                Console.WriteLine("5-Logradouro:  ");
                Console.WriteLine("6-Bairro:  ");
                Console.WriteLine("7-Numero:  ");
                Console.WriteLine("8-Complemento: ");
                Console.WriteLine("9-CEP:  ");
                Console.WriteLine("10-Cidade:  ");
                Console.WriteLine("11-UF:  ");
                Console.WriteLine("12-Voltar");
                opc = int.Parse(Console.ReadLine());

                //Tratamento opção invalida 

                switch (opc)
                {
                    case 1:
                        EditarNome();
                        break;
                    case 2:
                        EditarSexo();
                        break;
                    case 3:
                        EditarDataNascimento();
                        break;
                    case 4:
                        EditarTelefone();
                        break;
                    case 5:
                        EditarLogradouro();
                        break;
                    case 6:
                        EditarBairro();
                        break;
                    case 7:
                        EditarNumero();
                        break;
                    case 8:
                        EditarComplemento();
                        break;
                    case 9:
                        EditarCep();
                        break;
                    case 10:
                        EditarCidade();
                        break;
                    case 11:
                        EditarUf();
                        break;
                }
            } while (opc > 0 && opc < 12);




            void EditarNome()
            {
                Console.WriteLine("Nome: ");
                string nome = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Pessoa SET Nome = @Nome WHERE Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@Nome", System.Data.SqlDbType.VarChar).Value = nome;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

            }

            void EditarSexo()
            {
                Console.WriteLine("Sexo: ");
                char sexo = char.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Pessoa SET Sexo = @Sexo WHERE Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@Sexo", System.Data.SqlDbType.Char).Value = sexo;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarDataNascimento()
            {
                Console.WriteLine("Data Nascimento: ");
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Pessoa SET Data_Nascimento = @Data_Nascimento WHERE Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@Data_Nascimento", System.Data.SqlDbType.Char).Value = dataNascimento;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarTelefone()
            {
                Console.WriteLine("Telefone: ");
                string telefone = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Pessoa SET Telefone = @Telefone WHERE Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@Telefone", System.Data.SqlDbType.Char).Value = telefone;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarLogradouro()
            {
                Console.WriteLine("Logradouro: ");
                string logradouro = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Endereco SET Logradouro = @Logradouro FROM Pessoa WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@Logradouro", System.Data.SqlDbType.VarChar).Value = logradouro;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarBairro()
            {
                Console.WriteLine("Bairro: ");
                string bairro = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Endereco SET Bairro= @Bairro FROM Pessoa WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@Bairro", System.Data.SqlDbType.VarChar).Value = bairro;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarNumero()
            {
                Console.WriteLine("Numero: ");
                int numero = int.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Endereco SET Numero= @Numero FROM Pessoa WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@Numero", System.Data.SqlDbType.Int).Value = numero;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarComplemento()
            {
                Console.WriteLine("Complemento: ");
                string complemento = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Endereco SET Complemento= @Complemento FROM Pessoa WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@Complemento", System.Data.SqlDbType.VarChar).Value = complemento;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarCep()
            {
                Console.WriteLine("CEP: ");
                int cep = int.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Endereco SET CEP= @CEP FROM Pessoa WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@CEP", System.Data.SqlDbType.VarChar).Value = cep;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarCidade()
            {
                Console.WriteLine("Cidade: ");
                string cidade = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Endereco SET Cidade= @Cidade FROM Pessoa WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@Cidade", System.Data.SqlDbType.VarChar).Value = cidade;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarUf()
            {
                Console.WriteLine("Cidade: ");
                string uf = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Endereco SET UF= @UF FROM Pessoa WHERE Pessoa.Cod_Endereco = Endereco.Cod_Endereco AND Pessoa.CPF = @CPF;";
                cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
                cmd.Parameters.AddWithValue("@UF", System.Data.SqlDbType.VarChar).Value = uf;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
