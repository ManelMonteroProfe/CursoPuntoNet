using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesdeDatos01
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

            // SELECT
            Console.WriteLine("LISTADO DE PROVINCIAS");
            var provincias = tabla.GetAll();
            foreach (var registro in provincias)
            {
                Console.WriteLine($"{registro.IdProvincia} - {registro.ProvinciaNombre}");
            }

            // INSERT
            Console.WriteLine("INSERTAMOS BARCELONA CON idprovincia=99");
            tabla.Insert(99, "Barcelona");

            // UPDATE
            Console.WriteLine("ACTUALIZO PROVINCIA 99");
            tabla.Update(99, "Barcelona(Act)");

            // DELETE
            Console.WriteLine("ELIMINO PROVINCIA 99");
            tabla.Delete(99);

            Console.WriteLine("FINAL DEL PROGRAMA. PULSA [intro] PARA ACABAR");
            Console.ReadLine();

        }   // fin Main
    }   // fin program
}   // fin namespace
