using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Recomendado para que la imagen se vea bien
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle; // opcional
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            // Se abre el OPEN FILE DIALOG y CARGA UNA IMAGEN
            
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Selecciona una imagen JPG";
                ofd.Filter = "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Todos los archivos (*.*)|*.*";
                ofd.Multiselect = false;
                ofd.CheckFileExists = true;

                // Opcional: abre en la carpeta Imágenes del usuario
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Importante: si ya había una imagen, liberamos recursos
                        if (pictureBox1.Image != null)
                        {
                            var old = pictureBox1.Image;
                            pictureBox1.Image = null;
                            old.Dispose();
                        }

                        // Cargamos la imagen evitando bloquear el fichero (copia a memoria)
                        using (var fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            pictureBox1.Image = Image.FromStream(fs);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "No se pudo cargar la imagen.\n\nDetalle: " + ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCargaDirecta_Click(object sender, EventArgs e)
        {
            // Carga una imagen del disco directamente  en el fondo
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BackgroundImage = Image.FromFile(@"D:\imagenes\fondo.jpg");
            
            // Carga imagen en primer plano (TAPA LA DEL FONDO)
            pictureBox2.Image = Image.FromFile(@"D:\imagenes\dado.gif");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            // Carga imagen en primer plano (TAPA LA DEL FONDO)
            pictureBox2.Image = Image.FromFile(@"D:\imagenes\dado6.jpg");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
