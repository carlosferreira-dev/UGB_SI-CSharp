using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceitosBasicos
{
    public class AdivinharNumero
    {
        public static bool Numero(int numero_aleatorio, int numero_digitado)
        {
            return numero_aleatorio == numero_digitado;
        }
    }
}
