using ControleContas;
using System.Drawing;
using System.Text.RegularExpressions;

string nome_cliente2 = "Rosenclever";
string cpf_cliente2 = "11122233344";
int anonascimento_cliente2 = 1980;
Banco banco = new Banco();
Cliente cliente2 = new Cliente(nome_cliente2, cpf_cliente2,anonascimento_cliente2);
Conta conta2 = new Conta(654321, 2341.42m, cliente2);
Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
Console.WriteLine("Digite seu Nome para abertura da conta: ");
string nome = Console.ReadLine();
Console.WriteLine("----------------------------------------------");
Console.WriteLine("Digite seu ano de nascimento: ");
int anonascimento = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("----------------------------------------------");
Cliente cliente1 = null;
Conta conta1 = null;
Console.WriteLine("Digite seu CPF: ");
string cpf = Console.ReadLine();
if (cpf != "11122233344")
{
    cliente1 = new Cliente(nome, cpf, anonascimento);
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine("Digite a sua conta: ");
    long numero_conta = Convert.ToInt64(Console.ReadLine());
    Console.WriteLine("----------------------------------------------");
    Console.WriteLine("Informe o valor do depósito para ser o saldo inicial: ");
    decimal saldo = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-="); ;
    conta1 = new Conta(numero_conta, saldo, cliente1);
    Console.WriteLine($"{conta1.Titular.Nome} Seja bem vindo ao {banco.Nome}\nDados da sua conta: \nAgência: {banco.Agencia}\nConta: {conta1.Numero}\nSaldo: {conta1.Saldo}\nPara contato da agência:\nTelefone: {banco.Telefone}\nCaso queira nos visitar: \nCep: {banco.Cep}");
    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
}
else
{
    Console.WriteLine($"Desculpe {nome}, esse cpf já possui conta em nosso banco e você não é Titular");
}
if ( cliente1 != null && conta1 != null)
{
    Console.WriteLine("Digite seu cpf para acessar a sua conta.");
    string cpfdigitado = Console.ReadLine();
    string cpf_digitado = Regex.Replace(cpfdigitado, "[^0-9]", "");
    if (cpf_digitado == cliente2.Cpf && cpf_digitado.Length == 11)
    {
        Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n{conta2.Titular.Nome}, seja bem vindo ao {banco.Nome}\nDados da sua conta: \nAgência: {banco.Agencia}\nConta: {conta2.Numero}\nSaldo: {conta2.Saldo}\nPara contato da agência:\nTelefone: {banco.Telefone}\nCaso queira nos visitar: \nCep: {banco.Cep}\n");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
        int opcao = Convert.ToInt32(Console.ReadLine());
        while (opcao != 0)
        {
            if (opcao == 1)
            {
                Console.WriteLine("Digite o valor do deposito");
                decimal valor = Convert.ToDecimal(Console.ReadLine());
                conta2.Deposito(valor);
                Console.WriteLine($"Depósito realizado com sucesso, novo saldo: {conta2.Saldo}");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Digite o valor que deseja sacar");
                decimal valor = Convert.ToDecimal(Console.ReadLine());
                if (conta2.Saque(valor))
                {
                    Console.WriteLine($"Saque realizado com sucesso, novo saldo: {conta2.Saldo}");
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente");
                }
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 3)
            {
                Console.WriteLine($"Digite o valor que deseja transferir para a conta {conta1.Numero} - Titular: {cliente1.Nome}");
                decimal valor = Convert.ToDecimal(Console.ReadLine());
                if (conta2.Transferencia(conta1, valor))
                {
                    Console.WriteLine($"Transferência efetuada com sucesso, seu novo saldo é: {conta2.Saldo}\nNovo saldo da conta destino: {conta1.Saldo}");
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para essa transferência!");
                }
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 4)
            {
                Console.WriteLine($"Seu saldo atual é: {conta2.Saldo}");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        }
        var tupla1 = (conta1.Saldo, conta1.Numero);
        var tupla2 = (conta2.Saldo, conta2.Numero);
        long maiorsaldo = conta1.MaiorSaldo(tupla1, tupla2);
        Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n{cliente2.Nome}, obrigado por ser nosso cliente!\nSaindo com segurança da sua conta....\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nA conta que possui o maior saldo é: {conta2.MaiorSaldo(tupla1, tupla2)}");
    }
    else if (cpf_digitado == cliente1.Cpf && cpf_digitado.Length == 11)
    {
        Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n{cliente1.Nome} Seja bem vindo ao {banco.Nome}\nDados da sua conta: \nAgência: {banco.Agencia}\nConta: {conta1.Numero}\nSaldo: {conta2.Saldo}\nPara contato da agência:\nTelefone: {banco.Telefone}\nCaso queira nos visitar: \nCep: {banco.Cep}\n");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
        int opcao = Convert.ToInt32(Console.ReadLine());
        while (opcao != 0)
        {
            if (opcao == 1)
            {
                Console.WriteLine("Digite o valor do deposito");
                decimal deposito = Convert.ToDecimal(Console.ReadLine());
                conta1.Deposito(deposito);
                Console.WriteLine($"Depósito realizado com sucesso, novo saldo: {conta1.Saldo}");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\\n4 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 2)
            {
                Console.WriteLine("Digite o valor que deseja sacar");
                decimal valor = Convert.ToDecimal(Console.ReadLine());
                if (conta2.Saque(valor))
                {
                    Console.WriteLine($"Saque realizado com sucesso, novo saldo: {conta1.Saldo}");
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente");
                }
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\\n3 - Transferencia\\n4 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 3)
            {
                Console.WriteLine($"Digite o valor que deseja transferir para a conta {conta2.Numero} - Titular: {cliente2.Nome}");
                decimal valor = Convert.ToDecimal(Console.ReadLine());
                if (conta1.Transferencia(conta2, valor))
                {
                    Console.WriteLine($"Transferência efetuada com sucesso, seu novo saldo é: {conta1.Saldo}\nNovo saldo da conta destino: {conta2.Saldo}");
                }
                else
                {
                    Console.WriteLine("Saldo insuficiente para essa transferência!");
                }
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
            else if (opcao == 4)
            {
                Console.WriteLine($"Seu saldo atual é: {conta1.Saldo}");
                Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                opcao = Convert.ToInt32(Console.ReadLine());
            }
        }
        var tupla1 = (conta1.Saldo, conta1.Numero);
        var tupla2 = (conta2.Saldo, conta2.Numero);
        long maiorsaldo = conta1.MaiorSaldo(tupla1, tupla2);
        Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n{cliente1.Nome}, obrigado por ser nosso cliente!\nSaindo com segurança da sua conta....\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nA conta que possui o maior saldo é: {conta1.MaiorSaldo(tupla1, tupla2)}");
    }
    else if (cpf_digitado.Length != 11)
    {
        Console.WriteLine("CPF digitado é inválido, deve possuir 11 digitos");
    }
    else
    {
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nCPF digitado não pertence a uma conta do banco.");
    }
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
/*/