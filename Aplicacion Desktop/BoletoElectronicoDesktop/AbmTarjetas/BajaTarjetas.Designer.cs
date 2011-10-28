namespace BoletoElectronicoDesktop.AbmTarjetas
{
    partial class BajaTarjetas
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
            this.botEliminar = new System.Windows.Forms.Button();
            this.textCliente = new System.Windows.Forms.TextBox();
            this.textFechaAlta = new System.Windows.Forms.TextBox();
            this.textNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botEliminar
            // 
            this.botEliminar.Location = new System.Drawing.Point(158, 121);
            this.botEliminar.Name = "botEliminar";
            this.botEliminar.Size = new System.Drawing.Size(75, 23);
            this.botEliminar.TabIndex = 18;
            this.botEliminar.Text = "Eliminar";
            this.botEliminar.UseVisualStyleBackColor = true;
            this.botEliminar.Click += new System.EventHandler(this.botEliminar_Click);
            // 
            // textCliente
            // 
            this.textCliente.Location = new System.Drawing.Point(128, 68);
            this.textCliente.Name = "textCliente";
            this.textCliente.ReadOnly = true;
            this.textCliente.Size = new System.Drawing.Size(230, 20);
            this.textCliente.TabIndex = 16;
            // 
            // textFechaAlta
            // 
            this.textFechaAlta.Location = new System.Drawing.Point(128, 39);
            this.textFechaAlta.Name = "textFechaAlta";
            this.textFechaAlta.ReadOnly = true;
            this.textFechaAlta.Size = new System.Drawing.Size(230, 20);
            this.textFechaAlta.TabIndex = 14;
            // 
            // textNumeroTarjeta
            // 
            this.textNumeroTarjeta.Location = new System.Drawing.Point(128, 12);
            this.textNumeroTarjeta.Name = "textNumeroTarjeta";
            this.textNumeroTarjeta.ReadOnly = true;
            this.textNumeroTarjeta.Size = new System.Drawing.Size(230, 20);
            this.textNumeroTarjeta.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fecha de alta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Numero de Tarjeta:";
            // 
            // BajaTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 156);
            this.Controls.Add(this.botEliminar);
            this.Controls.Add(this.textCliente);
            this.Controls.Add(this.textFechaAlta);
            this.Controls.Add(this.textNumeroTarjeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BajaTarjetas";
            this.Text = "Tarjeta - Baja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botEliminar;
        private System.Windows.Forms.TextBox textCliente;
        private System.Windows.Forms.TextBox textFechaAlta;
        private System.Windows.Forms.TextBox textNumeroTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

        public string nro_tarjeta_viejo = "";

    }
}