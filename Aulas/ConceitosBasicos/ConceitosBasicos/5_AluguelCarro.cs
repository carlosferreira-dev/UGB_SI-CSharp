using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceitosBasicos
{
    public class AluguelCarro
    {
        public static double Aluguel(int dias_aluguel, double km_final, double km_inicial)
        {
            return Math.Round((95 * dias_aluguel) + ((km_final - km_inicial) * 0.35), 2);
        }
    }
}
