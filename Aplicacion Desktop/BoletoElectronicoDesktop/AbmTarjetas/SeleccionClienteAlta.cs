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
    public partial class SeleccionClienteAlta : Form
    {
        public SeleccionClienteAlta()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            FuncionesUtiles.llenarDataGridView("select * from ntvc.cliente where cod_cliente = 0", dataGridView1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

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
            FuncionesUtiles.llenarDataGridView("select * from ntvc.cliente where cod_cliente = 0", dataGridView1);
            
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            string query = "select nombre as Nombre, apellido as Apellido, doc as Documento, mail as Mail, telefono as Teléfono, dir_Calle as Calle, dir_nro as Número, dir_piso as Piso, dir_dpto as Depto from NTVC.Cliente where ";
            
            //chequeo que los campos sean numericos
            if ((FuncionesUtiles.esNumerico(textDNI) || FuncionesUtiles.estaVacio(textDNI)) && 
                (FuncionesUtiles.esNumerico(textTelefono) || FuncionesUtiles.estaVacio(textTelefono)) && 
                (FuncionesUtiles.esNumerico(textNumero) || FuncionesUtiles.estaVacio(textNumero)))
            {
                if (textNombre.Text != "")
                {
                    query += "nombre like '%" + textNombre.Text + "%' and ";
                }
                if (textApellido.Text != "")
                {
                    query += "apellido like '%" + textApellido.Text + "%' and ";
                }
                if (textDNI.Text != "")
                {
                    query += "DNI = " + textDNI.Text + " and ";
                }
                if (textTelefono.Text != "")
                {
                    query += "telefono = " + textTelefono.Text + " and ";
                }
                if (textMail.Text != "")
                {
                    query += "mail like '%" + textMail.Text + "%' and ";
                }
                if (textCalle.Text != "")
                {
                    query += "dir_calle like '%" + textCalle.Text + "%' and ";
                }
                if (textNumero.Text != "")
                {
                    query += "dir_nro = " + textNumero.Text + " and ";
                }
                if (textPiso.Text != "")
                {
                    query += "dir_piso = " + textPiso.Text + " and ";
                }
                if (textDepto.Text != "")
                {
                    query += "dir_dpto = '" + textDepto.Text + "' and ";
                }

                query += "1=1";
                FuncionesUtiles.llenarDataGridView(query, dataGridView1);
            }
            else
            {
                string mensaje = "Los siguientes campos deben ser numéricos y positivos:";
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
         }

        private void botSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {   
                string nombre = dataGridView1.SelectedCells[0].Value.ToString();
                string apellido = dataGridView1.SelectedCells[1].Value.ToString();
                string doc = dataGridView1.SelectedCells[2].Value.ToString();

                SqlConnection con = Conexion.conectar();
                con.Open();
                SqlCommand com = new SqlCommand("select cod_cliente from ntvc.cliente where nombre = @nombre and apellido = @apellido and doc = @doc", con);
                com.Parameters.AddWithValue("@nombre", nombre);
                com.Parameters.AddWithValue("@apellido", apellido);
                com.Parameters.AddWithValue("@doc", doc);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.Read())
                {
                    cod_cliente = reader["cod_cliente"].ToString();
                }
                reader.Close();
                con.Close();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
        }

       
    }
}
