using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmTarjetas
{
    public partial class ModificacionTarjetas : Form
    {
        public ModificacionTarjetas(string nro)
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            nro_tarjeta_viejo = nro;
            SqlConnection con = Conexion.conectar();
            con.Open();
            string query = "select nro_tarjeta, fecha_alta, cod_cliente from ntvc.tarjeta where nro_tarjeta = @nro_tarjeta";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@nro_tarjeta", nro_tarjeta_viejo);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                textCliente.Text = reader["cod_cliente"].ToString();
                textFechaAlta.Text = reader["fecha_alta"].ToString();
                textNumeroTarjeta.Text = reader["nro_tarjeta"].ToString();
            }
            cod_cliente_viejo = textCliente.Text;
            reader.Close();
            con.Close();
        }

        private void botSeleccionarCliente_Click(object sender, EventArgs e)
        {
            SeleccionClienteAlta formSeleccion = new SeleccionClienteAlta();
            formSeleccion.ShowDialog(this);
            textCliente.Text = formSeleccion.cod_cliente;
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            if (FuncionesUtiles.estanVacios(new List<TextBox> { textNumeroTarjeta, textCliente }))
            {

                string mensaje = "Debe completar los siguientes campos:";
                if (FuncionesUtiles.estaVacio(textNumeroTarjeta))
                {
                    mensaje += "\n-Número de tarjeta";
                }
                if (FuncionesUtiles.estaVacio(textCliente))
                {
                    mensaje += "\n-Cliente";
                }
                MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                if (FuncionesUtiles.esNumerico(this.textNumeroTarjeta))
                {
                    //el valor de numero de tarjeta es numerico
                    SqlConnection con = Conexion.conectar();
                    SqlCommand com = new SqlCommand("select nro_tarjeta from NTVC.TARJETA where nro_tarjeta = @nro_tarjeta", con);
                    com.Parameters.AddWithValue("@nro_tarjeta", this.textNumeroTarjeta.Text);
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.Read() && reader["nro_tarjeta"].ToString() != nro_tarjeta_viejo)
                    {
                        //ya existe esa tarjeta
                        MessageBox.Show("El número de tarjeta ingresado ya existe", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                        textNumeroTarjeta.Text = nro_tarjeta_viejo;
                        reader.Close();
                        con.Close();
                    }
                    else
                    {
                        reader.Close();
                        com = new SqlCommand("select * from NTVC.TARJETA where cod_cliente = @cod_cliente", con);
                        com.Parameters.AddWithValue("@cod_cliente", textCliente.Text);
                        reader = com.ExecuteReader();
                        if (reader.Read() && reader["cod_cliente"].ToString() != cod_cliente_viejo)
                        {
                            //el cliente ya tiene asignada una tarjeta
                            MessageBox.Show("El cliente ya tiene una tarjeta asignada.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                            textCliente.Text = cod_cliente_viejo;
                            reader.Close();
                            con.Close();
                        }
                        else
                        {
                            reader.Close();
                            com = new SqlCommand("update ntvc.tarjeta set nro_tarjeta = @nro_tarjeta, cod_cliente = @cod_cliente, habilitado = @habilitado where nro_tarjeta = @nro_viejo", con);
                            com.Parameters.AddWithValue("@nro_tarjeta", this.textNumeroTarjeta.Text);
                            if (chkHabilitado.Checked)
                            {
                                com.Parameters.AddWithValue("@habilitado", "1");
                            }
                            else
                            {
                                com.Parameters.AddWithValue("@habilitado", "0");
                            }
                            com.Parameters.AddWithValue("@nro_viejo", nro_tarjeta_viejo);
                            com.Parameters.AddWithValue("@cod_cliente", this.textCliente.Text);
                            com.ExecuteNonQuery();
                            this.Close();
                            MessageBox.Show("La tarjeta ha sido modificada.", "Modificación exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                            con.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El número de tarjeta debe ser un valor numérico menor a 2000000000", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                }
            }
        }

    }
}
