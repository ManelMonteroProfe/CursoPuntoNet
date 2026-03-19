using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M5errores
{
    public partial class Form1 : Form
    {
        // 1) Lista de ciudades (lo pide el ejercicio)
        private List<string> lista_ciudades = new List<string>
        {
            "Madrid", "Barcelona", "Valencia", "Sevilla", "Zaragoza",
            "Málaga", "Bilbao", "Murcia", "Valladolid", "Alicante"
        };

        // 2) Controles
        private TextBox txtCiudad;
        private Button btnComprobar;
        private Label lblResultado;

        public Form1()
        {
            Text = "Comprobar ciudad (try–catch–finally)";
            Width = 520;
            Height = 220;
            StartPosition = FormStartPosition.CenterScreen;

            CrearControles();
        }

        private void CrearControles()
        {
            var lbl = new Label
            {
                Text = "Escribe una ciudad:",
                Left = 20,
                Top = 20,
                AutoSize = true
            };

            txtCiudad = new TextBox
            {
                Name = "txtCiudad",
                Left = 20,
                Top = 50,
                Width = 300
            };

            btnComprobar = new Button
            {
                Name = "btnComprobar",
                Text = "Comprobar",
                Left = 340,
                Top = 48,
                Width = 120
            };

            // Evento Click (FACIL)
            btnComprobar.Click += btnComprobar_Click;

            lblResultado = new Label
            {
                Name = "lblResultado",
                Text = "Resultado:",
                Left = 20,
                Top = 95,
                Width = 440,
                Height = 40
            };

            Controls.Add(lbl);
            Controls.Add(txtCiudad);
            Controls.Add(btnComprobar);
            Controls.Add(lblResultado);
        }

        // 3) Evento del botón con try–catch–finally
        // Es lo principal del programa
        private void btnComprobar_Click(object sender, EventArgs e)
        {
            try
            {
                // A) Leer y limpiar espacios
                string ciudad = txtCiudad.Text.Trim();

                // B) Validación básica con Lanzamiento de Excepción
                if (string.IsNullOrWhiteSpace(ciudad))
                    throw new Exception("Debes escribir el nombre de una ciudad.");

                // (Opcional) Evitar números
                if (ciudad.Any(char.IsDigit))
                    throw new Exception("El nombre de una ciudad no debe contener números.");

                // C) Comprobar si existe (ignorando mayúsculas/minúsculas)
                bool existe = lista_ciudades.Any(c => c.Equals(ciudad, StringComparison.OrdinalIgnoreCase));

                // D) Mostrar resultado
                if (existe)
                    lblResultado.Text = "Resultado: La ciudad SÍ existe en la lista.";
                else
                    lblResultado.Text = "Resultado: La ciudad NO existe en la lista.";
            }
            catch (Exception ex)
            {
                // Si hay un error, lo mostramos
                lblResultado.Text = "Resultado: " + ex.Message;
            }
            finally
            {
                // El finally Se ejecuta SIEMPRE
                txtCiudad.Clear();
                txtCiudad.Focus();
            }
        }
    }
}
