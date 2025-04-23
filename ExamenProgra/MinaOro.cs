using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgra
{
    internal class MinaOro : Mina
    {
        public MinaOro()
        {
            Tipo = "Oro";
            Produccion = 50;
            Costo = 550;
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
