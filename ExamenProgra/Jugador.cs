using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgra
{
    internal class Jugador
    {
        public string Nombre;
        public int Plata;
        public int Almacenamiento;
        public List<Mina> Minas;

        public Jugador(string nombre)
        {
            Nombre = nombre;
            Plata = 0;
            Almacenamiento = 600;
            Minas = new List<Mina>();
            Minas.Add(new MinaHierro());
        }

        public int CalcularGananciaDia()
        {
            int total = 0;
            for (int i = 0; i < Minas.Count; i++)
            {
                total += Minas[i].GenerarPlata();
            }

            if (total > Almacenamiento)
            {
                return Almacenamiento;
            }
            return total;
        }
    }
}
