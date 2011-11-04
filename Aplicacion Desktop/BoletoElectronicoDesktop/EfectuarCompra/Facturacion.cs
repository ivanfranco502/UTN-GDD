using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.Facturación
{
    public partial class Facturacion : Form
    {
        public Facturacion()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
        }

        private void botSeleccionarBenficiario_Click(object sender, EventArgs e)
        {
            SeleccionarBeneficiario form = new SeleccionarBeneficiario();
            form.ShowDialog(this);
            textBeneficiario.Text = form.razon_social;
            comboBoxPostNet.Items.Clear();
            cods_postnets_.Clear();
            if(!FuncionesUtiles.estaVacio(textBeneficiario))
            {
                SqlConnection con = Conexion.conectar();
                con.Open();
                SqlCommand com = new SqlCommand("select cod_beneficiario from ntvc.beneficiario where razon_social = @rs", con);
                com.Parameters.AddWithValue("@rs", form.razon_social);
                SqlDataReader reader = com.ExecuteReader();
                cod_beneficiario_ = "";
                if (reader.Read())
                {
                    cod_beneficiario_ = reader["cod_beneficiario"].ToString().Trim();
                }
                reader.Close();
                com = new SqlCommand("select p.cod_postnet, p.nro_serie, p.marca, p.modelo from ntvc.postnet p, ntvc.beneficiario_postnet bp where bp.cod_beneficiario = @cb and bp.cod_postnet = p.cod_postnet", con);
                com.Parameters.AddWithValue("@cb", cod_beneficiario_);
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    string pn = reader["modelo"].ToString().Trim() + " " + reader["marca"].ToString().Trim() + " (" + reader["nro_serie"].ToString().Trim() + ")";
                    comboBoxPostNet.Items.Add(pn);
                    cods_postnets_.Add(reader["cod_postnet"].ToString().Trim());
                }
                reader.Close();
                con.Close();
            }
        }

        private void botSeleccionarFecha_Click(object sender, EventArgs e)
        {
            Comunes.Calendario formCalendario = new BoletoElectronicoDesktop.Comunes.Calendario();
            formCalendario.ShowDialog(this);
            textFecha.Text = formCalendario.fecha;
        }

        private void botEfectuarCompra_Click(object sender, EventArgs e)
        {
            //verificar campos llenos
            if (FuncionesUtiles.estanVacios(new List<TextBox> { textBeneficiario, textFecha, textMonto, textNumeroTarjeta }) || comboBoxPostNet.SelectedIndex == -1)
            {
                string mensaje = "Debe completar los siguientes campos:";
                if (textBeneficiario.Text == "")
                {
                    mensaje += "\n-Beneficiario";
                }
                if (textFecha.Text == "")
                {
                    mensaje += "\n-Fecha";
                }
                if (textMonto.Text == "")
                {
                    mensaje += "\n-Monto";
                }
                if (textNumeroTarjeta.Text == "")
                {
                    mensaje += "\n-Número de tarjeta";
                }
                if (comboBoxPostNet.SelectedIndex == -1)
                {
                    mensaje += "\n-Post-net";
                }
                MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                //campos completos, verificar los numericos
                if (!FuncionesUtiles.sonNumericos(new List<TextBox> { textNumeroTarjeta }) || !FuncionesUtiles.esDecimal(textMonto))
                {
                    //hay campos numericos con valores no numericos
                    string mensaje = "Los siguientes campos deben ser numéricos y positivos:";
                    if (!FuncionesUtiles.esDecimal(textMonto))
                    {
                        mensaje += "\n-Monto";
                    }
                    if (!FuncionesUtiles.esNumerico(textNumeroTarjeta))
                    {
                        mensaje += "\n-Número de tarjeta";
                    }
                    MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                }
                else
                {
                    //campos correctos, verificar numero de tarjeta
                    SqlConnection con = Conexion.conectar();
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from ntvc.tarjeta where nro_tarjeta = @nro_tarjeta", con);
                    com.Parameters.AddWithValue("@nro_tarjeta", textNumeroTarjeta.Text);
                    SqlDataReader reader = com.ExecuteReader();
                    if (!reader.Read())
                    {
                        //no existe la tarjeta
                        reader.Close();
                        MessageBox.Show("No existe la tarjeta.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                    }
                    else
                    {
                        if (reader["habilitado"].ToString().Trim() == "0")
                        {
                            reader.Close();
                            MessageBox.Show("La tarjeta se encuentra inhabilitada.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                        }
                        else
                        {
                            decimal credito_actual = Convert.ToDecimal(reader["credito"].ToString().Trim());
                            decimal monto = Convert.ToDecimal(textMonto.Text.Trim());
                            if ( credito_actual < monto)
                            {
                                reader.Close();
                                MessageBox.Show("La tarjeta no posee crédito suficiente para realizar la operación.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                            }
                            else
                            {
                                //todo piola, hacer la transaccion

                                //actualizar credito
                                string cod_tarjeta = reader["cod_tarjeta"].ToString().Trim();
                                decimal credito_nuevo = Convert.ToDecimal(reader["credito"].ToString().Trim()) - Convert.ToDecimal(textMonto.Text);
                                reader.Close();
                                com = new SqlCommand("update ntvc.tarjeta set credito = @credito where cod_tarjeta = @cod_tarjeta", con);
                                com.Parameters.AddWithValue("@credito", credito_nuevo);
                                com.Parameters.AddWithValue("@cod_tarjeta", cod_tarjeta);
                                com.ExecuteNonQuery();
                                string cod_postnet = cods_postnets_[comboBoxPostNet.SelectedIndex];

                                //obtener codigo de compra
                                string codigo_compra = "";
                                com = new SqlCommand("select top 1 codigo from ntvc.compra order by codigo desc", con);
                                reader = com.ExecuteReader();
                                if (reader.Read())
                                {
                                    codigo_compra = reader["codigo"].ToString().Trim();
                                }
                                reader.Close();

                                //insertar compra
                                string insert = "insert into ntvc.compra (codigo, fecha, monto, cod_tarjeta, cod_beneficiario, cod_postnet) values ";
                                insert += "(@codigo, @fecha, @monto, @cod_tarjeta, @cod_beneficiario, @cod_postnet)";
                                com = new SqlCommand(insert, con);
                                com.Parameters.AddWithValue("@codigo", codigo_compra);
                                com.Parameters.AddWithValue("@fecha", textFecha.Text);
                                com.Parameters.AddWithValue("@monto", Convert.ToDecimal(textMonto.Text));
                                com.Parameters.AddWithValue("@cod_tarjeta", cod_tarjeta);
                                com.Parameters.AddWithValue("@cod_beneficiario", cod_beneficiario_);
                                com.Parameters.AddWithValue("@cod_postnet", cod_postnet);
                                com.ExecuteNonQuery();
                                this.Close();
                                Saldo form = new Saldo();
                                form.labelSaldo.Text = "La compra ha sido efectuada exitosamente.\nSu saldo es " + credito_nuevo.ToString() + ".";
                                form.ShowDialog(this);
                            }
                        }
                    }
                    con.Close();
                }
            }
        }
    }
}
