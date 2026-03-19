using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polimorfismo01
{

    // Animal.cs
    public class Animal
    {
        // Propiedades comunes a todos los animales
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Color { get; set; }

        // Constructor
        public Animal(string nombre, int edad, string color)
        {
            Nombre = nombre;
            Edad = edad;
            Color = color;
        }

        // virtual => permite que las clases hijas lo "redefinan" (override)
        public virtual void EmitirSonido()
        {
            Console.WriteLine("Sonido genérico de animal...");
        }

        public void MostrarFicha()
        {
            Console.WriteLine($"Animal: {Nombre} | Edad: {Edad} | Color: {Color}");
        }
    }

    // CLASE PERRO. Deriva de la clase animal
    public class Perro : Animal
    {
        // Propiedades propias del perro
        public string Raza { get; set; }
        public bool EsGuardian { get; set; }

        public Perro(string nombre, int edad, string color, string raza, bool esGuardian)
            : base(nombre, edad, color) 
            // llama al constructor de la clase madre
        {
            Raza = raza;
            EsGuardian = esGuardian;
        }

        // override => cambia el comportamiento del método del padre
        public override void EmitirSonido()
        {
            Console.WriteLine("Sonido: Guau, Guau");
        }
    }

    // CLASE GATO. Deriva de la clase animal
    public class Gato : Animal
    {
        // Propiedades propias del gato
        public bool TieneBigotes { get; set; }
        public int Vidas { get; set; }

        public Gato(string nombre, int edad, string color, bool tieneBigotes, int vidas)
            : base(nombre, edad, color)
        {
            TieneBigotes = tieneBigotes;
            Vidas = vidas;
        }

        public override void EmitirSonido()
        {
            Console.WriteLine("Sonido: Miau, Miau");
        }
    }

    // CLASE PATO. Deriva de la clase animal
    public class Pato : Animal
    {
        // Propiedades propias del pato
        public bool PuedeVolar { get; set; }
        public string TipoPico { get; set; }

        public Pato(string nombre, int edad, string color, bool puedeVolar, string tipoPico)
            : base(nombre, edad, color)
        {
            PuedeVolar = puedeVolar;
            TipoPico = tipoPico;
        }

        public override void EmitirSonido()
        {
            Console.WriteLine("Sonido: Cua, Cua");
        }
    }

    // CLASE VACA. Deriva de la clase animal
    public class Vaca : Animal
    {
        // Propiedades propias de la vaca
        public bool Lunares { get; set; }
        public double Peso { get; set; }

        public Vaca(string nombre, int edad, string color, bool lunares, double peso)
            : base(nombre, edad, color)
        // llama al constructor de la clase madre
        {
            Lunares = lunares;
            Peso = peso;
        }
        public override void EmitirSonido()
        {
            Console.WriteLine("Sonido: Muuuuuuu");
        }
    }

        // PROGRAMA PRINCIPAL
        internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJEMPLO DE POLIMORFISMO EN C# ===\n");

            Console.WriteLine("Creamos 3 animales:\n");
            // Creamos animales concretos (clases hijas)
            Console.WriteLine("Perro, Gato y Pato\n");
            Animal a1 = new Perro("Rocky", 3, "Marrón", "Pastor Alemán", true);
            Animal a2 = new Gato("Misu", 2, "Blanco", true, 7);
            Animal a3 = new Pato("Donald", 1, "Amarillo", true, "Ancho");
            Animal a4 = new Vaca("Juana", 1, "BlancaNegra", true, 300);

            // Los metemos en una lista de tipo Animal (clase base)
            List<Animal> animales = new List<Animal> { a1, a2, a3, a4 };

            Console.WriteLine("Recorremos la lista y llamamos al MISMO método (EmitirSonido):\n");

            foreach (Animal animal in animales)
                {
                    animal.MostrarFicha();

                    // POLIMORFISMO:
                    // Aunque la variable sea Animal,
                    // se ejecuta la versión override
                    // del tipo real (Perro/Gato/Pato).
                    animal.EmitirSonido();

                    Console.WriteLine("-------------------------");
                }

            Console.WriteLine("\nFin. Pulsa una tecla para salir...");
            Console.ReadKey();
        }
    }
}
