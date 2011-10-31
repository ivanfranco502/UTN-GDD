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
    public partial class BajaUsuario : Form
    {
        public BajaUsuario(string un)
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            username_ = un;

            textUsername.Text = username_;
            SqlConnection con = Conexion.conectar();
            con.Open();
            //obtener codigo usuario
            string query = "select cod_usuario from ntvc.usuario where username = @username";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@username", username_);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                cod_usuario_ = reader["cod_usuario"].ToString().Trim();
            }
            reader.Close();
            //llenar roles
            com = new SqlCommand("select nombre from ntvc.rol order by cod_rol asc", con);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                checkedListBox1.Items.Add(reader["nombre"]);
            }
            reader.Close();
            //marcar roles del usuario
            com = new SqlCommand("select r.nombre as nombre from ntvc.rol r, ntvc.usuario_rol ur where ur.cod_usuario = @cod_usuario and r.cod_rol = ur.cod_rol", con);
            com.Parameters.AddWithValue("@cod_usuario", cod_usuario_);
            reader = com.ExecuteReader();
            int cant = 0;
            foreach (object item in checkedListBox1.Items)
            {
                cant++;
            }
            while (reader.Read())
            {
                for (int i = 0; i < cant; i++)
                {
                    if (checkedListBox1.GetItemText(checkedListBox1.Items[i]).Trim() == reader["nombre"].ToString().Trim())
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
            reader.Close();
            con.Close();
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("update ntvc.usuario set habilitado = @habilitado where cod_usuario = @cod_usuario", con);
            com.Parameters.AddWithValue("@cod_usuario", cod_usuario_);
            com.Parameters.AddWithValue("@habilitado", 0);
            com.ExecuteNonQuery();
        }

        
    }
}
