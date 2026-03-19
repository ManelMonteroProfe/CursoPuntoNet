using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// PROGRAMA EJEMPLO DE USO CON EXCEL
// CREA UNA HOJA DE CALCULO A PARTIR DE DOS ARRAYS
// lIBRERIAS PARA USAR EXCEL. Se ha de instalar antes de poderla llamar
using ClosedXML.Excel;

namespace consola06_excel
{
    internal class Program
    {
        // PROGRAMA DE USO DE EXCEL
        static void Main(string[] args)
        {
            string carpeta, ruta;
            // Vamos a Practicar ahora con EXCEL
            Console.WriteLine("Creamos fichero EXCEL");
            carpeta = @"D:\proyectos\consola06-excel\consola06-excel";
            string nombreFicheroExcel = "Alumnos.xlsx";
            ruta = Path.Combine(carpeta, nombreFicheroExcel);

            int[] valoresExcel = { 10, 20, 30, 40, 50 };
            string[] alumnos = { "alumno1", "alumno2", "alumno3", "alumno4", "alumno5" };

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Datos");

                // Encabezado opcional
                ws.Cell(1, 1).Value = "Enteros";

                // Escribir enteros desde la fila 2
                for (int i = 0; i < valoresExcel.Length; i++)
                {
                    ws.Cell(i + 2, 1).Value = valoresExcel[i];
                    ws.Cell(i + 2, 2).Value = alumnos[i];
                }

                // CREAMOS UNA FORMULA
                ws.Cell(8, 1).SetFormulaA1("=SUM(A2:A7)");

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
