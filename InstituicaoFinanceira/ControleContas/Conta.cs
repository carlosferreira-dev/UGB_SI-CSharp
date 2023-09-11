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
        }
        public Conta() 
        { 
        }

        public long Numero { get; private set; }

        public long Agencia { get; private set; }

        //Usada para armazenar o valor de saldo, quando estava como Saldo entrava em loop
        private decimal saldo;
        public decimal Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if (value >= 10.0m)
                {
                    saldo = value;
                }
                else
                {
                    Console.WriteLine("O saldo inicial não pode ser menor do que R$10.00!");
                    //Encerra o programa
                    Environment.Exit(0);
                }
            }
        }
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
            if (Saldo > 0 && valor <= Saldo - 0.10m)
            {
                Saldo -= (valor + 0.10m);
            }
        }
    }
}
