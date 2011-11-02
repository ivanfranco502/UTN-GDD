using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.Facturación
{
    public partial class Saldo : Form
    {
        public Saldo()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
        }

        private void botAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
