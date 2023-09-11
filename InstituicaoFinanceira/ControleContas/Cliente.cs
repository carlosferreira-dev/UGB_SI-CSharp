using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, int anoNascimento)
        {
            if (DateTime.Now.Year - anoNascimento < 18)
            {
                Console.WriteLine("Não é possível abrir uma conta para menores de 18 anos");
                //Encerra o programa, preferi usar dessa forma em vez de tratar com try, catch..
                Environment.Exit(0);
            }
            string cpfapenasnumeros = Regex.Replace(cpf, "[^0-9]", "");
            if (cpfapenasnumeros.Length != 11) 
            {
                Console.WriteLine("CPF digitado é inválido, deve possuir 11 digitos");
                //Encerra o programa, preferi usar dessa forma em vez de tratar com try, catch..
                Environment.Exit(0);
            }
            Nome = nome;
            Cpf = cpfapenasnumeros;
            AnoNascimento = anoNascimento;
        }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int AnoNascimento { get; private set; }
    }
}
