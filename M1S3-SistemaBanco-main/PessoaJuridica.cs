using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1S3_SistemaBanco
{
    public class PessoaJuridica : Cliente
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }


        public PessoaJuridica()
        {
        }
        public PessoaJuridica(string razaoSocial, string cnpj, string email, string telefone,
                       string end, int numeroConta) : base(email, telefone, end, numeroConta)
        {
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;

        }
        public override string ResumoCliente()
        {
            return $"{base.ResumoCliente()} | {RazaoSocial} | {Cnpj}";
        }
    }

}
