using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmClientes
{
    public partial class AltaClientes : Form
    {
        public AltaClientes()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            FuncionesUtiles.llenarTipoDoc(comboBoxTD);
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("select * from ntvc.provincia where cod_provincia != 26 order by nombre", con);
            SqlDataReader reader = com.ExecuteReader();
            while(reader.Read())
            {
                comboBox1.Items.Add(reader["nombre"]);
            }
            reader.Close();
            con.Close();

        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            textApellido.Text = "";
            textCalle.Text = "";
            textDepto.Text = "";
            textDNI.Text = "";
            textMail.Text = "";
            textNombre.Text = "";
            textNumero.Text = "";
            textPiso.Text = "";
            textTelefono.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBoxTD.SelectedIndex = -1;
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (FuncionesUtiles.estanVacios(new List<TextBox>{textApellido, textCalle, textDNI, textMail, textNombre, textNumero, textTelefono}) || comboBoxTD.SelectedIndex == -1 || comboBox1.SelectedIndex == -1)
            {   
                string mensaje = "Debe completar los siguientes campos:";
                if (textNombre.Text == "")
                {
                    mensaje += "\n-Nombre";
                }
                if (textApellido.Text == "")
                {
                    mensaje += "\n-Apellido";
                }
                if (comboBoxTD.SelectedIndex == -1)
                {
                    mensaje += "\n-Tipo de documento";
                }
                if (textDNI.Text == "")
                {
                    mensaje += "\n-Documento";
                }
                if (comboBox1.SelectedIndex == -1)
                {
                    mensaje += "\n-Provincia";
                }
                if (textTelefono.Text == "")
                {
                    mensaje += "\n-Teléfono";
                }
                if (textMail.Text == "")
                {
                    mensaje += "\n-Mail";
                }
                if (textCalle.Text == "")
                {
                    mensaje += "\n-Calle";
                }
                if (textNumero.Text == "")
                {
                    mensaje += "\n-Número";
                }
                MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                //campos completos, verificar los numericos
                if (!FuncionesUtiles.sonNumericos(new List<TextBox> { textDNI, textNumero, textTelefono }))
                {
                    //hay campos numericos con valores no numericos
                    string mensaje = "Los siguientes campos deben ser numéricos:";
                    if (!FuncionesUtiles.esNumerico(textDNI) && !FuncionesUtiles.estaVacio(textDNI))
                    {
                        mensaje += "\n-Documento";
                    }
                    if (!FuncionesUtiles.esNumerico(textTelefono) && !FuncionesUtiles.estaVacio(textTelefono))
                    {
                        mensaje += "\n-Teléfono";
                    }
                    if (!FuncionesUtiles.esNumerico(textNumero) && !FuncionesUtiles.estaVacio(textNumero))
                    {
                        mensaje += "\n-Número";
                    }
                    MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);                    
                }
                else
                {
                    //campos correctos, verificar unicidad del DNI
                    SqlConnection con = Conexion.conectar();
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from ntvc.cliente where doc = @doc and tipo_doc = @tipo", con);
                    com.Parameters.AddWithValue("@tipo", FuncionesUtiles.obtenerTipoDoc(comboBoxTD.SelectedIndex));
                    com.Parameters.AddWithValue("@doc", textDNI.Text);
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        //dni repetido
                        reader.Close();
                        MessageBox.Show("El Documento ya se encuentra en el sistema.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                    }
                    else
                    {
                        //hacer insert
                        reader.Close();
                        string cod_prov = "";
                        com = new SqlCommand("select cod_provincia from ntvc.provincia  where nombre = @nombre_prov", con);
                        com.Parameters.AddWithValue("@nombre_prov", comboBox1.Items[comboBox1.SelectedIndex].ToString().Trim());
                        reader = com.ExecuteReader();
                        if (reader.Read())
                        {
                            cod_prov = reader["cod_provincia"].ToString().Trim();
                        }
                        reader.Close();
                        string insert = "Insert into NTVC.cliente (nombre, apellido, tipo_doc, doc, mail, telefono, dir_calle, dir_nro, dir_piso, dir_dpto, habilitado, cod_provincia)";
                        insert += " values(@nombre, @apellido, @tipo_doc, @doc, @mail, @telefono, @dir_calle, @dir_numero, @dir_piso, @dir_depto, @habilitado, @cod_provincia)";
                        com = new SqlCommand(insert, con);
                        com.Parameters.AddWithValue("@nombre", textNombre.Text);
                        com.Parameters.AddWithValue("@apellido", textApellido.Text);
                        com.Parameters.AddWithValue("@tipo_doc", FuncionesUtiles.obtenerTipoDoc(comboBoxTD.SelectedIndex));
                        com.Parameters.AddWithValue("@doc", textDNI.Text);
                        com.Parameters.AddWithValue("@mail", textMail.Text);
                        com.Parameters.AddWithValue("@telefono", textTelefono.Text);
                        com.Parameters.AddWithValue("@dir_calle", textCalle.Text);
                        com.Parameters.AddWithValue("@dir_numero", textNumero.Text);
                        com.Parameters.AddWithValue("@dir_piso", textPiso.Text);
                        com.Parameters.AddWithValue("@dir_depto", textDepto.Text);
                        com.Parameters.AddWithValue("@habilitado", 1);
                        com.Parameters.AddWithValue("@cod_provincia", cod_prov);                        
                        com.ExecuteNonQuery();
                        MessageBox.Show("El cliente ha sido agregado.", "Alta exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                        this.Close();
                    }
                    con.Close();
                }
            }      
        }
    }
}
