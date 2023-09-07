using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas
{
    public class Conta
    {
        public Conta(long numero) 
        {
            Numero = numero;
        }
        public Conta() 
        { 
        }
        public long Numero { get; private set; }
        public decimal Saldo { get; set; }
    }
}
