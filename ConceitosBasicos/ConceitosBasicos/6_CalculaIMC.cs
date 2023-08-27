using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConceitosBasicos
{
    public class CalculaIMC
    {
        public static double IMC(double altura, double peso)
        {
            return Math.Round(peso / (altura * altura), 2);
        }
        
    }
}
