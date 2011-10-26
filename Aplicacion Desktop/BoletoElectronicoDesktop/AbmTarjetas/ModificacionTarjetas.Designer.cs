namespace BoletoElectronicoDesktop.AbmTarjetas
{
    partial class ModifTarjetas
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
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.botModificar = new System.Windows.Forms.Button();
            this.botSeleccionarCliente = new System.Windows.Forms.Button();
            this.textCliente = new System.Windows.Forms.TextBox();
            this.textFechaAlta = new System.Windows.Forms.TextBox();
            this.textNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Checked = true;
            this.chkHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabilitado.Location = new System.Drawing.Point(15, 119);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 28;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // botModificar
            // 
            this.botModificar.Location = new System.Drawing.Point(284, 115);
            this.botModificar.Name = "botModificar";
            this.botModificar.Size = new System.Drawing.Size(75, 23);
            this.botModificar.TabIndex = 27;
            this.botModificar.Text = "Modificar";
            this.botModificar.UseVisualStyleBackColor = true;
            // 
            // botSeleccionarCliente
            // 
            this.botSeleccionarCliente.Location = new System.Drawing.Point(284, 59);
            this.botSeleccionarCliente.Name = "botSeleccionarCliente";
            this.botSeleccionarCliente.Size = new System.Drawing.Size(75, 23);
            this.botSeleccionarCliente.TabIndex = 26;
            this.botSeleccionarCliente.Text = "Seleccionar";
            this.botSeleccionarCliente.UseVisualStyleBackColor = true;
            // 
            // textCliente
            // 
            this.textCliente.Location = new System.Drawing.Point(129, 62);
            this.textCliente.Name = "textCliente";
            this.textCliente.ReadOnly = true;
            this.textCliente.Size = new System.Drawing.Size(149, 20);
            this.textCliente.TabIndex = 25;
            // 
            // textFechaAlta
            // 
            this.textFechaAlta.Location = new System.Drawing.Point(129, 33);
            this.textFechaAlta.Name = "textFechaAlta";
            this.textFechaAlta.ReadOnly = true;
            this.textFechaAlta.Size = new System.Drawing.Size(230, 20);
            this.textFechaAlta.TabIndex = 24;
            // 
            // textNumeroTarjeta
            // 
            this.textNumeroTarjeta.Location = new System.Drawing.Point(129, 6);
            this.textNumeroTarjeta.Name = "textNumeroTarjeta";
            this.textNumeroTarjeta.Size = new System.Drawing.Size(230, 20);
            this.textNumeroTarjeta.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Fecha de alta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Numero de Tarjeta:";
            // 
            // ModifTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 145);
            this.Controls.Add(this.chkHabilitado);
            this.Controls.Add(this.botModificar);
            this.Controls.Add(this.botSeleccionarCliente);
            this.Controls.Add(this.textCliente);
            this.Controls.Add(this.textFechaAlta);
            this.Controls.Add(this.textNumeroTarjeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModifTarjetas";
            this.Text = "ModifTarjetas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Button botModificar;
        private System.Windows.Forms.Button botSeleccionarCliente;
        private System.Windows.Forms.TextBox textCliente;
        private System.Windows.Forms.TextBox textFechaAlta;
        private System.Windows.Forms.TextBox textNumeroTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}