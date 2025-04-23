using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgra
{
    abstract class Mina
    {
        public string Tipo;
        public int Produccion;
        public int Costo;
        public string Estado;
        public ITrabajador Trabajador;
        public abstract int GenerarPlata();
    }
}
