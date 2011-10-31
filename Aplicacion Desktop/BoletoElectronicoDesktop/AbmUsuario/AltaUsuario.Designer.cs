namespace BoletoElectronicoDesktop.AbmUsuario
{
    partial class AltaUsuario
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.botLimpiar = new System.Windows.Forms.Button();
            this.botGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 73);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(205, 139);
            this.checkedListBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Seleccione los roles:";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(74, 6);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(144, 20);
            this.textUsername.TabIndex = 4;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(74, 32);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(144, 20);
            this.textPassword.TabIndex = 5;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // botLimpiar
            // 
            this.botLimpiar.Location = new System.Drawing.Point(12, 231);
            this.botLimpiar.Name = "botLimpiar";
            this.botLimpiar.Size = new System.Drawing.Size(83, 21);
            this.botLimpiar.TabIndex = 6;
            this.botLimpiar.Text = "Limpiar";
            this.botLimpiar.UseVisualStyleBackColor = true;
            this.botLimpiar.Click += new System.EventHandler(this.botLimpiar_Click);
            // 
            // botGuardar
            // 
            this.botGuardar.Location = new System.Drawing.Point(138, 231);
            this.botGuardar.Name = "botGuardar";
            this.botGuardar.Size = new System.Drawing.Size(80, 21);
            this.botGuardar.TabIndex = 7;
            this.botGuardar.Text = "Guardar";
            this.botGuardar.UseVisualStyleBackColor = true;
            this.botGuardar.Click += new System.EventHandler(this.botGuardar_Click);
            // 
            // AltaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 262);
            this.Controls.Add(this.botGuardar);
            this.Controls.Add(this.botLimpiar);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "AltaUsuario";
            this.Text = "Usuario - Alta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Button botLimpiar;
        private System.Windows.Forms.Button botGuardar;

    }
}