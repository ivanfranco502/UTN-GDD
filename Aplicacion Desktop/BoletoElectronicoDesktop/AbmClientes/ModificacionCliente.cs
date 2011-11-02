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
    public partial class ModificacionCliente : Form
    {
        public ModificacionCliente(string tipo_doc, string doc)
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            tipo_doc_ = tipo_doc;
            doc_ = doc;

            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("select * from ntvc.provincia order by nombre", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["nombre"]);
            }
            reader.Close();

            string query = "select c.nombre as Nombre, c.apellido as Apellido, c.tipo_doc as Tipo, c.doc as Documento, p.nombre as Provincia, c.mail as Mail, c.telefono as Teléfono, c.dir_calle as Calle, c.dir_nro as Número, c.dir_piso as Piso, c.dir_dpto as Depto from NTVC.Cliente c, NTVC.provincia p where c.tipo_doc = @tipo_doc and c.doc = @doc and c.cod_provincia = p.cod_provincia";
            com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@tipo_doc", tipo_doc_);
            com.Parameters.AddWithValue("@doc", doc_);
            reader = com.ExecuteReader();
            if (reader.Read())
            {
                textNumero.Text = reader["Número"].ToString().Trim();
                textCalle.Text = reader["Calle"].ToString().Trim();
                textPiso.Text = reader["Piso"].ToString().Trim();
                textDepto.Text = reader["Depto"].ToString().Trim();
                textNombre.Text = reader["Nombre"].ToString().Trim();
                textApellido.Text = reader["Apellido"].ToString().Trim();
                textMail.Text = reader["Mail"].ToString().Trim();
                textTelefono.Text = reader["Teléfono"].ToString().Trim();
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(reader["Provincia"]);
                textTD.Text = tipo_doc_;
                textDoc.Text = doc_;
           }
            reader.Close();
            con.Close();
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            if (FuncionesUtiles.estanVacios(new List<TextBox> { textApellido, textCalle, textMail, textNombre, textNumero, textTelefono }) || comboBox1.SelectedIndex == -1)
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
                if (!FuncionesUtiles.sonNumericos(new List<TextBox> { textNumero, textTelefono }))
                {
                    //hay campos numericos con valores no numericos
                    string mensaje = "Los siguientes campos deben ser numéricos:";
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
                    //campos correctos
                    SqlConnection con = Conexion.conectar();
                    con.Open();
                    //hacer update
                    string cod_prov = "";
                    SqlCommand com = new SqlCommand("select cod_provincia from ntvc.provincia  where nombre = @nombre_prov", con);
                    com.Parameters.AddWithValue("@nombre_prov", comboBox1.Items[comboBox1.SelectedIndex].ToString().Trim());
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        cod_prov = reader["cod_provincia"].ToString().Trim();
                    }
                    reader.Close();
                    string update = "UPDATE NTVC.cliente set nombre = @nombre, apellido = @apellido, mail = @mail, telefono = @telefono,";
                    update += " dir_calle = @dir_calle, dir_nro = @dir_numero, dir_piso = @dir_piso, dir_dpto = @dir_depto, habilitado = @habilitado, cod_provincia = @cod_provincia";
                    update += " where doc = @doc and tipo_doc = @tipo_doc";
                    com = new SqlCommand(update, con);
                    com.Parameters.AddWithValue("@nombre", textNombre.Text);
                    com.Parameters.AddWithValue("@apellido", textApellido.Text);
                    com.Parameters.AddWithValue("@tipo_doc", tipo_doc_);
                    com.Parameters.AddWithValue("@doc", doc_);
                    com.Parameters.AddWithValue("@mail", textMail.Text);
                    com.Parameters.AddWithValue("@telefono", textTelefono.Text);
                    com.Parameters.AddWithValue("@dir_calle", textCalle.Text);
                    com.Parameters.AddWithValue("@dir_numero", textNumero.Text);
                    com.Parameters.AddWithValue("@dir_piso", textPiso.Text);
                    com.Parameters.AddWithValue("@dir_depto", textDepto.Text);
                    if(chkHabilitado.CheckState == CheckState.Checked)
                    {
                        com.Parameters.AddWithValue("@habilitado", 1);
                    }
                    else
                    {
                        com.Parameters.AddWithValue("@habilitado", 0);
                    }
                    com.Parameters.AddWithValue("@cod_provincia", cod_prov);
                    com.ExecuteNonQuery();
                    MessageBox.Show("El cliente ha sido modificado.", "Modificación exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                    this.Close();
                
                    con.Close();
                }
            }      
        }
    }
}
