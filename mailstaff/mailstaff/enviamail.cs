using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace manten
{
    public partial class enviamail : Form
    {
        private string ex;
        private string codigo = "";

        public enviamail()
        {
            InitializeComponent();
            this.label2.Visible = true;
            this.pictureBox2.Visible = true;
            this.label1.Visible = false;
            this.progressBar1.Visible = false;
        }

        public void sendmail(Exception exception, string codigoOrig)
        {
            //Get a StackTrace object for the exception
            StackTrace st = new StackTrace(exception, true);

            //Get the first stack frame
            StackFrame frame = st.GetFrame(0);

            //Get the file name
            string fileName = frame.GetFileName();

            //Get the method name
            string methodName = frame.GetMethod().Name;

            //Get the line number from the stack frame
            int line = frame.GetFileLineNumber();

            //Get the column number
            int col = frame.GetFileColumnNumber();

            //Fecha
            string fecha = DateTime.Now.ToShortDateString().ToString();

            ex =  "Fecha: " + fecha + "\nDescripcion: " + exception.Message + "\n" + st + "\n" + frame + "\n" + fileName + "\n" + methodName + "\n" + line + "\n" + col;
            codigo = codigoOrig;
            this.ShowDialog();
        }

        private void procesoEnvio(string ex, string codigoAenviar)
        {
            string bodyCompleto = ex + "\n\n" + codigoAenviar;
            EnviaMailStaff msj = new EnviaMailStaff();
            string confirmacion = msj.send(bodyCompleto);  // Si se envio el mail
            if ("OK" == confirmacion)
            {
                MessageBox.Show("El error enviado fue el siguiente: " + bodyCompleto, codigoAenviar, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.progressBar1.Visible = true;
            this.Refresh();
            procesoEnvio(ex, codigo);
        }
    }
}
