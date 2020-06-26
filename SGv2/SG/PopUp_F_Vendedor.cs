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
    public partial class PopUp_F_Vendedor : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static PopUp_F_Vendedor m_FormDefInstance;
        public static PopUp_F_Vendedor DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new PopUp_F_Vendedor();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public PopUp_F_Vendedor()
        {
            InitializeComponent();
        }

        private void PopUp_F_Vendedor_Load(object sender, EventArgs e)
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT [id_usuario],[nombre],[apellido] FROM data_usuarios WHERE usertype LIKE '%Vendedor%' ORDER BY id_usuario DESC";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "data_usuarios");

                BindingSource bindingSource = new BindingSource(sgdbDataSet.Tables[0], null);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear(); //Borro todas las columnas de dataGridView1

                dataGridView1.Columns.Add("VendedorNumero", "Vendedor N°"); //(nombre de la columna,Titulo de la columna)
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Apellido", "Apellido");

                //dataGridView1.Columns[0].Width = 110; // ancho de la columna
                //dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[0].DataPropertyName = "id_usuario"; //son los campos de la base de datos
                dataGridView1.Columns[1].DataPropertyName = "nombre";
                dataGridView1.Columns[2].DataPropertyName = "apellido";

                dataGridView1.DataSource = bindingSource;
                //bindingNavigator1.BindingSource = bindingSource;
                conexion.Close();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-VE1-001");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
