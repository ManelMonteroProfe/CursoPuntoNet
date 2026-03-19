using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menusimple
{
    internal class Program
    {
        // EJEMPLO PROGRAMA MENUS SIMPLE CON METODOS
        static void Main(string[] args)
        {

            //empieza
                int opcion;

                do
                {
                    Console.Clear();
                    MostrarMenu();

                    Console.Write("\nElige una opción (1-5): ");
                    while (!int.TryParse(Console.ReadLine(), out opcion))
                        Console.Write("Entrada no válida. Elige una opción (1-5): ");

                    Console.WriteLine();

                    switch (opcion)
                    {
                        case 1:
                            ListadoProvincias();
                            break;

                        case 2:
                            InsertarProvincia();
                            break;

                        case 3:
                            ModificarProvincia();
                            break;

                        case 4:
                            BorrarProvincia();
                            break;

                        case 5:
                            Terminar();
                            break;

                        default:
                            OpcionIncorrecta();
                            break;
                    }

                    if (opcion != 5)
                    {
                        Console.WriteLine("\nPulsa una tecla para continuar...");
                        Console.ReadKey();
                    }

                } while (opcion != 5);
        } // FIN DEL MAIN

        // ------------------- MÉTODOS -------------------
        static void MostrarMenu()
        {
            Console.WriteLine("GESTION DE PROVINCIAS");
            Console.WriteLine("1) Listado de Provincias");
            Console.WriteLine("2) Insertar una Provincia");
            Console.WriteLine("3) Modificar una Provincia");
            Console.WriteLine("4) Borrar una Provincia");
            Console.WriteLine("5) Terminar");
        }

        static void ListadoProvincias()
        {
            Console.WriteLine("HAS ELEGIDO LA OPCION 1 - LISTADO DE PROVINCIAS");
        }

        static void InsertarProvincia()
        {
            Console.WriteLine("HAS ELEGIDO LA OPCION 2 - INSERTAR UNA PROVINCIA");
        }

        static void ModificarProvincia()
        {
            Console.WriteLine("HAS ELEGIDO LA OPCION 3 - MODIFICAR UNA PROVINCIA");
        }

        static void BorrarProvincia()
        {
            Console.WriteLine("HAS ELEGIDO LA OPCION 4 - BORRAR UNA PROVINCIA");
        }

        static void Terminar()
        {
            Console.WriteLine("HAS ELEGIDO LA OPCION 5 - TERMINAR");
        }

        static void OpcionIncorrecta()
        {
            Console.WriteLine("OPCION INCORRECTA. Debe ser un número entre 1 y 5.");
        }
        // FIN DE LOS METODOS
    }  // FIN DEL PROGRAMA
} // FIN DEL NAMESPACE
