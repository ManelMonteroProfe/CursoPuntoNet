using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Gestión de Bicicletas
namespace tiendabicicletas
{
    // Definimos los elementos de la bicicleta
    public class Rueda
    {
        public int DiametroPulgadas { get; set; }
        public string Tipo { get; set; } // carretera, montaña... 
    }

    public class Frenos
    {
        public string Tipo { get; set; } // disco, zapata... 
    }

    public class Sillin
    {
        public string Material { get; set; } // gel, cuero... 
    }

    public class Bicicleta
    {
        public string Marca { get; set; }
        public string Modelo { get; set; } // COMPOSICIÓN (TIENE-UN) 
        public Rueda Rueda { get; set; }
        public Frenos Frenos { get; set; }
        public Sillin Sillin { get; set; }


        public string MostrarInfo()
        {
            return $"BICICLETA: {Marca} {Modelo}\n" + $"- Rueda: {Rueda.DiametroPulgadas}'' ({Rueda.Tipo})\n" + $"- Frenos: {Frenos.Tipo}\n" + $"- Sillín: {Sillin.Material}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // main
            // 1) Creamos componentes 
            var rueda = new Rueda { DiametroPulgadas = 29, Tipo = "montaña" };
            var frenos = new Frenos { Tipo = "disco" };
            var sillin = new Sillin { Material = "gel" };

            // 2) Creamos la bicicleta y le asignamos componentes (TIENE-UN) 
            var bici = new Bicicleta
            {
                Marca = "Orbea",
                Modelo = "MX 30",
                Rueda = rueda,
                Frenos = frenos,
                Sillin = sillin
            };
            // 3) Mostramos por consola 
            Console.WriteLine(bici.MostrarInfo());
        }
    }
}
