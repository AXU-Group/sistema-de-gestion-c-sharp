using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Configuration;
using System.Collections.Specialized;
using System.Printing;
using FacturaControl;
using System.Data.SqlServerCe;
using manten;
using System.Management;


namespace SG
{
    public partial class Form_Opciones : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_Opciones m_FormDefInstance;
        public static Form_Opciones DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_Opciones();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public Form_Opciones()
        {
            InitializeComponent();
        }
        /*
        protected void treeView1_AfterSelect (object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            try
            {
                // Veo que item fue seleccionado
                if ((e.Node.Text) == "Modo")
                {
                    Ocultar_paneles(e, e);
                    this.panel_modo.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panel_modo.Show();
                    Form_Opciones_LoadConexion(e, e);
                }

                if ((e.Node.Text) == "Conexion")
                {
                    Ocultar_paneles(e, e);
                    this.panel_conexion.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panel_conexion.Show();
                    Form_Opciones_LoadConexion(e, e);
                }

                if ((e.Node.Text) == "Datos de Empresa")
                {
                    Ocultar_paneles(e, e);
                    this.panel_DatosEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panel_DatosEmpresa.Show();
                }
                if ((e.Node.Text) == "Impresoras")
                {
                    Ocultar_paneles(e, e);
                    this.panel_impresoras.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panel_impresoras.Show();
                }
                if ((e.Node.Text) == "Lector de Codigo de Barras")
                {
                    Ocultar_paneles(e, e);
                    this.panel_LCB.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panel_LCB.Show();
                }
                if ((e.Node.Text) == "Configuracion General")
                {
                    Ocultar_paneles(e, e);
                    this.panel_ConfGral.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panel_ConfGral.Show();
                }
                if ((e.Node.Text) == "Restablecer a la Configuracion Original")
                {
                    Ocultar_paneles(e, e);
                    this.panel_ConfDefault.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panel_ConfDefault.Show();
                }
                if ((e.Node.Text) == "Cotización de Moneda")
                {
                    Ocultar_paneles(e, e);
                    this.panel_Cotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.panel_Cotizaciones.Show();
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-OP1-001");
            }
       }
       */
        public void Form_Opciones_LoadConexion(object sender, EventArgs e)
       {
           try
           {
               this.label_infoconexion.Text = "";
               string myHost = Dns.GetHostName();
               this.label_infoconexion.Text += "Nombre del Equipo: " + myHost + "\n";
               //string myIP = Dns.GetHostEntry(myHost).AddressList[0].Address.ToString();
               string macAddresses = "";
               string myIP = "";
               foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
               {
                   if (nic.OperationalStatus == OperationalStatus.Up)
                   {
                       macAddresses += nic.GetPhysicalAddress().ToString();
                       //nic.Description devuelve => Bradcom (TM ) Ethernet Gigabit 
                       //nic.Id devuelve => {0808708484 El id de la placa de red activa}
                       //nic.Name devuelve => Conexion de Area Local
                       //nic.NetworkInterfaceType devuelve => Ethernet
                       
                       break;
                   }
               }
               //this.label_infoconexion.Text += ("MAC Address: " + macAddresses + "\n");
               this.label_infoconexion.Text += ("IP Local: " + myIP + "\n");
               this.label_infoconexion.Text += "\n";
               this.label_infoconexion.Text += "Si este terminal va a ser configurada como servidor:\n";
               this.label_infoconexion.Text += "Ingresar en cada una de las terminales que quieran que formen parte del grupo de trabajo e ir a:\n";
               this.label_infoconexion.Text += "Tools -> Options -> Conexion -> Servidor o Host:\n";
               this.label_infoconexion.Text += @"Ahi ingresar la siguiente cade de texto que es el nombre de este equipo o HOST:  \\" + myHost + @"\Vizsla POS";
               this.label_infoconexion.Text += "\n\nATENCION: Para que sus clientes o puestos de trabajo puedan acceder localmente mediante esta configuracion se debe poner a compartir la carpeta:\n C:\\Vizsla POS \n\n";
               this.label_infoconexion.Text += "Si este terminal va a ser configurada como Cliente:\n";
               this.label_infoconexion.Text += "Ingresar en:\n";
               this.label_infoconexion.Text += "Tools -> Options -> Conexion -> Servidor o Host\n";
               this.label_infoconexion.Text += "Ahi ingresar el nombre del equipo Server";
               //para el campo de HOST
               this.textBox_HOST.Text = ConfigurationManager.AppSettings["textBox_HOST"];

           }
           catch (Exception ex)
           {
               em.sendmail(ex, "Error: F-OP1-002");
           }
       }
        /*
        private void Ocultar_paneles(object sender, EventArgs e)
        {
            try
            {
                // Oculto todos los paneles existentes
                this.panel_modo.Hide();
                this.panel_conexion.Hide();
                this.panel_DatosEmpresa.Hide();
                this.panel_impresoras.Hide();
                this.panel_LCB.Hide();
                this.panel_ConfGral.Hide();
                this.panel_ConfDefault.Hide();
                this.panel_Cotizaciones.Hide();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-OP1-003");
            }
        }
        */
        private void button_Guardar_Click(object sender, EventArgs e)
       {
           try
           {
               if (checkConection())
               {
                   if (SG.MDIParentPadre.backupdata("config"))
                   {
                       //Al presionar el boton Guardar guardo toda la configuracion en el XML
                       Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                       //Borro toda la configuracion vieja y guardo la nueva
                       config.AppSettings.Settings.Clear();
                       //Panel Modo
                       config.AppSettings.Settings.Add("rButton_ModoCliente", this.rButton_ModoCliente.Checked.ToString());
                       config.AppSettings.Settings.Add("rButton_ModoServidor", this.rButton_ModoServidor.Checked.ToString());
                       config.AppSettings.Settings.Add("rButton_TipoLocal", this.rButton_TipoLocal.Checked.ToString());
                       config.AppSettings.Settings.Add("rButton_TipoRemoto", this.rButton_TipoRemoto.Checked.ToString());
                       //Panel Conexion
                       config.AppSettings.Settings.Add("textBox_HOST", this.textBox_HOST.Text);
                       //Panel Datos Empresa
                       config.AppSettings.Settings.Add("textBox_DE_Nombre", this.textBox_DE_Nombre.Text);
                       config.AppSettings.Settings.Add("textBox_DE_Actividad", this.textBox_DE_Actividad.Text);
                       config.AppSettings.Settings.Add("textBox_DE_Domicilio", this.textBox_DE_Domicilio.Text);
                       config.AppSettings.Settings.Add("textBox_DE_Localidad", this.textBox_DE_Localidad.Text);
                       config.AppSettings.Settings.Add("textBox_DE_CodPost", this.textBox_DE_CodPost.Text);
                       config.AppSettings.Settings.Add("textBox_DE_Tel", this.textBox_DE_Tel.Text);
                       config.AppSettings.Settings.Add("textBox_DE_Fax", this.textBox_DE_Fax.Text);
                       config.AppSettings.Settings.Add("textBox_DE_Cuit", this.textBox_DE_Cuit.Text);
                       config.AppSettings.Settings.Add("radioButton_DE_RI", this.radioButton_DE_RI.Checked.ToString());
                       config.AppSettings.Settings.Add("radioButton_DE_RNI", this.radioButton_DE_RNI.Checked.ToString());
                       config.AppSettings.Settings.Add("radioButton_DE_Mono", this.radioButton_DE_Mono.Checked.ToString());
                       config.AppSettings.Settings.Add("textBox_DE_PuestosVenta", this.textBox_DE_PuestosVenta.Text);
                       config.AppSettings.Settings.Add("maskedTextBox_DE_puestoNumero", this.maskedTextBox_DE_puestoNumero.Text);
                       config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialA", this.maskedTextBox_DE_facturaInicalA.Text);
                       config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialB", this.maskedTextBox_DE_facturaInicalB.Text);
                       config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialC", this.maskedTextBox_DE_facturaInicalC.Text);
                       config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialT", this.maskedTextBox_DE_facturaInicalT.Text);
                       config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialR", this.maskedTextBox_DE_facturaInicalR.Text);
                       config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialNC", this.maskedTextBox_DE_facturaInicalNC.Text);
                       config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialNP", this.maskedTextBox_DE_facturaInicalNP.Text);
                       config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialP", this.maskedTextBox_DE_facturaInicalP.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaCopiasA", this.textBox_DE_facturaCopiasA.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaCopiasB", this.textBox_DE_facturaCopiasB.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaCopiasC", this.textBox_DE_facturaCopiasC.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaCopiasT", this.textBox_DE_facturaCopiasT.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaCopiasR", this.textBox_DE_facturaCopiasR.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaCopiasNC", this.textBox_DE_facturaCopiasNC.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaCopiasNP", this.textBox_DE_facturaCopiasNP.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaCopiasP", this.textBox_DE_facturaCopiasP.Text);
                       config.AppSettings.Settings.Add("radioButton_DE_factA", this.radioButton_DE_factA.Checked.ToString());
                       config.AppSettings.Settings.Add("radioButton_DE_factB", this.radioButton_DE_factB.Checked.ToString());
                       config.AppSettings.Settings.Add("radioButton_DE_factC", this.radioButton_DE_factC.Checked.ToString());
                       config.AppSettings.Settings.Add("radioButton_DE_factT", this.radioButton_DE_factT.Checked.ToString());
                       config.AppSettings.Settings.Add("radioButton_DE_factR", this.radioButton_DE_factR.Checked.ToString());
                       config.AppSettings.Settings.Add("radioButton_DE_factNC", this.radioButton_DE_factNC.Checked.ToString());
                       config.AppSettings.Settings.Add("radioButton_DE_factNP", this.radioButton_DE_factNP.Checked.ToString());
                       config.AppSettings.Settings.Add("radioButton_DE_factP", this.radioButton_DE_factP.Checked.ToString());
                       config.AppSettings.Settings.Add("textBox_DE_facturaImagenA", this.textBox_DE_facturaImagenA.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaImagenB", this.textBox_DE_facturaImagenB.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaImagenC", this.textBox_DE_facturaImagenC.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaImagenT", this.textBox_DE_facturaImagenT.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaImagenR", this.textBox_DE_facturaImagenR.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaImagenNC", this.textBox_DE_facturaImagenNC.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaImagenNP", this.textBox_DE_facturaImagenNP.Text);
                       config.AppSettings.Settings.Add("textBox_DE_facturaImagenP", this.textBox_DE_facturaImagenP.Text);
                       //Panel Impresoras
                       config.AppSettings.Settings.Add("textBox_ImpNOMBRE", this.textBox_ImpNOMBRE.Text);
                       //Solapa factura
                       config.AppSettings.Settings.Add("textBox_ImpDiaX", this.textBox_ImpDiaX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpDiaY", this.textBox_ImpDiaY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpMesX", this.textBox_ImpMesX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpMesY", this.textBox_ImpMesY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpAnoX", this.textBox_ImpAnoX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpAnoY", this.textBox_ImpAnoY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpHorX", this.textBox_ImpHorX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpHorY", this.textBox_ImpHorY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpSenX", this.textBox_ImpSenX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpSenY", this.textBox_ImpSenY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpDomX", this.textBox_ImpDomX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpDomY", this.textBox_ImpDomY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpLocX", this.textBox_ImpLocX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpLocY", this.textBox_ImpLocY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRiX", this.textBox_ImpRiX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRiY", this.textBox_ImpRiY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpCfX", this.textBox_ImpCfX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpCfY", this.textBox_ImpCfY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNorX", this.textBox_ImpNorX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNorY", this.textBox_ImpNorY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpExeX", this.textBox_ImpExeX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpExeY", this.textBox_ImpExeY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpCuiX", this.textBox_ImpCuiX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpCuiY", this.textBox_ImpCuiY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRemX", this.textBox_ImpRemX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRemY", this.textBox_ImpRemY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpConX", this.textBox_ImpConX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpConY", this.textBox_ImpConY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpCcoX", this.textBox_ImpCcoX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpCcoY", this.textBox_ImpCcoY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpCanX", this.textBox_ImpCanX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpCanY", this.textBox_ImpCanY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpCanMC", this.textBox_ImpCanMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpDetX", this.textBox_ImpDetX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpDetY", this.textBox_ImpDetY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpDetMC", this.textBox_ImpDetMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPreX", this.textBox_ImpPreX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPreY", this.textBox_ImpPreY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPreMC", this.textBox_ImpPreMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpAliX", this.textBox_ImpAliX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpAliY", this.textBox_ImpAliY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpAliMC", this.textBox_ImpAliMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpBivX", this.textBox_ImpBivX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpBivY", this.textBox_ImpBivY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpBivMC", this.textBox_ImpBivMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpImpX", this.textBox_ImpImpX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpImpY", this.textBox_ImpImpY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpImpMC", this.textBox_ImpImpMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpSu1X", this.textBox_ImpSu1X.Text);
                       config.AppSettings.Settings.Add("textBox_ImpSu1Y", this.textBox_ImpSu1Y.Text);
                       config.AppSettings.Settings.Add("textBox_ImpDesX", this.textBox_ImpDesX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpDesY", this.textBox_ImpDesY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpIpsX", this.textBox_ImpIpsX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpIpsY", this.textBox_ImpIpsY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpSu2X", this.textBox_ImpSu2X.Text);
                       config.AppSettings.Settings.Add("textBox_ImpSu2Y", this.textBox_ImpSu2Y.Text);
                       config.AppSettings.Settings.Add("textBox_ImpIvaX", this.textBox_ImpIvaX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpIvaY", this.textBox_ImpIvaY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpTotX", this.textBox_ImpTotX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpTotY", this.textBox_ImpTotY.Text);
                       //Solapa remito
                       config.AppSettings.Settings.Add("textBox_ImpRDiaX", this.textBox_ImpRDiaX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRDiaY", this.textBox_ImpRDiaY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRMesX", this.textBox_ImpRMesX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRMesY", this.textBox_ImpRMesY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRAnoX", this.textBox_ImpRAnoX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRAnoY", this.textBox_ImpRAnoY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRHorX", this.textBox_ImpRHorX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRHorY", this.textBox_ImpRHorY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRSenX", this.textBox_ImpRSenX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRSenY", this.textBox_ImpRSenY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRDomX", this.textBox_ImpRDomX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRDomY", this.textBox_ImpRDomY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRLocX", this.textBox_ImpRLocX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRLocY", this.textBox_ImpRLocY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRRiX", this.textBox_ImpRRiX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRRiY", this.textBox_ImpRRiY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRCfX", this.textBox_ImpRCfX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRCfY", this.textBox_ImpRCfY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRNorX", this.textBox_ImpRNorX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRNorY", this.textBox_ImpRNorY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRExeX", this.textBox_ImpRExeX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRExeY", this.textBox_ImpRExeY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRMtX", this.textBox_ImpRMtX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRMtY", this.textBox_ImpRMtY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRCuiX", this.textBox_ImpRCuiX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRCuiY", this.textBox_ImpRCuiY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRNumX", this.textBox_ImpRNumX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRNumY", this.textBox_ImpRNumY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRConX", this.textBox_ImpRConX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRConY", this.textBox_ImpRConY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRCcoX", this.textBox_ImpRCcoX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRCcoY", this.textBox_ImpRCcoY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRCanX", this.textBox_ImpRCanX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRCanY", this.textBox_ImpRCanY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRCanMC", this.textBox_ImpRCanMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRDetX", this.textBox_ImpRDetX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRDetY", this.textBox_ImpRDetY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpRDetMC", this.textBox_ImpRDetMC.Text);
                       // Solapa Nota de pedido
                       config.AppSettings.Settings.Add("textBox_ImpNPDiaX", this.textBox_ImpNPDiaX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPDiaY", this.textBox_ImpNPDiaY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPMesX", this.textBox_ImpNPMesX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPMesY", this.textBox_ImpNPMesY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPAnoX", this.textBox_ImpNPAnoX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPAnoY", this.textBox_ImpNPAnoY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPHorX", this.textBox_ImpNPHorX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPHorY", this.textBox_ImpNPHorY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPNumX", this.textBox_ImpNPNumX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPNumY", this.textBox_ImpNPNumY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPSenX", this.textBox_ImpNPSenX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPSenY", this.textBox_ImpNPSenY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPDomX", this.textBox_ImpNPDomX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPDomY", this.textBox_ImpNPDomY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPLocX", this.textBox_ImpNPLocX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPLocY", this.textBox_ImpNPLocY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPCanX", this.textBox_ImpNPCanX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPCanY", this.textBox_ImpNPCanY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPCanMC", this.textBox_ImpNPCanMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPDetX", this.textBox_ImpNPDetX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPDetY", this.textBox_ImpNPDetY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPDetMC", this.textBox_ImpNPDetMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPPreX", this.textBox_ImpNPPreX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPPreY", this.textBox_ImpNPPreY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPPreMC", this.textBox_ImpNPPreMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPImpX", this.textBox_ImpNPImpX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPImpY", this.textBox_ImpNPImpY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPImpMC", this.textBox_ImpNPImpMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPTotX", this.textBox_ImpNPTotX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpNPTotY", this.textBox_ImpNPTotY.Text);
                       // Solapa Presupuesto
                       config.AppSettings.Settings.Add("textBox_ImpPDiaX", this.textBox_ImpPDiaX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPDiaY", this.textBox_ImpPDiaY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPMesX", this.textBox_ImpPMesX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPMesY", this.textBox_ImpPMesY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPAnoX", this.textBox_ImpPAnoX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPAnoY", this.textBox_ImpPAnoY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPHorX", this.textBox_ImpPHorX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPHorY", this.textBox_ImpPHorY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPNumX", this.textBox_ImpPNumX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPNumY", this.textBox_ImpPNumY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPSenX", this.textBox_ImpPSenX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPSenY", this.textBox_ImpPSenY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPDomX", this.textBox_ImpPDomX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPDomY", this.textBox_ImpPDomY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPLocX", this.textBox_ImpPLocX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPLocY", this.textBox_ImpPLocY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPCanX", this.textBox_ImpPCanX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPCanY", this.textBox_ImpPCanY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPCanMC", this.textBox_ImpPCanMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPDetX", this.textBox_ImpPDetX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPDetY", this.textBox_ImpPDetY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPDetMC", this.textBox_ImpPDetMC.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPPreX", this.textBox_ImpPPreX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPPreY", this.textBox_ImpPPreY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPPreMC", this.textBox_ImpPPreMC.Text);                       
                       config.AppSettings.Settings.Add("textBox_ImpPImpX", this.textBox_ImpPImpX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPImpY", this.textBox_ImpPImpY.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPImpMC", this.textBox_ImpPImpMC.Text);                      
                       config.AppSettings.Settings.Add("textBox_ImpPTotX", this.textBox_ImpPTotX.Text);
                       config.AppSettings.Settings.Add("textBox_ImpPTotY", this.textBox_ImpPTotY.Text);
                       
                       // Panel configuracion general
                       config.AppSettings.Settings.Add("textBox_Cot_Dolar", this.textBox_Cot_Dolar.Text);
                       config.AppSettings.Settings.Add("textBox_Cot_Euro", this.textBox_Cot_Euro.Text);
                       config.AppSettings.Settings.Add("textBox_CG_Backup", this.textBox_CG_Backup.Text);

                       // Guardo la Configuarcion en el Archivo
                       config.Save(ConfigurationSaveMode.Modified);
                       // Fuerzo a releer los cambios
                       ConfigurationManager.RefreshSection("appSettings");

                       MessageBox.Show("Se guardo la información correctamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                   else MessageBox.Show("Ha ocurrido un error al tratar de guardar la información", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else MessageBox.Show("Ha ocurrido un error al tratar de conectarse a la base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           catch (Exception ex)
           {
               em.sendmail(ex, "Error: F-OP1-004");
           }
       }

       private void Form_Opciones_Load(object sender, EventArgs e)
       {
           try
           {
               //Ni bien leo el formulario cargo la configuarcion
               //Panel Modo
               this.rButton_ModoCliente.Checked = bool.Parse(ConfigurationManager.AppSettings["rButton_ModoCliente"]);
               this.rButton_ModoServidor.Checked = bool.Parse(ConfigurationManager.AppSettings["rButton_ModoServidor"]);
               this.rButton_TipoLocal.Checked = bool.Parse(ConfigurationManager.AppSettings["rButton_TipoLocal"]);
               this.rButton_TipoRemoto.Checked = bool.Parse(ConfigurationManager.AppSettings["rButton_TipoRemoto"]);
               //Panel Conexion
               this.textBox_HOST.Text = ConfigurationManager.AppSettings["textBox_HOST"];
               //Panel Datos Empresa
               this.textBox_DE_Nombre.Text = ConfigurationManager.AppSettings["textBox_DE_Nombre"];
               this.textBox_DE_Actividad.Text = ConfigurationManager.AppSettings["textBox_DE_Actividad"];
               this.textBox_DE_Domicilio.Text = ConfigurationManager.AppSettings["textBox_DE_Domicilio"];
               this.textBox_DE_Localidad.Text = ConfigurationManager.AppSettings["textBox_DE_Localidad"];
               this.textBox_DE_CodPost.Text = ConfigurationManager.AppSettings["textBox_DE_CodPost"];
               this.textBox_DE_Tel.Text = ConfigurationManager.AppSettings["textBox_DE_Tel"];
               this.textBox_DE_Fax.Text = ConfigurationManager.AppSettings["textBox_DE_Fax"];
               this.textBox_DE_Cuit.Text = ConfigurationManager.AppSettings["textBox_DE_Cuit"];
               this.radioButton_DE_RI.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_RI"]);
               this.radioButton_DE_RNI.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_RNI"]);
               this.radioButton_DE_Mono.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_Mono"]);
               this.textBox_DE_PuestosVenta.Text = ConfigurationManager.AppSettings["textBox_DE_PuestosVenta"];
               this.maskedTextBox_DE_puestoNumero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_puestoNumero"];
               this.maskedTextBox_DE_facturaInicalA.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialA"];
               this.maskedTextBox_DE_facturaInicalB.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialB"];
               this.maskedTextBox_DE_facturaInicalC.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialC"];
               this.maskedTextBox_DE_facturaInicalT.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialT"];
               this.maskedTextBox_DE_facturaInicalR.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialR"];
               this.maskedTextBox_DE_facturaInicalNC.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialNC"];
               this.maskedTextBox_DE_facturaInicalNP.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialNP"];
               this.maskedTextBox_DE_facturaInicalP.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialP"];
               this.textBox_DE_facturaCopiasA.Text = ConfigurationManager.AppSettings["textBox_DE_facturaCopiasA"];
               this.textBox_DE_facturaCopiasB.Text = ConfigurationManager.AppSettings["textBox_DE_facturaCopiasB"];
               this.textBox_DE_facturaCopiasC.Text = ConfigurationManager.AppSettings["textBox_DE_facturaCopiasC"];
               this.textBox_DE_facturaCopiasT.Text = ConfigurationManager.AppSettings["textBox_DE_facturaCopiasT"];
               this.textBox_DE_facturaCopiasR.Text = ConfigurationManager.AppSettings["textBox_DE_facturaCopiasR"];
               this.textBox_DE_facturaCopiasNC.Text = ConfigurationManager.AppSettings["textBox_DE_facturaCopiasNC"];
               this.textBox_DE_facturaCopiasNP.Text = ConfigurationManager.AppSettings["textBox_DE_facturaCopiasNP"];
               this.textBox_DE_facturaCopiasP.Text = ConfigurationManager.AppSettings["textBox_DE_facturaCopiasP"];
               this.radioButton_DE_factA.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factA"]);
               this.radioButton_DE_factB.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factB"]);
               this.radioButton_DE_factC.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factC"]);
               this.radioButton_DE_factT.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factT"]);
               this.radioButton_DE_factR.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factR"]);
               this.radioButton_DE_factNC.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factNC"]);
               this.radioButton_DE_factNP.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factNP"]);
               this.radioButton_DE_factP.Checked = bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factP"]);
               this.textBox_DE_facturaImagenA.Text = ConfigurationManager.AppSettings["textBox_DE_facturaImagenA"];
               this.textBox_DE_facturaImagenB.Text = ConfigurationManager.AppSettings["textBox_DE_facturaImagenB"];
               this.textBox_DE_facturaImagenC.Text = ConfigurationManager.AppSettings["textBox_DE_facturaImagenC"];
               this.textBox_DE_facturaImagenT.Text = ConfigurationManager.AppSettings["textBox_DE_facturaImagenT"];
               this.textBox_DE_facturaImagenR.Text = ConfigurationManager.AppSettings["textBox_DE_facturaImagenR"];
               this.textBox_DE_facturaImagenNC.Text = ConfigurationManager.AppSettings["textBox_DE_facturaImagenNC"];
               this.textBox_DE_facturaImagenNP.Text = ConfigurationManager.AppSettings["textBox_DE_facturaImagenNP"];
               this.textBox_DE_facturaImagenP.Text = ConfigurationManager.AppSettings["textBox_DE_facturaImagenP"];
               //Panel Impresoras
               this.textBox_ImpNOMBRE.Text = ConfigurationManager.AppSettings["textBox_ImpNOMBRE"];
               //Solapa factura
               this.textBox_ImpDiaX.Text = ConfigurationManager.AppSettings["textBox_ImpDiaX"];
               this.textBox_ImpDiaY.Text = ConfigurationManager.AppSettings["textBox_ImpDiaY"];
               this.textBox_ImpMesX.Text = ConfigurationManager.AppSettings["textBox_ImpMesX"];
               this.textBox_ImpMesY.Text = ConfigurationManager.AppSettings["textBox_ImpMesY"];
               this.textBox_ImpAnoX.Text = ConfigurationManager.AppSettings["textBox_ImpAnoX"];
               this.textBox_ImpAnoY.Text = ConfigurationManager.AppSettings["textBox_ImpAnoY"];
               this.textBox_ImpHorX.Text = ConfigurationManager.AppSettings["textBox_ImpHorX"];
               this.textBox_ImpHorY.Text = ConfigurationManager.AppSettings["textBox_ImpHorY"];
               this.textBox_ImpSenX.Text = ConfigurationManager.AppSettings["textBox_ImpSenX"];
               this.textBox_ImpSenY.Text = ConfigurationManager.AppSettings["textBox_ImpSenY"];
               this.textBox_ImpDomX.Text = ConfigurationManager.AppSettings["textBox_ImpDomX"];
               this.textBox_ImpDomY.Text = ConfigurationManager.AppSettings["textBox_ImpDomY"];
               this.textBox_ImpLocX.Text = ConfigurationManager.AppSettings["textBox_ImpLocX"];
               this.textBox_ImpLocY.Text = ConfigurationManager.AppSettings["textBox_ImpLocY"];
               this.textBox_ImpRiX.Text = ConfigurationManager.AppSettings["textBox_ImpRiX"];
               this.textBox_ImpRiY.Text = ConfigurationManager.AppSettings["textBox_ImpRiY"];
               this.textBox_ImpCfX.Text = ConfigurationManager.AppSettings["textBox_ImpCfX"];
               this.textBox_ImpCfY.Text = ConfigurationManager.AppSettings["textBox_ImpCfY"];
               this.textBox_ImpNorX.Text = ConfigurationManager.AppSettings["textBox_ImpNorX"];
               this.textBox_ImpNorY.Text = ConfigurationManager.AppSettings["textBox_ImpNorY"];
               this.textBox_ImpExeX.Text = ConfigurationManager.AppSettings["textBox_ImpExeX"];
               this.textBox_ImpExeY.Text = ConfigurationManager.AppSettings["textBox_ImpExeY"];
               this.textBox_ImpCuiX.Text = ConfigurationManager.AppSettings["textBox_ImpCuiX"];
               this.textBox_ImpCuiY.Text = ConfigurationManager.AppSettings["textBox_ImpCuiY"];
               this.textBox_ImpRemX.Text = ConfigurationManager.AppSettings["textBox_ImpRemX"];
               this.textBox_ImpRemY.Text = ConfigurationManager.AppSettings["textBox_ImpRemY"];
               this.textBox_ImpConX.Text = ConfigurationManager.AppSettings["textBox_ImpConX"];
               this.textBox_ImpConY.Text = ConfigurationManager.AppSettings["textBox_ImpConY"];
               this.textBox_ImpCcoX.Text = ConfigurationManager.AppSettings["textBox_ImpCcoX"];
               this.textBox_ImpCcoY.Text = ConfigurationManager.AppSettings["textBox_ImpCcoY"];
               this.textBox_ImpCanX.Text = ConfigurationManager.AppSettings["textBox_ImpCanX"];
               this.textBox_ImpCanY.Text = ConfigurationManager.AppSettings["textBox_ImpCanY"];
               this.textBox_ImpCanMC.Text = ConfigurationManager.AppSettings["textBox_ImpCanMC"];
               this.textBox_ImpDetX.Text = ConfigurationManager.AppSettings["textBox_ImpDetX"];
               this.textBox_ImpDetY.Text = ConfigurationManager.AppSettings["textBox_ImpDetY"];
               this.textBox_ImpDetMC.Text = ConfigurationManager.AppSettings["textBox_ImpDetMC"];
               this.textBox_ImpPreX.Text = ConfigurationManager.AppSettings["textBox_ImpPreX"];
               this.textBox_ImpPreY.Text = ConfigurationManager.AppSettings["textBox_ImpPreY"];
               this.textBox_ImpPreMC.Text = ConfigurationManager.AppSettings["textBox_ImpPreMC"];
               this.textBox_ImpAliX.Text = ConfigurationManager.AppSettings["textBox_ImpAliX"];
               this.textBox_ImpAliY.Text = ConfigurationManager.AppSettings["textBox_ImpAliY"];
               this.textBox_ImpAliMC.Text = ConfigurationManager.AppSettings["textBox_ImpAliMC"];
               this.textBox_ImpBivX.Text = ConfigurationManager.AppSettings["textBox_ImpBivX"];
               this.textBox_ImpBivY.Text = ConfigurationManager.AppSettings["textBox_ImpBivY"];
               this.textBox_ImpBivMC.Text = ConfigurationManager.AppSettings["textBox_ImpBivMC"];
               this.textBox_ImpImpX.Text = ConfigurationManager.AppSettings["textBox_ImpImpX"];
               this.textBox_ImpImpY.Text = ConfigurationManager.AppSettings["textBox_ImpImpY"];
               this.textBox_ImpImpMC.Text = ConfigurationManager.AppSettings["textBox_ImpImpMC"];
               this.textBox_ImpSu1X.Text = ConfigurationManager.AppSettings["textBox_ImpSu1X"];
               this.textBox_ImpSu1Y.Text = ConfigurationManager.AppSettings["textBox_ImpSu1Y"];
               this.textBox_ImpDesX.Text = ConfigurationManager.AppSettings["textBox_ImpDesX"];
               this.textBox_ImpDesY.Text = ConfigurationManager.AppSettings["textBox_ImpDesY"];
               this.textBox_ImpIpsX.Text = ConfigurationManager.AppSettings["textBox_ImpIpsX"];
               this.textBox_ImpIpsY.Text = ConfigurationManager.AppSettings["textBox_ImpIpsY"];
               this.textBox_ImpSu2X.Text = ConfigurationManager.AppSettings["textBox_ImpSu2X"];
               this.textBox_ImpSu2Y.Text = ConfigurationManager.AppSettings["textBox_ImpSu2Y"];
               this.textBox_ImpIvaX.Text = ConfigurationManager.AppSettings["textBox_ImpIvaX"];
               this.textBox_ImpIvaY.Text = ConfigurationManager.AppSettings["textBox_ImpIvaY"];
               this.textBox_ImpTotX.Text = ConfigurationManager.AppSettings["textBox_ImpTotX"];
               this.textBox_ImpTotY.Text = ConfigurationManager.AppSettings["textBox_ImpTotY"];
               //Solapa Remito
               this.textBox_ImpRDiaX.Text = ConfigurationManager.AppSettings["textBox_ImpRDiaX"];
               this.textBox_ImpRDiaY.Text = ConfigurationManager.AppSettings["textBox_ImpRDiaY"];
               this.textBox_ImpRMesX.Text = ConfigurationManager.AppSettings["textBox_ImpRMesX"];
               this.textBox_ImpRMesY.Text = ConfigurationManager.AppSettings["textBox_ImpRMesY"];
               this.textBox_ImpRAnoX.Text = ConfigurationManager.AppSettings["textBox_ImpRAnoX"];
               this.textBox_ImpRAnoY.Text = ConfigurationManager.AppSettings["textBox_ImpRAnoY"];
               this.textBox_ImpRHorX.Text = ConfigurationManager.AppSettings["textBox_ImpRHorX"];
               this.textBox_ImpRHorY.Text = ConfigurationManager.AppSettings["textBox_ImpRHorY"];
               this.textBox_ImpRSenX.Text = ConfigurationManager.AppSettings["textBox_ImpRSenX"];
               this.textBox_ImpRSenY.Text = ConfigurationManager.AppSettings["textBox_ImpRSenY"];
               this.textBox_ImpRDomX.Text = ConfigurationManager.AppSettings["textBox_ImpRDomX"];
               this.textBox_ImpRDomY.Text = ConfigurationManager.AppSettings["textBox_ImpRDomY"];
               this.textBox_ImpRLocX.Text = ConfigurationManager.AppSettings["textBox_ImpRLocX"];
               this.textBox_ImpRLocY.Text = ConfigurationManager.AppSettings["textBox_ImpRLocY"];
               this.textBox_ImpRRiX.Text = ConfigurationManager.AppSettings["textBox_ImpRRiX"];
               this.textBox_ImpRRiY.Text = ConfigurationManager.AppSettings["textBox_ImpRRiY"];
               this.textBox_ImpRCfX.Text = ConfigurationManager.AppSettings["textBox_ImpRCfX"];
               this.textBox_ImpRCfY.Text = ConfigurationManager.AppSettings["textBox_ImpRCfY"];
               this.textBox_ImpRNorX.Text = ConfigurationManager.AppSettings["textBox_ImpRNorX"];
               this.textBox_ImpRNorY.Text = ConfigurationManager.AppSettings["textBox_ImpRNorY"];
               this.textBox_ImpRExeX.Text = ConfigurationManager.AppSettings["textBox_ImpRExeX"];
               this.textBox_ImpRExeY.Text = ConfigurationManager.AppSettings["textBox_ImpRExeY"];
               this.textBox_ImpRMtX.Text = ConfigurationManager.AppSettings["textBox_ImpRMtX"];
               this.textBox_ImpRMtY.Text = ConfigurationManager.AppSettings["textBox_ImpRMtY"];
               this.textBox_ImpRCuiX.Text = ConfigurationManager.AppSettings["textBox_ImpRCuiX"];
               this.textBox_ImpRCuiY.Text = ConfigurationManager.AppSettings["textBox_ImpRCuiY"];
               this.textBox_ImpRNumX.Text = ConfigurationManager.AppSettings["textBox_ImpRNumX"];
               this.textBox_ImpRNumY.Text = ConfigurationManager.AppSettings["textBox_ImpRNumY"];
               this.textBox_ImpRConX.Text = ConfigurationManager.AppSettings["textBox_ImpRConX"];
               this.textBox_ImpRConY.Text = ConfigurationManager.AppSettings["textBox_ImpRConY"];
               this.textBox_ImpRCcoX.Text = ConfigurationManager.AppSettings["textBox_ImpRCcoX"];
               this.textBox_ImpRCcoY.Text = ConfigurationManager.AppSettings["textBox_ImpRCcoY"];
               this.textBox_ImpRCanX.Text = ConfigurationManager.AppSettings["textBox_ImpRCanX"];
               this.textBox_ImpRCanY.Text = ConfigurationManager.AppSettings["textBox_ImpRCanY"];
               this.textBox_ImpRCanMC.Text = ConfigurationManager.AppSettings["textBox_ImpRCanMC"];
               this.textBox_ImpRDetX.Text = ConfigurationManager.AppSettings["textBox_ImpRDetX"];
               this.textBox_ImpRDetY.Text = ConfigurationManager.AppSettings["textBox_ImpRDetY"];
               this.textBox_ImpRDetMC.Text = ConfigurationManager.AppSettings["textBox_ImpRDetMC"];
               //Solapa Nota de pedido
               this.textBox_ImpNPDiaX.Text = ConfigurationManager.AppSettings["textBox_ImpNPDiaX"];
               this.textBox_ImpNPDiaY.Text = ConfigurationManager.AppSettings["textBox_ImpNPDiaY"];
               this.textBox_ImpNPMesX.Text = ConfigurationManager.AppSettings["textBox_ImpNPMesX"];
               this.textBox_ImpNPMesY.Text = ConfigurationManager.AppSettings["textBox_ImpNPMesY"];
               this.textBox_ImpNPAnoX.Text = ConfigurationManager.AppSettings["textBox_ImpNPAnoX"];
               this.textBox_ImpNPAnoY.Text = ConfigurationManager.AppSettings["textBox_ImpNPAnoY"];
               this.textBox_ImpNPHorX.Text = ConfigurationManager.AppSettings["textBox_ImpNPHorX"];
               this.textBox_ImpNPHorY.Text = ConfigurationManager.AppSettings["textBox_ImpNPHorY"];
               this.textBox_ImpNPNumX.Text = ConfigurationManager.AppSettings["textBox_ImpNPNumX"];
               this.textBox_ImpNPNumY.Text = ConfigurationManager.AppSettings["textBox_ImpNPNumY"];
               this.textBox_ImpNPSenX.Text = ConfigurationManager.AppSettings["textBox_ImpNPSenX"];
               this.textBox_ImpNPSenY.Text = ConfigurationManager.AppSettings["textBox_ImpNPSenY"];
               this.textBox_ImpNPDomX.Text = ConfigurationManager.AppSettings["textBox_ImpNPDomX"];
               this.textBox_ImpNPDomY.Text = ConfigurationManager.AppSettings["textBox_ImpNPDomY"];
               this.textBox_ImpNPLocX.Text = ConfigurationManager.AppSettings["textBox_ImpNPLocX"];
               this.textBox_ImpNPLocY.Text = ConfigurationManager.AppSettings["textBox_ImpNPLocY"];
               this.textBox_ImpNPCanX.Text = ConfigurationManager.AppSettings["textBox_ImpNPCanX"];
               this.textBox_ImpNPCanY.Text = ConfigurationManager.AppSettings["textBox_ImpNPCanY"];
               this.textBox_ImpNPCanMC.Text = ConfigurationManager.AppSettings["textBox_ImpNPCanMC"];
               this.textBox_ImpNPDetX.Text = ConfigurationManager.AppSettings["textBox_ImpNPDetX"];
               this.textBox_ImpNPDetY.Text = ConfigurationManager.AppSettings["textBox_ImpNPDetY"];
               this.textBox_ImpNPDetMC.Text = ConfigurationManager.AppSettings["textBox_ImpNPDetMC"];
               this.textBox_ImpNPPreX.Text = ConfigurationManager.AppSettings["textBox_ImpNPPreX"];
               this.textBox_ImpNPPreY.Text = ConfigurationManager.AppSettings["textBox_ImpNPPreY"];
               this.textBox_ImpNPPreMC.Text = ConfigurationManager.AppSettings["textBox_ImpNPPreMC"];
               this.textBox_ImpNPImpX.Text = ConfigurationManager.AppSettings["textBox_ImpNPImpX"];
               this.textBox_ImpNPImpY.Text = ConfigurationManager.AppSettings["textBox_ImpNPImpY"];
               this.textBox_ImpNPImpMC.Text = ConfigurationManager.AppSettings["textBox_ImpNPImpMC"];
               this.textBox_ImpNPTotX.Text = ConfigurationManager.AppSettings["textBox_ImpNPTotX"];
               this.textBox_ImpNPTotY.Text = ConfigurationManager.AppSettings["textBox_ImpNPTotY"];
               //Solapa Presupuesto
               this.textBox_ImpPDiaX.Text = ConfigurationManager.AppSettings["textBox_ImpPDiaX"];
               this.textBox_ImpPDiaY.Text = ConfigurationManager.AppSettings["textBox_ImpPDiaY"];
               this.textBox_ImpPMesX.Text = ConfigurationManager.AppSettings["textBox_ImpPMesX"];
               this.textBox_ImpPMesY.Text = ConfigurationManager.AppSettings["textBox_ImpPMesY"];
               this.textBox_ImpPAnoX.Text = ConfigurationManager.AppSettings["textBox_ImpPAnoX"];
               this.textBox_ImpPAnoY.Text = ConfigurationManager.AppSettings["textBox_ImpPAnoY"];
               this.textBox_ImpPHorX.Text = ConfigurationManager.AppSettings["textBox_ImpPHorX"];
               this.textBox_ImpPHorY.Text = ConfigurationManager.AppSettings["textBox_ImpPHorY"];
               this.textBox_ImpPNumX.Text = ConfigurationManager.AppSettings["textBox_ImpPNumX"];
               this.textBox_ImpPNumY.Text = ConfigurationManager.AppSettings["textBox_ImpPNumY"];
               this.textBox_ImpPSenX.Text = ConfigurationManager.AppSettings["textBox_ImpPSenX"];
               this.textBox_ImpPSenY.Text = ConfigurationManager.AppSettings["textBox_ImpPSenY"];
               this.textBox_ImpPDomX.Text = ConfigurationManager.AppSettings["textBox_ImpPDomX"];
               this.textBox_ImpPDomY.Text = ConfigurationManager.AppSettings["textBox_ImpPDomY"];
               this.textBox_ImpPLocX.Text = ConfigurationManager.AppSettings["textBox_ImpPLocX"];
               this.textBox_ImpPLocY.Text = ConfigurationManager.AppSettings["textBox_ImpPLocY"];            
               this.textBox_ImpPCanX.Text = ConfigurationManager.AppSettings["textBox_ImpPCanX"];
               this.textBox_ImpPCanY.Text = ConfigurationManager.AppSettings["textBox_ImpPCanY"];
               this.textBox_ImpPCanMC.Text = ConfigurationManager.AppSettings["textBox_ImpPCanMC"];
               this.textBox_ImpPDetX.Text = ConfigurationManager.AppSettings["textBox_ImpPDetX"];
               this.textBox_ImpPDetY.Text = ConfigurationManager.AppSettings["textBox_ImpPDetY"];
               this.textBox_ImpPDetMC.Text = ConfigurationManager.AppSettings["textBox_ImpPDetMC"];
               this.textBox_ImpPPreX.Text = ConfigurationManager.AppSettings["textBox_ImpPPreX"];
               this.textBox_ImpPPreY.Text = ConfigurationManager.AppSettings["textBox_ImpPPreY"];
               this.textBox_ImpPPreMC.Text = ConfigurationManager.AppSettings["textBox_ImpPPreMC"];              
               this.textBox_ImpPImpX.Text = ConfigurationManager.AppSettings["textBox_ImpPImpX"];
               this.textBox_ImpPImpY.Text = ConfigurationManager.AppSettings["textBox_ImpPImpY"];
               this.textBox_ImpPImpMC.Text = ConfigurationManager.AppSettings["textBox_ImpPImpMC"];              
               this.textBox_ImpPTotX.Text = ConfigurationManager.AppSettings["textBox_ImpPTotX"];
               this.textBox_ImpPTotY.Text = ConfigurationManager.AppSettings["textBox_ImpPTotY"];
               //Panel Configuracion general 
               this.textBox_Cot_Dolar.Text = ConfigurationManager.AppSettings["textBox_Cot_Dolar"];
               this.textBox_Cot_Euro.Text = ConfigurationManager.AppSettings["textBox_Cot_Euro"];
               this.textBox_CG_Backup.Text = ConfigurationManager.AppSettings["textBox_CG_Backup"];
           }
           catch (Exception ex)
           {
               em.sendmail(ex, "Error: F-OP1-005");
           }
       }

       private void button_Prueba_Click(object sender, EventArgs e)
       {
           try
           {
               Factura factura = new Factura();
               string[] DateArray = DateTime.Now.ToShortDateString().Split('/');
               //Datos de Factura
               factura.AddDatos(DateArray[0], ConfigurationManager.AppSettings["textBox_ImpDiaX"], ConfigurationManager.AppSettings["textBox_ImpDiaY"]);
               factura.AddDatos(DateArray[1], ConfigurationManager.AppSettings["textBox_ImpMesX"], ConfigurationManager.AppSettings["textBox_ImpMesY"]);
               factura.AddDatos(DateArray[2], ConfigurationManager.AppSettings["textBox_ImpAnoX"], ConfigurationManager.AppSettings["textBox_ImpAnoY"]);
               factura.AddDatos(DateTime.Now.ToShortTimeString(), ConfigurationManager.AppSettings["textBox_ImpHorX"], ConfigurationManager.AppSettings["textBox_ImpHorY"]);
               factura.AddDatos("Manuel Belgrano", ConfigurationManager.AppSettings["textBox_ImpSenX"], ConfigurationManager.AppSettings["textBox_ImpSenY"]);
               factura.AddDatos("Av. San Martin 2477 piso 7 dto A", ConfigurationManager.AppSettings["textBox_ImpDomX"], ConfigurationManager.AppSettings["textBox_ImpDomY"]);
               factura.AddDatos("Capital Federal", ConfigurationManager.AppSettings["textBox_ImpLocX"], ConfigurationManager.AppSettings["textBox_ImpLocY"]);
               factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRiX"], ConfigurationManager.AppSettings["textBox_ImpRiY"]);
               factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpCfX"], ConfigurationManager.AppSettings["textBox_ImpCfY"]);
               factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpNorX"], ConfigurationManager.AppSettings["textBox_ImpNorY"]);
               factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpExeX"], ConfigurationManager.AppSettings["textBox_ImpExeY"]);
               factura.AddDatos("15-29058877-5", ConfigurationManager.AppSettings["textBox_ImpCuiX"], ConfigurationManager.AppSettings["textBox_ImpCuiY"]);
               factura.AddDatos("00022451", ConfigurationManager.AppSettings["textBox_ImpRemX"], ConfigurationManager.AppSettings["textBox_ImpRemY"]);
               factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpConX"], ConfigurationManager.AppSettings["textBox_ImpConY"]);
               factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpCcoX"], ConfigurationManager.AppSettings["textBox_ImpCcoY"]);
               //Items
               /*
               factura.AddItems("01,Gorrita Adidas,15.500,(10.50),***,15.50");
               factura.AddItems("22,DISCO rigido WesTern DIGITAL 500GB - continuacion del primer item en algun momento me lo deberia cortar y crear nuevas lineas que no importa la cantidad siempre las tiene que dividir siempre y cuadno yo ponga mucho texto en el casillero de detalle,600.6669,(10.50),***,600.00");
               factura.AddItems("01,Medias Adidas,6.0000,(10.50),***,6.00");
               factura.AddItems("05,Pantalones Acrilicos Nike MOD. 65544,12.0000,(10.50),***,12.00");
               */
               //Totales
               factura.AddDatos("0.0000", ConfigurationManager.AppSettings["textBox_ImpSu1X"], ConfigurationManager.AppSettings["textBox_ImpSu1Y"]);
               factura.AddDatos("0.0000", ConfigurationManager.AppSettings["textBox_ImpDesX"], ConfigurationManager.AppSettings["textBox_ImpDesY"]);
               factura.AddDatos("21%", ConfigurationManager.AppSettings["textBox_ImpIpsX"], ConfigurationManager.AppSettings["textBox_ImpIpsY"]);
               factura.AddDatos("0.0000", ConfigurationManager.AppSettings["textBox_ImpSu2X"], ConfigurationManager.AppSettings["textBox_ImpSu2Y"]);
               factura.AddDatos("21%", ConfigurationManager.AppSettings["textBox_ImpIvaX"], ConfigurationManager.AppSettings["textBox_ImpIvaY"]);
               factura.AddDatos("0.0000", ConfigurationManager.AppSettings["textBox_ImpTotX"], ConfigurationManager.AppSettings["textBox_ImpTotY"]);
               //Mando a Imprimir
               factura.PrintFactura(ConfigurationManager.AppSettings["textBox_ImpNOMBRE"]);
           }
           catch (Exception ex)
           {
               em.sendmail(ex, "Error: F-OP1-007");
           }
       }

       private bool checkConection()
       {
           try
           {
               // Me conecto
               SqlCeConnection conexion = new SqlCeConnection(SG.MDIParentPadre.st_conexion);
               SqlCeCommand cmd = new SqlCeCommand("",conexion);
               cmd.Connection.Open();
               //cmd.ExecuteNonQuery();
               cmd.Connection.Close();
               return true;
           }
           catch
           {
               return false;
           }
           
       }

       private void button1_Click_2(object sender, EventArgs e)
       {
           if (checkConection())
           {
               MessageBox.Show("La conexion con base de datos se realizó con éxito.");
           }
           else
           {
               MessageBox.Show("Conexion fallida, verifique la existencia del host.", "Error: F-OP1-008", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       private void button_VerDisp_Click(object sender, EventArgs e)
       {
           try
           {
               // Veo las impresoras disponibles, ventana de configuracion.
               PrintDialog pd = new PrintDialog();
               pd.PrinterSettings = new PrinterSettings();
               if (DialogResult.OK == pd.ShowDialog(this))
               {
                   this.textBox_ImpNOMBRE.Text = pd.PrinterSettings.PrinterName.ToString();
               }
           }
           catch (Exception ex)
           {
               em.sendmail(ex, "Error: F-OP1-006");
           }
       }

       private void button_BuscarCarpeta_Click(object sender, EventArgs e)
       {
           try
           {
               // Veo las impresoras disponibles, ventana de configuracion.
               FolderBrowserDialog fb = new FolderBrowserDialog();
               if (DialogResult.OK == fb.ShowDialog(this))
               {
                   this.textBox_CG_Backup.Text = fb.SelectedPath.ToString();
               }
           }
           catch (Exception ex)
           {
               em.sendmail(ex, "Error: F-OP1-006");
           }
       }


       
    }
}
