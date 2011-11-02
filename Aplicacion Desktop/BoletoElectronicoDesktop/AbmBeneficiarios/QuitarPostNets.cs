using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.AbmBeneficiarios
{
    public partial class QuitarPostNets : Form
    {
        public QuitarPostNets(List<string> serials)
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
            string select = "select nro_serie as Serial, marca as Marca, modelo as Modelo from ntvc.postnet where ";
            foreach (string serial in serials)
            {
                select += "nro_serie = " + serial + " or ";
            }
            select += "1=2";
            FuncionesUtiles.llenarDataGridView(select, dataGridView1);
            
        }

        private void botQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                serial_q = dataGridView1.SelectedCells[0].Value.ToString();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
            }
        }
    }
}
