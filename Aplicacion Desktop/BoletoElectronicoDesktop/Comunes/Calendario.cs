using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BoletoElectronicoDesktop.Comunes
{
    public partial class Calendario : Form
    {
        public Calendario()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string anio = monthCalendar1.SelectionRange.Start.Date.Year.ToString();
            string mes = monthCalendar1.SelectionRange.Start.Date.Month.ToString();
            string dia = monthCalendar1.SelectionRange.Start.Date.Day.ToString();

            fecha = anio;
            if (mes.Length == 1)
            {
                fecha += "0";
            }
            fecha += mes;
            if (dia.Length == 1)
            {
                fecha += "0";
            }
            fecha += dia;

        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            string anio = monthCalendar1.SelectionRange.Start.Date.Year.ToString();
            string mes = monthCalendar1.SelectionRange.Start.Date.Month.ToString();
            string dia = monthCalendar1.SelectionRange.Start.Date.Day.ToString();

            fecha = anio;
            if (mes.Length == 1)
            {
                fecha += "0";
            }
            fecha += mes;
            if (dia.Length == 1)
            {
                fecha += "0";
            }
            fecha += dia;
        }

        private void botSeleccionar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
