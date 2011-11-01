using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmClientes
{
    public partial class SeleccionCliente : Form
    {
        public SeleccionCliente()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            FuncionesUtiles.llenarDataGridView("select c.nombre as Nombre, c.apellido as Apellido, c.tipo_doc as Tipo, c.doc as Documento, p.nombre as Provincia, c.mail as Mail, c.telefono as Teléfono, c.dir_calle as Calle, c.dir_nro as Número, c.dir_piso as Piso, c.dir_dpto as Depto from NTVC.Cliente c, NTVC.provincia p where cod_cliente = 0 and p.cod_provincia = 0", dataGridView1);
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("select * from ntvc.provincia order by nombre", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["nombre"]);
            }
            reader.Close();
            con.Close();
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            textNombre.Text = "";
            textApellido.Text = "";
            textDNI.Text = "";
            comboBox1.SelectedIndex = -1;
            FuncionesUtiles.llenarDataGridView("select c.nombre as Nombre, c.apellido as Apellido, c.tipo_doc as Tipo, c.doc as Documento, p.nombre as Provincia, c.mail as Mail, c.telefono as Teléfono, c.dir_calle as Calle, c.dir_nro as Número, c.dir_piso as Piso, c.dir_dpto as Depto from NTVC.Cliente c, NTVC.provincia p where cod_cliente = 0 and p.cod_provincia = 0", dataGridView1);
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.conectar();
            con.Open();
            string busqueda = "select c.nombre as Nombre, c.apellido as Apellido, c.tipo_doc as Tipo, c.doc as Documento, p.nombre as Provincia, c.mail as Mail, c.telefono as Teléfono, c.dir_calle as Calle, c.dir_nro as Número, c.dir_piso as Piso, c.dir_dpto as Depto from NTVC.Cliente c, NTVC.provincia p where c.cod_provincia = p.cod_provincia and ";
            if (!FuncionesUtiles.estaVacio(textApellido))
            {
                busqueda += "c.apellido like '%" + textApellido.Text + "%' and ";
            }
            if(!FuncionesUtiles.estaVacio(textNombre))
            {
                busqueda += "c.nombre like '%" + textNombre.Text + "%' and ";
            }
            if(!FuncionesUtiles.estaVacio(textDNI))
            {
                busqueda += "c.doc = " + textDNI.Text + " and ";
            }
            if (comboBox1.SelectedIndex > -1)
            {
                busqueda += "p.nombre = '" + comboBox1.Items[comboBox1.SelectedIndex].ToString().Trim() + "' and ";
            }
            busqueda += "1=1";
            FuncionesUtiles.llenarDataGridView(busqueda, dataGridView1);

        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ModificacionCliente form = new ModificacionCliente(dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString());
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
                BajaCliente form = new BajaCliente(dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString());
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
