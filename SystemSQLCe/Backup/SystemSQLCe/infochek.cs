using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SystemSQLCe
{
    public partial class infochek : Form
    {
        SQLcatch cat = new SQLcatch();
        public infochek()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripción: " + ex.Message, "Error: D-IN1-001", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void check(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox_Code.Text.ToString() == cat.md5crypt())
                {
                    cat.EscriboCript(this.textBox_Code.Text.ToString());
                    this.Ok.Enabled = true;
                }
                else this.Ok.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripción: " + ex.Message, "Error: D-IN1-002", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void al_Cerrar(object sender, FormClosedEventArgs e)
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
                MessageBox.Show("Descripción: " + ex.Message, "Error: D-IN1-003", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
