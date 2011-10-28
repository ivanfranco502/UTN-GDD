using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmTarjetas
{
    public partial class BajaTarjetas : Form
    {
        public BajaTarjetas(string nro)
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            nro_tarjeta_viejo = nro;
            SqlConnection con = Conexion.conectar();
            con.Open();
            string query = "select nro_tarjeta, fecha_alta, cod_cliente from ntvc.tarjeta where nro_tarjeta = @nro_tarjeta";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@nro_tarjeta", nro_tarjeta_viejo);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                textCliente.Text = reader["cod_cliente"].ToString();
                textFechaAlta.Text = reader["fecha_alta"].ToString();
                textNumeroTarjeta.Text = reader["nro_tarjeta"].ToString();
            }
            reader.Close();
            con.Close();
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("update ntvc.tarjeta set habilitado = 0 where nro_tarjeta = @nro_viejo", con);
            com.Parameters.AddWithValue("@nro_viejo",this.nro_tarjeta_viejo);
            com.ExecuteNonQuery();
            this.Close();
            MessageBox.Show("La tarjeta ha sido eliminada.", "Eliminación exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
            con.Close();
        }
    }
}
