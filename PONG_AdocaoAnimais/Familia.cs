using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONG_AdocaoAnimais
{
    internal class Familia
    {
        public int Cod_Familia { get; set; }
        public string Tipo { get; set; }


        public Familia()
        {

        }

        public void CadastrarFamilia(SqlConnection sqlConnection)
        {
            Console.WriteLine("Tipo: ");
            this.Tipo = Console.ReadLine();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Familia(Tipo) OUTPUT INSERTED.Cod_Familia VALUES (@Tipo);";

            cmd.Parameters.AddWithValue("@Tipo", System.Data.SqlDbType.VarChar).Value = Tipo;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

        }

        public void ConsultarFamilia(SqlConnection sqlConnection)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Familia.Cod_Familia, Familia.Tipo FROM Familia";
            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();


            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Código: {0}", reader.GetInt32(0));
                    Console.WriteLine("Tipo: {0}\n", reader.GetString(1));
                }
            }
        }
    }
}
