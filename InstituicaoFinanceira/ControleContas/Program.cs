using ControleContas;
using System.Text.RegularExpressions;

Console.WriteLine("Digite seu Nome para abertura da conta: ");
string nome = Console.ReadLine();
Console.WriteLine("Digite seu ano de nascimento: ");
int anonascimento = Convert.ToInt32(Console.ReadLine());
if ((DateTime.Now.Year - anonascimento) >= 18)
{
    Console.WriteLine("Digite seu CPF: ");
    string cpf = Console.ReadLine();
    string cpfapenasumeros = Regex.Replace(cpf, "[^0-9]", "");
    if (cpfapenasumeros.Length == 11)
    {
        Cliente cliente1 = new Cliente(nome, cpf, anonascimento);
        Console.WriteLine("Digite a sua conta: ");
        long numero_conta = Convert.ToInt64(Console.ReadLine());
        Console.WriteLine("Informe o valor do depósito para ser o saldo inicial: ");
        decimal saldo = Convert.ToDecimal(Console.ReadLine());
        Conta conta1 = new Conta(numero_conta, saldo);
        Conta conta2 = new Conta(654321, 2341.42m);
        Console.WriteLine($"Número da conta: {conta1.Numero} com saldo: {conta1.Saldo}");
        Console.WriteLine($"Número da conta: {conta2.Numero} com saldo: {conta2.Saldo}");
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
    else
    {
        Console.WriteLine($"Desculpe {nome}, cpf informado é inválido!");
    }
}
else
{
    Console.WriteLine($"Desculpe {nome}, Não é possível abrir uma conta para menores de 18 anos");
}

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

