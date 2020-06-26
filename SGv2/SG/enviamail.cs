using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mailstaff;

namespace SG
{
    public partial class enviamail : Form
    {
        private string body = "";
        private string codigo = "";

        public enviamail()
        {
            InitializeComponent();
            this.label2.Visible = true;
            this.pictureBox2.Visible = true;
            this.label1.Visible = false;
            this.pictureBox1.Visible = false;
        }

        public void sendmail(string bodyOrig, string codigoOrig)
        {
            body = bodyOrig;
            codigo = codigoOrig;
            this.ShowDialog();
        }

        private void procesoEnvio(string bodyAenviar, string codigoAenviar)
        {
            string bodyCompleto = bodyAenviar + "\n\n\n" + codigoAenviar;
            EnviaMailStaff msj = new EnviaMailStaff();
            string confirmacion = msj.send(bodyCompleto);
            if ("OK" == confirmacion)
            {
                MessageBox.Show("El error enviado fue el siguiente: " + bodyAenviar, codigoAenviar, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(confirmacion);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label2.Visible = false;
            this.pictureBox2.Visible = false;
            this.label1.Visible = true;
            this.pictureBox1.Visible = true;
            this.Refresh();
            procesoEnvio(body, codigo);
        }
    }
}
