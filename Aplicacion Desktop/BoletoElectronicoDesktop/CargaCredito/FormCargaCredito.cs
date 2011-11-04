using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BoletoElectronicoDesktop.CargaCredito
{
    public partial class FormCargaCredito : Form
    {
        public FormCargaCredito()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            
        }

        private void botSeleccionarFecha_Click(object sender, EventArgs e)
        {
            Comunes.Calendario formCalendario = new BoletoElectronicoDesktop.Comunes.Calendario();
            formCalendario.ShowDialog(this);
            textFecha.Text = formCalendario.fecha;
        }

        private void botCargarCredito_Click(object sender, EventArgs e)
        {
            string cod_tarjeta;

            if (FuncionesUtiles.estanVacios(new List<TextBox> { textNumeroTarjeta, textFecha, textMonto }))
            {

                string mensaje = "Debe completar los siguientes campos:";
                if (FuncionesUtiles.estaVacio(textNumeroTarjeta))
                {
                    mensaje += "\n-Número de tarjeta";
                }
                if (FuncionesUtiles.estaVacio(textFecha))
                {
                    mensaje += "\n-Fecha";
                }
                if (FuncionesUtiles.estaVacio(textMonto))
                {
                    mensaje += "\n-Monto";
                }
                MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                if (FuncionesUtiles.esNumerico(this.textNumeroTarjeta))
                {
                    //el valor de numero de tarjeta es numerico
                    SqlConnection con = Conexion.conectar();
                    SqlCommand com = new SqlCommand("select * from NTVC.TARJETA where nro_tarjeta = @nro_tarjeta", con);
                    com.Parameters.AddWithValue("@nro_tarjeta", this.textNumeroTarjeta.Text);
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    //veo si el numero de tarjeta está repetido
                      if (reader.Read())
                        {
                            //la tarjeta existe
                            cod_tarjeta = reader["cod_tarjeta"].ToString().Trim();
                            reader.Close();
                            com = new SqlCommand("insert into ntvc.carga (cod_tarjeta, fecha,monto) values (@cod_tarjeta, @fecha, @monto)", con);
                            com.Parameters.AddWithValue("@cod_tarjeta", cod_tarjeta);
                            com.Parameters.AddWithValue("@fecha", this.textFecha.Text);
                            com.Parameters.AddWithValue("@monto", this.textMonto.Text);
                            com.ExecuteNonQuery();
                            this.Close();
                            MessageBox.Show("La tarjeta ha sido cargada.", "Carga exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("El número de tarjeta ingresado no existe", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                            reader.Close();
                            con.Close();
                        }
                    }
                
            }     
        }
    }
}
