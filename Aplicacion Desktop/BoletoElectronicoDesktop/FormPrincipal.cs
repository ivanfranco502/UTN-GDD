using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal(int cod_usuario)
        {
            InitializeComponent();
            this.BackgroundImage = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE;
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
