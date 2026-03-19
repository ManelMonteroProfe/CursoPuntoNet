using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consola04
{
    internal class Program
    {
        // CURSO DE C# Y PUNTO NET. 2026
        // Profesor: Manel MOntero
        // Tema: Acceso a Ficheros en Disco
        static void Main(string[] args)
        {

            /* INICIO

            Objetivo: el programa crea un fichero, guarda varios enteros y lo cierra.
            En este ejemplo guardamos 5 enteros (uno por línea).
            Posteriormente los leemos

            Necesitamos estas dos librerias (ya definidas arriba)
            using System;
            using System.IO;

            */

            // El simbolo @ hace que \D \p etc no se interprete como caracter especial
            string carpeta = @"D:\Proyectos\consola04\consola04\data";
            string nombreFichero = "fichero.txt";
            string ruta;
            ruta = Path.Combine(carpeta, nombreFichero);

            // Ejemplo Matriz o Array de Valores a Guardar en Disco
            int[] valores = { 10, 20, 30, 40, 50 };
            
            using (StreamWriter writer = new StreamWriter(ruta))
                {
                    foreach (int numero in valores)
                    {
                        writer.WriteLine(numero);
                    }
                } // cerrado automático

            Console.WriteLine($"Archivo creado y guardado: {Path.GetFullPath(ruta)}");
            Console.ReadLine();

            // Ubicación fichero
            if (!File.Exists(ruta))
            {
                Console.WriteLine("No existe: " + ruta);
                return;
            }

            // Mostramos contenido del fichero 
            Console.WriteLine("Mostramos el contenido del fichero");
            using (StreamReader reader = new StreamReader(ruta))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }

            // Añadir tres VALORES más al archivo
            Console.WriteLine("AÑADIMOS 99, 98 y 97 al Archivo");
            int[] nuevos = { 99, 98, 97 };

            using (StreamWriter writer = new StreamWriter(ruta, append: true))
            {
                foreach (int v in nuevos)
                {
                    writer.WriteLine(v);
                }
            }

            // Mostramos contenido del fichero 
            Console.WriteLine("Mostramos el contenido del fichero FINAL");
            using (StreamReader reader = new StreamReader(ruta))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }

            Console.WriteLine("Programa finalizado");
            Console.ReadLine();

            // FIN  PROGRAMA
        }
    }
}
