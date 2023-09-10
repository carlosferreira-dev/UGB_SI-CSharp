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
        public Conta(long numero, decimal saldo) 
        {
            Numero = numero;
            Saldo = saldo;
            if (saldo < 10.00m)
            {
                throw new ArgumentException("O saldo inicial não pode ser inferior a R$10,00.");
            }
        }
        public Conta() 
        { 
        }

        public long Numero { get; private set; }

        public decimal Saldo { get; private set; }

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
        public void deposito(decimal valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
            }
        }
        public void saque(decimal valor)
        {
            if (Saldo > 0 && valor <= Saldo)
            {
                Saldo -= valor - 0.10m;
            }
        }
    }
}
