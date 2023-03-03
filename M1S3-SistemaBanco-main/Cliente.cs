
namespace M1S3_SistemaBanco
{
    public abstract class Cliente
    { 
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo {  get {return GetSaldo(); }  private set{} }

        
        
        public List<Transacao> Extrato { get; set; }

        public Cliente(string email,string telefone, string endereco, int numeroConta)
        {
            Email = email;
            Telefone= telefone;
            Endereco = endereco;
            NumeroConta = numeroConta;
            Extrato = new List<Transacao>();
        }
        


        public string ResumoCliente(){
           return  $"{NumeroConta} |  {Nome}  | {CPF}";
        }

        public bool EhMaior(){
            return Idade >= 18;
        }

        private double GetSaldo(){
            double saldo = 0;
            foreach(Transacao transacao  in Extrato){
                saldo += transacao.Valor;
            }
            return saldo;
        }
    }
}