using System.Collections.Generic;

namespace BoletoElectronicoDesktop.AbmBeneficiarios
{
    partial class ModificacionBeneficiario
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
            this.comboBoxRubro = new System.Windows.Forms.ComboBox();
            this.botGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textNumero = new System.Windows.Forms.TextBox();
            this.textCalle = new System.Windows.Forms.TextBox();
            this.textPiso = new System.Windows.Forms.TextBox();
            this.textDepto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textPostNets = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textRazonSocial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.botQuitarPostNets = new System.Windows.Forms.Button();
            this.botAgregarPostNets = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxRubro
            // 
            this.comboBoxRubro.FormattingEnabled = true;
            this.comboBoxRubro.Location = new System.Drawing.Point(69, 160);
            this.comboBoxRubro.Name = "comboBoxRubro";
            this.comboBoxRubro.Size = new System.Drawing.Size(359, 21);
            this.comboBoxRubro.TabIndex = 54;
            // 
            // botGuardar
            // 
            this.botGuardar.Location = new System.Drawing.Point(353, 207);
            this.botGuardar.Name = "botGuardar";
            this.botGuardar.Size = new System.Drawing.Size(75, 23);
            this.botGuardar.TabIndex = 52;
            this.botGuardar.Text = "Modificar";
            this.botGuardar.UseVisualStyleBackColor = true;
            this.botGuardar.Click += new System.EventHandler(this.botGuardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textNumero);
            this.groupBox1.Controls.Add(this.textCalle);
            this.groupBox1.Controls.Add(this.textPiso);
            this.groupBox1.Controls.Add(this.textDepto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 82);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dirección";
            // 
            // textNumero
            // 
            this.textNumero.Location = new System.Drawing.Point(266, 22);
            this.textNumero.Name = "textNumero";
            this.textNumero.Size = new System.Drawing.Size(146, 20);
            this.textNumero.TabIndex = 14;
            // 
            // textCalle
            // 
            this.textCalle.Location = new System.Drawing.Point(45, 22);
            this.textCalle.Name = "textCalle";
            this.textCalle.Size = new System.Drawing.Size(146, 20);
            this.textCalle.TabIndex = 13;
            // 
            // textPiso
            // 
            this.textPiso.Location = new System.Drawing.Point(45, 48);
            this.textPiso.Name = "textPiso";
            this.textPiso.Size = new System.Drawing.Size(146, 20);
            this.textPiso.TabIndex = 12;
            // 
            // textDepto
            // 
            this.textDepto.Location = new System.Drawing.Point(266, 48);
            this.textDepto.Name = "textDepto";
            this.textDepto.Size = new System.Drawing.Size(146, 20);
            this.textDepto.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Piso:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Depto.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Número:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Calle:";
            // 
            // textPostNets
            // 
            this.textPostNets.Location = new System.Drawing.Point(69, 130);
            this.textPostNets.Name = "textPostNets";
            this.textPostNets.ReadOnly = true;
            this.textPostNets.Size = new System.Drawing.Size(201, 20);
            this.textPostNets.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Post-Nets:";
            // 
            // textRazonSocial
            // 
            this.textRazonSocial.Location = new System.Drawing.Point(88, 12);
            this.textRazonSocial.Name = "textRazonSocial";
            this.textRazonSocial.Size = new System.Drawing.Size(340, 20);
            this.textRazonSocial.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Rubro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Razón Social:";
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Checked = true;
            this.chkHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHabilitado.Location = new System.Drawing.Point(10, 211);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 55;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // botQuitarPostNets
            // 
            this.botQuitarPostNets.Location = new System.Drawing.Point(355, 128);
            this.botQuitarPostNets.Name = "botQuitarPostNets";
            this.botQuitarPostNets.Size = new System.Drawing.Size(73, 23);
            this.botQuitarPostNets.TabIndex = 57;
            this.botQuitarPostNets.Text = "Quitar";
            this.botQuitarPostNets.UseVisualStyleBackColor = true;
            this.botQuitarPostNets.Click += new System.EventHandler(this.botQuitarPostNets_Click);
            // 
            // botAgregarPostNets
            // 
            this.botAgregarPostNets.Location = new System.Drawing.Point(276, 128);
            this.botAgregarPostNets.Name = "botAgregarPostNets";
            this.botAgregarPostNets.Size = new System.Drawing.Size(73, 23);
            this.botAgregarPostNets.TabIndex = 56;
            this.botAgregarPostNets.Text = "Agregar";
            this.botAgregarPostNets.UseVisualStyleBackColor = true;
            this.botAgregarPostNets.Click += new System.EventHandler(this.botAgregarPostNets_Click);
            // 
            // ModificacionBeneficiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 239);
            this.Controls.Add(this.botQuitarPostNets);
            this.Controls.Add(this.botAgregarPostNets);
            this.Controls.Add(this.chkHabilitado);
            this.Controls.Add(this.comboBoxRubro);
            this.Controls.Add(this.botGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textPostNets);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textRazonSocial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModificacionBeneficiario";
            this.Text = "Beneficiario - Modificación";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxRubro;
        private System.Windows.Forms.Button botGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textNumero;
        private System.Windows.Forms.TextBox textCalle;
        private System.Windows.Forms.TextBox textPiso;
        private System.Windows.Forms.TextBox textDepto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPostNets;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textRazonSocial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkHabilitado;


        public string razon_social_vieja = "";
        public string cod_beneficiario_ = "";
        public List<string> serials = new List<string>();
        private System.Windows.Forms.Button botQuitarPostNets;
        private System.Windows.Forms.Button botAgregarPostNets;

    }
}