using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dadosv2
{
    public partial class Form1 : Form
    {
        // VARIABLES
        // limite puntos juego
        int LimitePuntos = 10;
        int PuntosJugador = 0;
        string NombreJugador = "M A N E L";
        bool final = false;

        public Form1()
        {
            // JUEGO DE DADOS
            InitializeComponent();
            Text = "Juego de Dados - V1";
            Width = 1000;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;
            this.BackgroundImage = Image.FromFile(@"d:\proyectos\dadosv2\imagenes\fondo2.jpg");

            // Fuente 
            tbJuego.Font = new System.Drawing.Font("Arial", 18);
            tbJuego.ReadOnly = true;
            tbJuego.Text = "Iniciamos Juego !!!\r\n";
            Actualizar_Marcador();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lanzamiento de Dado
            var rnd = new Random();
            picboxDado.Image = Image.FromFile(@"D:\proyectos\dadosv2\imagenes\dado.gif");
            //MessageBox.Show("Lanzamos dado", "Lanzamiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int dado = rnd.Next(1, 7); // 1,2,3,4,5 o 6
            MessageBox.Show("Ha salido un: " + dado.ToString(), "RESULTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // ACUMULAMOS PUNTOS JUGADOR
            PuntosJugador += dado;

            Mostrar_Dado(dado);

            Actualizar_Marcador();
            
            Verificar_Final();
        }

        public void Actualizar_Marcador()
        {
            // JUEGO DE DADOS
            tbJuego.Text += $"OBJETIVO PUNTOS: " + LimitePuntos.ToString() + "\r\n";
            tbJuego.Text += $"NOMBRE JUGADOR: " + NombreJugador + "\r\n";
            tbJuego.Text += $"PUNTOS ACTUAL: " + PuntosJugador.ToString() + "\r\n";
        }
        public void Mostrar_Dado(int numero)
        {
            // MOSTRAR EL JPG QUE HA SALIDO
            string fichero = @"D:\proyectos\dadosv2\imagenes\dado" + numero.ToString() + ".jpg";
            picboxDado.Image = Image.FromFile(fichero);
        }

        public void Verificar_Final()
        {
            // SI SE SUPERAN LOS PUNTOS LIMITE, FINALIZA EL JUEGO
            // Y SALE DE LA APLICACIÓN
            if (PuntosJugador >= LimitePuntos)
            {
                final = true;
                MessageBox.Show("HA FINALIZADO EL JUEGO");
                Application.Exit();
            }
        }
    }
}