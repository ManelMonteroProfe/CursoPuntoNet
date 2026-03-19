namespace dadosv1
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
            this.SuspendLayout();
            // 
            // tbJuego
            // 
            this.tbJuego.Location = new System.Drawing.Point(25, 34);
            this.tbJuego.Multiline = true;
            this.tbJuego.Name = "tbJuego";
            this.tbJuego.Size = new System.Drawing.Size(806, 564);
            this.tbJuego.TabIndex = 0;
            // 
            // btnLanzar
            // 
            this.btnLanzar.Location = new System.Drawing.Point(848, 517);
            this.btnLanzar.Name = "btnLanzar";
            this.btnLanzar.Size = new System.Drawing.Size(168, 62);
            this.btnLanzar.TabIndex = 1;
            this.btnLanzar.Text = "Lanzar Dado";
            this.btnLanzar.UseVisualStyleBackColor = true;
            this.btnLanzar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 610);
            this.Controls.Add(this.btnLanzar);
            this.Controls.Add(this.tbJuego);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbJuego;
        private System.Windows.Forms.Button btnLanzar;
    }
}

