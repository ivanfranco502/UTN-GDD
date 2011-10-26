using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BoletoElectronicoDesktop
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            
            Login.FormLogin formLog = new Login.FormLogin();
            formLog.ShowDialog(this);
            
            
            InitializeComponent();
            this.BackgroundImage = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE;
            this.Icon = BoletoElectronicoDesktop.Properties.Resources.NTVCSUBE1;


            int cod_usuario = formLog.cod_usuario;
            SqlConnection con = Conexion.conectar();
            String comText = "select distinct(F.descripcion) " +
                             "from ntvc.usuario_rol ur, ntvc.rol r, ntvc.rol_funcionalidad rf, ntvc.funcionalidad f " +
                             "where ur.cod_usuario = @cu and ur.cod_rol = r.cod_rol and r.cod_rol = rf.cod_rol and rf.cod_funcionalidad = f.cod_funcionalidad";
            SqlCommand com = new SqlCommand(comText, con);
            com.Parameters.AddWithValue("@cu", cod_usuario);
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                switch (Convert.ToString(reader.GetValue(0)).Trim())
                {
                    case "ABM de Beneficiarios/Empresas":
                        this.adminToolStripMenuItem.Visible = true;
                        this.beneficiariosEmpresasToolStripMenuItem.Visible = true;
                        this.altaBEToolStripMenuItem.Visible = true;
                        this.bajaBEToolStripMenuItem.Visible = true;
                        this.modifBEToolStripMenuItem.Visible = true;
                        break;
                    case "ABM de Cliente":
                        this.adminToolStripMenuItem.Visible = true;
                        this.clientesToolStripMenuItem.Visible = true;
                        this.altaCtoolStripMenuItem10.Visible = true;
                        this.bajaCtoolStripMenuItem11.Visible = true;
                        this.modifCtoolStripMenuItem12.Visible = true;
                        break;
                    case "ABM de Rol":
                        this.adminToolStripMenuItem.Visible = true;
                        this.rolesToolStripMenuItem.Visible = true;
                        this.altaRtoolStripMenuItem7.Visible = true;
                        this.bajaRtoolStripMenuItem8.Visible = true;
                        this.modifRtoolStripMenuItem9.Visible = true;
                        break;
                    case "ABM de Tarjetas":
                        this.adminToolStripMenuItem.Visible = true;
                        this.tarjetasToolStripMenuItem.Visible = true;
                        this.altaTtoolStripMenuItem4.Visible = true;
                        this.bajaTtoolStripMenuItem5.Visible = true;
                        this.modifTtoolStripMenuItem6.Visible = true;
                        break;
                    case "ABM de Usuario":
                        this.adminToolStripMenuItem.Visible = true;
                        this.usuariosToolStripMenuItem.Visible = true;
                        this.altaUtoolStripMenuItem1.Visible = true;
                        this.bajaUtoolStripMenuItem2.Visible = true;
                        this.modifUtoolStripMenuItem3.Visible = true;
                        break;
                    case "Carga de credito":
                        this.operacionToolStripMenuItem.Visible = true;
                        this.cargarCréditoToolStripMenuItem.Visible = true;
                        break;
                    case "Clientes Premium":
                        this.controlToolStripMenuItem.Visible = true;
                        this.clientesPremiumToolStripMenuItem.Visible = true;
                        break;
                    case "Efectuar Compra":
                        this.operacionToolStripMenuItem.Visible = true;
                        this.efectuarCompraToolStripMenuItem.Visible = true;
                        break;
                    case "Inactividad de tarjetas":
                        this.controlToolStripMenuItem.Visible = true;
                        this.inactividadDeTarjetasToolStripMenuItem.Visible = true;
                        break;
                    case "Pago a empresas":
                        this.operacionToolStripMenuItem.Visible = true;
                        this.pagarAEmpresasToolStripMenuItem.Visible = true;
                        break;
                }
            }

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
           
        }

        /*private void altaBEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmBeneficiarios.AltaBeneficiario form = new AbmBeneficiarios.AltaBeneficiario();
            form.ShowDialog(this);
        }

        private void bajaBEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmBeneficiarios.BajaBeneficiario form = new AbmBeneficiarios.BajaBeneficiario();
            form.ShowDialog(this);
        }

        private void modifBEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmBeneficiarios.ModificacionBeneficiario form = new AbmBeneficiarios.ModificacionBeneficiario();
            form.ShowDialog(this);
        }

        private void altaCtoolStripMenuItem10_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmClientes.AltaClientes form = new AbmClientes.AltaClientes();
            form.ShowDialog(this);
        }

        private void bajaCtoolStripMenuItem11_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmClientes.BajaCliente form = new AbmClientes.BajaCliente();
            form.ShowDialog(this);
        }
        
        private void modifCtoolStripMenuItem12_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmClientes.ModificacionCliente form = new AbmClientes.ModificacionCliente();
            form.ShowDialog(this);
        }
        
        private void altaRtoolStripMenuItem7_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmRol.AltaRoles form = new AbmRol.AltaRoles();
            form.ShowDialog(this);
        }

        private void bajaRtoolStripMenuItem8_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmRol.BajaRoles form = new AbmRol.BajaRoles();
            form.ShowDialog(this);
        }

        private void modifRtoolStripMenuItem9_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmRol.ModificacionRoles form = new AbmRol.ModificacionRoles();
            form.ShowDialog(this);
        }*/
    }
}
