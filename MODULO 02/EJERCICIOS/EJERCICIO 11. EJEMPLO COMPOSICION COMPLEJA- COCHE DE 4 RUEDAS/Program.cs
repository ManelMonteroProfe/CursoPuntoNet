using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coche4ruedas
{
    // Definimos la rueda

    public class Rueda
    {
        public int DiametroPulgadas { get; set; }
        public string Tipo { get; set; } // verano, invierno, etc.
    }

    public class Coche
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        // Composición: el coche contiene ruedas
        public Rueda RuedaDelanteraIzquierda { get; set; }
        public Rueda RuedaDelanteraDerecha { get; set; }
        public Rueda RuedaTraseraIzquierda { get; set; }
        public Rueda RuedaTraseraDerecha { get; set; }

        public string MostrarInfo()
        {
            return
                "COCHE: " + Marca + " " + Modelo + "\n" +
                "- DI: " + RuedaDelanteraIzquierda.DiametroPulgadas + "'' " + RuedaDelanteraIzquierda.Tipo + "\n" +
                "- DD: " + RuedaDelanteraDerecha.DiametroPulgadas + "'' " + RuedaDelanteraDerecha.Tipo + "\n" +
                "- TI: " + RuedaTraseraIzquierda.DiametroPulgadas + "'' " + RuedaTraseraIzquierda.Tipo + "\n" +
                "- TD: " + RuedaTraseraDerecha.DiametroPulgadas + "'' " + RuedaTraseraDerecha.Tipo;
        }
    }

    // Vamos a definir otro coche con un Array de Ruedas
    public class CocheArray
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        // Array de tamaño fijo: 4 ruedas 
        public Rueda[] Ruedas { get; set; } = new Rueda[4];
        public string MostrarInfo()
        {
            return "COCHE: " + Marca + " " + Modelo + "\n" + "Rueda 1: " + Ruedas[0].DiametroPulgadas + "'' " + Ruedas[0].Tipo + "\n" + "Rueda 2: " + Ruedas[1].DiametroPulgadas + "'' " + Ruedas[1].Tipo + "\n" + "Rueda 3: " + Ruedas[2].DiametroPulgadas + "'' " + Ruedas[2].Tipo + "\n" + "Rueda 4: " + Ruedas[3].DiametroPulgadas + "'' " + Ruedas[3].Tipo;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio Programa");

            Console.WriteLine("Creamos las 4 ruedas");
            // Creamos las 4 ruedas (componentes)
            var r1 = new Rueda { DiametroPulgadas = 17, Tipo = "verano" };
            var r2 = new Rueda { DiametroPulgadas = 17, Tipo = "verano" };
            var r3 = new Rueda { DiametroPulgadas = 17, Tipo = "verano" };
            var r4 = new Rueda { DiametroPulgadas = 17, Tipo = "verano" };

            // Creamos el coche y le asignamos las ruedas
            Console.WriteLine("Creamos el coche");
            var coche = new Coche
            {
                Marca = "Seat",
                Modelo = "Ibiza",
                RuedaDelanteraIzquierda = r1,
                RuedaDelanteraDerecha = r2,
                RuedaTraseraIzquierda = r3,
                RuedaTraseraDerecha = r4
            };
            Console.WriteLine(coche.MostrarInfo());


            // Mostramos segundo CocheArray
            Console.WriteLine("Creando segundo Coche con ARray de Ruedas");
            var coche2 = new CocheArray
            {
                Marca = "Toyota",
                Modelo = "Corolla"
            };
            coche2.Ruedas[0] = new Rueda { DiametroPulgadas = 16, Tipo = "verano" };
            coche2.Ruedas[1] = new Rueda { DiametroPulgadas = 16, Tipo = "verano" };
            coche2.Ruedas[2] = new Rueda { DiametroPulgadas = 16, Tipo = "verano" };
            coche2.Ruedas[3] = new Rueda { DiametroPulgadas = 16, Tipo = "verano" };

            Console.WriteLine("MOSTRAMOS COCHE ARRAY");
            Console.WriteLine(coche2.MostrarInfo());

            Console.WriteLine("FIN DEL PROGRAMA");
            Console.ReadLine();

        }
    }
}