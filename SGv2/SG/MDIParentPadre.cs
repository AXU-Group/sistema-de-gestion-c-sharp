using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;
using SystemSQLCe;
using System.Configuration;
using manten;
using System.Threading;
using System.Diagnostics;
using Ionic.Zip;


namespace SG
{
    public partial class MDIParentPadre : Form
    {
        public static string MiVariable; // DECLARO VARIABLE GLOBAL PARA QUE SEA LEGIBLE DE CUALQUIER FORM
        public static string st_conexion_cliente;
        public static string st_conexion = @"Data Source=" + ConfigurationManager.AppSettings["textBox_HOST"] + @"\sgdb.sdf;password=adminROOT464;";
        public static string Usuario;
        public static string Password;
        public static int UserID;
        SQLcatch data = new SQLcatch();
        enviamail em = new enviamail();

        public MDIParentPadre()
        {
                try
                {
                    InitializeComponent();
                }
                catch (Exception ex)
                {
                    em.sendmail(ex, "Error: F-MDI-001");
                }
        }
        
        private void Salir_toolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void PrintSetup_toolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBar_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = StatusBar_toolStripMenuItem.Checked;
        }

        private void Cascada_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void Vertical_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void Horizontal_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void CerrarTodo_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Login_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Sobre_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AboutBox1 sobre = new AboutBox1();
            //sobre.MdiParent = this; //Para que el form quede dentro del MDIParent
            //childFormNumber++;
            //sobre.Show();
            AboutBox1.DefInstance.BringToFront();
            AboutBox1.DefInstance.Owner = this;
            AboutBox1.DefInstance.Show();
        }

        private void Opciones_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_Opciones Options = new Form_Opciones();
            //Options.MdiParent = this;
            //Options.Show();
            Form_Opciones.DefInstance.BringToFront();
            Form_Opciones.DefInstance.MdiParent = this;
            Form_Opciones.DefInstance.Show();
        }

        private void Usuarios_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Usuarios.DefInstance.BringToFront();
            Form_Usuarios.DefInstance.MdiParent = this;
            Form_Usuarios.DefInstance.Show();
        }

        private void Stock_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_Articulos Articulos = new Form_Articulos();
            //Articulos.MdiParent = this;
            //Articulos.Show();
            Form_Articulos.DefInstance.BringToFront();
            Form_Articulos.DefInstance.MdiParent = this;
            Form_Articulos.DefInstance.Show();
        }

        private void Clientes_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_Clientes Clientes = new Form_Clientes();
            //Clientes.MdiParent = this;
            //Clientes.Show();
            Form_Clientes.DefInstance.BringToFront();
            Form_Clientes.DefInstance.MdiParent = this;
            Form_Clientes.DefInstance.Show();
        }

        private void Proveedores_ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Form_Clientes Clientes = new Form_Clientes();
            //Clientes.MdiParent = this;
            //Clientes.Show();
            Form_Clientes.DefInstance.BringToFront();
            Form_Clientes.DefInstance.MdiParent = this;
            Form_Clientes.DefInstance.Show();
        }

        private void Facturador_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_Facturador Facturador = new Form_Facturador();
            //Facturador.MdiParent = this;
            //Facturador.Show();
            Form_Facturador.DefInstance.BringToFront();
            Form_Facturador.DefInstance.MdiParent = this;
            Form_Facturador.DefInstance.Show();
        }

        private void Mantenimiento_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Mantenimiento.DefInstance.BringToFront();
            Form_Mantenimiento.DefInstance.Owner = this;
            Form_Mantenimiento.DefInstance.Show();
        }

        private void Caja_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Caja.DefInstance.BringToFront();
            Form_Caja.DefInstance.Owner = this;
            Form_Caja.DefInstance.Show();
        }

        public void Login()
        {
            try
            {
                if (this.Login_ToolStripMenuItem.Text != "&Cerrar sessión")
                {
                    Login form_login = new Login();
                    DialogResult respuesta = form_login.ShowDialog();   // también podemos llamarlo usando ShowDialog();
                    if (respuesta == DialogResult.OK) //si acepto osea OK en el formulario LOGIN
                    {
                        // Me conecto
                        
                        SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                        DataSet ds = new DataSet();
                        SqlCeCommand cmd = new SqlCeCommand();
                        string sql = "SELECT id_usuario, login, password, nombre, apellido, usertype FROM data_usuarios WHERE login='" + MDIParentPadre.Usuario + "' AND password='" + MDIParentPadre.Password + "'";
                        SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);
                        da.Fill(ds, "data_usuarios");

                        if (ds.Tables["data_usuarios"].Rows.Count > 0) //Si existe un resultado es OK
                        {
                            DataRow dRow = ds.Tables["data_usuarios"].Rows[0];
                            //Muestra el contenido de la primera columna
                            UserID = Int32.Parse(dRow.ItemArray.GetValue(0).ToString());
                            string lg_usuario = dRow.ItemArray.GetValue(1).ToString();
                            string lg_password = dRow.ItemArray.GetValue(2).ToString();
                            string usertype = dRow.ItemArray.GetValue(5).ToString();
                            MDIParentPadre.MiVariable = dRow.ItemArray.GetValue(3).ToString() + " " + dRow.ItemArray.GetValue(4).ToString();
                            conexion.Close();
                            conexion.Dispose();

                            // Si es root muestro el acceso al form de mantenimiento en el menu
                            if (usertype == "Root") this.mantenimientoToolStripMenuItem.Visible = true;
                            else this.mantenimientoToolStripMenuItem.Visible = false;

                            // Este formulario es el que se va abrir con el primer formulario para el usuario despues de logearse
                            //Form Form_principal = new Form();
                            //Form_principal.MdiParent = this;
                            //childFormNumber++;
                            //Form_principal.Show();
                            this.Login_ToolStripMenuItem.Text = "&Cerrar sessión";
                            this.toolStripStatus_Usuario.Text = MDIParentPadre.MiVariable;  //ahora puedo usar la variable que modifique en el LOGIN
                        }
                        else
                        {
                            MessageBox.Show("Usuario o password incorrectos, pruebe nuevamente");
                            Login();//this.Close();//form_login.Close();
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Login_ToolStripMenuItem.Text = "&Ingresar";
                    this.toolStripStatus_Usuario.Text = "";
                    for (int i = 0; i < this.MdiChildren.Length; i++)
                    {
                        this.MdiChildren[i].Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Esta es son las lineas que hay que agregar para que mande un mail.
                em.sendmail(ex, "Error: F-MDI-002");
            }
        }

        public static bool backupdata(string tipo) //datos o config
        {
            try
            {
                string[] AppArray = Application.ExecutablePath.Split('\\');
                string ExeFile = AppArray[AppArray.Count()-1];

                DirectoryInfo backupdata = new DirectoryInfo(Environment.CurrentDirectory + @"\backupdata\");
                
                string[] DateArray = DateTime.Now.ToShortDateString().Split('/');

                string DateTimeHora = DateTime.Now.Hour.ToString();
                string DateTimeMin = DateTime.Now.Minute.ToString();
                string DateTimeSeg = DateTime.Now.Second.ToString();

                string DateTimeNow = DateArray[2] + "-" + DateArray[1] + "-" + DateArray[0] + "-" + DateTimeHora + "-" + DateTimeMin + "-" + DateTimeSeg;
                if (!backupdata.Exists)
                {
                    backupdata.Create(); // creo el directorio ARTICULOS
                }

                if (tipo == "datos")
                {
                    //busco archivo y lo salvo sgdb.sdf
                    File.Copy(Environment.CurrentDirectory + @"\sgdb.sdf", Environment.CurrentDirectory + @"\backupdata\" + DateTimeNow + @".sdf");
                    return true; 
                }
                else
                {
                    if (tipo == "config")
                    {
                        //busco archivo y lo salvo App.config
                        File.Copy(Environment.CurrentDirectory + @"\" + ExeFile + @".config", Environment.CurrentDirectory + @"\backupdata\" + DateTimeNow + @".config");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }                
            }
            catch (Exception ex)
            {
                enviamail em = new enviamail(); // Porque el metodo es publico
                em.sendmail(ex, "Error: F-MDI-003");
                return false;
            }
        }

        private void MDIParentPadre_Load(object sender, EventArgs e)
        {
            try
            {
                if (data.SQLceConect())
                {
                    Login();
                    data.daysLeft();
                    makeBackupApp();
                }
                else this.Close();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-MDI-004");
            }
        }

        private void makeBackupApp()
        {
            
            try
            {
                // Si esta configurado el path destino y existe actualmente
                if (ConfigurationManager.AppSettings["textBox_CG_Backup"] != "" && Directory.Exists(ConfigurationManager.AppSettings["textBox_CG_Backup"]))
                {
                    ZipFile zip = new ZipFile();
                    //string[] filePaths = Directory.GetFiles(@"c:\MyDir\");
                    zip.AddItem(Environment.CurrentDirectory.ToString());
                    //zip.AddFile("imagen.png", "");
                    //zip.AddFile("texto.txt", "");
                    //zip.AddFile("musica.mp3", "");
                    string[] DateArray = DateTime.Now.ToShortDateString().Split('/');
                    zip.Save(ConfigurationManager.AppSettings["textBox_CG_Backup"]+ @"\vizsla_backup_" + DateArray[2] + "_" + DateArray[1] + "_" + DateArray[0] + ".zip");

                    MessageBox.Show("Se creo el backup del sistema correctamente en:\n" + ConfigurationManager.AppSettings["textBox_CG_Backup"], "BACKUP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Se intentó crear un backup del sistema pero no se encontro el directorio.\nEn Herramientas->Opciones->Configuracion General puede\nseleccionar un directorio.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-MDI-005");
            }
        }

        private void MDIParentPadre_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(""+ e.KeyData);
            //((System.Windows.Forms.Keys)));
            //if (e.KeyData == Keys.Alt && e.KeyData == Keys.Control && e.KeyData == Keys.LShiftKey && e.KeyData == Keys.F12)
            if(e.KeyData == (((Keys.Control | Keys.Alt) | Keys.Shift) | Keys.F12))
            {
                Form_Mantenimiento.DefInstance.BringToFront();
                Form_Mantenimiento.DefInstance.Owner = this;
                Form_Mantenimiento.DefInstance.Show();
            }

            if (e.KeyData == (((Keys.Control | Keys.Alt) | Keys.Shift) | Keys.F11))
            {
                Form_FacturadorBotones.DefInstance.BringToFront();
                Form_FacturadorBotones.DefInstance.Owner = this;
                Form_FacturadorBotones.DefInstance.Show();
            }
        }

        private void MDIParentPadre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 16 && e.KeyChar == 17 && e.KeyChar == 18 && e.KeyChar == 123)
            {
                Form_Mantenimiento.DefInstance.BringToFront();
                Form_Mantenimiento.DefInstance.Owner = this;
                Form_Mantenimiento.DefInstance.Show();
            }
        }

    }
}
