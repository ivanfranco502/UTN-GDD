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
    public partial class AltaUsuario : Form
    {
        public AltaUsuario()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("select nombre from ntvc.rol order by cod_rol asc", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                checkedListBox1.Items.Add(reader["nombre"]);
            }
            reader.Close();
            con.Close();

        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            textPassword.Text = "";
            textUsername.Text = "";
            foreach (int rol in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(rol, CheckState.Unchecked);
            }     
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            int cant_roles = 0;
            foreach(int indice in checkedListBox1.CheckedIndices)
            {
                cant_roles++;
            }
            if (FuncionesUtiles.estanVacios(new List<TextBox> { textPassword, textUsername }) || cant_roles == 0)
            {

                string mensaje = "Debe completar los siguientes campos:";
                if (FuncionesUtiles.estaVacio(textUsername))
                {
                    mensaje += "\n-Username";
                }
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
                //los campos estan completos
                SqlConnection con = Conexion.conectar();
                con.Open();
                SqlCommand com = new SqlCommand("select * from ntvc.usuario where username = @username", con);
                com.Parameters.AddWithValue("@username", textUsername.Text);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    //ya existe el username
                    reader.Close();
                    con.Close();
                    MessageBox.Show("El nombre de usuario ingresado ya existe.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                }
                else
                {
                    reader.Close();
                    com = new SqlCommand("insert into ntvc.usuario (username, password, cant_log_falla, habilitado) values (@username, @password, 0, 1)", con);
                    com.Parameters.AddWithValue("@username", textUsername.Text);
                    com.Parameters.AddWithValue("@password", Encriptar.sha256(textPassword.Text));
                    com.ExecuteNonQuery();
                    string cod_usuario = "";
                    com = new SqlCommand("select cod_usuario from ntvc.usuario where username = @username", con);
                    com.Parameters.AddWithValue("@username", textUsername.Text);
                    reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        cod_usuario = reader["cod_usuario"].ToString();
                    }
                    reader.Close();
                    foreach (int indice in checkedListBox1.CheckedIndices)
                    {
                        com = new SqlCommand("insert into ntvc.usuario_rol (cod_usuario, cod_rol) values(@cod_usuario, @cod_rol)", con);
                        com.Parameters.AddWithValue("@cod_usuario", cod_usuario);
                        SqlCommand com2 = new SqlCommand("select cod_rol from ntvc.rol where nombre = @nombre_rol", con);
                        com2.Parameters.AddWithValue("@nombre_rol", checkedListBox1.Items[indice].ToString().Trim());
                        reader = com2.ExecuteReader();
                        if (reader.Read())
                        {
                            com.Parameters.AddWithValue("@cod_rol", reader["cod_rol"].ToString());
                            reader.Close();
                            com.ExecuteNonQuery();
                        }
                        else
                        {
                            reader.Close();
                        }
                        
                    }
                    con.Close();
                    this.Close();
                    MessageBox.Show("El usuario ha sido agregado.", "Alta exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                }
            }
        }

   
      
    }
}
