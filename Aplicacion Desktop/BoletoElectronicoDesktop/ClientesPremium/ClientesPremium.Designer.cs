namespace BoletoElectronicoDesktop.ClientesPremium
{
    partial class ClientesPremium
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroTarjeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotalAcumulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaUltimaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botAnalizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(95, 7);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1995,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(231, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1995,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año a analizar:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.DNI,
            this.NumeroTarjeta,
            this.MontoTotalAcumulado,
            this.FechaUltimaCompra});
            this.dataGridView1.Location = new System.Drawing.Point(15, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(485, 127);
            this.dataGridView1.TabIndex = 2;
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
            // NumeroTarjeta
            // 
            this.NumeroTarjeta.HeaderText = "Número de tarjeta";
            this.NumeroTarjeta.Name = "NumeroTarjeta";
            this.NumeroTarjeta.ReadOnly = true;
            // 
            // MontoTotalAcumulado
            // 
            this.MontoTotalAcumulado.HeaderText = "Monto total acumulado";
            this.MontoTotalAcumulado.Name = "MontoTotalAcumulado";
            this.MontoTotalAcumulado.ReadOnly = true;
            // 
            // FechaUltimaCompra
            // 
            this.FechaUltimaCompra.HeaderText = "Fecha de última compra";
            this.FechaUltimaCompra.Name = "FechaUltimaCompra";
            this.FechaUltimaCompra.ReadOnly = true;
            // 
            // botAnalizar
            // 
            this.botAnalizar.Location = new System.Drawing.Point(332, 3);
            this.botAnalizar.Name = "botAnalizar";
            this.botAnalizar.Size = new System.Drawing.Size(168, 25);
            this.botAnalizar.TabIndex = 3;
            this.botAnalizar.Text = "Ver clientes Premium";
            this.botAnalizar.UseVisualStyleBackColor = true;
            // 
            // ClientesPremium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 193);
            this.Controls.Add(this.botAnalizar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "ClientesPremium";
            this.Text = "Clientes Premium";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroTarjeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotalAcumulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaUltimaCompra;
        private System.Windows.Forms.Button botAnalizar;
    }
}