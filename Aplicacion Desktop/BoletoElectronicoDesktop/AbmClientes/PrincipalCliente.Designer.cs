namespace BoletoElectronicoDesktop.AbmClientes
{
    partial class PrincipalCliente
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
            this.botBaja = new System.Windows.Forms.Button();
            this.botModificacion = new System.Windows.Forms.Button();
            this.botAlta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botBaja
            // 
            this.botBaja.Location = new System.Drawing.Point(44, 139);
            this.botBaja.Name = "botBaja";
            this.botBaja.Size = new System.Drawing.Size(151, 26);
            this.botBaja.TabIndex = 11;
            this.botBaja.Text = "Eliminar un cliente";
            this.botBaja.UseVisualStyleBackColor = true;
            // 
            // botModificacion
            // 
            this.botModificacion.Location = new System.Drawing.Point(44, 97);
            this.botModificacion.Name = "botModificacion";
            this.botModificacion.Size = new System.Drawing.Size(151, 26);
            this.botModificacion.TabIndex = 10;
            this.botModificacion.Text = "Modificar un cliente";
            this.botModificacion.UseVisualStyleBackColor = true;
            // 
            // botAlta
            // 
            this.botAlta.Location = new System.Drawing.Point(44, 56);
            this.botAlta.Name = "botAlta";
            this.botAlta.Size = new System.Drawing.Size(151, 26);
            this.botAlta.TabIndex = 9;
            this.botAlta.Text = "Crear un cliente";
            this.botAlta.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "¿Qué desea hacer?";
            // 
            // PrincipalCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 172);
            this.Controls.Add(this.botBaja);
            this.Controls.Add(this.botModificacion);
            this.Controls.Add(this.botAlta);
            this.Controls.Add(this.label1);
            this.Name = "PrincipalCliente";
            this.Text = "Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botBaja;
        private System.Windows.Forms.Button botModificacion;
        private System.Windows.Forms.Button botAlta;
        private System.Windows.Forms.Label label1;
    }
}