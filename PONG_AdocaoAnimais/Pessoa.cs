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
            endereco.CadastrarEndereco(sqlConnection);

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Pessoa(Nome, CPF, Sexo, Data_Nascimento, Telefone, Cod_Endereco) VALUES(@Nome, @CPF, @Sexo, @Data_Nascimento,@Telefone, @Cod_Endereco);";
            cmd.Parameters.AddWithValue("@Nome", System.Data.SqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.VarChar).Value = Cpf;
            cmd.Parameters.AddWithValue("@Sexo", System.Data.SqlDbType.VarChar).Value = Sexo;
            cmd.Parameters.AddWithValue("@Data_Nascimento", System.Data.SqlDbType.DateTime).Value = DataNascimento;
            cmd.Parameters.AddWithValue("@Telefone", System.Data.SqlDbType.VarChar).Value = DataNascimento;
            cmd.Parameters.AddWithValue("@Cod_Endereco", System.Data.SqlDbType.Int).Value = 3;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();
        }

    }
}
