using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos03
{
    /* Este programa accede a Base de Datos SQL SERVER
        Servidor:  (bdlocal)\SQLxxxxxx
        BBDD: bdpruebas01
        Table: Provincias (idprovincia, provincia)
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                @"Server=(localdb)\MSSQLLocalDB;Database=bdprueba01;Trusted_Connection=True;TrustServerCertificate=True;";

            var tabla = new ProvinciaRepository(connectionString);

            Console.WriteLine("INICIAMOS PROGRAMA GESTIÓN DE BASE DE DATOS");
            Console.WriteLine("-------------------------------------------");
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("GESTION DE PROVINCIAS");
                Console.WriteLine("1) Listado de Provincias");
                Console.WriteLine("2) Insertar una Provincia");
                Console.WriteLine("3) Modificar una Provincia");
                Console.WriteLine("4) Borrar una Provincia");
                Console.WriteLine("5) Terminar");
                Console.Write("\nElige una opción (1-5): ");

                while (!int.TryParse(Console.ReadLine(), out opcion))
                    Console.Write("Entrada no válida. Elige una opción (1-5): ");

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Has elegido: Listado de Provincias");
                        // Mostramos listado
                        Console.WriteLine("LISTADO DE PROVINCIAS");
                        var provincias = tabla.GetAll();
                        foreach (var registro in provincias)
                        {
                            Console.WriteLine($"{registro.IdProvincia} - {registro.ProvinciaNombre}");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Has elegido: Insertar una Provincia");
                        // INSERT
                        //Console.WriteLine("INSERTAMOS BARCELONA CON idprovincia=99");
                        //tabla.Insert(99, "Barcelona");
                        Console.WriteLine("Vamos a insertar Un ( IDPROVINCIA, NOMBRE_PROVINCIA)");
                        int numero;
                        while (true)
                        {
                            Console.Write("Introduce el ID Provincia: ");
                            string entrada = Console.ReadLine();

                            if (int.TryParse(entrada, out numero))
                                break;
                            Console.WriteLine("ERROR: NO ES UN ID VÁLIDO.");
                        }

                        string nombre;
                        do
                        {
                            Console.Write("Introduce un NOMBRE PROVINCIA: ");
                            nombre = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(nombre));

                        tabla.Insert(numero, nombre);
                        Console.WriteLine($"REGISTRO INSERTADO {numero} {nombre}");
                        break;
                    case 3:
                        Console.WriteLine("Has elegido: Modificar una Provincia");
                        // UPDATE
                        //Console.WriteLine("ACTUALIZO PROVINCIA 99");
                        //tabla.Update(99, "Barcelona(Act)");
                        while (true)
                        {
                            Console.Write("Introduce el ID Provincia: ");
                            string entrada = Console.ReadLine();

                            if (int.TryParse(entrada, out numero))
                                break;
                            Console.WriteLine("ERROR: NO ES UN ID VÁLIDO.");
                        }

                        do
                        {
                            Console.Write("Introduce un NOMBRE PROVINCIA NUEVO: ");
                            nombre = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(nombre));

                        tabla.Update(numero, nombre);
                        Console.WriteLine($"REGISTRO ACTUALIZADO {numero} {nombre}");
                        break;
                    case 4:
                        // EJECUTA UN DELETE DE LA TABLA SQL
                        Console.WriteLine("Has elegido: Borrar una Provincia");
                        //Console.WriteLine("ELIMINO PROVINCIA 99");
                        //tabla.Delete(99);
                        while (true)
                        {
                            Console.Write("Introduce el ID Provincia A BORRAR: ");
                            string entrada = Console.ReadLine();

                            if (int.TryParse(entrada, out numero))
                                break;
                            Console.WriteLine("ERROR: NO ES UN ID VÁLIDO.");
                        }
                        // Borra el Registro de la Tabla SQL SERVER
                        tabla.Delete(numero);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo... (Terminar)");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta. Debe ser un número entre 1 y 5.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPulsa una tecla para continuar...");
                    Console.ReadKey();
                }
            } while (opcion != 5);

            Console.WriteLine("FINAL DEL PROGRAMA. PULSA [intro] PARA ACABAR");
            Console.ReadLine();

        }   // fin Main
    }   // fin program
}   // fin namespace