namespace BoletoElectronicoDesktop.AbmTarjetas
{
    partial class ModificacionTarjetas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.textFechaAlta = new System.Windows.Forms.TextBox();
            this.botSeleccionarFecha = new System.Windows.Forms.Button();
            this.textCliente = new System.Windows.Forms.TextBox();
            this.botSeleccionarCliente = new System.Windows.Forms.Button();
            this.botLimpiar = new System.Windows.Forms.Button();
            this.botGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Tarjeta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha de alta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente:";
            // 
            // textNumeroTarjeta
            // 
            this.textNumeroTarjeta.Location = new System.Drawing.Point(129, 6);
            this.textNumeroTarjeta.Name = "textNumeroTarjeta";
            this.textNumeroTarjeta.Size = new System.Drawing.Size(230, 20);
            this.textNumeroTarjeta.TabIndex = 3;
            // 
            // textFechaAlta
            // 
            this.textFechaAlta.Location = new System.Drawing.Point(129, 33);
            this.textFechaAlta.Name = "textFechaAlta";
            this.textFechaAlta.ReadOnly = true;
            this.textFechaAlta.Size = new System.Drawing.Size(149, 20);
            this.textFechaAlta.TabIndex = 4;
            // 
            // botSeleccionarFecha
            // 
            this.botSeleccionarFecha.Location = new System.Drawing.Point(284, 31);
            this.botSeleccionarFecha.Name = "botSeleccionarFecha";
            this.botSeleccionarFecha.Size = new System.Drawing.Size(75, 23);
            this.botSeleccionarFecha.TabIndex = 5;
            this.botSeleccionarFecha.Text = "Seleccionar";
            this.botSeleccionarFecha.UseVisualStyleBackColor = true;
            // 
            // textCliente
            // 
            this.textCliente.Location = new System.Drawing.Point(129, 62);
            this.textCliente.Name = "textCliente";
            this.textCliente.ReadOnly = true;
            this.textCliente.Size = new System.Drawing.Size(149, 20);
            this.textCliente.TabIndex = 6;
            // 
            // botSeleccionarCliente
            // 
            this.botSeleccionarCliente.Location = new System.Drawing.Point(284, 59);
            this.botSeleccionarCliente.Name = "botSeleccionarCliente";
            this.botSeleccionarCliente.Size = new System.Drawing.Size(75, 23);
            this.botSeleccionarCliente.TabIndex = 7;
            this.botSeleccionarCliente.Text = "Seleccionar";
            this.botSeleccionarCliente.UseVisualStyleBackColor = true;
            // 
            // botLimpiar
            // 
            this.botLimpiar.Location = new System.Drawing.Point(12, 115);
            this.botLimpiar.Name = "botLimpiar";
            this.botLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botLimpiar.TabIndex = 9;
            this.botLimpiar.Text = "Limpiar";
            this.botLimpiar.UseVisualStyleBackColor = true;
            this.botLimpiar.Click += new System.EventHandler(this.botLimpiar_Click);
            // 
            // botGuardar
            // 
            this.botGuardar.Location = new System.Drawing.Point(284, 115);
            this.botGuardar.Name = "botGuardar";
            this.botGuardar.Size = new System.Drawing.Size(75, 23);
            this.botGuardar.TabIndex = 10;
            this.botGuardar.Text = "Guardar";
            this.botGuardar.UseVisualStyleBackColor = true;
            // 
            // ModificacionTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 150);
            this.Controls.Add(this.botGuardar);
            this.Controls.Add(this.botLimpiar);
            this.Controls.Add(this.botSeleccionarCliente);
            this.Controls.Add(this.textCliente);
            this.Controls.Add(this.botSeleccionarFecha);
            this.Controls.Add(this.textFechaAlta);
            this.Controls.Add(this.textNumeroTarjeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModificacionTarjetas";
            this.Text = "Tarjeta - Alta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNumeroTarjeta;
        private System.Windows.Forms.TextBox textFechaAlta;
        private System.Windows.Forms.Button botSeleccionarFecha;
        private System.Windows.Forms.TextBox textCliente;
        private System.Windows.Forms.Button botSeleccionarCliente;
        private System.Windows.Forms.Button botLimpiar;
        private System.Windows.Forms.Button botGuardar;
    }
}