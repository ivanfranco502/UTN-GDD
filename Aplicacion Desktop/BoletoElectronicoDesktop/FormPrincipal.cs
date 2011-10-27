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
                        this.bajaOModifBEToolStripMenuItem.Visible = true;
                        break;
                    case "ABM de Cliente":
                        this.adminToolStripMenuItem.Visible = true;
                        this.clientesToolStripMenuItem.Visible = true;
                        this.altaCtoolStripMenuItem.Visible = true;
                        this.bajaOModifCtoolStripMenuItem.Visible = true;
                        break;
                    case "ABM de Rol":
                        this.adminToolStripMenuItem.Visible = true;
                        this.rolesToolStripMenuItem.Visible = true;
                        this.altaRtoolStripMenuItem.Visible = true;
                        this.bajaRtoolStripMenuItem.Visible = true;
                        this.modifRtoolStripMenuItem.Visible = true;
                        break;
                    case "ABM de Tarjetas":
                        this.adminToolStripMenuItem.Visible = true;
                        this.tarjetasToolStripMenuItem.Visible = true;
                        this.altaTtoolStripMenuItem.Visible = true;
                        this.bajaOModifTtoolStripMenuItem.Visible = true;
                        break;
                    case "ABM de Usuario":
                        this.adminToolStripMenuItem.Visible = true;
                        this.usuariosToolStripMenuItem.Visible = true;
                        this.altaUtoolStripMenuItem.Visible = true;
                        this.bajaOModifUtoolStripMenuItem.Visible = true;
                        break;
                    case "Carga de credito":
                        this.operacionToolStripMenuItem.Visible = true;
                        this.cargarCreditoToolStripMenuItem.Visible = true;
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

        private void altaBEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmBeneficiarios.AltaBeneficiario form = new AbmBeneficiarios.AltaBeneficiario();
            form.ShowDialog(this);
        }

        private void bajaOModifBEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmBeneficiarios.SeleccionarBeneficiario form = new AbmBeneficiarios.SeleccionarBeneficiario();
            form.ShowDialog(this);
        }

        private void altaCtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmClientes.AltaClientes form = new AbmClientes.AltaClientes();
            form.ShowDialog(this);
        }

        private void bajaOModifCtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmClientes.SeleccionCliente form = new AbmClientes.SeleccionCliente();
            form.ShowDialog(this);
        }
        
 
        private void altaRtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmRol.AltaRoles form = new AbmRol.AltaRoles();
            form.ShowDialog(this);
        }

        private void bajaRtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmRol.BajaRoles form = new AbmRol.BajaRoles();
            form.ShowDialog(this);
        }

        private void modifRtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmRol.ModificacionRoles form = new AbmRol.ModificacionRoles();
            form.ShowDialog(this);
        }
        
        private void altaTtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmTarjetas.AltaTarjetas form = new AbmTarjetas.AltaTarjetas();
            form.ShowDialog(this);
        }

        private void bajaOModifTtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmTarjetas.SeleccionClienteBM form = new AbmTarjetas.SeleccionClienteBM();
            form.ShowDialog(this);
        }
        private void altaUtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmUsuario.AltaUsuario form = new AbmUsuario.AltaUsuario();
            form.ShowDialog(this);
        }

        private void bajaOModifUtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.AbmUsuario.SeleccionUsuario form = new AbmUsuario.SeleccionUsuario();
            form.ShowDialog(this);
        }

        private void cargarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.CargaCredito.FormCargaCredito form = new BoletoElectronicoDesktop.CargaCredito.FormCargaCredito();
            form.ShowDialog(this);       
        }

        private void clientesPremiumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.ClientesPremium.ClientesPremium form = new BoletoElectronicoDesktop.ClientesPremium.ClientesPremium();
            form.ShowDialog(this);
        }
        
        private void efectuarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.Facturación.Facturacion form = new BoletoElectronicoDesktop.Facturación.Facturacion();
            form.ShowDialog(this);
        }
        
        private void inactividadDeTarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.InactividadTarjetas.InactividadTarjetas form = new BoletoElectronicoDesktop.InactividadTarjetas.InactividadTarjetas();
            form.ShowDialog(this);
        }
        
        private void pagarAEmpresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BoletoElectronicoDesktop.PagoEmpresas.FormPagoEmpresas form = new BoletoElectronicoDesktop.PagoEmpresas.FormPagoEmpresas();
            form.ShowDialog(this);
        }
        
    }
}
