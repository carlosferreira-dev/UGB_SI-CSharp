using ControleContas;
using System.Text.RegularExpressions;

string nome_cliente2 = "Rosenclever";
string cpf_cliente2 = "11122233344";
int anonascimento_cliente2 = 1980;
Banco banco = new Banco();
Cliente cliente2 = new Cliente(nome_cliente2, cpf_cliente2,anonascimento_cliente2);
Conta conta2 = new Conta(654321, 2341.42m);
Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
Console.WriteLine("Digite seu Nome para abertura da conta: ");
string nome = Console.ReadLine();
Console.WriteLine("----------------------------------------------");
Console.WriteLine("Digite seu ano de nascimento: ");
int anonascimento = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("----------------------------------------------");
Cliente cliente1 = null;
Conta conta1 = null;
if ((DateTime.Now.Year - anonascimento) >= 18)
{
    Console.WriteLine("Digite seu CPF: ");
    string cpf = Console.ReadLine();
    string cpfapenasnumeros = Regex.Replace(cpf, "[^0-9]", "");
    if (cpfapenasnumeros.Length == 11)
    {
        cliente1 = new Cliente(nome, cpfapenasnumeros, anonascimento);
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Digite a sua conta: ");
        long numero_conta = Convert.ToInt64(Console.ReadLine());
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Informe o valor do depósito para ser o saldo inicial: ");
        decimal saldo = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); ;
        conta1 = new Conta(numero_conta, saldo);
        Console.WriteLine($"{nome} Seja bem vindo ao {banco.Nome}\nDados da sua conta: \nAgência: {banco.Agencia}\nConta: {conta1.Numero}\nSaldo: {conta1.Saldo}\nPara contato da agência:\nTelefone: {banco.Telefone}\nCaso queira nos visitar: \nCep: {banco.Cep}");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
    }
    else
    {
        Console.WriteLine($"Desculpe {nome}, cpf informado é inválido!");
    }
}
else
{
    Console.WriteLine($"Desculpe {nome}, Não é possível abrir uma conta para menores de 18 anos");
}
if ( cliente1 != null && conta1 != null)
{
    Console.WriteLine("Digite seu cpf para acessar a conta efetuar transações.");
    string cpf_digitado = Console.ReadLine();
    if (cpf_digitado == cliente2.Cpf)
    {
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine($"{cliente2.Nome} Seja bem vindo ao {banco.Nome}\nDados da sua conta: \nAgência: {banco.Agencia}\nConta: {conta2.Numero}\nSaldo: {conta2.Saldo}\nPara contato da agência:\nTelefone: {banco.Telefone}\nCaso queira nos visitar: \nCep: {banco.Cep}\n");
        Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
        int opcao = Convert.ToInt32(Console.ReadLine());
        while (opcao != 9)
        {
            if (opcao == 1)
            {
                Console.WriteLine("Digite o valor do deposito");
                decimal valor = Convert.ToDecimal(Console.ReadLine());
                conta2.deposito(valor);
                Console.WriteLine($"Depósito realizado com sucesso, novo saldo: {conta2.Saldo}");
                Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Digite o valor que deseja sacar");
                decimal valor = Convert.ToDecimal(Console.ReadLine());
                conta2.saque(valor);
                Console.WriteLine($"Saque realizado com sucesso, novo saldo: {conta2.Saldo}");
                Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 3)
            {
                Console.WriteLine($"Seu saldo atual é: {conta2.Saldo}");
                Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
    else if (cpf_digitado == cliente1.Cpf)
    {
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine($"{cliente1.Nome} Seja bem vindo ao {banco.Nome}\nDados da sua conta: \nAgência: {banco.Agencia}\nConta: {conta1.Numero}\nSaldo: {conta2.Saldo}\nPara contato da agência:\nTelefone: {banco.Telefone}\nCaso queira nos visitar: \nCep: {banco.Cep}\n");
        Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
        int opcao = Convert.ToInt32(Console.ReadLine());
        while (opcao != 9)
        {
            if (opcao == 1)
            {
                Console.WriteLine("Digite o valor do deposito");
                decimal deposito = Convert.ToDecimal(Console.ReadLine());
                conta1.deposito(deposito);
                Console.WriteLine($"Depósito realizado com sucesso, novo saldo: {conta1.Saldo}");
                Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Digite o valor que deseja sacar");
                decimal saque = Convert.ToDecimal(Console.ReadLine());
                conta2.saque(saque);
                Console.WriteLine($"Saque realizado com sucesso, novo saldo: {conta1.Saldo}");
                Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 3)
            {
                Console.WriteLine($"Seu saldo atual é: {conta1.Saldo}");
                Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
    else
    {
        Console.WriteLine("CPF digitado não pertence a uma conta do banco.");
    }
}

/*/
        var tupla1 = (conta1.Saldo, conta1.Numero);
        var tupla2 = (conta2.Saldo, conta2.Numero);
        long maiorsaldo = conta1.MaiorSaldo(tupla1, tupla2);
        Console.WriteLine($"A conta que possui o maior saldo é: {maiorsaldo}");
        Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
        int opcao = Convert.ToInt32(Console.ReadLine());
        while (opcao != 9)
        {
            if (opcao == 1)
            {
                Console.WriteLine("Digite o valor do deposito");
                decimal deposito = Convert.ToDecimal(Console.ReadLine());
                conta1.deposito(deposito);
                Console.WriteLine($"Depósito realizado com sucesso, novo saldo: {conta1.Saldo}");
                Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 2) 
            {
                Console.WriteLine("Digite o valor que deseja sacar");
                decimal saque = Convert.ToDecimal(Console.ReadLine());
                conta2.saque(saque);
                Console.WriteLine($"Saque realizado com sucesso, novo saldo: {conta1.Saldo}");
                Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 3)
            {
                Console.WriteLine($"Seu saldo atual é: {conta1.Saldo}");
                Console.WriteLine("Digite qual operação deseja realizar ou 9 para sair\n1 - Deposito\n2 - Saque\n3 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
/*/

/*/
 * Se usarmos somente variáveis sem o uso da classe, teriamos 8 linhas somente com as variáveis + as operações:
 * conta1
 * conta2
 * saldo1
 * saldo2
 * saque
 * deposito
 * transferencia
 * saldofinal
 * 
 * Analise como poderíamos vincular a classe conta com a classe cliente, que neste caso seria o titular da conta.
 * No método construtor da classe cliente usamos uma variável contavinculada fazendo instancia da classe Conta
/*/

