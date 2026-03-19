using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juegodados
{
    /* DEFINICION CLASE JUGADOR */
    public class Jugador
    {
        // Define Propiedades del Jugador
        public string Nombre { get; set; }
        public int Puntuacion { get; set; }

        // Define los métodos del Jugador
        public void Mostrar() => Console.WriteLine($"Jugador: {Nombre} -->> ({Puntuacion} Puntos.)");

    }


    /* DEFINICION CLASE DADO */
    public class Dado
    {
        // Define Propiedades del Dado
        // Codigo del dado : 1, 2, ......
        private readonly Random _rnd = new Random();
        public int Codigo { get; set; }
        public int NumCaras { get; set; }
        public int Valor { get; set; }
        
		// Define los métodos del Dado
        public int Tirada()
        {
            int resultado = _rnd.Next(1, NumCaras + 1);
            Console.WriteLine($"Dado Muestra un :{resultado}");
            return resultado;
        }
    }
}
