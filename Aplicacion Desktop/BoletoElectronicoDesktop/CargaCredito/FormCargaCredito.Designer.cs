namespace BoletoElectronicoDesktop.CargaCredito
{
    partial class FormCargaCredito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.botCargarCredito = new System.Windows.Forms.Button();
            this.botSeleccionarFecha = new System.Windows.Forms.Button();
            this.textNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.textFecha = new System.Windows.Forms.TextBox();
            this.textMonto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botCargarCredito
            // 
            this.botCargarCredito.Location = new System.Drawing.Point(147, 117);
            this.botCargarCredito.Name = "botCargarCredito";
            this.botCargarCredito.Size = new System.Drawing.Size(138, 24);
            this.botCargarCredito.TabIndex = 20;
            this.botCargarCredito.Text = "Cargar Crédito";
            this.botCargarCredito.UseVisualStyleBackColor = true;
            this.botCargarCredito.Click += new System.EventHandler(this.botCargarCredito_Click);
            // 
            // botSeleccionarFecha
            // 
            this.botSeleccionarFecha.Location = new System.Drawing.Point(304, 36);
            this.botSeleccionarFecha.Name = "botSeleccionarFecha";
            this.botSeleccionarFecha.Size = new System.Drawing.Size(129, 23);
            this.botSeleccionarFecha.TabIndex = 19;
            this.botSeleccionarFecha.Text = "Seleccionar";
            this.botSeleccionarFecha.UseVisualStyleBackColor = true;
            this.botSeleccionarFecha.Click += new System.EventHandler(this.botSeleccionarFecha_Click);
            // 
            // textNumeroTarjeta
            // 
            this.textNumeroTarjeta.Location = new System.Drawing.Point(111, 12);
            this.textNumeroTarjeta.Name = "textNumeroTarjeta";
            this.textNumeroTarjeta.Size = new System.Drawing.Size(174, 20);
            this.textNumeroTarjeta.TabIndex = 18;
            // 
            // textFecha
            // 
            this.textFecha.Location = new System.Drawing.Point(111, 38);
            this.textFecha.Name = "textFecha";
            this.textFecha.ReadOnly = true;
            this.textFecha.Size = new System.Drawing.Size(174, 20);
            this.textFecha.TabIndex = 17;
            // 
            // textMonto
            // 
            this.textMonto.Location = new System.Drawing.Point(112, 64);
            this.textMonto.Name = "textMonto";
            this.textMonto.Size = new System.Drawing.Size(174, 20);
            this.textMonto.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Monto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Número de tarjeta:";
            // 
            // FormCargaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 147);
            this.Controls.Add(this.botCargarCredito);
            this.Controls.Add(this.botSeleccionarFecha);
            this.Controls.Add(this.textNumeroTarjeta);
            this.Controls.Add(this.textFecha);
            this.Controls.Add(this.textMonto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "FormCargaCredito";
            this.Text = "Carga de crédito";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botCargarCredito;
        private System.Windows.Forms.Button botSeleccionarFecha;
        private System.Windows.Forms.TextBox textNumeroTarjeta;
        private System.Windows.Forms.TextBox textFecha;
        private System.Windows.Forms.TextBox textMonto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}