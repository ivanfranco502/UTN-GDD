using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmTarjetas
{
    public partial class SeleccionClienteBM : Form
    {
        public SeleccionClienteBM()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
        }

        private void botSeleccionarFecha_Click(object sender, EventArgs e)
        {
            Comunes.Calendario formCalendario = new BoletoElectronicoDesktop.Comunes.Calendario();
            formCalendario.ShowDialog(this);
            textFechaAlta.Text = formCalendario.fecha;
        }

        private void botSeleccionarCliente_Click(object sender, EventArgs e)
        {
            SeleccionClienteAlta formSeleccion = new SeleccionClienteAlta();
            formSeleccion.ShowDialog(this);
            textCliente.Text = formSeleccion.cod_cliente;
        }

        private void botLimpiar_Click(object sender, EventArgs e)
        {
            this.textCliente.Text = "";
            this.textFechaAlta.Text = "";
            this.textNumeroTarjeta.Text = "";
            FuncionesUtiles.llenarDataGridView("select c.nombre as Nombre, c.apellido as Apellido, c.doc as Documento, t.nro_tarjeta as Número_tarjeta, t.fecha_alta as Fecha from NTVC.Cliente c, NTVC.tarjeta t where c.cod_cliente = 0 and t.cod_cliente = 0", dataGridView1);
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            string query = "select c.nombre as Nombre, c.apellido as Apellido, c.doc as Documento, t.nro_tarjeta as Número_tarjeta, t.fecha_alta as Fecha from NTVC.Cliente c, NTVC.tarjeta t where t.cod_cliente = c.cod_cliente and ";
            if (FuncionesUtiles.esNumerico(textNumeroTarjeta) || FuncionesUtiles.estaVacio(textNumeroTarjeta))
            {
                if (!FuncionesUtiles.estaVacio(textNumeroTarjeta))
                {
                    query += "t.nro_tarjeta = " + textNumeroTarjeta.Text + " and ";
                }
                if (!FuncionesUtiles.estaVacio(textFechaAlta))
                {
                    query += "t.fecha_alta = '" + textFechaAlta.Text + "' and ";
                }
                if (!FuncionesUtiles.estaVacio(textCliente))
                {
                    query += "t.cod_cliente = " + textCliente.Text + " and ";
                }
                query += "1=1";
                FuncionesUtiles.llenarDataGridView(query, dataGridView1);
            }
            else
            {
                MessageBox.Show("El número de tarjeta debe ser un valor numérico y menor a 2000000000", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
        }

        private void botModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ModificacionTarjetas form = new ModificacionTarjetas(dataGridView1.SelectedCells[3].Value.ToString());
                form.ShowDialog(this);
                this.Close(); 
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
        }

        private void botEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BajaTarjetas form = new BajaTarjetas(dataGridView1.SelectedCells[3].Value.ToString());
                form.ShowDialog(this);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
        }
    }
}
