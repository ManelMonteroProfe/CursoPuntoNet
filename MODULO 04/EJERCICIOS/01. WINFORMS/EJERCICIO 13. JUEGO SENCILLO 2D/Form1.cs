using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace juego2D
{
    //Juego muy sencillo de pelota Rebotando
    public partial class Form1 : Form
    {
        // --- Variables de la pelota ---
        private int pelotaX = 50;        // Posición X (horizontal)
        private int pelotaY = 50;        // Posición Y (vertical)
        private int Tamano = 80;     // Tamaño (diámetro) de la pelota

        // Velocidad: cuántos píxeles avanza por "tick" del timer
        private int velocidadX = 5;
        private int velocidadY = 4;

        // Timer para animar el juego (simula FPS)
        private Timer timer;

        public Form1()
        {
            InitializeComponent();

            // Evita parpadeo al repintar
            this.DoubleBuffered = true;

            // (Opcional) título y tamaño inicial
            this.Text = "Juego de Pelota (WinForms)";
            this.ClientSize = new Size(900, 600);

            // Crear y configurar el Timer
            timer = new Timer();
            // Repinta cada 16 milisegundos
            timer.Interval = 16; // ~60 FPS (1000ms/60 ≈ 16ms)
            timer.Tick += Timer_Tick;
            timer.Start();

            // Evento que se dispara cuando hay que dibujar
            this.Paint += Form1_Paint;
        }

        // 1) Aquí actualizamos Posiciones: mover y rebotar
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Mover la pelota
            pelotaX += velocidadX;
            pelotaY += velocidadY;

            // Calcular límites (bordes del formulario)
            int leftLimit = 0;
            int topLimit = 0;
            int rightLimit = this.ClientSize.Width - Tamano;
            int bottomLimit = this.ClientSize.Height - Tamano;

            // Rebotar en el borde izquierdo o derecho
            if (pelotaX <= leftLimit)
            {
                pelotaX = leftLimit;     // “encajamos” para que no se salga
                velocidadX *= -1;          // invertir dirección horizontal
            }
            else if (pelotaX >= rightLimit)
            {
                pelotaX = rightLimit;
                velocidadX *= -1;
            }

            // Rebotar en el borde superior o inferior
            if (pelotaY <= topLimit)
            {
                pelotaY = topLimit;
                velocidadY *= -1;          // invertir dirección vertical
            }
            else if (pelotaY >= bottomLimit)
            {
                pelotaY = bottomLimit;
                velocidadY *= -1;
            }

            // Pedimos que el formulario se repinte
            // (para ver el movimiento)
            this.Invalidate();
        }

        // 2) Aquí dibujamos la pelota
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Fondo. Fácil cambiar color de fondo,
            e.Graphics.Clear(Color.LightGreen);

            // Dibujar la pelota: un círculo (elipse con ancho = alto)
            // BRUSH es el Pincel de color (Relleno)
            // Para cambiar el color, cambia Color.Blue por el color que quieras
            using (Brush brush = new SolidBrush(Color.Blue))
            {
                e.Graphics.FillEllipse(brush, pelotaX, pelotaY, Tamano, Tamano);
            }

            // (Opcional) dibujar borde a la pelota
            // grosor Borde 3 con Objeto Pen
            using (Pen pen = new Pen(Color.Black, 3))
            {
                e.Graphics.DrawEllipse(pen, pelotaX, pelotaY, Tamano, Tamano);
            }
        }
    }
}