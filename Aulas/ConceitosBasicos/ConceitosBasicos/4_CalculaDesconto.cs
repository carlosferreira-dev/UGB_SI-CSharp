using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceitosBasicos
{
    public class CalculaDesconto
    {
        public static double Desconto(double valor_atual, double percentual)
        {
            return (valor_atual / 100) * percentual;
        }
    }
}