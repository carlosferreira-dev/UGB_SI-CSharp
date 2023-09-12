using ControleContas;
using System.Drawing;
using System.Text.RegularExpressions;

string nome_cliente2 = "Rosenclever";
string cpf_cliente2 = "11122233344";
int anonascimento_cliente2 = 1980;
Banco banco = new Banco();
Cliente cliente2 = new Cliente(nome_cliente2, cpf_cliente2,anonascimento_cliente2);
Conta conta2 = new Conta(654321, 2341.42m, cliente2);
Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nBem vindo ao Banco X, vamos realizar a abertura da sua conta!\nDigite seu Nome: ");
string nome = Console.ReadLine();
Console.WriteLine("----------------------------------------------\nDigite seu ano de nascimento: ");
int anonascimento = Convert.ToInt32(Console.ReadLine());
Cliente cliente1 = null;
Conta conta1 = null;
Console.WriteLine("----------------------------------------------\nDigite seu CPF: ");
string cpf = Console.ReadLine();
if (cpf != "11122233344")
{
    cliente1 = new Cliente(nome, cpf, anonascimento);
    Console.WriteLine("----------------------------------------------\nDigite a sua conta: ");
    long numero_conta = Convert.ToInt64(Console.ReadLine());
    Console.WriteLine("----------------------------------------------\nInforme o valor do depósito para ser o saldo inicial: ");
    decimal saldo = Convert.ToDecimal(Console.ReadLine());
    conta1 = new Conta(numero_conta, saldo, cliente1);
    Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n{conta1.Titular.Nome}, Conta aberta com sucesso.\nDados da sua conta \nAgência: {banco.Agencia}\nConta: {conta1.Numero}\nSaldo: {conta1.Saldo}\nPara contato da agência:\nTelefone: {banco.Telefone}\nCaso queira nos visitar: \nCep: {banco.Cep}\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
}
else
{
    Console.WriteLine($"Desculpe {nome}, esse cpf já possui conta em nosso banco e você não é Titular");
}
if ( cliente1 != null && conta1 != null)
{
    Console.WriteLine($"Selecione uma conta:\n1 - Conta: {conta1.Numero} - Titular: {conta1.Titular.Nome}\n2 - Conta: {conta2.Numero} - Titular: {conta2.Titular.Nome}\n9 - Sair do sistema.");
    int escolha_menu = Convert.ToInt32(Console.ReadLine());
    bool menu_principal = true;
    while (menu_principal)
        if (escolha_menu == 2)
        {
            Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n{conta2.Titular.Nome}, seja bem vindo ao {banco.Nome}\nDados da sua conta: \nAgência: {banco.Agencia}\nConta: {conta2.Numero}\nSaldo: {conta2.Saldo}\nPara contato da agência:\nTelefone: {banco.Telefone}\nCaso queira nos visitar: \nCep: {banco.Cep}\n");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
            int escolha_conta = Convert.ToInt32(Console.ReadLine());
            bool menu_conta = true;
            while (menu_conta)
            {
                if (escolha_conta == 0)
                {
                    var tupla1 = (conta1.Saldo, conta1.Numero);
                    var tupla2 = (conta2.Saldo, conta2.Numero);
                    Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n{cliente2.Nome}, obrigado por ser nosso cliente!\nSaindo com segurança da sua conta....\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nA conta que possui o maior saldo é: {conta2.MaiorSaldo(tupla1, tupla2)}");
                    Console.WriteLine($"Selecione uma conta:\n1 - Conta: {conta1.Numero} - Titular: {conta1.Titular.Nome}\n2 - Conta: {conta2.Numero} - Titular: {conta2.Titular.Nome}\n9 - Sair do sistema.");
                    escolha_menu = Convert.ToInt32(Console.ReadLine());
                    menu_conta = false;
                }
                if (escolha_conta == 1)
                {
                    Console.WriteLine("Digite o valor do deposito");
                    decimal valor = Convert.ToDecimal(Console.ReadLine());
                    conta2.Deposito(valor);
                    Console.WriteLine($"Depósito realizado com sucesso, novo saldo: {conta2.Saldo}");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
                else if (escolha_conta == 2)
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
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
                else if (escolha_conta == 3)
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
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
                else if (escolha_conta == 4)
                {
                    Console.WriteLine($"Seu saldo atual é: {conta2.Saldo}");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nOpção inválida, tente novamente.");
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        else if (escolha_menu == 1)
        {
            Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n{cliente1.Nome} Seja bem vindo ao {banco.Nome}\nDados da sua conta: \nAgência: {banco.Agencia}\nConta: {conta1.Numero}\nSaldo: {conta1.Saldo}\nPara contato da agência:\nTelefone: {banco.Telefone}\nCaso queira nos visitar: \nCep: {banco.Cep}\n");
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
            int escolha_conta = Convert.ToInt32(Console.ReadLine());
            bool menu_conta = true;
            while (menu_conta)
            {
                if (escolha_conta == 0)
                {
                    var tupla1 = (conta1.Saldo, conta1.Numero);
                    var tupla2 = (conta2.Saldo, conta2.Numero);
                    Console.WriteLine($"=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n{cliente1.Nome}, obrigado por ser nosso cliente!\nSaindo com segurança da sua conta....\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nA conta que possui o maior saldo é: {conta1.MaiorSaldo(tupla1, tupla2)}");
                    Console.WriteLine($"Selecione uma conta:\n1 - Conta: {conta1.Numero} - Titular: {conta1.Titular.Nome}\n2 - Conta: {conta2.Numero} - Titular: {conta2.Titular.Nome}\n9 - Sair do sistema.");
                    escolha_menu = Convert.ToInt32(Console.ReadLine());
                    menu_conta = false;
                }
                if (escolha_conta == 1)
                {
                    Console.WriteLine("Digite o valor do deposito");
                    decimal deposito = Convert.ToDecimal(Console.ReadLine());
                    conta1.Deposito(deposito);
                    Console.WriteLine($"Depósito realizado com sucesso, novo saldo: {conta1.Saldo}");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
                else if (escolha_conta == 2)
                {
                    Console.WriteLine("Digite o valor que deseja sacar");
                    decimal valor = Convert.ToDecimal(Console.ReadLine());
                    if (conta1.Saque(valor))
                    {
                        Console.WriteLine($"Saque realizado com sucesso, novo saldo: {conta1.Saldo}");
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente");
                    }
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
                else if (escolha_conta == 3)
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
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
                else if (escolha_conta == 4)
                {
                    Console.WriteLine($"Seu saldo atual é: {conta1.Saldo}");
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nDigite qual operação deseja realizar: \n0 - Sair\n1 - Deposito\n2 - Saque\n3 - Transferencia\n4 - Saldo atual");
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nOpção inválida, tente novamente.");
                    escolha_conta = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        else if (escolha_menu == 9)
        {
            Console.WriteLine("Muito obrigado por utilizar nossos serviços. Volte sempre!");
            menu_principal = false;
        }
        else
        {
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\nOpção inválida, tente novamente.");
            Console.WriteLine($"Selecione uma conta:\n1 - Conta: {conta1.Numero} - Titular: {conta1.Titular.Nome}\n2 - Conta: {conta2.Numero} - Titular: {conta2.Titular.Nome}\n9 - Sair do sistema.");
            escolha_menu = Convert.ToInt32(Console.ReadLine());
        }
}


/*/
 * Se usarmos somente variáveis sem o uso da classe, teriamos várias linhas somente com as variáveis + as operações:
 * conta1
 * nome_cliente1
 * cpf_cliente1
 * anonascimento_cliente2
 * conta2
 * nome_cliente2
 * cpf_cliente2
 * anonascimento_cliente2
 * saldo1
 * saldo2
 * saque
 * deposito
 * transferencia
 * saldofinal
/*/