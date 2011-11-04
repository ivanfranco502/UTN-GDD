using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.ClientesPremium
{
    public partial class ClientesPremium : Form
    {
        public ClientesPremium()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
        }

        private void botAnalizar_Click(object sender, EventArgs e)
        {
            string select = "SELECT cli.apellido APELLIDO,cli.nombre NOMBRE,cli.doc DOCUMENTO,t.nro_tarjeta NRO_TARJETA,aux.fecha FECHA,aux.monto MONTO FROM (ntvc.tarjeta t INNER JOIN (SELECT TOP 30 MAX(c.fecha) fecha,c.cod_tarjeta codigo_tarjeta,SUM(c.monto) monto FROM ntvc.compra c WHERE year(fecha)=";

            select += "'" + numericUpDown1.Text + "' GROUP BY c.cod_tarjeta ORDER BY monto DESC) AS AUX ON aux.codigo_tarjeta=t.cod_tarjeta) INNER JOIN ntvc.cliente cli ON cli.cod_cliente=t.cod_cliente";

            FuncionesUtiles.llenarDataGridView(select, dataGridView1);
           
        }
    }
}
