using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Banco
    {
        //Método construtor
        public Banco()
        {
            Numero = 1;
            Nome = "Banco X";
            Agencia = 123;
            Cep = 27275000;
            Telefone = 2433447070;
        }

        public int Numero { get; private set; }
        public string Nome { get; private set; }
        public int Agencia { get; private set; }
        public int Cep { get; private set; }
        public double Telefone { get; private set; }
    }
}