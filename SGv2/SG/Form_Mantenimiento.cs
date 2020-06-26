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
using System.Threading;

namespace SG
{
    public partial class Form_Mantenimiento : Form
    {
        enviamail em = new enviamail();
        string SQL_SELECT = "";
        int boton = 0;

        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_Mantenimiento m_FormDefInstance;
        public static Form_Mantenimiento DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_Mantenimiento();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public Form_Mantenimiento()
        {
            InitializeComponent();
        }

        private void button_M_sqlSelect_Click(object sender, EventArgs e)
        {
            this.textBox_M_sqlcommand.Text = "SELECT * FROM articulos WHERE 1=1";
            SQL_SELECT = this.textBox_M_sqlcommand.Text;
            boton = 1;
        }

        private void button_M_sqlUpdate_Click(object sender, EventArgs e)
        {
            this.textBox_M_sqlcommand.Text = "UPDATE articulos SET codigo_barra='1001', codigo_interno='11' WHERE id=1";
            boton = 2;
        }

        private void button_M_sqlInsert_Click(object sender, EventArgs e)
        {
            this.textBox_M_sqlcommand.Text = "INSERT INTO articulos (codigo_barra, codigo_interno) VALUES ('','')";
            boton = 3;
        }

        private void button_M_sqlDelete_Click(object sender, EventArgs e)
        {
            this.textBox_M_sqlcommand.Text = "DELETE FROM articulos WHERE id='1'";
            boton = 4;
        }

        private void button_M_sqlTruncate_Click(object sender, EventArgs e)
        {
            this.textBox_M_sqlcommand.Text = "DELETE FROM articulos WHERE 1=1 .... ALTER TABLE articulos ALTER COLUMN id IDENTITY (1,1)";
            boton = 5;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            switch (boton)
            {
                case 0: break;
                case 1: executeSQL(); showInDataGrid(); break;
                case 2: executeSQL(); showInDataGrid(); break;
                case 3: executeSQL(); showInDataGrid(); break;
                case 4: executeSQL(); showInDataGrid(); break;
                case 5: executeSQL(); break;
                default: break;
            }
        }

        private void executeSQL()
        {
            try
            {
                string sql = this.textBox_M_sqlcommand.Text;

                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                // Muestro los datos resultantes a la busqueda en el datagrid

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error: F-M-001", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showInDataGrid()
        {
            try
            {
                string sql = this.textBox_M_sqlcommand.Text;

                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet dataSet = new DataSet();
                SqlCeDataAdapter dAdapter = new SqlCeDataAdapter(sql, conexion);

                dAdapter.Fill(dataSet);
                BindingSource bindingSource = new BindingSource(dataSet.Tables[0], null);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.Columns.Clear(); //Borro todas las columnas de dataGridView1
                dataGridView1.DataSource = bindingSource;
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error: F-M-002", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
