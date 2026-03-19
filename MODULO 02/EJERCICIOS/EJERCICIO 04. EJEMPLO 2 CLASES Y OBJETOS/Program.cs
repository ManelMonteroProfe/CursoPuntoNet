using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AQUI EMPIEZA EL PROGRAMA

            Console.WriteLine("Empieza el programa de Almacen");


            // CReamos el objeto producto
            Console.WriteLine("Creando objeto Producto p1");
            var p1 = new Producto { idProducto= 1, NomProducto = "Portatil", Stock = 10 };


            // Los escribimos por pantalla
            p1.Mostrar();


            // Compramos 10 POrtátiles
            p1.Reponer(10);
			
			// Vendemos 15 POrtátiles
            p1.Vender(15);
			

            // Los escribimos por pantalla
            p1.Mostrar();


            Console.WriteLine("Fin de Programa. Pulse una tecla");
            Console.ReadLine();
            // FIN DE PROGRAMA
            }
    }
}
