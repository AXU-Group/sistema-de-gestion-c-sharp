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
    public partial class Form_Caja : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_Caja m_FormDefInstance;
        public static Form_Caja DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_Caja();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public Form_Caja()
        {
            InitializeComponent();
        }

        private void cargoVendedores()
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                string sql = "SELECT id_usuario, nombre, apellido FROM data_usuarios WHERE usertype='Vendedor' ORDER BY id_usuario DESC";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "data_usuarios");
                int rowsCount = sgdbDataSet.Tables["data_usuarios"].Rows.Count;

                Dictionary<string, string> Items = new Dictionary<string, string>();

                // Cargo el primer item vacio
                Items.Add("", "");

                for (int i = 0; i < rowsCount; i++)
                {
                    DataRow dRow = sgdbDataSet.Tables["data_usuarios"].Rows[i];

                    Items.Add(dRow.ItemArray.GetValue(0).ToString(), dRow.ItemArray.GetValue(1).ToString() + "  " + dRow.ItemArray.GetValue(2).ToString());
                }

                this.comboBox_C_Vendedor.DataSource = new BindingSource(Items, null);
                this.comboBox_C_Vendedor.DisplayMember = "Value";
                this.comboBox_C_Vendedor.ValueMember = "Key";

                // Get combobox selection (in handler)
                //string value = ((KeyValuePair<string, string>)this.comboBox_C_Vendedor.SelectedItem).Value;

                conexion.Close();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CA0-003");
            }
        }

        private void calculoCaja(object sender, EventArgs e)
        {
            caja();
        }

        private void caja()
        {
            try
            {
                string fecha = this.dateTimePicker_C_Fecha.Value.ToString();
                string[] DateArray1 = fecha.Split(' '); // queda dd/mm/aaaa
                fecha = DateArray1[0];
                string vendedorId = ((KeyValuePair<string, string>)this.comboBox_C_Vendedor.SelectedItem).Key; // Get combobox selection (in handler)
                string tipo_comprobante = "";

                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet ds = new DataSet();

                string sql_search = "";

                // Armo condiciones del sql si se cambian los select
                if (this.comboBox_C_CondVenta.Text != "") sql_search += " f.f_c_condicion='" + this.comboBox_C_CondVenta.Text + "' AND ";
                if (vendedorId != "") sql_search += " f.f_vendedor=" + vendedorId + " AND ";
                if (tipo_comprobante != "") sql_search += " f.f_tipo='" + tipo_comprobante + "' AND ";

                string sql = "SELECT f.f_fecha, u.nombre, u.apellido, f.f_c_condicion, f.f_tipo, f.fi_total FROM facturas f, data_usuarios u WHERE " + sql_search + " f.f_fecha='" + fecha + "' AND u.id_usuario=f.f_vendedor";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);
                da.Fill(ds, "facturas");

                BindingSource bindingSource = new BindingSource(ds.Tables[0], null);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear(); //Borro todas las columnas de dataGridView1

                dataGridView1.Columns.Add("Fecha", "Fecha"); //(nombre de la columna,Titulo de la columna)
                dataGridView1.Columns.Add("Vendedor", "Vendedor");
                dataGridView1.Columns.Add("Condicion", "Condicion");
                dataGridView1.Columns.Add("Comprobante", "Comprobante");
                dataGridView1.Columns.Add("Total", "Total");

                int cantidadRows = ds.Tables["facturas"].Rows.Count;
                float total = 0;

                for (int i = 0; i < cantidadRows; i++)
                {
                    DataRow dRow = ds.Tables["facturas"].Rows[i];

                    dataGridView1.Columns[0].DataPropertyName = "f_fecha"; //son los campos de la base de datos
                    dataGridView1.Columns[1].DataPropertyName = "nombre";
                    dataGridView1.Columns[2].DataPropertyName = "f_c_condicion";
                    dataGridView1.Columns[3].DataPropertyName = "f_tipo";
                    dataGridView1.Columns[4].DataPropertyName = "fi_total";

                    total = total + float.Parse(dRow.ItemArray.GetValue(5).ToString());
                }

                dataGridView1.DataSource = bindingSource;
                //bindingNavigator1.BindingSource = bindingSource;

                conexion.Close();

                this.label_F_TOTAL.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                em.sendmail(ex, "Error: F-CA0-004");
            }
        }

        private void Form_Caja_Load(object sender, EventArgs e)
        {
            cargoVendedores();
            caja();
        }
    }
}
