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
    public partial class BajaCliente : Form
    {
        public BajaCliente(string tipo_doc, string doc)
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            tipo_doc_ = tipo_doc;
            doc_ = doc;

            SqlConnection con = Conexion.conectar();
            con.Open();
            string query = "select c.nombre as Nombre, c.apellido as Apellido, c.tipo_doc as Tipo, c.doc as Documento, c.cod_provincia as Provincia, c.mail as Mail, c.telefono as Teléfono, c.dir_calle as Calle, c.dir_nro as Número, c.dir_piso as Piso, c.dir_dpto as Depto from NTVC.Cliente c, NTVC.provincia p where c.tipo_doc = @tipo_doc and c.doc = @doc and c.cod_provincia = p.cod_provincia";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@tipo_doc", tipo_doc_);
            com.Parameters.AddWithValue("@doc", doc_);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                textNumero.Text = reader["Número"].ToString().Trim();
                textCalle.Text = reader["Calle"].ToString().Trim();
                textPiso.Text = reader["Piso"].ToString().Trim();
                textDepto.Text = reader["Depto"].ToString().Trim();
                textNombre.Text = reader["Nombre"].ToString().Trim();
                textApellido.Text = reader["Apellido"].ToString().Trim();
                textMail.Text = reader["Mail"].ToString().Trim();
                textTelefono.Text = reader["Teléfono"].ToString().Trim();
                textProvincia.Text = reader["Provincia"].ToString().Trim();
                textTD.Text = tipo_doc_;
                textDoc.Text = doc_;
            }
            reader.Close();
            con.Close();
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.conectar();
            con.Open();
            //hacer update de habilitado
            SqlCommand com = new SqlCommand("update ntvc.cliente set habilitado = 0 where doc = @doc and tipo_doc = @tipo_doc", con);
            com.Parameters.AddWithValue("@doc", doc_);
            com.Parameters.AddWithValue("@tipo_doc", tipo_doc_);
            com.ExecuteNonQuery();
            //inhabilitar tarjeta correspondiente
            com = new SqlCommand("select cod_cliente from ntvc.cliente where doc = @doc and tipo_doc = @tipo_doc", con);
            com.Parameters.AddWithValue("@doc", doc_);
            com.Parameters.AddWithValue("@tipo_doc", tipo_doc_);
            SqlDataReader reader = com.ExecuteReader();
            string cod_cliente = "";
            if (reader.Read())
            {
                cod_cliente = reader["cod_cliente"].ToString().Trim();
            }
            reader.Close();
            com = new SqlCommand("update ntvc.tarjeta set habilitado = 0 where cod_cliente = @cod_cliente", con);
            com.Parameters.AddWithValue("@cod_cliente", cod_cliente);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("El cliente ha sido eliminado.", "Eliminación exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
            this.Close();
        }
    }
}
