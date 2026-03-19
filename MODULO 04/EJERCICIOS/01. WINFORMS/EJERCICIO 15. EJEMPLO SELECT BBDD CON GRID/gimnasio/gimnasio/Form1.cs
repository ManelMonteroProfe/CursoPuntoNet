using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gimnasio
{
    public partial class Form1 : Form
    {
        private MenuStrip menu;
        private DataGridView grid;
        public Form1()
        {
            InitializeComponent();
            Text = "MOSTRAR TABLA Provincias (base datos: bdprueba01)";
            Width = 800;
            Height = 450;
            StartPosition = FormStartPosition.CenterScreen;
            CrearMenu();
            CrearGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarProvincias();
        }
        private void CrearMenu()
        {
            menu = new MenuStrip();

            // "Archivo" (solo como categoría, sin acción)
            var mArchivo = new ToolStripMenuItem("Archivo");

            // "Acerca de" -> abre Formulario modal
            var mAcerca = new ToolStripMenuItem("Acerca de");
            mAcerca.Click += mAcerca_Click;

            // "Salir" -> cierra la app
            var mSalir = new ToolStripMenuItem("Salir");
            mSalir.Click += Salir_Click;

            menu.Items.AddRange(new ToolStripItem[] { mArchivo, mAcerca, mSalir });
            MainMenuStrip = menu;
            Controls.Add(menu);
        }

        private void CrearGrid()
        {
            grid = new DataGridView
            {
                Left = 10,
                Top = 40,
                Width = 760,
                Height = 350,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(grid);
        }

        /// Hace un SELECT a la tabla provincias y lo muestra en el DataGridView.
        private void CargarProvincias()
        {
            try
            {
                // Tabla: provincias (idprovincia, provincia)
                grid.DataSource = Db.Query("SELECT idprovincia, provincia FROM provincias ORDER BY idprovincia");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la tabla provincias.\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Opción de Menu ACERCA DE
        private void mAcerca_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog(); // modal, sin indicar padre
        }

        // Opción de Menu SALIR
        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
