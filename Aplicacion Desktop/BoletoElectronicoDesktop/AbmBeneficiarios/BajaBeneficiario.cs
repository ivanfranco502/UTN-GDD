using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmBeneficiarios
{
    public partial class BajaBeneficiario : Form
    {
        public BajaBeneficiario(string rs)
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            razon_social_vieja = rs;
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("select b.cod_beneficiario, b.razon_social, b.dir_calle , b.dir_nro , b.dir_piso , b.dir_dpto , r.descripcion from ntvc.beneficiario b, ntvc.rubro r where b.cod_rubro = r.cod_rubro and razon_social = @rs", con);
            com.Parameters.AddWithValue("@rs", razon_social_vieja);
            SqlDataReader reader = com.ExecuteReader();
            string cod_beneficiario = "";
            if (reader.Read())
            {
                cod_beneficiario = reader["cod_beneficiario"].ToString().Trim();
                textCalle.Text = reader["dir_calle"].ToString().Trim();
                textDepto.Text = reader["dir_dpto"].ToString().Trim();
                textNumero.Text = reader["dir_nro"].ToString().Trim();
                textPiso.Text = reader["dir_piso"].ToString().Trim();
                textRazonSocial.Text = reader["razon_social"].ToString().Trim();
                textRubro.Text = reader["descripcion"].ToString().Trim();
            }
            reader.Close();
            com = new SqlCommand("select p.nro_serie from ntvc.postnet p, ntvc.beneficiario_postnet bp where bp.cod_beneficiario = @cb and bp.cod_postnet = p.cod_postnet", con);
            com.Parameters.AddWithValue("@cb", cod_beneficiario);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                serials.Add(reader["nro_serie"].ToString().Trim());
            }
            reader.Close();
            foreach (string serial in serials)
            {
                if (FuncionesUtiles.estaVacio(textPostNets))
                {
                    textPostNets.Text = serial;
                }
                else
                {
                    textPostNets.Text += ", " + serial;
                }
            }
            con.Close();
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("update ntvc.beneficiario set habilitado = 0 where razon_social = @rs", con);
            com.Parameters.AddWithValue("@rs", razon_social_vieja);
            com.ExecuteNonQuery();
            this.Close();
            MessageBox.Show("El beneficiario ha sido eliminado.", "Eliminación exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
            con.Close();
        }
    }
}
