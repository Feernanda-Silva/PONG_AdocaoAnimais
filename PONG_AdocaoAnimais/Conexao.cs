using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONG_AdocaoAnimais
{
    internal class Conexao
    {
        string conexaosql = "Data Source=localhost;Initial Catalog=ONG;User Id=sa;Password=fernanda123;";

        public SqlConnection ConectarBanco()
        {
            SqlConnection conexao = new SqlConnection(this.conexaosql);
            conexao.Open();
            return conexao;
        }
    }
}
