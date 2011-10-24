﻿namespace BoletoElectronicoDesktop.PagoEmpresas
{
    partial class FormPagoEmpresas
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
            this.botSeleccionarFechaInicio = new System.Windows.Forms.Button();
            this.textFechaInicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.botSeleccionarFechaFin = new System.Windows.Forms.Button();
            this.textFechaFin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.botSeleccionarBenficiario = new System.Windows.Forms.Button();
            this.textBeneficiario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butBuscarVentas = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPostNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcaPostNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeloPostNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botRegistrarPago = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // botSeleccionarFechaInicio
            // 
            this.botSeleccionarFechaInicio.Location = new System.Drawing.Point(306, 10);
            this.botSeleccionarFechaInicio.Name = "botSeleccionarFechaInicio";
            this.botSeleccionarFechaInicio.Size = new System.Drawing.Size(129, 23);
            this.botSeleccionarFechaInicio.TabIndex = 14;
            this.botSeleccionarFechaInicio.Text = "Seleccionar";
            this.botSeleccionarFechaInicio.UseVisualStyleBackColor = true;
            // 
            // textFechaInicio
            // 
            this.textFechaInicio.Location = new System.Drawing.Point(113, 12);
            this.textFechaInicio.Name = "textFechaInicio";
            this.textFechaInicio.ReadOnly = true;
            this.textFechaInicio.Size = new System.Drawing.Size(174, 20);
            this.textFechaInicio.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fecha de inicio:";
            // 
            // botSeleccionarFechaFin
            // 
            this.botSeleccionarFechaFin.Location = new System.Drawing.Point(306, 36);
            this.botSeleccionarFechaFin.Name = "botSeleccionarFechaFin";
            this.botSeleccionarFechaFin.Size = new System.Drawing.Size(129, 23);
            this.botSeleccionarFechaFin.TabIndex = 17;
            this.botSeleccionarFechaFin.Text = "Seleccionar";
            this.botSeleccionarFechaFin.UseVisualStyleBackColor = true;
            // 
            // textFechaFin
            // 
            this.textFechaFin.Location = new System.Drawing.Point(113, 38);
            this.textFechaFin.Name = "textFechaFin";
            this.textFechaFin.ReadOnly = true;
            this.textFechaFin.Size = new System.Drawing.Size(174, 20);
            this.textFechaFin.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Fecha de fin:";
            // 
            // botSeleccionarBenficiario
            // 
            this.botSeleccionarBenficiario.Location = new System.Drawing.Point(305, 62);
            this.botSeleccionarBenficiario.Name = "botSeleccionarBenficiario";
            this.botSeleccionarBenficiario.Size = new System.Drawing.Size(129, 23);
            this.botSeleccionarBenficiario.TabIndex = 20;
            this.botSeleccionarBenficiario.Text = "Seleccionar";
            this.botSeleccionarBenficiario.UseVisualStyleBackColor = true;
            // 
            // textBeneficiario
            // 
            this.textBeneficiario.Location = new System.Drawing.Point(113, 64);
            this.textBeneficiario.Name = "textBeneficiario";
            this.textBeneficiario.ReadOnly = true;
            this.textBeneficiario.Size = new System.Drawing.Size(174, 20);
            this.textBeneficiario.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Beneficiario:";
            // 
            // butBuscarVentas
            // 
            this.butBuscarVentas.Location = new System.Drawing.Point(155, 109);
            this.butBuscarVentas.Name = "butBuscarVentas";
            this.butBuscarVentas.Size = new System.Drawing.Size(132, 23);
            this.butBuscarVentas.TabIndex = 21;
            this.butBuscarVentas.Text = "Buscar ventas";
            this.butBuscarVentas.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Apellido,
            this.Nombre,
            this.NumeroTarjeta,
            this.CodigoPostNet,
            this.MarcaPostNet,
            this.ModeloPostNet,
            this.Monto});
            this.dataGridView1.Location = new System.Drawing.Point(16, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(418, 141);
            this.dataGridView1.TabIndex = 22;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // NumeroTarjeta
            // 
            this.NumeroTarjeta.HeaderText = "Número de tarjeta";
            this.NumeroTarjeta.Name = "NumeroTarjeta";
            this.NumeroTarjeta.ReadOnly = true;
            // 
            // CodigoPostNet
            // 
            this.CodigoPostNet.HeaderText = "Código PostNet";
            this.CodigoPostNet.Name = "CodigoPostNet";
            this.CodigoPostNet.ReadOnly = true;
            // 
            // MarcaPostNet
            // 
            this.MarcaPostNet.HeaderText = "Marca PostNet";
            this.MarcaPostNet.Name = "MarcaPostNet";
            this.MarcaPostNet.ReadOnly = true;
            // 
            // ModeloPostNet
            // 
            this.ModeloPostNet.HeaderText = "Modelo PostNet";
            this.ModeloPostNet.Name = "ModeloPostNet";
            this.ModeloPostNet.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            // 
            // botRegistrarPago
            // 
            this.botRegistrarPago.Location = new System.Drawing.Point(155, 323);
            this.botRegistrarPago.Name = "botRegistrarPago";
            this.botRegistrarPago.Size = new System.Drawing.Size(132, 23);
            this.botRegistrarPago.TabIndex = 23;
            this.botRegistrarPago.Text = "Registrar pago";
            this.botRegistrarPago.UseVisualStyleBackColor = true;
            // 
            // FormPagoEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 355);
            this.Controls.Add(this.botRegistrarPago);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.butBuscarVentas);
            this.Controls.Add(this.botSeleccionarBenficiario);
            this.Controls.Add(this.textBeneficiario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botSeleccionarFechaFin);
            this.Controls.Add(this.textFechaFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botSeleccionarFechaInicio);
            this.Controls.Add(this.textFechaInicio);
            this.Controls.Add(this.label4);
            this.Name = "FormPagoEmpresas";
            this.Text = "Pago a beneficiarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botSeleccionarFechaInicio;
        private System.Windows.Forms.TextBox textFechaInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button botSeleccionarFechaFin;
        private System.Windows.Forms.TextBox textFechaFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botSeleccionarBenficiario;
        private System.Windows.Forms.TextBox textBeneficiario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butBuscarVentas;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroTarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPostNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcaPostNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeloPostNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.Button botRegistrarPago;
    }
}