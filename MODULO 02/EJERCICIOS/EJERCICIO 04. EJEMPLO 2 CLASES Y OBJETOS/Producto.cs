using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almacen
{
    public class Producto
    {
        // Define Propiedades del Producto
            public int idProducto { get; set; }
            public string NomProducto { get; set; }
            public int Stock { get; set; }

        // Define los métodos del Producto
        public void Reponer(int cantidad);
		public void Vender(int cantidad);
		public void Mostrar();
    }
}
