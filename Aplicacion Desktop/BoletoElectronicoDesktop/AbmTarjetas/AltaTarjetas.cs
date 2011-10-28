using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BoletoElectronicoDesktop.AbmTarjetas
{
    public partial class AltaTarjetas : Form
    {
        public AltaTarjetas()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            this.textCliente.Text = "";
            this.textFechaAlta.Text = "";
            this.textNumeroTarjeta.Text = "";
        }

        private void botGuardar_Click(object sender, EventArgs e)
        {
            
            if (FuncionesUtiles.estanVacios(new List<TextBox>{textNumeroTarjeta, textFechaAlta, textCliente}))
            {
                
                string mensaje = "Debe completar los siguientes campos:";
                if (FuncionesUtiles.estaVacio(textNumeroTarjeta))
                {
                    mensaje += "\n-Número de tarjeta";
                }
                if (FuncionesUtiles.estaVacio(textFechaAlta))
                {
                    mensaje += "\n-Fecha de alta";
                }
                if (FuncionesUtiles.estaVacio(textCliente))
                {
                    mensaje += "\n-Cliente";
                }
                MessageBox.Show(mensaje, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                if(FuncionesUtiles.esNumerico(this.textNumeroTarjeta))
                {
                    //el valor de numero de tarjeta es numerico
                    SqlConnection con = Conexion.conectar();
                    SqlCommand com = new SqlCommand("select nro_tarjeta from NTVC.TARJETA where nro_tarjeta = @nro_tarjeta", con);
                    com.Parameters.AddWithValue("@nro_tarjeta", this.textNumeroTarjeta.Text);
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    if(reader.Read()){
                        //ya existe esa tarjeta
                        MessageBox.Show("El número de tarjeta ingresado ya existe", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                        reader.Close();
                        con.Close();
                    }
                    else
                    {
                        reader.Close();
                        com = new SqlCommand("insert into ntvc.tarjeta (nro_tarjeta, fecha_alta, credito, cod_cliente) values (@nro_tarjeta, @fecha_alta, @cred, @cod_cliente)",con);
                        com.Parameters.AddWithValue("@nro_tarjeta", this.textNumeroTarjeta.Text);
                        com.Parameters.AddWithValue("@fecha_alta", this.textFechaAlta.Text);
                        com.Parameters.AddWithValue("@cred", 0);
                        com.Parameters.AddWithValue("@cod_cliente", this.textCliente.Text);
                        com.ExecuteNonQuery();
                        this.Close();
                        MessageBox.Show("La tarjeta ha sido agregada.", "Alta exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("El número de tarjeta debe ser un valor numérico menor a 2000000000", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
                }

            }
        }

        private void botSeleccionarCliente_Click(object sender, EventArgs e)
        {
            SeleccionClienteAlta formSeleccion = new SeleccionClienteAlta();
            formSeleccion.ShowDialog(this);
            textCliente.Text = formSeleccion.cod_cliente;
        }

        private void botSeleccionarFecha_Click(object sender, EventArgs e)
        {
            Comunes.Calendario formCalendario = new BoletoElectronicoDesktop.Comunes.Calendario();
            formCalendario.ShowDialog(this);
            textFechaAlta.Text = formCalendario.fecha;
        }

        
    }
}
