namespace dadosv2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbJuego = new System.Windows.Forms.TextBox();
            this.btnLanzar = new System.Windows.Forms.Button();
            this.picboxDado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxDado)).BeginInit();
            this.SuspendLayout();
            // 
            // tbJuego
            // 
            this.tbJuego.Location = new System.Drawing.Point(9, 18);
            this.tbJuego.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbJuego.Multiline = true;
            this.tbJuego.Name = "tbJuego";
            this.tbJuego.Size = new System.Drawing.Size(515, 516);
            this.tbJuego.TabIndex = 0;
            // 
            // btnLanzar
            // 
            this.btnLanzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLanzar.Location = new System.Drawing.Point(863, 18);
            this.btnLanzar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLanzar.Name = "btnLanzar";
            this.btnLanzar.Size = new System.Drawing.Size(192, 62);
            this.btnLanzar.TabIndex = 1;
            this.btnLanzar.Text = "Lanzar Dado";
            this.btnLanzar.UseVisualStyleBackColor = true;
            this.btnLanzar.Click += new System.EventHandler(this.button1_Click);
            // 
            // picboxDado
            // 
            this.picboxDado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picboxDado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picboxDado.Location = new System.Drawing.Point(528, 18);
            this.picboxDado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picboxDado.Name = "picboxDado";
            this.picboxDado.Size = new System.Drawing.Size(320, 244);
            this.picboxDado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxDado.TabIndex = 2;
            this.picboxDado.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1128, 545);
            this.Controls.Add(this.picboxDado);
            this.Controls.Add(this.btnLanzar);
            this.Controls.Add(this.tbJuego);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picboxDado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbJuego;
        private System.Windows.Forms.Button btnLanzar;
        private System.Windows.Forms.PictureBox picboxDado;
    }
}

