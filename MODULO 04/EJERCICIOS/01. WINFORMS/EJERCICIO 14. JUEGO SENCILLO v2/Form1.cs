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

namespace juego2D_v2
{
    public partial class Form1 : Form
    {
        // ------------------ PELOTA ------------------
        private int ballX = 220;
        private int ballY = 120;
        private int ballSize = 30;

        private int speedX = 5;
        private int speedY = 4;

        // ------------------ PORTERÍA (IMAGEN) ------------------
        private Bitmap goalImg;           // imagen cargada desde porteria.png
        private int goalX = 10;           // siempre al lado izquierdo
        private int goalY = 160;          // se mueve con flechas
        private int goalW = 45;           // tamaño dibujado (puedes ajustarlo)
        private int goalH = 160;

        // Movimiento de la portería
        private int goalSpeedY = 0;
        private int goalMoveSpeed = 7;

        // ------------------ TIMER (bucle) ------------------
        private Timer timer;

        public Form1()
        {
            InitializeComponent();

            // Evita parpadeos al animar
            this.DoubleBuffered = true;

            // Para que el Form capture teclas aunque haya controles
            this.KeyPreview = true;

            this.Text = "Pelota rebotando + Portería (PNG) MOVIL";
            this.ClientSize = new Size(900, 600);

            // Cargar imagen desde archivo (porteria.png)
            CargarPorteriaPNG();

            // Eventos de dibujo y teclado
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            // Timer (≈60 FPS)
            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void CargarPorteriaPNG()
        {
            // Buscamos porteria.png en la carpeta donde se ejecuta el .exe
            string ruta = Path.Combine(Application.StartupPath, "porteria.png");

            if (!File.Exists(ruta))
            {
                MessageBox.Show(
                    "No se encuentra 'porteria.png' en:\n" + ruta +
                    "\n\nCopia la imagen a la carpeta (bin\\Debug...) ",
                    "Imagen no encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                // Cerramos la app para no seguir sin imagen
                this.Close();
                return;
            }

            // Cargamos el PNG como Bitmap
            goalImg = (Bitmap)Image.FromFile(ruta);
        }

        // 1) LÓGICA: mover portería + mover pelota + rebotes + colisión
        private void Timer_Tick(object sender, EventArgs e)
        {
            // ----- mover portería (vertical) -----
            goalY += goalSpeedY;

            // Limitar la portería para que no se salga
            int topLimit = 0;
            int bottomLimit = this.ClientSize.Height - goalH;
            if (goalY < topLimit) goalY = topLimit;
            if (goalY > bottomLimit) goalY = bottomLimit;

            // ----- mover pelota -----
            ballX += speedX;
            ballY += speedY;

            // Límites para la pelota
            int leftLimit = 0;
            int rightLimit = this.ClientSize.Width - ballSize;
            int bottomBallLimit = this.ClientSize.Height - ballSize;

            // Rebote izquierda/derecha
            if (ballX <= leftLimit)
            {
                ballX = leftLimit;
                speedX *= -1;
            }
            else if (ballX >= rightLimit)
            {
                ballX = rightLimit;
                speedX *= -1;
            }

            // Rebote arriba/abajo
            if (ballY <= 0)
            {
                ballY = 0;
                speedY *= -1;
            }
            else if (ballY >= bottomBallLimit)
            {
                ballY = bottomBallLimit;
                speedY *= -1;
            }

            // ----- colisión de pelota vs portería -----
            Rectangle ballRect = new Rectangle(ballX, ballY, ballSize, ballSize);
            Rectangle goalRect = new Rectangle(goalX, goalY, goalW, goalH);

            if (ballRect.IntersectsWith(goalRect))
            {
                // Empujamos la pelota hacia la derecha y rebotamos
                ballX = goalX + goalW;
                speedX = Math.Abs(speedX);
            }

            // Repintar
            this.Invalidate();
        }

        // 2) DIBUJO: portería (PNG) + pelota
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            // Dibujar la portería con la imagen (escalada a goalW x goalH)
            e.Graphics.DrawImage(goalImg, goalX, goalY, goalW, goalH);

            // Dibujar la pelota
            using (Brush brush = new SolidBrush(Color.Blue))
                e.Graphics.FillEllipse(brush, ballX, ballY, ballSize, ballSize);

            using (Pen pen = new Pen(Color.Black, 2))
                e.Graphics.DrawEllipse(pen, ballX, ballY, ballSize, ballSize);
        }

        // 3) TECLADO: flechas para mover la portería
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                goalSpeedY = -goalMoveSpeed;

            if (e.KeyCode == Keys.Down)
                goalSpeedY = goalMoveSpeed;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Paramos al soltar la tecla correspondiente
            if (e.KeyCode == Keys.Up && goalSpeedY < 0)
                goalSpeedY = 0;

            if (e.KeyCode == Keys.Down && goalSpeedY > 0)
                goalSpeedY = 0;
        }

        // liberar recursos Al final
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timer?.Stop();
            goalImg?.Dispose();
            base.OnFormClosed(e);
        }
    }
}