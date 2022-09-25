using System;
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


        }
    }
}
