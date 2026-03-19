using System;
using System.IO;
using System.Windows.Forms;
// Se necesita INSTALAR este componente con NUGET
using Microsoft.Web.WebView2.WinForms;

namespace LecturaPdf
{
    public partial class Form1 : Form
    {
        private readonly Button btnAbrir = new Button();
        private readonly WebView2 web = new WebView2();

        public Form1()
        {
            Text = "Visor PDF (WebView2)";
            Width = 1000;
            Height = 700;

            btnAbrir.Text = "Abrir PDF...";
            btnAbrir.Dock = DockStyle.Top;
            btnAbrir.Height = 45;
            btnAbrir.Click += (s, e) => AbrirPdf();

            web.Dock = DockStyle.Fill;

            Controls.Add(web);
            Controls.Add(btnAbrir);
        }

        private async void AbrirPdf()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "PDF (*.pdf)|*.pdf";
            ofd.Title = "Selecciona un PDF";

            ofd.ShowDialog();

            // necesario para inicializar el control
            await web.EnsureCoreWebView2Async();

            // cargar PDF local (convertimos a URI file:///)
            web.CoreWebView2.Navigate(new Uri(ofd.FileName).AbsoluteUri);
        }
    }
}