using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProgra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de minas!");
            Console.Write("Por favor, ingresa tu nombre: ");
            string nombreJugador = Console.ReadLine();

            Jugador jugador = new Jugador(nombreJugador);
            int dia = 1;

            while (jugador.Plata < 100000)
            {
                Console.WriteLine("--- MENÚ --- [Día: " + dia + "]");
                Console.WriteLine("1. Ver Datos");
                Console.WriteLine("2. Comprar Mina");
                Console.WriteLine("3. Comprar Obrero");
                Console.WriteLine("4. Mejorar Almacenamiento");
                Console.WriteLine("5. Pasar Día");

                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.WriteLine("Plata: " + jugador.Plata + "/" + jugador.Almacenamiento);
                    Console.WriteLine("Almacenamiento: " + jugador.Almacenamiento);
                    for (int i = 0; i < jugador.Minas.Count; i++)
                    {
                        Console.WriteLine(i + ". Mina de " + jugador.Minas[i].Tipo + " [" + jugador.Minas[i].Estado + "]");
                    }
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("¿Qué mina deseas comprar?");
                    Console.WriteLine("1. Hierro (100)");
                    Console.WriteLine("2. Oro (550)");
                    Console.WriteLine("3. Diamante (1000)");
                    string tipo = Console.ReadLine();

                    Mina nueva = null;

                    if (tipo == "1" && jugador.Plata >= 100)
                    {
                        nueva = new MinaHierro();
                        nueva.Trabajador = null;
                        nueva.Estado = "Vacía";
                        jugador.Plata -= 100;
                    }
                    else if (tipo == "2" && jugador.Plata >= 550)
                    {
                        nueva = new MinaOro();
                        jugador.Plata -= 550;
                    }
                    else if (tipo == "3" && jugador.Plata >= 1000)
                    {
                        nueva = new MinaDiamante();
                        jugador.Plata -= 1000;
                    }

                    if (nueva != null)
                    {
                        jugador.Minas.Add(nueva);
                        Console.WriteLine("Mina comprada.");
                    }
                    else
                    {
                        Console.WriteLine("No tienes suficiente plata.");
                    }
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("¿A qué mina deseas asignar el obrero? (0 a " + (jugador.Minas.Count - 1) + ")");

                    string indiceString = Console.ReadLine();
                    int indice;

                    if (int.TryParse(indiceString, out indice))
                    {
                        if (indice >= 0 && indice < jugador.Minas.Count)
                        {
                            if (jugador.Minas[indice].Trabajador == null ||
                                (jugador.Minas[indice].Estado == "Vacía" ||
                                (jugador.Minas[indice].Estado != "Con ultraobrero" && jugador.Minas[indice].Estado != "Con superobrero")))
                            {
                                Console.WriteLine("1. Obrero (gratis)");
                                Console.WriteLine("2. Superobrero (150)");
                                Console.WriteLine("3. Ultraobrero (300)");
                                string tipo = Console.ReadLine();

                                if (tipo == "1")
                                {
                                    jugador.Minas[indice].Trabajador = new Obrero();
                                    jugador.Minas[indice].Estado = "Con obrero";
                                    Console.WriteLine("Obrero asignado correctamente.");
                                }
                                else if (tipo == "2" && jugador.Plata >= 150)
                                {
                                    jugador.Minas[indice].Trabajador = new SuperObrero();
                                    jugador.Minas[indice].Estado = "Con superobrero";
                                    jugador.Plata -= 150;
                                    Console.WriteLine("Superobrero asignado correctamente.");
                                }
                                else if (tipo == "3" && jugador.Plata >= 300)
                                {
                                    jugador.Minas[indice].Trabajador = new UltraObrero();
                                    jugador.Minas[indice].Estado = "Con ultraobrero";
                                    jugador.Plata -= 300;
                                    Console.WriteLine("Ultraobrero asignado correctamente.");
                                }
                                else
                                {
                                    Console.WriteLine("No tienes suficiente plata o selección inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Esta mina ya tiene un trabajador de nivel superior.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Índice de mina inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor, introduce un número válido.");
                    }
                }
                else if (opcion == "4")
                {
                    Console.WriteLine("Mejorar almacenamiento cuesta 300 de plata.");
                    if (jugador.Plata >= 300)
                    {
                        jugador.Plata -= 300;
                        jugador.Almacenamiento += 750;
                        Console.WriteLine("Almacenamiento aumentado a " + jugador.Almacenamiento);
                    }
                    else
                    {
                        Console.WriteLine("No tienes suficiente plata.");
                    }
                }
                else if (opcion == "5")
                {
                    int ganancia = jugador.CalcularGananciaDia();
                    int nuevaPlata = jugador.Plata + ganancia;
                    if (nuevaPlata > jugador.Almacenamiento)
                    {
                        int plataPerdida = nuevaPlata - jugador.Almacenamiento;
                        jugador.Plata = jugador.Almacenamiento;
                        Console.WriteLine("Pasó el día " + dia + ". Ganaste " + ganancia + " de plata pero perdiste " + plataPerdida + " por falta de almacenamiento.");
                    }
                    else
                    {
                        jugador.Plata = nuevaPlata;
                        Console.WriteLine("Pasó el día " + dia + ". Ganaste " + ganancia + " de plata.");
                    }

                    dia++;
                }
            }

            Console.WriteLine("¡Felicidades " + jugador.Nombre + "! Te has vuelto rico con " + jugador.Plata + " de plata en " + (dia - 1) + " días.");
        }
    }
}

