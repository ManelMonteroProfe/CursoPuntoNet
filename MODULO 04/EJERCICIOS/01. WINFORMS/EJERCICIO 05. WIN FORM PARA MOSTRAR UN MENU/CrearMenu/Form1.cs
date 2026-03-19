using System;
using System.Windows.Forms;

namespace CrearMenu
{
    /// Demo MUY sencilla de Menú (MenuStrip) en WinForms.
    /// Cada opción del menú muestra un MessageBox.Show y no hace nada más.
    public partial class Form1 : Form
    {
        public Form1()
        {
            Text = "Aplicación Fácil Demostración de Menús (solo MessageBox)";
            Width = 800;
            Height = 450;
            StartPosition = FormStartPosition.CenterScreen;

            // 1) Creamos el MenuStrip (la barra superior de menús)
            var menu = new MenuStrip();

            // 2) Creamos el menú principal: ARCHIVO
            var mArchivo = new ToolStripMenuItem("ARCHIVO");

            var mEdicion = new ToolStripMenuItem("EDICION");


            // 3) Creamos cada opción del menú y la asociamos a un click (evento)
            var miConectar = new ToolStripMenuItem("CONECTAR A BASE DE DATOS");
            miConectar.Click += (s, e) => MessageBox.Show("CONECTAR A BASE DE DATOS", "Menú");

            var miAbrirTabla = new ToolStripMenuItem("ABRIR Y CARGAR TABLA");
            miAbrirTabla.Click += (s, e) => MessageBox.Show("ABRIR Y CARGAR TABLA", "Menú");

            var miInsertar = new ToolStripMenuItem("INSERTAR REGISTRO");
            miInsertar.Click += (s, e) => MessageBox.Show("INSERTAR REGISTRO", "Menú");

            var miActualizar = new ToolStripMenuItem("ACTUALIZAR REGISTRO");
            miActualizar.Click += (s, e) => MessageBox.Show("ACTUALIZAR REGISTRO", "Menú");

            var miBorrar = new ToolStripMenuItem("BORRAR REGISTRO");
            miBorrar.Click += (s, e) => MessageBox.Show("BORRAR REGISTRO", "Menú");

            // Separador visual (línea horizontal)
            var sep1 = new ToolStripSeparator();

            var miAcercaDe = new ToolStripMenuItem("ACERCA DE");
            miAcercaDe.Click += (s, e) =>
                MessageBox.Show("Demo de menús WinForms.\n(En el siguiente ejercicio meteremos código real.)", "Acerca de");

            var miSalir = new ToolStripMenuItem("SALIR");
            miSalir.Click += (s, e) => Close();

            // 4) Añadimos las opciones al menú ARCHIVO (en orden)
            mArchivo.DropDownItems.Add(miConectar);
            mArchivo.DropDownItems.Add(miAbrirTabla);
            mArchivo.DropDownItems.Add(miInsertar);
            mArchivo.DropDownItems.Add(miActualizar);
            mArchivo.DropDownItems.Add(miBorrar);
            mArchivo.DropDownItems.Add(sep1);
            mArchivo.DropDownItems.Add(miAcercaDe);
            mArchivo.DropDownItems.Add(miSalir);

            // Opciones del Menú EDICION
            mEdicion.DropDownItems.Add(miAcercaDe);

            // 5) Añadimos ARCHIVO a la barra de menús
            menu.Items.Add(mArchivo);
            menu.Items.Add(mEdicion);  // A la derecha de Archivo

            // 6) Indicamos que este MenuStrip es el menú principal del formulario
            MainMenuStrip = menu;

            // 7) Lo añadimos a los controles del formulario
            Controls.Add(menu);
        }
    }
}
