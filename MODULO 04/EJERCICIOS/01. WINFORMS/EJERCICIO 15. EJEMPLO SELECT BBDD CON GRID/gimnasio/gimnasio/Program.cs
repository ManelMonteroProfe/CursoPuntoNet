using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gimnasio
{
    internal static class Program
    {
        // Punto de entrada principal para la aplicación.
        [STAThread]
        // Indica que se trabaja en modo de "UNICO HILO EJECUCION"
        // "Single Thread Apartment"
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
