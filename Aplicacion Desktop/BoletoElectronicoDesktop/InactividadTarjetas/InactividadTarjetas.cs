using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BoletoElectronicoDesktop.InactividadTarjetas
{
    public partial class InactividadTarjetas : Form
    {
        public InactividadTarjetas()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            string select = "SELECT * FROM NTVC.TARJETASINACTIVAS()";
            FuncionesUtiles.llenarDataGridView(select, dataGridView1);
        }

        private void botInhabilitar_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.conectar();
            SqlCommand com = new SqlCommand("UPDATE NTVC.TARJETA SET HABILITADO = 0"+
	                                           " FROM (SELECT COD_CLIENTE FROM NTVC.CLIENTE_INACTIVO) AS CLIENTE_INACTIVO"+
	                                           " WHERE TARJETA.COD_CLIENTE = CLIENTE_INACTIVO.COD_CLIENTE",con);
            con.Open();
            com.ExecuteNonQuery();
            this.Close();
            MessageBox.Show("Se han deshabilitado las tarjetas.", "Inhabilitacion exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
            con.Close();
        }

        private void InactividadTarjetas_Load(object sender, EventArgs e)
        {

        }

    }
}
