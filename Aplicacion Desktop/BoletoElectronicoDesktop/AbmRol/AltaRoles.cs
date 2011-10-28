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
    public partial class AltaRoles : Form
    {
        public AltaRoles()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            textNombre.Text = "";
            foreach (int func in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(func, CheckState.Unchecked);
            }             
                
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (FuncionesUtiles.estaVacio(textNombre))
            {
                MessageBox.Show("Debe ingresar un nombre de rol.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {

                int cantFunc = 0;
                foreach (int func in checkedListBox1.CheckedIndices)
                {
                    cantFunc++;
                }
                if (cantFunc == 0)
                {
                    //no hay ninguna funcionalidad seleccionada
                    MessageBox.Show("Debe seleccionar al menos una funcionalidad", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                }
                else
                {
                    SqlConnection con = Conexion.conectar();
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from ntvc.rol where nombre = @nombre", con);
                    com.Parameters.AddWithValue("@nombre", textNombre.Text);
                    SqlDataReader reader = com.ExecuteReader();
                    if (!reader.Read())
                    {
                        //guardar el rol
                        reader.Close();
                        string cod_rol = "";
                        com = new SqlCommand("insert into ntvc.rol (nombre, habilitacion) values (@nombre, 1)", con);
                        com.Parameters.AddWithValue("@nombre", textNombre.Text);
                        com.ExecuteNonQuery();
                        com = new SqlCommand("select cod_rol from ntvc.rol where nombre = @nombre", con);
                        com.Parameters.AddWithValue("@nombre", textNombre.Text);
                        reader.Close();
                        reader = com.ExecuteReader();
                        if (reader.Read())
                        {
                            cod_rol = reader["cod_rol"].ToString();
                        }
                        reader.Close();
                        foreach (int indice in checkedListBox1.CheckedIndices)
                        {
                            com = new SqlCommand("insert into ntvc.rol_funcionalidad (cod_rol, cod_funcionalidad) values(@cod_rol, @cod_funcionalidad)", con);
                            com.Parameters.AddWithValue("@cod_rol", cod_rol);
                            com.Parameters.AddWithValue("@cod_funcionalidad", indice + 1);
                            com.ExecuteNonQuery();
                        }
                        con.Close();
                        this.Close();
                        MessageBox.Show("El rol ha sido agregado exitosamente.", "Rol agregado", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                    else
                    {
                        //ya existe el rol
                        reader.Close();
                        MessageBox.Show("El rol ya existe. Por favor, ingrese otro nombre.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                        textNombre.Text = "";
                        con.Close();
                    }
                }
            }
        }
    }
}
