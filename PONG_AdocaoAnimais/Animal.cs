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

        public Familia familia { get; set; }
        public Familia Cod_Familia { get; set; }

        public Animal()
        {

        }


        public void CadastrarAnimal(SqlConnection sqlConnection)
        {
            this.familia= new Familia(); 

            Console.WriteLine("Numero do Chip: ");
            this.Chip = int.Parse(Console.ReadLine());
            Console.WriteLine("Raça: ");
            this.Raca = Console.ReadLine();
            Console.WriteLine("Sexo(M/F): ");
            this.Sexo = char.Parse(Console.ReadLine());
            while (this.Sexo != 'M' && this.Sexo!= 'F')
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

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Animal(CHIP, Raca, Sexo, Nome, Cod_Familia) VALUES (@CHIP, @Raca, @Sexo, @Nome, @Cod_Familia);";
            cmd.Parameters.AddWithValue("@CHIP", System.Data.SqlDbType.Int).Value = Chip;
            cmd.Parameters.AddWithValue("@Raca", System.Data.SqlDbType.VarChar).Value = Raca;
            cmd.Parameters.AddWithValue("@Sexo", System.Data.SqlDbType.Char).Value = Sexo;
            cmd.Parameters.AddWithValue("@Nome", System.Data.SqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("@Cod_Familia", System.Data.SqlDbType.Int).Value = 1;

            cmd.Connection = sqlConnection;
            cmd.ExecuteNonQuery();

        }

        public void EditarCadastroAnimal()
        {

        }



    }
}
