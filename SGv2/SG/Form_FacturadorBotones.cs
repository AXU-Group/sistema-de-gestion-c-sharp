using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using manten;

namespace SG
{
    public partial class Form_FacturadorBotones : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_FacturadorBotones m_FormDefInstance;
        public static Form_FacturadorBotones DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_FacturadorBotones();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public Form_FacturadorBotones()
        {
            InitializeComponent();
            creoBotones();
        }

        private void creoBotones()
        {
            try
            {
                /*
                 * EJEMPLO DE COMO AGREGAR UN ELEMENTO
                 * 
                this.button1 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // button1
                // 
                this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
                this.button1.Location = new System.Drawing.Point(12, 32);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 75);
                this.button1.TabIndex = 0;
                this.button1.Text = "Caramelos $0.25";
                this.button1.UseVisualStyleBackColor = false;

                this.Controls.Add(this.button1);
                */
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet ds = new DataSet();
                string sql = "SELECT codigo_barra, codigo_interno, descripcion, unidad, precio_venta1 FROM articulos WHERE orden!='' ORDER BY orden";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(ds, "articulos");

                int i;
                int c = 1;
                int cols = 80;
                int rows = 80;
                int cantidad = ds.Tables["articulos"].Rows.Count;
                MessageBox.Show(cantidad.ToString());

                for (i = 0; i < cantidad && i < 30; i++)
                {
                    if (c == 10) { cols = 80; rows = rows + 80; c = 1; }
                    else cols = c * 80;

                    DataRow dRow = ds.Tables["articulos"].Rows[i];

                    this.button1 = new System.Windows.Forms.Button();
                    this.SuspendLayout(); 
                    this.button1.BackColor = System.Drawing.Color.PaleTurquoise;
                    this.button1.Location = new System.Drawing.Point((15 + cols), (15 + rows));
                    this.button1.Name = "button"+i;
                    this.button1.Size = new System.Drawing.Size(75, 75);
                    this.button1.TabIndex = 0;
                    this.button1.Text = dRow.ItemArray.GetValue(2).ToString() + "\n\t(" + dRow.ItemArray.GetValue(3).ToString() + "x" + dRow.ItemArray.GetValue(4).ToString() + ")";
                    this.button1.UseVisualStyleBackColor = false;

                    this.Controls.Add(this.button1);

                    c++;
                }
                

                
                /*
                if (dRow.ItemArray.GetValue(14).ToString() != "")
                {
                    this.pictureBox_E_Imagen.Image = Image.FromFile(dRow.ItemArray.GetValue(14).ToString());
                }
                else this.pictureBox_E_Imagen.Image = null;
                */ 
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                em.sendmail(ex, "Error: F-FB1-001");
            }
        }
    }
}
