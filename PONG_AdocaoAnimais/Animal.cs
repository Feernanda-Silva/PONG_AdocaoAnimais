using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONG_AdocaoAnimais
{
    internal class Animal
    {

        public int Chip { get; set; }
        public string Raca { get; set; }
        public char Sexo { get; set; }
        public string Nome { get; set; }
        public Pessoa Cpf { get; set; }
        public int Cod_Familia { get; set; }

        public Animal()
        {

        }


        public void CadastrarAnimal(SqlConnection sqlConnection)
        {
          

            Console.WriteLine("Numero do Chip: ");
            this.Chip = int.Parse(Console.ReadLine());
             //Tratamento: SELECT para ver se já existe o chip

            Console.WriteLine("Raça: ");
            this.Raca = Console.ReadLine();

            Console.WriteLine("Sexo(M/F): ");
            this.Sexo = char.Parse(Console.ReadLine());
            while (this.Sexo != 'M' && this.Sexo != 'F')
            {
                Console.WriteLine("Campo inválido");
                Console.WriteLine("Digite novamente!");
                this.Sexo = char.Parse(Console.ReadLine());
            }

            Console.WriteLine("O animal já possui um nome? Digite : 1-Sim ou 2-Não: ");
            int opc = int.Parse(Console.ReadLine());
            while (opc != 1 && opc != 2)
            {
                Console.WriteLine("Opção inválida");
                Console.WriteLine("Digite novamente!");
                opc = int.Parse(Console.ReadLine());
            }

            if (opc == 1)
            {
                Console.WriteLine("Nome: ");
                this.Nome = Console.ReadLine();
            }

            else
            {
                this.Nome = "Sem Nome";
            }

            Console.WriteLine("Código Familia: ");
            this.Cod_Familia = int.Parse(Console.ReadLine());

            //Inserindo o animal na tabela Animal
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Animal(CHIP, Raca, Sexo, Nome, Cod_Familia) VALUES (@CHIP, @Raca, @Sexo, @Nome, @Cod_Familia);";
            cmd.Parameters.AddWithValue("@CHIP", System.Data.SqlDbType.Int).Value = Chip;
            cmd.Parameters.AddWithValue("@Raca", System.Data.SqlDbType.VarChar).Value = Raca;
            cmd.Parameters.AddWithValue("@Sexo", System.Data.SqlDbType.Char).Value = Sexo;
            cmd.Parameters.AddWithValue("@Nome", System.Data.SqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("@Cod_Familia", System.Data.SqlDbType.Int).Value = Cod_Familia;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

        }

        public void ConsultarAnimal(SqlConnection sqlConnection)
        {
            Console.WriteLine("\nDigite o código do chip para localizar o animal: ");
            int chip = int.Parse(Console.ReadLine());
            //Tratamento se existe o chip

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Animal.CHIP, Animal.Raca, Animal.Sexo, Animal.Nome, Animal.CPF, Familia.Cod_Familia, Familia.Tipo FROM Animal, Familia WHERE Animal.CHIP = @CHIP;";
            cmd.Parameters.AddWithValue("@CHIP", System.Data.SqlDbType.VarChar).Value = chip;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("\nChip: {0}", reader.GetInt32(0));
                    Console.WriteLine("Raça: {0}", reader.GetString(1));
                    Console.WriteLine("Sexo: {0}", reader.GetString(2));
                    Console.WriteLine("Nome do animal: {0}", reader.GetString(3));
                    if (reader.IsDBNull(4))
                    {
                        Console.WriteLine("Cpf: Não possui tutor");
                    }

                    else
                    {
                        Console.WriteLine("Cpf do tutor: {0}", reader?.GetString(4));
                    }

                    Console.WriteLine("Cod_Familia: {0}", reader.GetInt32(5));
                    Console.WriteLine("Tipo de familia: {0}", reader.GetString(6));
                }

            }
        }

        public void EditarAnimal(SqlConnection sqlConnection)
        {
            SqlCommand cmd = new SqlCommand();

            Console.WriteLine("\nDigite o código do CHIP para localizar o animal: ");
            int chip = int.Parse(Console.ReadLine());

            //Fazer um SELECT para ver se existe o animal no cadastro

            Console.WriteLine("\nDigite o número do campo que deseja editar: ");
            Console.WriteLine("1-Raça: ");
            Console.WriteLine("2-Sexo: ");
            Console.WriteLine("3- Nome do Animal: ");
            Console.WriteLine("4-Código Familia: ");
            int opc = int.Parse(Console.ReadLine());

            //Tratamento opção invalida 

            switch (opc)
            {
                case 1:
                    EditarRaca();
                    break;
                case 2:
                    EditarSexo();
                    break;
                case 3:
                    EditarNomeAnimal();
                    break;
                case 4:
                    EditarCod_Familia();
                    break;
            }

            void EditarRaca()
            {
                Console.WriteLine("Raça: ");
                string raca = Console.ReadLine();
                cmd.CommandText = "UPDATE Animal SET Raca = @Raca WHERE Animal.CHIP = @CHIP;";
                cmd.Parameters.AddWithValue("@CHIP", System.Data.SqlDbType.VarChar).Value = chip;
                cmd.Parameters.AddWithValue("@Raca", System.Data.SqlDbType.VarChar).Value = raca;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

            }

            void EditarSexo()
            {
                Console.WriteLine("Sexo: ");
                string sexo = Console.ReadLine();

                cmd.CommandText = "UPDATE Animal SET Sexo = @Sexo WHERE Animal.CHIP = @CHIP;";
                cmd.Parameters.AddWithValue("@CHIP", System.Data.SqlDbType.VarChar).Value = chip;
                cmd.Parameters.AddWithValue("@Sexo", System.Data.SqlDbType.VarChar).Value = sexo;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarNomeAnimal()
            {
                Console.WriteLine("Nome do Animal: ");
                string nome = Console.ReadLine();

                cmd.CommandText = "UPDATE Animal SET Nome = @Nome WHERE Animal.CHIP = @CHIP;";
                cmd.Parameters.AddWithValue("@CHIP", System.Data.SqlDbType.VarChar).Value = chip;
                cmd.Parameters.AddWithValue("@Nome", System.Data.SqlDbType.VarChar).Value = nome;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }

            void EditarCod_Familia()
            {
                Console.WriteLine("Código Familia: ");
                string codigoFamilia = Console.ReadLine();

                //Tratamento se existe o código da familia 

                cmd.CommandText = "UPDATE Animal SET Cod_Familia = @Cod_Familia WHERE Animal.CHIP = @CHIP;";
                cmd.Parameters.AddWithValue("@CHIP", System.Data.SqlDbType.VarChar).Value = chip;
                cmd.Parameters.AddWithValue("@Cod_Familia", System.Data.SqlDbType.VarChar).Value = codigoFamilia;

                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();

            }

        }

        public void AdotarAnimal(SqlConnection sqlConnection)
        {
            Console.WriteLine("Digite o CPF do futuro Tutor: ");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite o CHIP do Animal: ");
            int chip = int.Parse(Console.ReadLine());

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Animal SET CPF = @CPF WHERE Animal.CHIP = @CHIP;";
            cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
            cmd.Parameters.AddWithValue("@CHIP", System.Data.SqlDbType.Int).Value = chip;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();
            Console.WriteLine("\nAdoção efetuada com sucesso!");
        }

        public void ConsultarAdocao(SqlConnection sqlConnection)
        {
            Console.WriteLine("Digite o CPF do Tutor: ");
            string cpf = Console.ReadLine();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT Pessoa.Nome, Pessoa.CPF, Animal.CHIP, Animal.Raca, Animal.Sexo, Animal.Nome, Animal.Cod_Familia, Familia.Tipo " +
                "FROM Pessoa, Animal, Familia " +
                "WHERE Pessoa.CPF = Animal.CPF " +
                "AND Familia.Cod_Familia = Animal.Cod_Familia " +
                "AND Pessoa.CPF = @CPF;";

            cmd.Parameters.AddWithValue("@CPF", System.Data.SqlDbType.Char).Value = cpf;
            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("Nome do adotante: {0}", reader.GetString(0));
                    Console.WriteLine("CPF do adotante: {0}", reader.GetString(1));
                    Console.WriteLine("CHIP: {0}", reader.GetInt32(2));
                    Console.WriteLine("Raça: {0}", reader.GetString(3));
                    Console.WriteLine("Sexo: {0}", reader.GetString(4));
                    Console.WriteLine("Nome Animal: {0}", reader.GetString(5));
                    Console.WriteLine("Código da Família: {0}", reader.GetInt32(6));
                    Console.WriteLine("Tipo do Animal: {0}\n", reader.GetString(7));
                }
            }

        }
    }
}
