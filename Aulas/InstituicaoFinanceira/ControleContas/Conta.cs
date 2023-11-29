using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Conta
    {
        //Método construtor
        public Conta(long numero, decimal saldo, Cliente titular) 
        {
            Numero = numero;
            Saldo = saldo;
            Titular = titular;
            if (saldo < 10.00m)
            {
                Console.WriteLine("O saldo inicial não pode ser menor do que R$10.00!");
                //Encerra o programa, preferi usar dessa forma em vez de tratar com try, catch..
                Environment.Exit(0);
            }
        }
        public Cliente Titular { get; set; }
        public Conta() 
        { 
        }

        public long Numero { get; private set; }

        public long Agencia { get; private set; }

        public decimal Saldo { get; set; }

        //Método que recebe uma tupla com saldo/numero da conta e retorna o numero de acordo com o maior saldo
        public long MaiorSaldo((decimal saldo1, long numero1) tupla1, (decimal saldo2, long numero2) tupla2)
        {
            if ((tupla1.saldo1) > (tupla2.saldo2))
            {
                return tupla1.numero1;
            }
            else
            {
                return tupla2.numero2;
            }
        }
        public void Deposito(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
        }
        public bool Saque(decimal valor)
        {
            if (Saldo > 0 && valor <= Saldo - 0.10m)
            {
                Saldo -= (valor + 0.10m);
                return true;
            }
            return false;
        }
        public bool Transferencia(Conta destino, decimal valor)
        {
            if (Saldo - valor >= 0)
            {
                Saldo -= valor;
                destino.Deposito(valor);
                return true;
            }
            return false;
        }
    }
}
