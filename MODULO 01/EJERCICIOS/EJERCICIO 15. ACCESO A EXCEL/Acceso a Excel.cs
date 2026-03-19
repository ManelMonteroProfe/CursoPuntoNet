using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Para Usar EXCEL , se instala esta libreria
using ClosedXML.Excel;

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

            // Vamos a Practicar ahora con EXCEL
            Console.WriteLine("Creamos fichero EXCEL");
            carpeta = @"D:\Proyectos\consola04\consola04\data";
            string nombreFicheroExcel = "fichero.xlsx";
            ruta = Path.Combine(carpeta, nombreFicheroExcel);

            int[] valoresExcel = { 10, 20, 30, 40, 50 };

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Datos");

                // Encabezado opcional
                ws.Cell(1, 1).Value = "Enteros";

                // Escribir enteros desde la fila 2
                for (int i = 0; i < valoresExcel.Length; i++)
                {
                    ws.Cell(i + 2, 1).Value = valoresExcel[i];
                }

                // Ajuste visual (opcional)
                ws.Columns().AdjustToContents();

                wb.SaveAs(ruta); // GUARDAR (equivale a “cerrar” el fichero)
            }
            Console.WriteLine("Excel creado: " + ruta);

            Console.WriteLine("Programa finalizado");
            Console.ReadLine();

            // FIN  PROGRAMA
        }
    }
}
