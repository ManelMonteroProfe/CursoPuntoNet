using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juegodados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // AQUI EMPIEZA EL PROGRAMA

            Console.WriteLine("Empieza el programa");


            // CReamos los dos objetos libro
            Console.WriteLine("Creando objeto Libro l1");
            var l1 = new Libro { Titulo = "El Quijote", Autor = "Cervantes" };
            Console.WriteLine("Creando objeto Libro l2");
            var l2 = new Libro { Titulo = "1984", Autor = "George Orwell" };
            Console.WriteLine("Creando objeto Libro l3");
            var l3 = new Libro { Titulo = "Harry Potter", Autor = "JK Rowling" };


            // Los escribimos por pantalla
            //Console.WriteLine($"{l1.Titulo} - {l1.Autor}");
            //Console.WriteLine($"{l2.Titulo} - {l2.Autor}");
            Console.WriteLine("Mostrando Libros...");
            l1.Mostrar();
            l2.Mostrar();
            l3.Mostrar();

            Console.WriteLine("Fin de Programa. Pulse una tecla");
            Console.ReadLine();
            // FIN DE PROGRAMA
            }
    }
}
