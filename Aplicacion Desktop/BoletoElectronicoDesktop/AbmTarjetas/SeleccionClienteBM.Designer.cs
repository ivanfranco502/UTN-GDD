﻿namespace BoletoElectronicoDesktop.AbmTarjetas
{
    partial class SeleccionClienteBM
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
            this.botSeleccionarCliente = new System.Windows.Forms.Button();
            this.textCliente = new System.Windows.Forms.TextBox();
            this.botSeleccionarFecha = new System.Windows.Forms.Button();
            this.textFechaAlta = new System.Windows.Forms.TextBox();
            this.textNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.botLimpiar = new System.Windows.Forms.Button();
            this.botBuscar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teléfono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Número = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Piso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Depto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // botSeleccionarCliente
            // 
            this.botSeleccionarCliente.Location = new System.Drawing.Point(355, 65);
            this.botSeleccionarCliente.Name = "botSeleccionarCliente";
            this.botSeleccionarCliente.Size = new System.Drawing.Size(75, 23);
            this.botSeleccionarCliente.TabIndex = 15;
            this.botSeleccionarCliente.Text = "Seleccionar";
            this.botSeleccionarCliente.UseVisualStyleBackColor = true;
            // 
            // textCliente
            // 
            this.textCliente.Location = new System.Drawing.Point(129, 68);
            this.textCliente.Name = "textCliente";
            this.textCliente.ReadOnly = true;
            this.textCliente.Size = new System.Drawing.Size(220, 20);
            this.textCliente.TabIndex = 14;
            // 
            // botSeleccionarFecha
            // 
            this.botSeleccionarFecha.Location = new System.Drawing.Point(355, 36);
            this.botSeleccionarFecha.Name = "botSeleccionarFecha";
            this.botSeleccionarFecha.Size = new System.Drawing.Size(75, 23);
            this.botSeleccionarFecha.TabIndex = 13;
            this.botSeleccionarFecha.Text = "Seleccionar";
            this.botSeleccionarFecha.UseVisualStyleBackColor = true;
            // 
            // textFechaAlta
            // 
            this.textFechaAlta.Location = new System.Drawing.Point(129, 39);
            this.textFechaAlta.Name = "textFechaAlta";
            this.textFechaAlta.ReadOnly = true;
            this.textFechaAlta.Size = new System.Drawing.Size(220, 20);
            this.textFechaAlta.TabIndex = 12;
            // 
            // textNumeroTarjeta
            // 
            this.textNumeroTarjeta.Location = new System.Drawing.Point(129, 12);
            this.textNumeroTarjeta.Name = "textNumeroTarjeta";
            this.textNumeroTarjeta.Size = new System.Drawing.Size(301, 20);
            this.textNumeroTarjeta.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cliente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha de alta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Numero de Tarjeta:";
            // 
            // botLimpiar
            // 
            this.botLimpiar.Location = new System.Drawing.Point(12, 98);
            this.botLimpiar.Name = "botLimpiar";
            this.botLimpiar.Size = new System.Drawing.Size(75, 23);
            this.botLimpiar.TabIndex = 26;
            this.botLimpiar.Text = "Limpiar";
            this.botLimpiar.UseVisualStyleBackColor = true;
            // 
            // botBuscar
            // 
            this.botBuscar.Location = new System.Drawing.Point(355, 98);
            this.botBuscar.Name = "botBuscar";
            this.botBuscar.Size = new System.Drawing.Size(75, 23);
            this.botBuscar.TabIndex = 25;
            this.botBuscar.Text = "Buscar";
            this.botBuscar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.DNI,
            this.Teléfono,
            this.Mail,
            this.Calle,
            this.Número,
            this.Piso,
            this.Depto,
            this.Seleccionar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(418, 126);
            this.dataGridView1.TabIndex = 24;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "DNI";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // Teléfono
            // 
            this.Teléfono.HeaderText = "Teléfono";
            this.Teléfono.Name = "Teléfono";
            this.Teléfono.ReadOnly = true;
            // 
            // Mail
            // 
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            // 
            // Calle
            // 
            this.Calle.HeaderText = "Calle";
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            // 
            // Número
            // 
            this.Número.HeaderText = "Número";
            this.Número.Name = "Número";
            this.Número.ReadOnly = true;
            // 
            // Piso
            // 
            this.Piso.HeaderText = "Piso";
            this.Piso.Name = "Piso";
            this.Piso.ReadOnly = true;
            // 
            // Depto
            // 
            this.Depto.HeaderText = "Depto.";
            this.Depto.Name = "Depto";
            this.Depto.ReadOnly = true;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // SeleccionClienteBM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 276);
            this.Controls.Add(this.botLimpiar);
            this.Controls.Add(this.botBuscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.botSeleccionarCliente);
            this.Controls.Add(this.textCliente);
            this.Controls.Add(this.botSeleccionarFecha);
            this.Controls.Add(this.textFechaAlta);
            this.Controls.Add(this.textNumeroTarjeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SeleccionClienteBM";
            this.Text = "Tarjeta - Selección del cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botSeleccionarCliente;
        private System.Windows.Forms.TextBox textCliente;
        private System.Windows.Forms.Button botSeleccionarFecha;
        private System.Windows.Forms.TextBox textFechaAlta;
        private System.Windows.Forms.TextBox textNumeroTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botLimpiar;
        private System.Windows.Forms.Button botBuscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teléfono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Número;
        private System.Windows.Forms.DataGridViewTextBoxColumn Piso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Depto;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;

    }
}