using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using manten;

namespace SG
{
    public partial class Form_FacturadorImagen : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_FacturadorImagen m_FormDefInstance;
        public static Form_FacturadorImagen DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_FacturadorImagen();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public Form_FacturadorImagen()
        {
            InitializeComponent();
        }
        public void cambio_pictureBox(string picPath)
        {
            try
            {
                if(picPath!="") this.pictureBox_I_Imagen.Image = Image.FromFile(picPath);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA2-001");
            }
        }
    }
}
