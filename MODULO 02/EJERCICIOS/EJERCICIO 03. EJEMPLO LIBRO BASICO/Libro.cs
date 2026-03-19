using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juegodados
{
    public class Libro
    {
        // Define Propiedades del Libro
            public string Titulo { get; set; }
            public string Autor { get; set; }

        // Define los métodos del Libro
        public void Mostrar() => Console.WriteLine($"{Titulo} ({Autor})");

    }
}
