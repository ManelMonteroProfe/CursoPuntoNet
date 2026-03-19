using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consola05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Programa que lee alumnos y los guarda en un CSV para EXCEL


            Console.Write("¿Cuántos Alumnos quieres guardar? ");
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Introduce un número entero válido (>0): ");
            }

            // CREAMOS mATRIZ DE ALUMNOS bidimensional
            // Llenar la matriz de alumnos[4,3]
            // Nombre, apellido, dni

            string[,] Alumnos = new string[n, 3];

            string nombre, apellido, dni;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Alumno:{0}", i);
                // rellenamos la matriz
                Console.WriteLine("NOMBRE:");
                nombre = Console.ReadLine();
                Alumnos[i, 0] = nombre;

                Console.WriteLine("APELLIDO:");
                apellido = Console.ReadLine();
                Alumnos[i,1] = apellido;

                Console.WriteLine("DNI:");
                dni = Console.ReadLine();
                Alumnos[i,2] = dni;
            }

            // Ahora lo guardamos en fichero
            // El simbolo @ hace que \D \p etc no se interprete como caracter especial
            string carpeta = @"D:\Proyectos\consola05\consola05";
            string nombreFichero = "ficheroAlumnos.csv";
            string ruta;
            ruta = Path.Combine(carpeta, nombreFichero);

            // Ejemplo Matriz o Array de Valores a Guardar en Disco
            string registro;
            using (StreamWriter writer = new StreamWriter(ruta))
            {
                for (int i = 0; i < n; i++)
                {
                    registro = Alumnos[i, 0] +","+ Alumnos[i, 1] + "," + Alumnos[i, 2]; 
                    writer.WriteLine(registro);
                }
            } // cerrado automático 
            Console.WriteLine($"Archivo creado y guardado: {Path.GetFullPath(ruta)}");

            Console.WriteLine("Pulsa INTRO para salir");
            Console.ReadLine();
        }
    }
}
