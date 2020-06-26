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
    public partial class Form_FacturadorBuscar : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_FacturadorBuscar m_FormDefInstance;
        public static Form_FacturadorBuscar DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_FacturadorBuscar();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca
        public Form_FacturadorBuscar()
        {
            InitializeComponent();
        }

        //private DataGridViewCheckBoxColumn facturar;

        private void listoFacturas()
        {
            try
            {
                string buscarEn = "";

                if (toolStripComboBox_buscarEn.SelectedItem.ToString() != "") buscarEn = toolStripComboBox_buscarEn.SelectedItem.ToString();
                else buscarEn = "Facturado A,B,C,T";

                string busco = toolStripTextBox_Buscar.Text;
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();

                if (this.toolStripTextBox_Buscar.Text != "")
                {
                    string sql = "";
                    if (buscarEn == "Facturado A,B,C,T") sql = "SELECT * FROM facturas WHERE (upper(f_numero) LIKE upper('%" + busco + "%') OR upper(f_fecha) LIKE upper('%" + busco + "%') OR upper(f_c_razon_social) LIKE upper('%" + busco + "%')) AND (upper(f_tipo) = upper('A') OR upper(f_tipo) = upper('B') OR  upper(f_tipo) = upper('C') OR upper(f_tipo) = upper('Ticket'))";
                    if (buscarEn == "Cuenta Corriente") sql = "SELECT * FROM facturas WHERE (upper(f_numero) LIKE upper('%" + busco + "%') OR upper(f_fecha) LIKE upper('%" + busco + "%') OR upper(f_c_razon_social) LIKE upper('%" + busco + "%')) AND (upper(f_tipo) = upper('CC'))";
                    if (buscarEn == "NC") sql = "SELECT * FROM facturas WHERE (upper(f_numero) LIKE upper('%" + busco + "%') OR upper(f_fecha) LIKE upper('%" + busco + "%') OR upper(f_c_razon_social) LIKE upper('%" + busco + "%')) AND (upper(f_tipo) = upper('NC'))";
                    if (buscarEn == "NP") sql = "SELECT * FROM facturas WHERE (upper(f_numero) LIKE upper('%" + busco + "%') OR upper(f_fecha) LIKE upper('%" + busco + "%') OR upper(f_c_razon_social) LIKE upper('%" + busco + "%')) AND (upper(f_tipo) = upper('NC'))";
                    if (buscarEn == "MovStock") sql = "SELECT * FROM facturas WHERE (upper(f_numero) LIKE upper('%" + busco + "%') OR upper(f_fecha) LIKE upper('%" + busco + "%') OR upper(f_c_razon_social) LIKE upper('%" + busco + "%')) AND (upper(f_tipo) = upper('MovStock'))";
                    if (buscarEn == "Remitos") sql = "SELECT * FROM facturas WHERE (upper(f_numero) LIKE upper('%" + busco + "%') OR upper(f_fecha) LIKE upper('%" + busco + "%') OR upper(f_c_razon_social) LIKE upper('%" + busco + "%')) AND (upper(f_tipo) = upper('Remito'))";
                    if (buscarEn == "Presupuesto") sql = "SELECT * FROM facturas WHERE (upper(f_numero) LIKE upper('%" + busco + "%') OR upper(f_fecha) LIKE upper('%" + busco + "%') OR upper(f_c_razon_social) LIKE upper('%" + busco + "%')) AND (upper(f_tipo) = upper('Presupuesto'))";
                    if (buscarEn == "Guardado") sql = "SELECT * FROM facturas WHERE (upper(f_numero) LIKE upper('%" + busco + "%') OR upper(f_fecha) LIKE upper('%" + busco + "%') OR upper(f_c_razon_social) LIKE upper('%" + busco + "%')) AND (upper(f_tipo) = upper('Guardado'))";

                    SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);
                    da.Fill(sgdbDataSet, "facturas");
                    int rowsCount = sgdbDataSet.Tables["facturas"].Rows.Count;
                    
                    if (rowsCount > 0)
                    {
                        this.dataGridView.AutoGenerateColumns = false;  // Sin esta linea me llena el datagrid con todo lo que tiene la tabla o las tablas

                        this.dataGridView.Columns[1].DataPropertyName = "f_tipo";
                        this.dataGridView.Columns[2].DataPropertyName = "f_punto_venta";
                        this.dataGridView.Columns[3].DataPropertyName = "f_numero"; //son los campos de la base de datos
                        this.dataGridView.Columns[4].DataPropertyName = "f_fecha";
                        this.dataGridView.Columns[5].DataPropertyName = "fi_total";
                        this.dataGridView.Columns[6].DataPropertyName = "f_c_codigo";
                        this.dataGridView.Columns[7].DataPropertyName = "f_c_razon_social";
                        this.dataGridView.Columns[8].DataPropertyName = "f_c_descuento";
                        /*
                        if (buscarEn == "Facturado A,B,C,T")
                        {
                            DataGridViewCheckBoxColumn facturar = new DataGridViewCheckBoxColumn();
                            {
                                facturar.HeaderText = "Facturar";
                                facturar.Name = "facturar";
                                facturar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                                facturar.ReadOnly = true;
                                facturar.Width = 52;
                                facturar.CellTemplate = cbFacturar;
                            }
                            
                            this.dataGridView.Columns.Insert(9, facturar);
                        }
                        else
                        {
                            this.dataGridView.Columns.RemoveAt(9);
                        }
                        this.dataGridView.Columns[9].DataPropertyName = "f_status";
                        
                        //dataGridView.Columns[9].CellTemplate = new DataGridViewCheckBoxCell();
                        //dataGridView.Columns[9].CellTemplate.ReadOnly = false;
                        

                        if (buscarEn == "Facturado A,B,C,T" || buscarEn == "Nota de Credito" || buscarEn == "Movimiento Stock")
                        {
                            this.dataGridView.Columns[9].Visible = false;
                        }
                        else
                        {
                            this.dataGridView.Columns[9].Visible = true;
                            this.dataGridView.Columns[9].DataPropertyName = "f_status";
                        }
                        */
                        BindingSource bS = new BindingSource(sgdbDataSet.Tables["facturas"], null);
                        dataGridView.DataSource = bS;
                        bindingNavigator1.BindingSource = bS;
                    }
                }
                else
                {
                    this.dataGridView.DataSource = null;                  
                    //MessageBox.Show("Debe seleccionar un método de busqueda desde la lista desplegable.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                if (dataGridView.Rows.Count > 0)
                {
                    this.toolStripButton_Eliminar.Enabled = true;
                }
                else this.toolStripButton_Eliminar.Enabled = false;
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA3-001");
            }
        }

        private void buscar(object sender, EventArgs e)
        {
            listoFacturas();
        }

        private void onLoad(object sender, EventArgs e)
        {
            this.toolStripTextBox_Buscar.Focus();
        }

        private void acciones(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                //Si le dio click a la celda del signo mas "detalle"
                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex == 0)
                {
                    //Envio el numero de factura al form para que busque el detalle. dataGridView.Rows[e.RowIndex].Cells[0]
                    //Form_FacturadorBuscarDetalle Detalle = new Form_FacturadorBuscarDetalle();
                    Form_Facturador.numeroDeFactura = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString() + "-" + dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() + "-" + dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    //Detalle.Owner = this;
                    //Detalle.Show();
                    Form_FacturadorBuscarDetalle.DefInstance.BringToFront();
                    Form_FacturadorBuscarDetalle.DefInstance.Owner = this;
                    Form_FacturadorBuscarDetalle.DefInstance.Show();
                }
                /*
                //Si le dio click a la celda del checkbox facturar
                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex == 9)
                {
                    //activo el checkbox DataGridViewCheckBoxColumn
                    //if(Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[9].Value) == false)
                    //{
                        MessageBox.Show("hola");
                        dataGridView.Rows[e.RowIndex].Cells[9].Value = true;
                        //Busco numero de factura
                        string numeroDeFactura = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString() + "-" + dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() + "-" + dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                        // Me conecto
                        SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                        DataSet DS = new DataSet();
                        string sql = "";
                        string[] f = numeroDeFactura.Split('-');
                        if (f[0] == "A" || f[0] == "B" || f[0] == "C" || f[0] == "Ticket" || f[0] == "Remito" || f[0] == "NC") sql = "SELECT * FROM facturas_detalles WHERE fd_tipo = '" + f[0] + "' AND fd_punto_venta = '" + f[1] + "' AND fd_factura = '" + f[2] + "'";
                        if (f[0] == "Guardado" || f[0] == "MovStock" || f[0] == "CC") sql = "SELECT * FROM facturas_detalles WHERE fd_tipo = '" + f[0] + "'";
                        SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);
                        da.Fill(DS, "facturas_detalles");
                        int rowsCount = DS.Tables["facturas_detalles"].Rows.Count;
                        if (rowsCount > 0)
                        {
                            Form_Facturador.DefInstance.agregaProductoAlDetalle("Eco de los Andes 250ml"); //son los campos de la base de datos
                        }                        
                    //}
                    //else
                    //{
                        //bool estado = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[9].Value);
                        //dataGridView.Rows[e.RowIndex].Cells[9].Value = !estado;
                    //}
                     
                }
                */
                //Si le dio click a la celda del signo mas "detalle"
                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex == 9)
                {
                    bool estado = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !estado;
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA3-002");
            }

        }

        private void toolStripButton_Eliminar_Click(object sender, EventArgs e)
        {
            borrarSelectedItems();
        }

        private void borrarSelectedItems()
        {
            try
            {
                int rows = dataGridView.Rows.Count;
                if (rows > 0)
                {
                    DialogResult confirm = MessageBox.Show("¿Realmente desea borrar todos los elementos seleccionados?", "ATENCION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.OK)
                    {
                        for (int i = rows-1; i >= 0; i--)
                        {
                            if (Convert.ToBoolean(dataGridView.Rows[i].Cells[9].Value) == true)
                            {
                                string fTipo = dataGridView.Rows[i].Cells[1].Value.ToString();
                                string fPuntoDeVenta = dataGridView.Rows[i].Cells[2].Value.ToString();
                                string facturaNumero = dataGridView.Rows[i].Cells[3].Value.ToString();

                                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                                string sql = "DELETE FROM facturas_detalles WHERE fd_tipo = '" + fTipo + "' AND fd_punto_venta = '" + fPuntoDeVenta + "' AND fd_factura = '" + facturaNumero + "'";
                                SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                                cmd.Connection.Open();
                                cmd.ExecuteNonQuery();
                                sql = "DELETE FROM facturas WHERE f_tipo = '" + fTipo + "' AND f_punto_venta = '" + fPuntoDeVenta + "' AND f_numero = '" + facturaNumero + "'";
                                cmd = new SqlCeCommand(sql, conexion);
                                cmd.ExecuteNonQuery();
                                cmd.Connection.Close();
                                dataGridView.Rows.RemoveAt(i);

                                if (dataGridView.Rows.Count > 0)
                                {
                                    this.toolStripButton_Eliminar.Enabled = true;
                                }
                                else this.toolStripButton_Eliminar.Enabled = false;
                            }
                        }
                    }
                }
                else this.toolStripButton_Eliminar.Enabled = false;
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA3-003");
            }
        }
    }
}
