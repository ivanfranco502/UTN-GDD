namespace BoletoElectronicoDesktop.Facturación
{
    partial class Saldo
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSaldo = new System.Windows.Forms.Label();
            this.botAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Location = new System.Drawing.Point(12, 9);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(35, 13);
            this.labelSaldo.TabIndex = 0;
            this.labelSaldo.Text = "label1";
            // 
            // botAceptar
            // 
            this.botAceptar.Location = new System.Drawing.Point(50, 48);
            this.botAceptar.Name = "botAceptar";
            this.botAceptar.Size = new System.Drawing.Size(131, 23);
            this.botAceptar.TabIndex = 1;
            this.botAceptar.Text = "Aceptar";
            this.botAceptar.UseVisualStyleBackColor = true;
            this.botAceptar.Click += new System.EventHandler(this.botAceptar_Click);
            // 
            // Saldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 79);
            this.ControlBox = false;
            this.Controls.Add(this.botAceptar);
            this.Controls.Add(this.labelSaldo);
            this.Name = "Saldo";
            this.Text = "Saldo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Button botAceptar;
    }
}