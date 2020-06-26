using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using manten;

namespace SG
{
    public partial class Login : Form
    {
        enviamail em = new enviamail();
        public Login()
        {
            InitializeComponent();
        }

        private void Ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                MDIParentPadre.Usuario = textBox_Usuario.Text;
                MDIParentPadre.Password = textBox_Pass.Text;
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-LO1-001");
            }
        }

        private void al_cerrar(object sender, FormClosedEventArgs e)
        {
            try
            {
                float StepVal = (float)(100f / 10);
                float fOpacity = 100f;
                for (byte b = 0; b < 10; b++)
                {
                    this.Opacity = fOpacity / 100;
                    this.Refresh();
                    fOpacity -= StepVal;
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-LO1-002");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
