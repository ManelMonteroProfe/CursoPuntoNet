using System;
using System.Windows.Forms;

namespace WinFormBaseDatosv1
{
    internal static class Program
    {
        // Punto de entrada de la aplicación (WinForms).
        [STAThread]
        static void Main()
        {
            // Activa estilos visuales (típico en .NET Framework).
            Application.EnableVisualStyles();

            // Configuración clásica de renderizado de texto.
            Application.SetCompatibleTextRenderingDefault(false);

            // Abre el formulario principal.
            Application.Run(new Form1());
        }
    }
}
