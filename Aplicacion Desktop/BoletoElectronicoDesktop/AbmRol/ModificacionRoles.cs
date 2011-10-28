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
    public partial class ModificacionRoles : Form
    {
        public ModificacionRoles(string cod_rol)
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            cod_rol_modificar = cod_rol;
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("select nombre from ntvc.rol where cod_rol = @cod_rol", con);
            com.Parameters.AddWithValue("@cod_rol", cod_rol_modificar);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                textNombre.Text = reader["nombre"].ToString();
                nombre_rol_viejo = textNombre.Text;
            }
            reader.Close();
            com = new SqlCommand("select cod_funcionalidad from ntvc.rol_funcionalidad where cod_rol = @cod_rol order by cod_funcionalidad", con);
            com.Parameters.AddWithValue("@cod_rol", cod_rol_modificar);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                int indice = -1;
                Int32.TryParse(reader["cod_funcionalidad"].ToString(), out indice);
                checkedListBox1.SetItemCheckState(indice - 1, CheckState.Checked);
            }
            reader.Close();
            con.Close();
        }

        private void botModificar_Click(object sender, EventArgs e)
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
                    if (!reader.Read() || textNombre.Text == nombre_rol_viejo)
                    {
                        //guardar el rol
                        reader.Close();
                        com = new SqlCommand("update ntvc.rol set nombre = @nombre, habilitacion = @habilitado where cod_rol = @cod_rol", con);
                        com.Parameters.AddWithValue("@cod_rol", cod_rol_modificar);
                        com.Parameters.AddWithValue("@nombre", textNombre.Text);
                        if (chkHabilitado.Checked)
                        {
                            com.Parameters.AddWithValue("@habilitado", "1");
                        }
                        else
                        {
                            com.Parameters.AddWithValue("@habilitado", "0");
                        }
                        com.ExecuteNonQuery();
                        com = new SqlCommand("delete ntvc.rol_funcionalidad where cod_rol = @cod_rol", con);
                        com.Parameters.AddWithValue("@cod_rol", cod_rol_modificar);
                        com.ExecuteNonQuery();
                        foreach (int indice in checkedListBox1.CheckedIndices)
                        {
                            com = new SqlCommand("insert into ntvc.rol_funcionalidad (cod_rol, cod_funcionalidad) values(@cod_rol, @cod_funcionalidad)", con);
                            com.Parameters.AddWithValue("@cod_rol", cod_rol_modificar);
                            com.Parameters.AddWithValue("@cod_funcionalidad", indice + 1);
                            com.ExecuteNonQuery();
                        }
                        con.Close();
                        this.Close();
                        MessageBox.Show("El rol ha sido modificado exitosamente.", "Rol agregado", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    }
                    else
                    {
                        //ya existe el rol
                        reader.Close();
                        MessageBox.Show("El rol ya existe. Por favor, ingrese otro nombre.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                        textNombre.Text = nombre_rol_viejo;
                        con.Close();
                    }
                }
            }
        }
    }
}
