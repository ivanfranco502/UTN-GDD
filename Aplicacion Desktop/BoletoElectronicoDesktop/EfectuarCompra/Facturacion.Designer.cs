namespace BoletoElectronicoDesktop.Facturación
{
    partial class Facturacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBeneficiario = new System.Windows.Forms.TextBox();
            this.botSeleccionarBenficiario = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPostNet = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.botSeleccionarFecha = new System.Windows.Forms.Button();
            this.botEfectuarCompra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beneficiario:";
            // 
            // textBeneficiario
            // 
            this.textBeneficiario.Location = new System.Drawing.Point(115, 7);
            this.textBeneficiario.Name = "textBeneficiario";
            this.textBeneficiario.ReadOnly = true;
            this.textBeneficiario.Size = new System.Drawing.Size(174, 20);
            this.textBeneficiario.TabIndex = 1;
            // 
            // botSeleccionarBenficiario
            // 
            this.botSeleccionarBenficiario.Location = new System.Drawing.Point(307, 5);
            this.botSeleccionarBenficiario.Name = "botSeleccionarBenficiario";
            this.botSeleccionarBenficiario.Size = new System.Drawing.Size(129, 23);
            this.botSeleccionarBenficiario.TabIndex = 2;
            this.botSeleccionarBenficiario.Text = "Seleccionar";
            this.botSeleccionarBenficiario.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PostNet:";
            // 
            // comboBoxPostNet
            // 
            this.comboBoxPostNet.FormattingEnabled = true;
            this.comboBoxPostNet.Location = new System.Drawing.Point(115, 33);
            this.comboBoxPostNet.Name = "comboBoxPostNet";
            this.comboBoxPostNet.Size = new System.Drawing.Size(173, 21);
            this.comboBoxPostNet.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Número de tarjeta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Monto:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(115, 112);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 20);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(114, 86);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(174, 20);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(114, 60);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(174, 20);
            this.textBox4.TabIndex = 10;
            // 
            // botSeleccionarFecha
            // 
            this.botSeleccionarFecha.Location = new System.Drawing.Point(307, 84);
            this.botSeleccionarFecha.Name = "botSeleccionarFecha";
            this.botSeleccionarFecha.Size = new System.Drawing.Size(129, 23);
            this.botSeleccionarFecha.TabIndex = 11;
            this.botSeleccionarFecha.Text = "Seleccionar";
            this.botSeleccionarFecha.UseVisualStyleBackColor = true;
            // 
            // botEfectuarCompra
            // 
            this.botEfectuarCompra.Location = new System.Drawing.Point(150, 165);
            this.botEfectuarCompra.Name = "botEfectuarCompra";
            this.botEfectuarCompra.Size = new System.Drawing.Size(138, 24);
            this.botEfectuarCompra.TabIndex = 12;
            this.botEfectuarCompra.Text = "Efectuar compra";
            this.botEfectuarCompra.UseVisualStyleBackColor = true;
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 200);
            this.Controls.Add(this.botEfectuarCompra);
            this.Controls.Add(this.botSeleccionarFecha);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPostNet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botSeleccionarBenficiario);
            this.Controls.Add(this.textBeneficiario);
            this.Controls.Add(this.label1);
            this.Name = "Facturacion";
            this.Text = "Facturación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBeneficiario;
        private System.Windows.Forms.Button botSeleccionarBenficiario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPostNet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button botSeleccionarFecha;
        private System.Windows.Forms.Button botEfectuarCompra;
    }
}