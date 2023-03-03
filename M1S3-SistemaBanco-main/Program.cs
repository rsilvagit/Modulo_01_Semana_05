
using System.Globalization;
using M1S3_SistemaBanco;

List<Cliente> clientes = new List<Cliente>();

clientes.Add(new PessoaFisica("Vitor", "123456", "vitor@email", "123", "rua",
            new DateTime(2002, 5, 15), 1));

clientes.Add(new PessoaFisica("Fernando", "123456", "Fernando@email", "123", "rua",
            new DateTime(2002, 5, 15), 2));

clientes.Add(new PessoaFisica("Vanessa", "123456", "Vanessa@email", "123", "rua",
            new DateTime(2002, 5, 15), 3));

clientes.Add(new PessoaFisica("Lucas", "123456", "Lucas@email", "123", "rua",
            new DateTime(2002, 5, 15), 4));



string opcao;
do
{
    Console.WriteLine("Bem vindos ao Banco FULL STACK BANCK, escolha uma opção");
    Console.WriteLine("1 - Criar Conta ");
    Console.WriteLine("2 - Adicionar Transacao");
    Console.WriteLine("3 - Consultar Extrato");
    Console.WriteLine("4 - Sair");
    Console.WriteLine("5 - Exibir Clientes");
    opcao = Console.ReadLine();

    if (opcao == "1")
    {
        Console.WriteLine("Qual conta você deseja criar.");
        Console.WriteLine("1 - Criar Conta Pessoa Fisica.");
        Console.WriteLine("2 - Criar Conta Pessoa Juridica.");
        Console.WriteLine("3 - Sair");
        string tipoConta = Console.ReadLine();
        CriarConta(tipoConta);
    }
    else if (opcao == "5")
    {
        ExibirClientes();
    }
    else if (opcao == "2")
    {
        AdicionarTransacao();
    }
    else if (opcao == "3")
    {
        ExibirExtrato();
    }

    Console.WriteLine("Tecle Enter para continuar");
    Console.ReadLine();
} while (opcao != "4");




void AdicionarTransacao()
{
    Console.WriteLine("Qual a conta?");
    int numeroConta = int.Parse(Console.ReadLine());

    Cliente contaCliente = BuscarClientePorNumeroDeConta(numeroConta);

    if (contaCliente == null)
    {
        Console.WriteLine("Conta não cadastrada, favor cadastrar antes");
        return;
    }

    Console.WriteLine("Qual o valor da transação?");
    double valor = double.Parse(Console.ReadLine());
    Transacao transacao = new Transacao(DateTime.Now, valor);

    contaCliente.Extrato.Add(transacao);

}

void ExibirExtrato()
{
    Console.WriteLine("Qual a conta?");
    int numeroConta = int.Parse(Console.ReadLine());

    Cliente contaCliente = BuscarClientePorNumeroDeConta(numeroConta);

    if (contaCliente == null)
    {
        Console.WriteLine("Conta não cadastrada, favor cadastrar antes");
        return;
    }
    double saldo = 0;
    foreach (Transacao transacao in contaCliente.Extrato)
    {
        Console.WriteLine(" Data: " + transacao.Data + " Valor: " + transacao.Valor.ToString("C2", new CultureInfo("pt-BR")));
        saldo += transacao.Valor;
        //Console.WriteLine($"Data: {transacao.Data} Valor: R$  {transacao.Valor}" );
    }

    Console.WriteLine("Saldo = " + contaCliente.Saldo);

}



Cliente BuscarClientePorNumeroDeConta(int numeroConta)
{
    ;
    foreach (Cliente cliente in clientes)
    {
        if (cliente.NumeroConta == numeroConta)
        {
            return cliente;
        }
    }
    // mesma coisa que o foreach
    // for(int i =0; i < clientes.Count; i++){
    //    if(clientes[i].NumeroConta == numeroConta);
    //     return clientes[i];
    // }
    return null;
}

void ExibirClientes()
{
    Console.WriteLine("Número da conta        | Nome         | CPF    ");
    for (int i = 0; i < clientes.Count; i++)
    {
        Console.WriteLine(clientes[i].ResumoCliente());
    }
}


void CriarConta(string tipoConta)
{ //Variavel indica tipo de conta
    if (tipoConta == "1")
    { //identificar tipo de conta
        PessoaFisica clientePf = new PessoaFisica();// instaciada classe Pessoa Fisica e criação de construtor vazio.
        Console.WriteLine("Data de Nascimento do cliente:");
        clientePf.DataNascimento = DateTime.Parse(Console.ReadLine());

        if (!clientePf.EhMaior())// verificação maioridade
        {
            Console.WriteLine("não é possivel abrir a conta pois o CLiente é menor de idade");
            return;
        }
        Console.WriteLine("A idade do cliente é " + clientePf.Idade);
        Console.WriteLine("Nome do cliente:");
        clientePf.Nome = Console.ReadLine();
        Console.WriteLine("CPF do cliente:");
        clientePf.CPF = Console.ReadLine();
        Console.WriteLine("Endereco do cliente:");
        clientePf.Endereco = Console.ReadLine();
        Console.WriteLine("Telefone do cliente:");
        clientePf.Telefone = Console.ReadLine();
        Console.WriteLine("Email do cliente:");
        clientePf.Email = Console.ReadLine();
        Console.WriteLine("Numero Da Conta");
        clientePf.NumeroConta = int.Parse(Console.ReadLine());
        clientes.Add(clientePf);
    }
    else if (tipoConta == "2")
    {
        PessoaJuridica clientePj = new PessoaJuridica();

       
        Console.WriteLine("Razão Social:");
        clientePj.RazaoSocial = Console.ReadLine();
        Console.WriteLine("CNPJ do cliente:");
        clientePj.Cnpj = Console.ReadLine();
        Console.WriteLine("Endereco do cliente:");
        clientePj.Endereco = Console.ReadLine();
        Console.WriteLine("Telefone do cliente:");
        clientePj.Telefone = Console.ReadLine();
        Console.WriteLine("Email do cliente:");
        clientePj.Email = Console.ReadLine();
        Console.WriteLine("Numero Da Conta");
        clientePj.NumeroConta = int.Parse(Console.ReadLine());
        clientes.Add(clientePj);

    }


}