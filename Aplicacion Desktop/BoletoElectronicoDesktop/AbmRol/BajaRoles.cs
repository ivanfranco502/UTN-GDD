using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmRol
{
    public partial class BajaRoles : Form
    {
        public BajaRoles()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("select nombre from ntvc.rol order by cod_rol asc", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["nombre"]);
            }
            reader.Close();
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {   
                MessageBox.Show("Debe seleccionar un rol a eliminar.", "Rol agregado", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                string cod_rol = "";
                SqlConnection con = Conexion.conectar();
                con.Open();
                SqlCommand com = new SqlCommand("select cod_rol from ntvc.rol where nombre = @nombre", con);
                com.Parameters.AddWithValue("@nombre", comboBox1.Items[comboBox1.SelectedIndex].ToString().Trim());
                SqlDataReader reader = com.ExecuteReader();
                if(reader.Read())
                {
                    cod_rol = reader["cod_rol"].ToString();
                }
                reader.Close();
                com = new SqlCommand("update ntvc.rol set habilitacion = 0 where cod_rol = @cod_rol", con);
                com.Parameters.AddWithValue("@cod_rol", cod_rol);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("El rol ha sido eliminado exitosamente.", "Rol eliminado", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                this.Close();
            }
        }
    }
}
