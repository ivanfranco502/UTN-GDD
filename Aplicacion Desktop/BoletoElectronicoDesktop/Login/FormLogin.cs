using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using BoletoElectronicoDesktop;

namespace BoletoElectronicoDesktop.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void botLogIn_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            SqlCommand com;
            SqlDataReader reader;
            
            if (this.txtUsername.Text == "" || this.txtPassword.Text == "")
            {
                MessageBox.Show("Debe rellenar todos los campos", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                con = Conexion.conectar();
                com = new SqlCommand("SELECT PASSWORD, COD_USUARIO, CANT_LOG_FALLA, HABILITADO FROM NTVC.USUARIO where USERNAME = '" + this.txtUsername.Text + "'", con);
                con.Open();
                reader = com.ExecuteReader();

                if (reader.Read())
                {
                    if ((Int32)reader.GetValue(3) == 1)
                    {
                        String pass = reader["PASSWORD"].ToString().Trim();
                        String passH = ((Encriptar.sha256(this.txtPassword.Text)));
                        cod_usuario = Convert.ToInt32(reader["COD_USUARIO"]);
                        if (pass == passH)
                        {
                            reader.Close();
                            con.Close();
                            com = new SqlCommand("UPDATE NTVC.USUARIO set CANT_LOG_FALLA = 0 where COD_USUARIO = @cu", con);
                            com.Parameters.AddWithValue("@cu", cod_usuario);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            this.Close();
                            //fp = new FormPrincipal(cod_usuario);
                            //fp.Show();
                            //fp.ShowDialog(this);
                        }
                        else
                        {
                            int cant_log_falla = (Int32)reader.GetValue(2);
                            cant_log_falla++;
                            reader.Close();
                            con.Close();
                            com = new SqlCommand("UPDATE NTVC.USUARIO set CANT_LOG_FALLA = @clf where COD_USUARIO = @cu", con);
                            com.Parameters.AddWithValue("@clf", cant_log_falla);
                            com.Parameters.AddWithValue("@cu", cod_usuario);
                            con.Open();
                            com.ExecuteNonQuery();
                            con.Close();
                            if (cant_log_falla == 3)
                            {
                                com = new SqlCommand("UPDATE NTVC.USUARIO set HABILITADO = 0 where COD_USUARIO = @cu", con);
                                com.Parameters.AddWithValue("@cu", cod_usuario);
                                con.Open();
                                com.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Ha alcanzado el número de intentos máximos. El usuario se ha inhabilitado.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                            }
                            else
                            {
                                MessageBox.Show("Contraseña incorrecta, intente nuevamente.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                                this.txtPassword.Text = "";
                            }

                        }
                    }
                    else
                    {
                        reader.Close();
                        con.Close();
                        MessageBox.Show("El usuario se encuentra inhabilitado.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                        this.txtUsername.Text = "";
                        this.txtPassword.Text = "";
                    }

                }
                else
                {
                    con.Close();
                    MessageBox.Show("El nombre de usuario no existe.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                    this.txtUsername.Text = "";
                    this.txtPassword.Text = "";
                }
            }

        }
        
    }
}
