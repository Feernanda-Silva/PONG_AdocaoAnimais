using System;
using System.Collections.Generic;
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
        public Familia Cod_Familia { get; set; }

        public Animal()
        {

        }

        public Animal(int chip, string raca, char sexo, string nome, Pessoa cpf, Familia cod_Familia)
        {
            this.Chip = chip;
            this.Raca = raca;
            this.Sexo = sexo;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Cod_Familia = cod_Familia;
        }

        public void CadastrarAnimal()
        {
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
                Console.WriteLine("Nome: ");
                this.Nome = Console.ReadLine();
            }

        }
    }
}
