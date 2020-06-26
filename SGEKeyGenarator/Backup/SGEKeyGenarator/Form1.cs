using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace SGEKeyGenarator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string md5crypt()
        {
            try
            {
                string Value = "";
                Value = "Guillermo Moreno" + this.textBox_MES.Text + this.textBox_ANIO.Text + "AXU GROUP";
                MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
                byte[] data = ASCIIEncoding.Default.GetBytes(Value);
                data = x.ComputeHash(data);
                string[] y = BitConverter.ToString(data).Split('-');
                int cantidad = y.Count();
                string z = "";
                for (int i = 0; i < cantidad; i++)
                {
                    z += y[i];
                }
                return z;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descripción: " + ex.Message, "Error: F-K00-001", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void button_Gen_Click(object sender, EventArgs e)
        {
            this.textBox_KEY.Text = md5crypt();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
