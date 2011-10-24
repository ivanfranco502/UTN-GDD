namespace BoletoElectronicoDesktop.InactividadTarjetas
{
    partial class InactividadTarjetas
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.botInhabilitar = new System.Windows.Forms.Button();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoTotalAcumulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaUltimaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeneficiarioUltimaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoPostNetUltimaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.DNI,
            this.MontoTotalAcumulado,
            this.FechaUltimaCompra,
            this.BeneficiarioUltimaCompra,
            this.CodigoPostNetUltimaCompra});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(615, 179);
            this.dataGridView1.TabIndex = 3;
            // 
            // botInhabilitar
            // 
            this.botInhabilitar.Location = new System.Drawing.Point(249, 221);
            this.botInhabilitar.Name = "botInhabilitar";
            this.botInhabilitar.Size = new System.Drawing.Size(146, 27);
            this.botInhabilitar.TabIndex = 4;
            this.botInhabilitar.Text = "Inhabilitar tarjetas";
            this.botInhabilitar.UseVisualStyleBackColor = true;
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
            // BeneficiarioUltimaCompra
            // 
            this.BeneficiarioUltimaCompra.HeaderText = "Beneficiario de última compra";
            this.BeneficiarioUltimaCompra.Name = "BeneficiarioUltimaCompra";
            this.BeneficiarioUltimaCompra.ReadOnly = true;
            // 
            // CodigoPostNetUltimaCompra
            // 
            this.CodigoPostNetUltimaCompra.HeaderText = "Código PostNet de última compra";
            this.CodigoPostNetUltimaCompra.Name = "CodigoPostNetUltimaCompra";
            this.CodigoPostNetUltimaCompra.ReadOnly = true;
            // 
            // InactividadTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 262);
            this.Controls.Add(this.botInhabilitar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "InactividadTarjetas";
            this.Text = "Inactividad de tarjetas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button botInhabilitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoTotalAcumulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaUltimaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeneficiarioUltimaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoPostNetUltimaCompra;
    }
}