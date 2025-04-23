using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgra
{
    internal class MinaHierro : Mina
    {
        public MinaHierro()
        {
            Tipo = "Hierro";
            Produccion = 20;
            Costo = 100;
            Estado = "Con obrero";
            Trabajador = new Obrero();
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
