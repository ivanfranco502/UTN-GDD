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
    public partial class ModificacionUsuario : Form
    {
        public ModificacionUsuario(string un)
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
                for(int i = 0; i < cant; i++)
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

        private void botModificar_Click(object sender, EventArgs e)
        {
            int cant_roles = 0;
            foreach(int indice in checkedListBox1.CheckedIndices)
            {
                cant_roles++;
            }
            if (FuncionesUtiles.estanVacios(new List<TextBox> { textPassword }) || cant_roles == 0)
            {

                string mensaje = "Debe completar los siguientes campos:";
                if (FuncionesUtiles.estaVacio(textPassword))
                {
                    mensaje += "\n-Password";
                }
                if (cant_roles == 0)
                {
                    mensaje += "\n-Roles";
                }

                MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                SqlDataReader reader;
                SqlConnection con = Conexion.conectar();
                con.Open();
                SqlCommand com = new SqlCommand("delete ntvc.usuario_rol where cod_usuario = @cod_usuario", con);
                com.Parameters.AddWithValue("@cod_usuario", cod_usuario_);
                com.ExecuteNonQuery();
                com = new SqlCommand("update ntvc.usuario set password = @password, habilitado = @habilitado where cod_usuario = @cod_usuario", con);
                com.Parameters.AddWithValue("@password", Encriptar.sha256(textPassword.Text));
                com.Parameters.AddWithValue("@cod_usuario", cod_usuario_);
                if (chkHabilitado.Checked)
                {
                    com.Parameters.AddWithValue("@habilitado", "1");
                }
                else
                {
                    com.Parameters.AddWithValue("@habilitado", "0");
                }
                com.ExecuteNonQuery();
                string cod_rol = "";
                foreach (int indice in checkedListBox1.CheckedIndices)
                {
                    com = new SqlCommand("select cod_rol from ntvc.rol where nombre = @nombre_rol", con);
                    com.Parameters.AddWithValue("@nombre_rol", checkedListBox1.GetItemText(checkedListBox1.Items[indice]).ToString().Trim());
                    reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        cod_rol = reader["cod_rol"].ToString().Trim();
                    }
                    reader.Close();
                    com = new SqlCommand("insert into ntvc.usuario_rol (cod_rol, cod_usuario) values(@cod_rol, @cod_usuario)", con);
                    com.Parameters.AddWithValue("@cod_rol", cod_rol);
                    com.Parameters.AddWithValue("@cod_usuario", cod_usuario_);
                    com.ExecuteNonQuery();
                }
                this.Close();
                MessageBox.Show("El usuario ha sido modificado.", "Modificación exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
            }
        }
    }
}
