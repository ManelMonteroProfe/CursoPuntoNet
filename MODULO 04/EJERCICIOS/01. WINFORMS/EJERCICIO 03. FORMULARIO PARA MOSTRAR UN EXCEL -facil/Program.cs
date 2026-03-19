using LecturaExcelFacil;
using System;
using System.Windows.Forms;

#if NETCOREAPP
using System.Text;
#endif

namespace LecturaExcelFacil
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
