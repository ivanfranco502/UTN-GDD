using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmBeneficiarios
{
    public partial class AltaBeneficiario : Form
    {
        public AltaBeneficiario()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("select * from ntvc.rubro order by descripcion", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBoxRubro.Items.Add(reader["descripcion"]);
            }
            reader.Close();
            con.Close();
        }

        private void AltaBeneficarios_Load(object sender, EventArgs e)
        {

        }

        private void botAgregarPostNets_Click(object sender, EventArgs e)
        {
            
            SeleccionarPostNets form = new SeleccionarPostNets();
            form.ShowDialog(this);
            if (form.serial_a != "")
            {
                if (!serials.Contains(form.serial_a))
                {
                    serials.Add(form.serial_a);
                    textPostNets.Text = "";
                    foreach (string serial in serials)
                    {
                        if (FuncionesUtiles.estaVacio(textPostNets))
                        {
                            textPostNets.Text = serial;
                        }
                        else
                        {
                            textPostNets.Text += ", " + serial;
                        }
                    }
                }
            }
        }

        private void botQuitarPostNets_Click(object sender, EventArgs e)
        {
            if (serials.Count() == 0)
            {
                MessageBox.Show("No hay post-nets que quitar", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                QuitarPostNets form = new QuitarPostNets(serials);
                form.ShowDialog(this);
                serials.Remove(form.serial_q);
                textPostNets.Text = "";
                foreach (string serial in serials)
                {
                    if (FuncionesUtiles.estaVacio(textPostNets))
                    {
                        textPostNets.Text = serial;
                    }
                    else
                    {
                        textPostNets.Text += ", " + serial;
                    }
                }
            }
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            textCalle.Text = "";
            textDepto.Text = "";
            textNumero.Text = "";
            textPiso.Text = "";
            textPostNets.Text = "";
            textRazonSocial.Text = "";
            comboBoxRubro.SelectedIndex = -1;
            serials.Clear();
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            if (FuncionesUtiles.estanVacios(new List<TextBox> { textPostNets, textCalle, textRazonSocial, textNumero }) || comboBoxRubro.SelectedIndex == -1)
            {
                string mensaje = "Debe completar los siguientes campos:";
                if (textRazonSocial.Text == "")
                {
                    mensaje += "\n-Razón social";
                }
                if (comboBoxRubro.SelectedIndex == -1)
                {
                    mensaje += "\n-Rubro";
                }
                if (textPostNets.Text == "")
                {
                    mensaje += "\n-Post-nets";
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
                if (!FuncionesUtiles.sonNumericos(new List<TextBox> { textNumero }))
                {
                    //hay campos numericos con valores no numericos
                    string mensaje = "Los siguientes campos deben ser numéricos:";
                    if (!FuncionesUtiles.esNumerico(textNumero) && !FuncionesUtiles.estaVacio(textNumero))
                    {
                        mensaje += "\n-Número";
                    }
                    MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                }
                else
                {
                    //campos correctos, verificar unicidad de la razon social
                    SqlConnection con = Conexion.conectar();
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from ntvc.beneficiario where razon_social = @razon_social", con);
                    com.Parameters.AddWithValue("@razon_social", textRazonSocial.Text);
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        //razon social repetida
                        reader.Close();
                        MessageBox.Show("La razón social ya se encuentra en el sistema.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                    }
                    else
                    {
                        //hacer insert
                        reader.Close();
                        string cod_rubro = "";
                        com = new SqlCommand("select cod_rubro from ntvc.rubro where descripcion = @descripcion", con);
                        com.Parameters.AddWithValue("@descripcion", comboBoxRubro.Items[comboBoxRubro.SelectedIndex].ToString().Trim());
                        reader = com.ExecuteReader();
                        if (reader.Read())
                        {
                            cod_rubro = reader["cod_rubro"].ToString().Trim();
                        }
                        reader.Close();
                        string insert = "Insert into NTVC.beneficiario (razon_social, dir_calle, dir_nro, dir_piso, dir_dpto, habilitado, cod_rubro)";
                        insert += " values(@razon_social, @dir_calle, @dir_numero, @dir_piso, @dir_depto, @habilitado, @cod_rubro)";
                        com = new SqlCommand(insert, con);
                        com.Parameters.AddWithValue("@razon_social", textRazonSocial.Text);
                        com.Parameters.AddWithValue("@dir_calle", textCalle.Text);
                        com.Parameters.AddWithValue("@dir_numero", textNumero.Text);
                        com.Parameters.AddWithValue("@dir_piso", textPiso.Text);
                        com.Parameters.AddWithValue("@dir_depto", textDepto.Text);
                        com.Parameters.AddWithValue("@habilitado", 1);
                        com.Parameters.AddWithValue("@cod_rubro", cod_rubro);
                        com.ExecuteNonQuery();
                        
                        //insert de postnets
                        string cod_beneficiario = "";
                        com = new SqlCommand("select cod_beneficiario from ntvc.beneficiario where razon_social = @razon_social", con);
                        com.Parameters.AddWithValue("@razon_social", textRazonSocial.Text);
                        reader = com.ExecuteReader();
                        if (reader.Read())
                        {
                            cod_beneficiario = reader["cod_beneficiario"].ToString().Trim();
                        }
                        reader.Close();
                        foreach (string serial in serials)
                        {
                            string cod_postnet = "";
                            com = new SqlCommand("select cod_postnet from ntvc.postnet where nro_serie = @serial", con);
                            com.Parameters.AddWithValue("@serial", serial);
                            reader = com.ExecuteReader();
                            if (reader.Read())
                            {
                                cod_postnet = reader["cod_postnet"].ToString().Trim();
                            }
                            reader.Close();
                            com = new SqlCommand("insert into ntvc.beneficiario_postnet (cod_beneficiario, cod_postnet) values (@cod_beneficiario, @cod_postnet)", con);
                            com.Parameters.AddWithValue("@cod_beneficiario", cod_beneficiario);
                            com.Parameters.AddWithValue("@cod_postnet", cod_postnet);
                            com.ExecuteNonQuery();
                        }
                        MessageBox.Show("El beneficiario ha sido agregado.", "Alta exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                        this.Close();
                    }
                    con.Close();
                }
            }
        }
    }
}
