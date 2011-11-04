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
    public partial class ModificacionBeneficiario : Form
    {
        public ModificacionBeneficiario(string rs)
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            razon_social_vieja = rs;
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("select * from ntvc.rubro order by descripcion", con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBoxRubro.Items.Add(reader["descripcion"]);
            }
            reader.Close();
            com = new SqlCommand("select b.cod_beneficiario, b.razon_social, b.dir_calle , b.dir_nro , b.dir_piso , b.dir_dpto , r.descripcion from ntvc.beneficiario b, ntvc.rubro r where b.cod_rubro = r.cod_rubro and razon_social = @rs", con);
            com.Parameters.AddWithValue("@rs", razon_social_vieja);
            reader = com.ExecuteReader();
            cod_beneficiario_ = "";
            if (reader.Read())
            {
                cod_beneficiario_ = reader["cod_beneficiario"].ToString().Trim();
                textCalle.Text = reader["dir_calle"].ToString().Trim();
                textDepto.Text = reader["dir_dpto"].ToString().Trim();
                textNumero.Text = reader["dir_nro"].ToString().Trim();
                textPiso.Text = reader["dir_piso"].ToString().Trim();
                textRazonSocial.Text = reader["razon_social"].ToString().Trim();
                comboBoxRubro.SelectedIndex = comboBoxRubro.Items.IndexOf(reader["descripcion"]);
            }
            reader.Close();
            com = new SqlCommand("select p.nro_serie from ntvc.postnet p, ntvc.beneficiario_postnet bp where bp.cod_beneficiario = @cb and bp.cod_postnet = p.cod_postnet", con);
            com.Parameters.AddWithValue("@cb", cod_beneficiario_);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                serials.Add(reader["nro_serie"].ToString().Trim());
            }
            reader.Close();
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
            con.Close();
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
                    string mensaje = "Los siguientes campos deben ser numéricos y positivos:";
                    if (!FuncionesUtiles.esNumerico(textNumero) && !FuncionesUtiles.estaVacio(textNumero))
                    {
                        mensaje += "\n-Número";
                    }
                }
                else
                {
                    //campos correctos, verificar unicidad de la razon social
                    SqlConnection con = Conexion.conectar();
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from ntvc.beneficiario where razon_social = @razon_social and cod_beneficiario != @cb", con);
                    com.Parameters.AddWithValue("@razon_social", textRazonSocial.Text);
                    com.Parameters.AddWithValue("@cb", cod_beneficiario_);
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        //razon social repetida
                        reader.Close();
                        MessageBox.Show("La razón social ya se encuentra en el sistema.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                    }
                    else
                    {
                        //hacer update
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
                        string insert = "update NTVC.beneficiario set razon_social=@razon_social, dir_calle=@dir_calle, dir_nro=@dir_numero, ";
                        insert += " dir_piso=@dir_piso, dir_dpto=@dir_depto, habilitado=@habilitado, cod_rubro=@cod_rubro where cod_beneficiario = @cb";
                        com = new SqlCommand(insert, con);
                        com.Parameters.AddWithValue("@razon_social", textRazonSocial.Text);
                        com.Parameters.AddWithValue("@dir_calle", textCalle.Text);
                        com.Parameters.AddWithValue("@dir_numero", textNumero.Text);
                        com.Parameters.AddWithValue("@dir_piso", textPiso.Text);
                        com.Parameters.AddWithValue("@dir_depto", textDepto.Text);
                        if (chkHabilitado.CheckState == CheckState.Checked)
                        {
                            com.Parameters.AddWithValue("@habilitado", 1);
                        }
                        else
                        {
                            com.Parameters.AddWithValue("@habilitado", 0);
                        }
                        com.Parameters.AddWithValue("@cod_rubro", cod_rubro);
                        com.Parameters.AddWithValue("@cb", cod_beneficiario_);
                        com.ExecuteNonQuery();

                        //borrar postnets viejos
                        com = new SqlCommand("delete ntvc.beneficiario_postnet where cod_beneficiario = @cb", con);
                        com.Parameters.AddWithValue("@cb", cod_beneficiario_);
                        com.ExecuteNonQuery();
                        //insert de postnets
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
                            com.Parameters.AddWithValue("@cod_beneficiario", cod_beneficiario_);
                            com.Parameters.AddWithValue("@cod_postnet", cod_postnet);
                            com.ExecuteNonQuery();
                        }
                        MessageBox.Show("El beneficiario ha sido modificado.", "Modificación exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                        this.Close();
                    }
                    con.Close();
                }
            }
        }
    }
}
