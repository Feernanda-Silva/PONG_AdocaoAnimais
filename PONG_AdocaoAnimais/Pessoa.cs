using System;
using System.Collections.Generic;
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

        public Pessoa(string nome, string cpf, char sexo, DateTime dataNascimento, string telefone)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Sexo = sexo;
            this.DataNascimento = dataNascimento;
            this.Telefone = telefone;
        }

        public void CadastrarPessoa()
        {

        }

    }
}
