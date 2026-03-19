using WinFormBaseDatosv1.Controllers;
using WinFormBaseDatosv1.Data;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormBaseDatosv1
{
    /// VISTA (WinForms).
    /// - Solo se encarga de la interfaz (controles, eventos, mostrar mensajes).
    /// - No contiene SQL ni reglas “serias”: eso va en Controller y Repository.
    public class Form1 : Form
    {
        // ==========================
        // CONTROLES DE LA VISTA
        // ==========================
        private DataGridView dgvProvincias;  // Tabla para mostrar registros.
        private TextBox txtId;               // Muestra el id seleccionado (solo lectura).
        private TextBox txtProvincia;        // Texto con el nombre de la provincia.

        private Button btnCargar;            // Refresca el grid.
        private Button btnInsertar;          // Inserta un registro.
        private Button btnModificar;         // Modifica el registro seleccionado.
        private Button btnEliminar;          // Elimina el registro seleccionado.
        private Button btnLimpiar;           // Limpia campos.

        // ==========================
        // CONTROLADOR (NEGOCIO)
        // ==========================
        private readonly ProvinciasController _controller;

        public Form1()
        {
            // 1) Construimos la interfaz por código (no necesitamos Designer).
            InitializeComponent();

            // 2) Creamos Repository y Controller (inyección simple por constructor).
            var repo = new ProvinciaRepository(DbConfig.ConnectionString);
            _controller = new ProvinciasController(repo);

            // 3) Ajustes del grid para trabajar cómodo.
            PrepararGrid();

            // 4) Cargamos datos al iniciar.
            CargarProvincias();
        }

        // ==========================================
        // “DISEÑO” DEL FORM (SIN DESIGNER)
        // ==========================================
        private void InitializeComponent()
        {
            // Propiedades básicas del formulario.
            this.Text = "Gestión de Provincias (CRUD) - SQL Server LocalDB";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(900, 520);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // ==========================
            // GRID
            // ==========================
            dgvProvincias = new DataGridView();
            dgvProvincias.Location = new Point(20, 20);
            dgvProvincias.Size = new Size(540, 420);

            // Evento: cuando el usuario hace clic en una celda/fila.
            dgvProvincias.CellClick += dgvProvincias_CellClick;

            // ==========================
            // LABEL + TXT ID
            // ==========================
            var lblId = new Label();
            lblId.Text = "ID:";
            lblId.Location = new Point(590, 40);
            lblId.AutoSize = true;

            txtId = new TextBox();
            txtId.Location = new Point(590, 65);
            txtId.Size = new Size(260, 25);

            // Importantísimo: el ID NO se escribe a mano.
            txtId.ReadOnly = false;

            // ==========================
            // LABEL + TXT PROVINCIA
            // ==========================
            var lblProvincia = new Label();
            lblProvincia.Text = "Provincia:";
            lblProvincia.Location = new Point(590, 105);
            lblProvincia.AutoSize = true;

            txtProvincia = new TextBox();
            txtProvincia.Location = new Point(590, 130);
            txtProvincia.Size = new Size(260, 25);

            // ==========================
            // BOTONES
            // ==========================
            btnCargar = new Button();
            btnCargar.Text = "Cargar";
            btnCargar.Location = new Point(590, 185);
            btnCargar.Size = new Size(120, 35);
            btnCargar.Click += btnCargar_Click;

            btnLimpiar = new Button();
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Location = new Point(730, 185);
            btnLimpiar.Size = new Size(120, 35);
            btnLimpiar.Click += btnLimpiar_Click;

            btnInsertar = new Button();
            btnInsertar.Text = "Insertar";
            btnInsertar.Location = new Point(590, 235);
            btnInsertar.Size = new Size(260, 35);
            btnInsertar.Click += btnInsertar_Click;

            btnModificar = new Button();
            btnModificar.Text = "Modificar";
            btnModificar.Location = new Point(590, 285);
            btnModificar.Size = new Size(260, 35);
            btnModificar.Click += btnModificar_Click;

            btnEliminar = new Button();
            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(590, 335);
            btnEliminar.Size = new Size(260, 35);
            btnEliminar.Click += btnEliminar_Click;

            // ==========================
            // AÑADIMOS AL FORM
            // ==========================
            this.Controls.Add(dgvProvincias);

            this.Controls.Add(lblId);
            this.Controls.Add(txtId);

            this.Controls.Add(lblProvincia);
            this.Controls.Add(txtProvincia);

            this.Controls.Add(btnCargar);
            this.Controls.Add(btnLimpiar);
            this.Controls.Add(btnInsertar);
            this.Controls.Add(btnModificar);
            this.Controls.Add(btnEliminar);
        }

        private void PrepararGrid()
        {
            // Evita la fila “vacía” al final del grid.
            dgvProvincias.AllowUserToAddRows = false;

            // Bloquea edición directa en el grid (editamos con botones).
            dgvProvincias.ReadOnly = true;

            // Selección de fila completa.
            dgvProvincias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Solo permite una fila seleccionada.
            dgvProvincias.MultiSelect = false;

            // Ajuste automático del ancho de columnas.
            dgvProvincias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ==========================================
        // CARGAR Y MOSTRAR DATOS
        // ==========================================
        private void CargarProvincias()
        {
            try
            {
                // Pedimos al controlador un DataTable listo para DataGridView.
                DataTable tabla = _controller.ListarTabla();

                // Enlazamos la tabla al grid.
                dgvProvincias.DataSource = tabla;

                // Cambiamos títulos para que el usuario lo vea más claro.
                if (dgvProvincias.Columns["idprovincia"] != null)
                    dgvProvincias.Columns["idprovincia"].HeaderText = "ID";

                if (dgvProvincias.Columns["provincia"] != null)
                    dgvProvincias.Columns["provincia"].HeaderText = "Provincia";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincias: " + ex.Message);
            }
        }

        private void dgvProvincias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si el usuario pulsa en la cabecera, RowIndex será -1.
            if (e.RowIndex < 0) return;

            // Cogemos la fila clicada.
            DataGridViewRow fila = dgvProvincias.Rows[e.RowIndex];

            // Pasamos datos al formulario (cajas de texto).
            txtId.Text = Convert.ToString(fila.Cells["idprovincia"].Value);
            txtProvincia.Text = Convert.ToString(fila.Cells["provincia"].Value);
        }

        // ==========================================
        // BOTONES (CRUD)
        // ==========================================
        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Refrescamos el grid.
            CargarProvincias();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Leemos el nombre desde la pantalla.
                string nombre = txtProvincia.Text;

                // 2) Insertamos (el Controller valida que no esté vacío).
                int nuevoId = int.Parse(txtId.Text);
                int error = _controller.Crear(nuevoId, nombre);


                // 3) Informamos al usuario.
                MessageBox.Show("Insertado correctamente. ID = " + nuevoId);

                // 4) Refrescamos y limpiamos.
                CargarProvincias();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Si no hay ID seleccionado, no sabemos qué modificar.
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Selecciona una fila para modificar.");
                    return;
                }

                // Leemos datos desde la pantalla.
                int id = Convert.ToInt32(txtId.Text);
                string nombre = txtProvincia.Text;

                // Pedimos al Controller que modifique.
                bool ok = _controller.Modificar(id, nombre);

                // Mensaje según resultado.
                MessageBox.Show(ok ? "Modificado correctamente." : "No se encontró el registro para modificar.");

                // Refrescamos y limpiamos.
                CargarProvincias();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Si no hay ID seleccionado, no sabemos qué eliminar.
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Selecciona una fila para eliminar.");
                    return;
                }

                int id = Convert.ToInt32(txtId.Text);

                // Confirmación para evitar borrados por accidente.
                DialogResult r = MessageBox.Show(
                    "¿Seguro que quieres eliminar el ID " + id + "?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (r != DialogResult.Yes)
                    return;

                // Eliminamos mediante el Controller.
                bool ok = _controller.Eliminar(id);

                // Mensaje según resultado.
                MessageBox.Show(ok ? "Eliminado correctamente." : "No se encontró el registro para eliminar.");

                // Refrescamos y limpiamos.
                CargarProvincias();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Deja el formulario listo para insertar otra provincia.
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtProvincia.Clear();

            // Ponemos el cursor en el campo provincia para escribir rápido.
            txtProvincia.Focus();
        }
    }
}
