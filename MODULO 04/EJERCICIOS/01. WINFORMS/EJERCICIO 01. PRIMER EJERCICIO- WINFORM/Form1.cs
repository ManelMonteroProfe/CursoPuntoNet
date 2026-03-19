using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinForm01
{
    // Primer Programa De winforms
        
    public partial class Form1 : Form
    {
        // Declaramos el TextBox como campo para poder usarlo desde varios métodos
        private TextBox txtTexto;
        public Form1()
        {
            // Inicializa el Formulario
            InitializeComponent();
            // Creamos y configuramos el TextBox
            CrearControles();
            // Metemos texto con varias líneas
            CargarTextoDeEjemplo();
            CargarArchivoEnTextBox();
        }

        private void CrearControles()
        {
            // Creamos el TextBox
            txtTexto = new TextBox();

            // Propiedades importantes para “varias líneas”
            txtTexto.Multiline = true;                      // Permite varias líneas
            txtTexto.ScrollBars = ScrollBars.Vertical;      // Barra de scroll vertical
            txtTexto.WordWrap = true;                       // Ajusta palabras al ancho del control

            // Opcional: si solo quieres mostrar (no editar)
            txtTexto.ReadOnly = true;

            // Ocupa todo el formulario (se adapta al redimensionar)
            txtTexto.Dock = DockStyle.Fill;

            // Fuente un poco más “de lectura” (opcional)
            txtTexto.Font = new System.Drawing.Font("Arial", 25);

            // Añadimos el control al formulario
            this.Controls.Add(txtTexto);

            // Título del formulario (opcional)
            this.Text = "Visor de texto (multilínea)";
        }

        private void CargarTextoDeEjemplo()
        {
            // \r\n es salto de línea en Windows
            txtTexto.Text =
                "Línea 1: Hola WinForms\r\n" +
                "Línea 2: Este TextBox es multilínea\r\n" +
                "Línea 3: Con scroll vertical\r\n" +
                "Línea 4: Puedes pegar un texto largo aquí...\r\n" +
                "Línea 5: Fin.";
        }
        private void CargarArchivoEnTextBox()
        {
            string ruta = @"D:\proyectos\WinForm01\manel.txt";

            try
            {
                if (!File.Exists(ruta))
                {
                    MessageBox.Show($"No se encuentra el archivo:\n{ruta}",
                                    "Archivo no encontrado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                string contenido = File.ReadAllText(ruta);
                txtTexto.Text = contenido;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer el archivo:\n{ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* al cargar el formulario */
        }
    }
}
