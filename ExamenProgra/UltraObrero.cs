using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgra
{
    internal class UltraObrero : ITrabajador
    {
        public int CalcularProduccion(int produccionMina)
        {
            return produccionMina * 3;
        }
    }
}
