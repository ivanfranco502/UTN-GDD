using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BoletoElectronicoDesktop.PagoEmpresas
{
    public partial class FormPagoEmpresas : Form
    {
        public FormPagoEmpresas()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
        }

        private void botSeleccionarFechaInicio_Click(object sender, EventArgs e)
        {
            Comunes.Calendario formCalendario = new BoletoElectronicoDesktop.Comunes.Calendario();
            formCalendario.ShowDialog(this);
            textFechaInicio.Text = formCalendario.fecha;

        }

        private void botSeleccionarFechaFin_Click(object sender, EventArgs e)
        {
            Comunes.Calendario formCalendario = new BoletoElectronicoDesktop.Comunes.Calendario();
            formCalendario.ShowDialog(this);
            textFechaFin.Text = formCalendario.fecha;
        }

        private void botSeleccionarBenficiario_Click(object sender, EventArgs e)
        {

            SeleccionarBeneficiario form = new SeleccionarBeneficiario();
            form.ShowDialog(this);
            textBeneficiario.Text = form.razon_social;
            if(!FuncionesUtiles.estaVacio(textBeneficiario))
            {
                SqlConnection con = Conexion.conectar();
                con.Open();
                SqlCommand com = new SqlCommand("select cod_beneficiario from ntvc.beneficiario where razon_social = @rs", con);
                com.Parameters.AddWithValue("@rs", form.razon_social);
                SqlDataReader reader = com.ExecuteReader();
                string cod_beneficiario_ = "";
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
                }
                reader.Close();
                con.Close();
            }
        }

        private void butBuscarVentas_Click(object sender, EventArgs e)
        {

            string select = "SELECT  c.fecha FECHA,cli.apellido APELLIDO,cli.nombre NOMBRE,t.nro_tarjeta NRO_TARJETA,c.cod_postnet COD_POSNET,pos.marca MARCA,pos.modelo MODELO,c.monto MONTO FROM (((ntvc.beneficiario b INNER JOIN ntvc.compra c ON b.cod_beneficiario=c.cod_beneficiario) INNER JOIN ntvc.postnet pos ON pos.cod_postnet=c.cod_postnet) INNER JOIN ntvc.tarjeta t ON t.cod_tarjeta=c.cod_tarjeta) INNER JOIN ntvc.cliente cli ON cli.cod_cliente=t.cod_cliente WHERE b.razon_social=";
                if (!FuncionesUtiles.estaVacio(textBeneficiario))
                {
                    select +="'"+textBeneficiario.Text+"' and ";
                }
                if (!FuncionesUtiles.estaVacio(textFechaInicio))
                {
                    select += "c.fecha between'" + textFechaInicio.Text + "' and ";
                }
                if (!FuncionesUtiles.estaVacio(textFechaFin))
                {
                    select += "'" + textFechaFin.Text+ "'";
                }
                if ((!FuncionesUtiles.estaVacio(textFechaFin)) && (!FuncionesUtiles.estaVacio(textFechaInicio)) && (!FuncionesUtiles.estaVacio(textBeneficiario)))
                {
                FuncionesUtiles.llenarDataGridView(select, dataGridView1);
                }
            }

        private void botRegistrarPago_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.conectar();
            con.Open();
            SqlCommand com = new SqlCommand("INSERT INTO ntvc.pago SELECT c.fecha,c.monto monto,c.cod_beneficiario cod_ben,c.cod_compra cod_compra FROM ntvc.beneficiario b INNER JOIN ntvc.compra c ON b.cod_beneficiario=c.cod_beneficiario WHERE b.razon_social=@razon_social and c.fecha between @fechaInicio and @fechaFin", con);
            com.Parameters.AddWithValue("@razon_social", this.textBeneficiario.Text);
            com.Parameters.AddWithValue("@fechaInicio", this.textFechaInicio.Text);
            com.Parameters.AddWithValue("@fechaFin", this.textFechaFin.Text);
            com.ExecuteNonQuery();
            this.Close();
            MessageBox.Show("Los pagos se han registrado.", "Registro exitoso", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
            con.Close();
        }
        

     }
 }

