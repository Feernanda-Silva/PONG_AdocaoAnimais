using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONG_AdocaoAnimais
{
    internal class Endereco
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int Cod_Endereco { get; set; }
       

        public Endereco()
        {

        }

        public Endereco(string logradouro, string bairro, int numero, string complemento, int cep, string cidade, string uf, int cod_Endereco)
        {
            this.Logradouro = logradouro;
            this. Bairro = bairro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Cep = cep;
            this.Cidade = cidade;
            this.Uf = uf;
            this.Cod_Endereco = cod_Endereco;
            
        }   

        public int CadastrarEndereco(SqlConnection sqlConnection)
        {
            Console.WriteLine("Logradouro: ");
            this.Logradouro = Console.ReadLine();
            Console.WriteLine("Bairro: ");
            this.Bairro = Console.ReadLine();
            Console.WriteLine("Número: ");
            this.Numero = int.Parse(Console.ReadLine());
            Console.WriteLine("Complemento:");
            this.Complemento = Console.ReadLine();
            Console.WriteLine("CEP: ");
            this.Cep = int.Parse(Console.ReadLine());
            Console.WriteLine("Cidade: ");
            this.Cidade = Console.ReadLine();
            Console.WriteLine("UF: ");
            this.Uf =(Console.ReadLine());

            SqlCommand cmd = new SqlCommand(); 

            cmd.CommandText = "INSERT INTO Endereco(Logradouro, Bairro, Numero, Complemento, CEP, Cidade, UF) OUTPUT INSERTED.Cod_Endereco VALUES (@Logradouro, @Bairro, @Numero, @Complemento, @CEP, @Cidade, @UF);";

            cmd.Parameters.AddWithValue("@Logradouro", System.Data.SqlDbType.VarChar).Value = Logradouro;
            cmd.Parameters.AddWithValue("@Bairro", System.Data.SqlDbType.VarChar).Value = Bairro;
            cmd.Parameters.AddWithValue("@Numero", System.Data.SqlDbType.Int).Value = Numero;
            cmd.Parameters.AddWithValue("@Complemento", System.Data.SqlDbType.VarChar).Value = Complemento;
            cmd.Parameters.AddWithValue("@CEP", System.Data.SqlDbType.Int).Value = Cep;
            cmd.Parameters.AddWithValue("@Cidade", System.Data.SqlDbType.VarChar).Value = Cep;
            cmd.Parameters.AddWithValue("@UF", System.Data.SqlDbType.Char).Value = Uf;

            cmd.Connection = sqlConnection;
            int codigoEndereco = (int)cmd.ExecuteScalar();
            return codigoEndereco;
        }

        public void EditarEndereco()
        {

        }
    }
}
