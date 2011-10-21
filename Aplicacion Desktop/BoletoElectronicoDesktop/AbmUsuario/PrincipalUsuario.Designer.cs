namespace BoletoElectronicoDesktop.AbmUsuario
{
    partial class PrincipalUsuario
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
            this.botAlta = new System.Windows.Forms.Button();
            this.botModificacion = new System.Windows.Forms.Button();
            this.botBaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Qué desea hacer?";
            // 
            // botAlta
            // 
            this.botAlta.Location = new System.Drawing.Point(57, 50);
            this.botAlta.Name = "botAlta";
            this.botAlta.Size = new System.Drawing.Size(151, 26);
            this.botAlta.TabIndex = 1;
            this.botAlta.Text = "Crear un usuario";
            this.botAlta.UseVisualStyleBackColor = true;
            // 
            // botModificacion
            // 
            this.botModificacion.Location = new System.Drawing.Point(57, 91);
            this.botModificacion.Name = "botModificacion";
            this.botModificacion.Size = new System.Drawing.Size(151, 26);
            this.botModificacion.TabIndex = 2;
            this.botModificacion.Text = "Modificar un usuario";
            this.botModificacion.UseVisualStyleBackColor = true;
            // 
            // botBaja
            // 
            this.botBaja.Location = new System.Drawing.Point(57, 133);
            this.botBaja.Name = "botBaja";
            this.botBaja.Size = new System.Drawing.Size(151, 26);
            this.botBaja.TabIndex = 3;
            this.botBaja.Text = "Eliminar un usuario";
            this.botBaja.UseVisualStyleBackColor = true;
            // 
            // PrincipalUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 173);
            this.Controls.Add(this.botBaja);
            this.Controls.Add(this.botModificacion);
            this.Controls.Add(this.botAlta);
            this.Controls.Add(this.label1);
            this.Name = "PrincipalUsuario";
            this.Text = "Usuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botAlta;
        private System.Windows.Forms.Button botModificacion;
        private System.Windows.Forms.Button botBaja;
    }
}