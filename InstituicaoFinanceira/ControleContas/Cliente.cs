using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, int anoNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            AnoNascimento = anoNascimento;
            ContaVinculada = new Conta();
        }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int AnoNascimento { get; private set; }
        public Conta ContaVinculada { get; set; }
    }
}
