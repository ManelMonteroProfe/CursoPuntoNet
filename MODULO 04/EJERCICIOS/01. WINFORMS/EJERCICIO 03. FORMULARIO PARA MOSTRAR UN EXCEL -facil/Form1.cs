using System.Data;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace LecturaExcelFacil
{
    /// EJEMPLO MUY SENCILLO:
    /// - Botón "Cargar" -> lee un Excel desde una RUTA FIJA
    /// - Muestra la hoja "Provincias" en un DataGridView
    ///
    /// NuGet necesarios:
    /// - ExcelDataReader
    /// - ExcelDataReader.DataSet
    public partial class Form1 : Form
    {
        // RUTA FIJA (cámbiala en tu PC)
        private const string RUTA_EXCEL = @"d:\proyectos\provincias.xlsx";

        private readonly Button btnCargar = new Button();
        private readonly DataGridView dgv = new DataGridView();

        public Form1()
        {
            InitializeComponent();

            Text = "Excel -> DataGridView layout con Dock";
            Width = 800;
            Height = 500;

            // ===== Layout SIN coordenadas (sin Location / Size) =====
            // 1) Barra superior para el botón
            var barra = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(16)
            };

            btnCargar.Text = "Cargar Hoja";
            btnCargar.AutoSize = true;          // ✅ sin Size
            btnCargar.Dock = DockStyle.Left;    // ✅ sin Location
            btnCargar.Click += (s, e) => CargarExcelEnGrid();

            barra.Controls.Add(btnCargar);

            // 2) Grid ocupando el resto
            dgv.Dock = DockStyle.Fill;          // sin Location / Size
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            Controls.Add(dgv);
            Controls.Add(barra);
        }

        private void CargarExcelEnGrid()
        {
            // 1) Abrimos el Excel
            var stream = File.Open(RUTA_EXCEL, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // 2) Creamos el lector (detecta XLS/XLSX)
            var reader = ExcelReaderFactory.CreateReader(stream);

            // 3) Convertimos a DataSet (tablas en memoria) usando cabeceras
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true // primera fila = cabeceras
                }
            };

            DataSet ds = reader.AsDataSet(conf);

            // 4) Cogemos la hoja "Provincias" y la mostramos en el grid
            DataTable dt = ds.Tables["Provincias"];
            dgv.DataSource = dt;
        }
    }
}
