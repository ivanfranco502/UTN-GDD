namespace BoletoElectronicoDesktop.AbmUsuario
{
    partial class BajaUsuario
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
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // botEliminar
            // 
            this.botEliminar.Location = new System.Drawing.Point(74, 208);
            this.botEliminar.Name = "botEliminar";
            this.botEliminar.Size = new System.Drawing.Size(83, 21);
            this.botEliminar.TabIndex = 11;
            this.botEliminar.Text = "Eliminar";
            this.botEliminar.UseVisualStyleBackColor = true;
            this.botEliminar.Click += new System.EventHandler(this.botEliminar_Click);
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(74, 11);
            this.textUsername.Name = "textUsername";
            this.textUsername.ReadOnly = true;
            this.textUsername.Size = new System.Drawing.Size(144, 20);
            this.textUsername.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Roles asignados:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 54);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.checkedListBox1.Size = new System.Drawing.Size(205, 139);
            this.checkedListBox1.TabIndex = 7;
            // 
            // BajaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 241);
            this.Controls.Add(this.botEliminar);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "BajaUsuario";
            this.Text = "Usuario - Baja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botEliminar;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;

        public string username_ = "";
        public string cod_usuario_ = "";
    }
}