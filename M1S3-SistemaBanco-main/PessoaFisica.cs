using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1S3_SistemaBanco
{
    public class PessoaFisica : Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get { return (int)(Math.Floor((DateTime.Now - DataNascimento).TotalDays / 365.25)); } private set { } }

        public PessoaFisica()
        {
        }
        public PessoaFisica(string nome, string cpf, string email, string telefone,
                       string endereco, DateTime dtNascimento, int numeroConta) : base(email,telefone,endereco,numeroConta)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dtNascimento;

        }
        public bool EhMaior()
        {
            return Idade >= 18;
        }
        public override string ResumoCliente()
        {
            return $"{base.ResumoCliente()} | {Nome} | {CPF}";
        }
    }

}
