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
    public partial class SeleccionarBeneficiario : Form
    {
        public SeleccionarBeneficiario()
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

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            textCalle.Text = "";
            textDepto.Text = "";
            textNumero.Text = "";
            textPiso.Text = "";
            textRazonSocial.Text = "";
            comboBoxRubro.SelectedIndex = -1;
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            //verificar los numericos
            if ((!FuncionesUtiles.esNumerico(textNumero) && !FuncionesUtiles.estaVacio(textNumero)))
            {
                //hay campos numericos con valores no numericos
                string mensaje = "Los siguientes campos deben ser numéricos:";
                if (!FuncionesUtiles.esNumerico(textNumero) && !FuncionesUtiles.estaVacio(textNumero))
                {
                    mensaje += "\n-Número";
                }
            }
            else
            {
                SqlConnection con = Conexion.conectar();
                con.Open();
                SqlCommand com;
                SqlDataReader reader;
                string cod_rubro = "";
                if (comboBoxRubro.SelectedIndex > -1)
                {
                    com = new SqlCommand("select cod_rubro from ntvc.rubro where descripcion = @descripcion", con);
                    com.Parameters.AddWithValue("@descripcion", comboBoxRubro.Items[comboBoxRubro.SelectedIndex].ToString().Trim());
                    reader = com.ExecuteReader();
                    if (reader.Read())
                    {
                        cod_rubro = reader["cod_rubro"].ToString().Trim();
                    }
                    reader.Close();
                }
                string select = "select distinct b.razon_social as Razón_Social, b.dir_calle as Calle, b.dir_nro as Número, b.dir_piso as Piso, b.dir_dpto as Depto, r.descripcion as Rubro from ntvc.beneficiario b, ntvc.rubro r where b.cod_rubro = r.cod_rubro and ";
                if (!FuncionesUtiles.estaVacio(textCalle))
                {
                    select += "b.dir_calle like '%" + textCalle.Text + "%' and ";
                }
                if (!FuncionesUtiles.estaVacio(textDepto))
                {
                    select += "b.dir_dpto like '%" + textDepto.Text + "%' and ";
                }
                if (!FuncionesUtiles.estaVacio(textNumero))
                {
                    select += "b.dir_nro = " + textNumero.Text + " and ";
                }
                if (!FuncionesUtiles.estaVacio(textPiso))
                {
                    select += "b.dir_piso = " + textPiso.Text + " and ";
                }
                if (!FuncionesUtiles.estaVacio(textRazonSocial))
                {
                    select += "b.razon_social like '%" + textRazonSocial.Text + "%' and ";
                }
                if (comboBoxRubro.SelectedIndex > -1)
                {
                    select += "r.descripcion = '" + comboBoxRubro.Items[comboBoxRubro.SelectedIndex].ToString().Trim() + "' and ";
                }
                select += "1 = 1";
                FuncionesUtiles.llenarDataGridView(select, dataGridView1);
                con.Close();
            }
        }

        private void botSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                razon_social = dataGridView1.SelectedCells[0].Value.ToString().Trim();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
        }
    }
}
