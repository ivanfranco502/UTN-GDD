using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BoletoElectronicoDesktop.InactividadTarjetas
{
    public partial class InactividadTarjetas : Form
    {
        public InactividadTarjetas()
        {
            InitializeComponent();
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;

            string select ="SELECT tablet.nombre NOMBRE,tablet.apellido APELLIDO,tablet.doc DNI,aux2.razon_social ULTIMO_BENEFICIARIO,aux2.fecha FECHA_ULTIMA_COMPRA,aux2.postnet ULTIMO_POSTNET,aux2.monto MONTO_TOTAL FROM ((SELECT b.razon_social razon_social,aux.fecha fecha,aux.codigo_tarjeta codigo_tarjeta,aux.postnet postnet,aux.monto monto FROM ((SELECT beneficiario,postnet,o.codigo_tarjeta,u.fecha,monto FROM (SELECT cod_beneficiario beneficiario,cod_postnet postnet,MAX(fecha) fecha,c.cod_tarjeta codigo_tarjeta FROM ntvc.compra c GROUP BY c.cod_beneficiario,c.cod_tarjeta,cod_postnet) AS u INNER JOIN (SELECT MAX(c.fecha) fecha,c.cod_tarjeta codigo_tarjeta,SUM(c.monto) monto FROM ntvc.compra c WHERE (getdate()-fecha)>30 GROUP BY c.cod_tarjeta)AS o ON  o.codigo_tarjeta=u.codigo_tarjeta and o.fecha=u.fecha))AS aux INNER JOIN ntvc.beneficiario b ON b.cod_beneficiario=aux.beneficiario)) aux2 INNER JOIN (SELECT cli.nombre nombre,cli.apellido apellido,cli.doc doc,t.cod_tarjeta cod_tarjeta FROM ntvc.cliente cli INNER JOIN ntvc.tarjeta t ON cli.cod_cliente=t.cod_cliente) AS tablet ON tablet.cod_tarjeta=aux2.codigo_tarjeta";
            FuncionesUtiles.llenarDataGridView(select, dataGridView1);
        }

        private void botInhabilitar_Click(object sender, EventArgs e)
        {
            SqlConnection con = Conexion.conectar();
            SqlCommand com = new SqlCommand("DECLARE @cod_tarjeta int DECLARE miCursor CURSOR FOR SELECT aux2.codigo_tarjeta CODIGO_TARJETA FROM ((SELECT b.razon_social razon_social,aux.fecha fecha,aux.codigo_tarjeta codigo_tarjeta,aux.postnet postnet,aux.monto monto FROM ((SELECT beneficiario,postnet,o.codigo_tarjeta,u.fecha,monto FROM (SELECT cod_beneficiario beneficiario,cod_postnet postnet,MAX(fecha) fecha,c.cod_tarjeta codigo_tarjeta FROM ntvc.compra c GROUP BY c.cod_beneficiario,c.cod_tarjeta,cod_postnet) AS u INNER JOIN (SELECT MAX(c.fecha) fecha,c.cod_tarjeta codigo_tarjeta,SUM(c.monto) monto FROM ntvc.compra c WHERE (getdate()-fecha)>30 GROUP BY c.cod_tarjeta)AS o ON  o.codigo_tarjeta=u.codigo_tarjeta and o.fecha=u.fecha))AS aux INNER JOIN ntvc.beneficiario b ON b.cod_beneficiario=aux.beneficiario)) aux2 INNER JOIN (SELECT cli.nombre nombre,cli.apellido apellido,cli.doc doc,t.cod_tarjeta cod_tarjeta FROM ntvc.cliente cli INNER JOIN ntvc.tarjeta t ON cli.cod_cliente=t.cod_cliente) AS tablet ON tablet.cod_tarjeta=aux2.codigo_tarjeta OPEN miCursor FETCH miCursor INTO @cod_tarjeta WHILE (@@FETCH_STATUS = 0 )BEGIN	UPDATE ntvc.tarjeta	SET habilitado=0 WHERE cod_tarjeta=@cod_tarjeta	FETCH miCursor INTO @cod_tarjeta END CLOSE miCursor DEALLOCATE miCursor", con);
            con.Open();
            com.ExecuteReader();
            this.Close();
            MessageBox.Show("Se han deshabilitado las tarjetas.", "Baja exitosa", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);
            con.Close();
        }

    }
}
