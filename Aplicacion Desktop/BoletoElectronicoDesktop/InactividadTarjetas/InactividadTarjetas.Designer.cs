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
            this.botInhabilitar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // botInhabilitar
            // 
            this.botInhabilitar.Location = new System.Drawing.Point(344, 277);
            this.botInhabilitar.Name = "botInhabilitar";
            this.botInhabilitar.Size = new System.Drawing.Size(146, 27);
            this.botInhabilitar.TabIndex = 4;
            this.botInhabilitar.Text = "Inhabilitar tarjetas";
            this.botInhabilitar.UseVisualStyleBackColor = true;
            this.botInhabilitar.Click += new System.EventHandler(this.botInhabilitar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(746, 234);
            this.dataGridView1.TabIndex = 5;
            // 
            // InactividadTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 332);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.botInhabilitar);
            this.Name = "InactividadTarjetas";
            this.Text = "Inactividad de tarjetas";
            this.Load += new System.EventHandler(this.InactividadTarjetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botInhabilitar;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}