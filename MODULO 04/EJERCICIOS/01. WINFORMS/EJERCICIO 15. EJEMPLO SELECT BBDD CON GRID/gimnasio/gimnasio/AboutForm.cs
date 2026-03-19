using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace gimnasio
{
    /// Formulario modal "Acerca de".
    /// Un Formulario Modal es un formulario que se genera y abre en primer plano
    public class AboutForm : Form
    {
        public AboutForm()
        {
            Text = "Acerca de";
            Width = 420;
            Height = 220;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var lbl = new Label
            {
                Left = 20,
                Top = 20,
                Width = 360,
                Height = 90,
                Text = "Autor: MANEL PROFE\nFecha: " + DateTime.Now.ToString("dd/MM/yyyy")
            };

            var btnCerrar = new Button
            {
                Text = "Cerrar",
                Left = 150,
                Top = 120,
                Width = 100
            };
            btnCerrar.Click += (s, e) => Close();

            Controls.Add(lbl);
            Controls.Add(btnCerrar);
        }
    }
}
