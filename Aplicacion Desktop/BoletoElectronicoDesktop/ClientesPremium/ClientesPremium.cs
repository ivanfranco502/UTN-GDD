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
            string select = "SELECT * from NTVC.ClientePremium(" + numericUpDown1.Text + ")";
            FuncionesUtiles.llenarDataGridView(select, dataGridView1);
           
        }
    }
}
