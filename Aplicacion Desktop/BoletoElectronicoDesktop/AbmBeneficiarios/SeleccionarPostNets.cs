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
    public partial class SeleccionarPostNets : Form
    {
        public SeleccionarPostNets()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            FuncionesUtiles.llenarDataGridView("select nro_serie as Serial, marca as Marca, modelo as Modelo from ntvc.postnet where cod_postnet = 0", dataGridView1);
        }

       

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            textMarca.Text = "";
            textModelo.Text = "";
            textNumeroSerie.Text = "";
            FuncionesUtiles.llenarDataGridView("select nro_serie as Serial, marca as Marca, modelo as Modelo from ntvc.postnet where cod_postnet = 0", dataGridView1);
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            if (!FuncionesUtiles.esNumerico(textNumeroSerie) && !FuncionesUtiles.estaVacio(textNumeroSerie))
            {
                MessageBox.Show("El número de serie debe ser numérico.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
            else
            {
                SqlConnection con = Conexion.conectar();
                con.Open();
                string busqueda = "select nro_serie as Serial, marca as Marca, modelo as Modelo from ntvc.postnet where cod_postnet not in (select cod_postnet from ntvc.beneficiario_postnet) and ";
                if (!FuncionesUtiles.estaVacio(textMarca))
                {
                    busqueda += "Marca like '%" + textMarca.Text + "%' and ";
                }
                if (!FuncionesUtiles.estaVacio(textModelo))
                {
                    busqueda += "Modelo like '%" + textModelo.Text + "%' and ";
                }
                if (!FuncionesUtiles.estaVacio(textNumeroSerie))
                {
                    busqueda += "nro_serie  = " + textNumeroSerie.Text + " and ";
                }
                busqueda += "1=1";
                FuncionesUtiles.llenarDataGridView(busqueda, dataGridView1);
                con.Close();
            }
        }

        private void botAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                serial_a = dataGridView1.SelectedCells[0].Value.ToString();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
        }
    }
}
