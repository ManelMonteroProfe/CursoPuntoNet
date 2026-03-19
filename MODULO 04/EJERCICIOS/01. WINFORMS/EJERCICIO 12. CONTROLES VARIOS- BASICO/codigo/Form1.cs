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
using ClosedXML.Excel;

namespace FormularioControles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Cargamos Combobox.
            /*
            cbCiudad.Items.Add("Madrid");
            cbCiudad.Items.Add("Barcelona");
            cbCiudad.Items.Add("Cádiz");
            cbCiudad.Items.Add("Sevilla");
            cbCiudad.Items.Add("Bilbao");

            cbCiudad.SelectedIndex = 0;
            */

            //Otra Forma de Cargar Combobox
            var ciudades = new List<string> { 
                "Madrid", 
                "Barcelona", 
                "Cádiz", 
                "Sevilla", 
                "Bilbao" };
            cbCiudad.DataSource = ciudades;   

        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            // Crea una fila nueva en el grid
            string sexo = "";
            if (rbHombre.Checked)
                { sexo = "H"; }
            if (rbMujer.Checked)
                { sexo = "M"; }
        
            // Cargamos una fila nueva en el GRID
            dgListado.Rows.Add(
                tbNombre.Text.Trim(),
                tbApellido.Text.Trim(),
                sexo,
                cbCiudad.Text
            );
        }

        private void ExportarGridACsv(DataGridView dg, string ruta)
        {
            var sb = new StringBuilder();

            // Cabeceras
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                sb.Append(dg.Columns[i].HeaderText);
                if (i < dg.Columns.Count - 1) sb.Append(";");
            }
            sb.AppendLine();

            // Datos
            foreach (DataGridViewRow row in dg.Rows)
            {
                if (row.IsNewRow) continue;

                for (int i = 0; i < dg.Columns.Count; i++)
                {
                    string valor = row.Cells[i].Value?.ToString()?.Replace(";", ",") ?? "";
                    sb.Append(valor);
                    if (i < dg.Columns.Count - 1) sb.Append(";");
                }
                sb.AppendLine();
            }

            // Escribimos todo el String a CSV
            File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8);
        }

        private void ExportarGridAExcel(DataGridView dgListado)
        {
            if (dgListado.Rows.Count == 0) return;

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                sfd.FileName = "Listado.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK) return;

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Datos");

                int colCount = dgListado.Columns.Count;

                // Cabeceras
                for (int c = 0; c < colCount; c++)
                    ws.Cell(1, c + 1).Value = dgListado.Columns[c].HeaderText;

                // Filas
                int filaExcel = 2;
                foreach (DataGridViewRow row in dgListado.Rows)
                {
                    if (row.IsNewRow) continue; // evita la fila vacía final

                    for (int c = 0; c < colCount; c++)
                        ws.Cell(filaExcel, c + 1).Value = row.Cells[c].Value?.ToString() ?? "";

                    filaExcel++;
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);
            }

            MessageBox.Show("Exportado correctamente.");
            }
        }
    
    private void btnExcel_Click(object sender, EventArgs e)
        {
            // Exporta a Excel el DBGRID
            ExportarGridACsv(dgListado, @"d:\proyectos\miexcel.csv");
            MessageBox.Show("Exportado");
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Exportamos Grid a Excel
            ExportarGridAExcel(dgListado);
        }
    }
}
