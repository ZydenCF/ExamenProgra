using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgra
{
    internal class MinaDiamante : Mina
    {
        public MinaDiamante()
        {
            Tipo = "Diamante";
            Produccion = 120;
            Costo = 1000;
            Estado = "Vacía";
        }

        public override int GenerarPlata()
        {
            if (Trabajador != null)
            {
                return Trabajador.CalcularProduccion(Produccion);
            }
            return 0;
        }
    }
}
