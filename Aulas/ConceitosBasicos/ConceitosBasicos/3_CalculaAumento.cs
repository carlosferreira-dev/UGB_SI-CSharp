using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceitosBasicos
{
    public class CalculaAumento
    {
        public static double Aumento(double salario_atual, double percentual)
        {
            return salario_atual * (percentual / 100);
        }
    }
}
