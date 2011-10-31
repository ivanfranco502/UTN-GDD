using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmUsuario
{
    public partial class SeleccionUsuario : Form
    {
        public SeleccionUsuario()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            FuncionesUtiles.llenarDataGridView("select username as Username from NTVC.usuario where cod_usuario = 0", dataGridView1);
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
            FuncionesUtiles.llenarDataGridView("select username as Username from NTVC.usuario where cod_usuario = 0", dataGridView1);
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = "select username as Username from NTVC.usuario";
            if (!FuncionesUtiles.estaVacio(textUsername))
            {
                busqueda += " where username like '" + textUsername.Text + "'";
            }
            FuncionesUtiles.llenarDataGridView(busqueda, dataGridView1);
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ModificacionUsuario form = new ModificacionUsuario(dataGridView1.SelectedCells[0].Value.ToString());
                form.ShowDialog(this);
                this.Close(); 
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BajaUsuario form = new BajaUsuario(dataGridView1.SelectedCells[0].Value.ToString());
                form.ShowDialog(this);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
        }
    }
}
