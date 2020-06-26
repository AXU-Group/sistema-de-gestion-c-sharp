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
    public partial class Form_FacturadorBuscarDetalle : Form
    {
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_FacturadorBuscarDetalle m_FormDefInstance;
        public static Form_FacturadorBuscarDetalle DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_FacturadorBuscarDetalle();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public Form_FacturadorBuscarDetalle()
        {
            InitializeComponent();
        }

        private void Form_FacturadorBuscarDetalle_Load(object sender, EventArgs e)
        {
            // Me conecto
            SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
            DataSet DS = new DataSet();
            string sql = "";
            string[] f = Form_Facturador.numeroDeFactura.Split('-');
            if (f[0] == "A" || f[0] == "B" || f[0] == "C" || f[0] == "Ticket" || f[0] == "Remito" || f[0] == "NC") sql = "SELECT * FROM facturas_detalles WHERE fd_tipo = '" + f[0] + "' AND fd_punto_venta = '" + f[1] + "' AND fd_factura = '" + f[2] + "'";
            if (f[0] == "Guardado" || f[0] == "MovStock" || f[0] == "CC" || f[0] == "NP" || f[0] == "Presupuesto") sql = "SELECT * FROM facturas_detalles WHERE fd_tipo = '" + f[0] + "'";
            SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);
            da.Fill(DS, "facturas_detalles");
            int rowsCount = DS.Tables["facturas_detalles"].Rows.Count;
            if (rowsCount > 0)
            {
                this.dataGridView.AutoGenerateColumns = false;  // Sin esta linea me llena el datagrid con todo lo que tiene la tabla o las tablas
                this.dataGridView.Columns.Clear(); //Borro todas las columnas de dataGridView1

                this.dataGridView.Columns.Add("facturanumero", "Factura");
                this.dataGridView.Columns.Add("cantidad", "Cantidad");
                this.dataGridView.Columns.Add("detalle", "Detalle"); //(nombre de la columna,Titulo de la columna)
                this.dataGridView.Columns.Add("preciounitario", "Precio Unitario");
                this.dataGridView.Columns.Add("alicuota", "Ali.C");
                this.dataGridView.Columns.Add("baseiva", "Base IVA");
                this.dataGridView.Columns.Add("importe", "Importe");
                this.dataGridView.Columns.Add("idproducto", "ID producto");

                //dataGridView1.Columns[0].Width = 110; // ancho de la columna
                //dataGridView1.Columns[1].Width = 300;
                this.dataGridView.Columns[0].DataPropertyName = "fd_factura";
                this.dataGridView.Columns[1].DataPropertyName = "fd_cantidad";
                this.dataGridView.Columns[2].DataPropertyName = "fd_detalle"; //son los campos de la base de datos
                this.dataGridView.Columns[3].DataPropertyName = "fd_precio_unitario";
                this.dataGridView.Columns[4].DataPropertyName = "fd_alicuota";
                this.dataGridView.Columns[5].DataPropertyName = "fd_base_iva";
                this.dataGridView.Columns[6].DataPropertyName = "fd_iva";
                this.dataGridView.Columns[7].DataPropertyName = "fd_idproducto";

                BindingSource BS = new BindingSource(DS.Tables["facturas_detalles"], null);
                dataGridView.DataSource = BS;
            }
        }
    }
}
