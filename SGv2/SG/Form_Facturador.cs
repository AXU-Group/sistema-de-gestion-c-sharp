using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Runtime.InteropServices;
using FacturaControl;
using manten;


namespace SG
{
    public partial class Form_Facturador : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_Facturador m_FormDefInstance;
        public static Form_Facturador DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_Facturador();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public static string numeroDeFactura;
        public int IVASI = 1;
        public Form_Facturador()
        {
            InitializeComponent();
        }

        Form_FacturadorImagen FactImagen = new Form_FacturadorImagen(); 

        private void Form_Facturador_Load(object sender, EventArgs e)
        {
            Limpio_Facturador();
        }

        public void Limpio_Facturador()
        {
            try
            {
                //Datos Empresa
                this.label_F_Nombre.Text = ConfigurationManager.AppSettings["textBox_DE_Nombre"];
                this.label_F_DomicilioCompleto.Text = ConfigurationManager.AppSettings["textBox_DE_Domicilio"] + " (" + ConfigurationManager.AppSettings["textBox_DE_CodPost"] + ")";
                this.label_F_LPP.Text = ConfigurationManager.AppSettings["textBox_DE_Localidad"];
                this.label_F_TF.Text = "Tel: " + ConfigurationManager.AppSettings["textBox_DE_Tel"] + " / Fax:" + ConfigurationManager.AppSettings["textBox_DE_Fax"];
                this.label_F_Cuit.Text = ConfigurationManager.AppSettings["textBox_DE_Cuit"];
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_RI"].ToString())) this.label_F_IVA.Text = "Responsable Inscripto";
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_RNI"].ToString())) this.label_F_IVA.Text = "Responsable No Inscripto";
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_Mono"].ToString())) this.label_F_IVA.Text = "Monotributista";
                //Limpio y lleno de nuevo el combobox
                this.comboBox_F_PuntoVenta.Items.Clear();
                int PV = Int32.Parse(ConfigurationManager.AppSettings["textBox_DE_PuestosVenta"].ToString());
                for (int k = 1; k <= PV; k++)
                {
                    if (k == Int32.Parse(ConfigurationManager.AppSettings["maskedTextBox_DE_puestoNumero"].ToString()))
                    {
                        this.comboBox_F_PuntoVenta.Items.Add(k);
                        this.comboBox_F_PuntoVenta.SelectedItem = k;
                    }
                    else this.comboBox_F_PuntoVenta.Items.Add(k);
                }
                //Numeracion y Tipo
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factA"])) { this.comboBox_F_TipoFactura.SelectedItem = "A"; this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialA"]; }
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factB"])) { this.comboBox_F_TipoFactura.SelectedItem = "B"; this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialB"]; }
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factC"])) { this.comboBox_F_TipoFactura.SelectedItem = "C"; this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialC"]; }
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factT"])) { this.comboBox_F_TipoFactura.SelectedItem = "Ticket"; this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialT"]; }
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factR"])) { this.comboBox_F_TipoFactura.SelectedItem = "Remito"; this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialR"]; }
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factNC"])) { this.comboBox_F_TipoFactura.SelectedItem = "NC"; this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialNC"]; }
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factNP"])) { this.comboBox_F_TipoFactura.SelectedItem = "NP"; this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialNP"]; }
                if (true == bool.Parse(ConfigurationManager.AppSettings["radioButton_DE_factP"])) { this.comboBox_F_TipoFactura.SelectedItem = "Presupuesto"; this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialP"]; }
                //--
                this.dateTimePicker_F_Fecha.Text = "";
                this.label_F_Vendedor.Text = SG.MDIParentPadre.MiVariable.ToString();
                this.textBox_F_ClienteCodigo.Text = "0";
                this.textBox_F_RazonSocial.Text = "";
                this.textBox_F_ClienteCuit.Text = "";
                this.textBox_F_ClienteDomicilio.Text = "";
                this.textBox_F_Localidad.Text = "";
                this.comboBox_F_CondVenta.Text = "";
                this.textBox_F_Descuento.Text = "";
                this.radioButton_F_Fact1.Checked = true;
                this.radioButton_F_IvaCF.Checked = true;
                this.label_F_Items.Text = "0";
                this.checkBox_F_Emitir.Checked = true;
                this.label_F_ValorDolar.Text = ConfigurationManager.AppSettings["textBox_Cot_Dolar"];
                this.label_F_ValorEuro.Text = ConfigurationManager.AppSettings["textBox_Cot_Euro"];
                this.label_F_Subtotal1.Text = "0.00";
                this.label_F_Impuestos.Text = "0.00";
                this.label_F_TDesc.Text = "0.00";
                this.label_F_Subtotal2.Text = "0.00";
                this.label_F_TIva.Text = "0.00";
                this.label_F_TOTAL.Text = "0.00";

                // Limpio lista del detalle
                dataGridView1.Rows.Clear();

                Busco_Cliente();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-001");
            }
        }
        private void Abro_PopUp_Vendedores(object sender, EventArgs e)
        {
            try
            {
                //PopUp_F_Vendedor Vendedores = new PopUp_F_Vendedor();
                //Vendedores.Owner = this;
                //Vendedores.Show();
                PopUp_F_Vendedor.DefInstance.BringToFront();
                PopUp_F_Vendedor.DefInstance.Owner = this;
                PopUp_F_Vendedor.DefInstance.Show();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-002");
            }
        }

        private void pictureBox_BuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                //Form_Clientes Clientes = new Form_Clientes();
                //Clientes.Owner = this;
                //Clientes.Show();
                Form_Clientes.DefInstance.BringToFront();
                Form_Clientes.DefInstance.Owner = this;
                Form_Clientes.DefInstance.Show();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-003");
            }
        }

        private void textBox_F_ClienteCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyData == Keys.Enter) || (e.KeyData == Keys.Tab)) && (this.textBox_F_ClienteCodigo.Text != ""))
            {
                Busco_Cliente();
            }
        }
        
        private void Obtengo_Cliente(object sender, EventArgs e)
        {
            Busco_Cliente();
        }

        public void Busco_Cliente()
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet ds = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT [razon_social],[domicilio_calle],[domicilio_numero],[domicilio_piso],[domicilio_localidad],[domicilio_cod_post],[domicilio_provincia],[cuit],[lista_facturacion],[descuento],[condicion_venta],[iva] FROM cliente_proveedor WHERE numero_id = '" + this.textBox_F_ClienteCodigo.Text + "'";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);
                da.Fill(ds, "cliente_proveedor");
                if (ds.Tables["cliente_proveedor"].Rows.Count != 0)
                {
                    DataRow dRow = ds.Tables["cliente_proveedor"].Rows[0];

                    //Muestra el contenido de la primera columna
                    this.textBox_F_RazonSocial.Text = dRow.ItemArray.GetValue(0).ToString();
                    this.textBox_F_ClienteDomicilio.Text = dRow.ItemArray.GetValue(1).ToString() + " " + dRow.ItemArray.GetValue(2).ToString() + " " + dRow.ItemArray.GetValue(3).ToString() + " (" + dRow.ItemArray.GetValue(5).ToString() + ")";
                    this.textBox_F_Localidad.Text = dRow.ItemArray.GetValue(4).ToString() + " - " + dRow.ItemArray.GetValue(6).ToString();
                    this.textBox_F_ClienteCuit.Text = dRow.ItemArray.GetValue(7).ToString();
                    this.comboBox_F_CondVenta.Text = dRow.ItemArray.GetValue(10).ToString();
                    this.textBox_F_Descuento.Text = dRow.ItemArray.GetValue(9).ToString();
                    this.label_F_TDesc.Text = dRow.ItemArray.GetValue(9).ToString();

                    if (dRow.ItemArray.GetValue(8).ToString() == "1") this.radioButton_F_Fact1.Checked = true;
                    if (dRow.ItemArray.GetValue(8).ToString() == "2") this.radioButton_F_Fact2.Checked = true;
                    if (dRow.ItemArray.GetValue(8).ToString() == "3") this.radioButton_F_Fact3.Checked = true;

                    if (dRow.ItemArray.GetValue(11).ToString() == "1") this.radioButton_F_IvaRNI.Checked = true;
                    if (dRow.ItemArray.GetValue(11).ToString() == "2") this.radioButton_F_IvaRI.Checked = true;
                    if (dRow.ItemArray.GetValue(11).ToString() == "3") this.radioButton_F_IvaCF.Checked = true;
                    if (dRow.ItemArray.GetValue(11).ToString() == "4") this.radioButton_F_IvaEXE.Checked = true;
                    if (dRow.ItemArray.GetValue(11).ToString() == "5") this.radioButton_F_IvaNR.Checked = true;
                    if (dRow.ItemArray.GetValue(11).ToString() == "6") this.radioButton_F_IvaMT.Checked = true;
                    if (dRow.ItemArray.GetValue(11).ToString() == "7") this.radioButton_F_IvaSC.Checked = true;

                    this.textBox_F_CodigoProducto.Focus();

                    conexion.Close();
                    conexion.Dispose();
                }
                else
                {
                    if (this.textBox_F_ClienteCodigo.Text == "0")
                    {
                        this.textBox_F_ClienteCodigo.Text = "0";
                        this.textBox_F_RazonSocial.Text = "Consumidor Final";
                        this.comboBox_F_CondVenta.Text = "Contado";
                        this.radioButton_F_IvaCF.Checked = true;
                        this.textBox_F_ClienteCuit.Text = "";
                        this.textBox_F_Localidad.Text = "";
                        this.textBox_F_ClienteDomicilio.Text = "";
                        this.textBox_F_Descuento.Text = "";
                    }
                    else MessageBox.Show("Error: No existe el numero de cliente.\n\nPruebe usando el boton de Buscar para\nencontrar el numero de cliente correcto o bien ingrese\nCERO para utilizar el modo de cliente en blanco.", "Error: F-FA1-004", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Calculo_Importes();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-005");
            }
        }

        private void button_F_agregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                //Form_Clientes Clientes = new Form_Clientes();
                //Clientes.Owner = this;
                //Clientes.Show();
                Form_Clientes.DefInstance.BringToFront();
                Form_Clientes.DefInstance.Owner = this;
                Form_Clientes.DefInstance.Show();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-006");
            }
        }

        private void verifica_CodigoCliente(object sender, KeyEventArgs e)
        {
            if ((e.KeyData != Keys.D0) && (e.KeyData != Keys.D1) && (e.KeyData != Keys.D2) && (e.KeyData != Keys.D3) && (e.KeyData != Keys.D4) && (e.KeyData != Keys.D5) && (e.KeyData != Keys.D6) && (e.KeyData != Keys.D7) && (e.KeyData != Keys.D8) && (e.KeyData != Keys.D9) && (e.KeyData != Keys.Back) && (e.KeyData != Keys.Delete) && (e.KeyData != Keys.NumPad0) && (e.KeyData != Keys.NumPad1) && (e.KeyData != Keys.NumPad2) && (e.KeyData != Keys.NumPad3) && (e.KeyData != Keys.NumPad4) && (e.KeyData != Keys.NumPad5) && (e.KeyData != Keys.NumPad6) && (e.KeyData != Keys.NumPad7) && (e.KeyData != Keys.NumPad8) && (e.KeyData != Keys.NumPad9) && (e.KeyData != Keys.Enter) && (e.KeyData != Keys.Up) && (e.KeyData != Keys.Left) && (e.KeyData != Keys.Right) && (e.KeyData != Keys.Down))
            {
                int cantLetras = ((TextBox)sender).Text.Length;
                ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, cantLetras - 1);
                MessageBox.Show("Error: Se aceptan solo numero en este casillero.", "Error: F-FA1-007", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Agrega_ProductoAldetalle(object sender, KeyEventArgs e)
        {
            string BuscarItem = "";
            if (e.KeyData == Keys.Enter && this.textBox_F_CodigoProducto.Text != "")
            {
                BuscarItem = this.textBox_F_CodigoProducto.Text;
            }
            if (e.KeyData == Keys.Enter && this.textBox_F_NombreProducto.Text != "")
            {
                BuscarItem = this.textBox_F_NombreProducto.Text;
            }
            agregaProductoAlDetalle(BuscarItem);
        }

        public void agregaProductoAlDetalle(string BuscarItem)
        {
            if (BuscarItem != "")
            {
                try
                {
                    string codigo;
                    // Me conecto
                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    DataSet sgdbDataSet = new DataSet();
                    SqlCeCommand cmd = new SqlCeCommand();
                    string sql = "SELECT * FROM articulos WHERE upper(codigo_barra) = upper('" + BuscarItem + "') OR upper(codigo_interno) = upper('" + BuscarItem + "') OR upper(descripcion) = upper('" + BuscarItem + "')";
                    SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                    da.Fill(sgdbDataSet, "articulos");
                    int dRowCount = sgdbDataSet.Tables["articulos"].Rows.Count;
                    
                    if (dRowCount == 1)
                    {
                        DataRow dRow = sgdbDataSet.Tables["articulos"].Rows[0];
                        // Uso valor segun numero de lista
                        decimal precio = 0m;
                        if (radioButton_F_Fact1.Checked == true) precio = Math.Round(Convert.ToDecimal(dRow.ItemArray.GetValue(7).ToString()), 2, MidpointRounding.AwayFromZero);
                        if (radioButton_F_Fact2.Checked == true) precio = Math.Round(Convert.ToDecimal(dRow.ItemArray.GetValue(8).ToString()), 2, MidpointRounding.AwayFromZero);
                        if (radioButton_F_Fact3.Checked == true) precio = Math.Round(Convert.ToDecimal(dRow.ItemArray.GetValue(9).ToString()), 2, MidpointRounding.AwayFromZero);

                        // Valor segun dolar
                        decimal importe = 0m;
                        decimal Dolar = 0m;
                        if (dRow.ItemArray.GetValue(15).ToString() == "0")
                        {
                            Dolar = 1.00m;
                            precio = Math.Round(precio * Dolar, 2);
                        }
                        if (dRow.ItemArray.GetValue(15).ToString() == "1")
                        {
                            Dolar = Convert.ToDecimal(ConfigurationManager.AppSettings["textBox_Cot_Dolar"]);
                            precio = Math.Round(precio * Dolar, 2);
                        }
                        if (dRow.ItemArray.GetValue(15).ToString() == "2")
                        {
                            Dolar = Convert.ToDecimal(ConfigurationManager.AppSettings["textBox_Cot_Euro"]);
                            precio = Math.Round(precio * Dolar, 2);
                        }
                        decimal ivaIndividual = Math.Round((precio * Convert.ToDecimal(textBox_F_Cantidad.Text) * Convert.ToDecimal(dRow.ItemArray.GetValue(13).ToString())) / 100, 2); //este ultimo 2 es del redondeo de dos decimales
                        importe = Math.Round(precio * Convert.ToDecimal(textBox_F_Cantidad.Text) + ivaIndividual, 2);

                        conexion.Close();
                        if (this.checkBox_F_Emitir.Checked == true)
                        {
                            // Uso el codigo de barras o el codigo interno
                            if (dRow.ItemArray.GetValue(1).ToString() != "") codigo = dRow.ItemArray.GetValue(1).ToString();
                            else codigo = dRow.ItemArray.GetValue(2).ToString();

                            string validStock = verifico_stock(codigo, this.textBox_F_Cantidad.Text.ToString());
                            if (validStock == "1")
                            {
                                // Si el producto ya existe en la lista sumo la cantidad nomas
                                int cantidadRows = dataGridView1.Rows.Count;
                                int cantidadArticulosNuevos = Convert.ToInt32(this.textBox_F_Cantidad.Text);
                                int cantidadArticulosExistentes = 0;
                                int cantidadArticulosTotales = 0;
                                int flagExiste = 0;

                                for (int i = 0; i < cantidadRows; i++)
                                {
                                    // Si existe en la grilla actualizo la cantidad si no lo agrego
                                    if (dRow.ItemArray.GetValue(3).ToString() == dataGridView1.Rows[i].Cells[1].Value.ToString())
                                    {
                                        cantidadArticulosExistentes = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                                        cantidadArticulosTotales = cantidadArticulosExistentes + cantidadArticulosNuevos;
                                        dataGridView1.Rows[i].Cells[0].Value = cantidadArticulosTotales;
                                        flagExiste = 1;
                                    }
                                }
                                // Si despues de revisar toda la datagrid no encontro el producto no puso a flagExiste en 1 (no existe el articulo en la lista)
                                if (cantidadRows != 0 && flagExiste == 0)
                                { 
                                    cantidadArticulosTotales = cantidadArticulosNuevos;
                                    dataGridView1.Rows.Add(cantidadArticulosTotales, dRow.ItemArray.GetValue(3).ToString(), precio, dRow.ItemArray.GetValue(13).ToString(), "", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
                                }
                                // Si no hay productos en la lista agrego el primero
                                if (cantidadRows == 0)
                                {
                                    dataGridView1.Rows.Add(this.textBox_F_Cantidad.Text, dRow.ItemArray.GetValue(3).ToString(), precio, dRow.ItemArray.GetValue(13).ToString(), "", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
                                    Calculo_Importes();
                                }
                                else
                                {
                                    RecalculoImportes();
                                }

                                this.label_F_Items.Text = dataGridView1.Rows.Count.ToString();
                                this.textBox_F_CodigoProducto.Text = "";
                                this.textBox_F_NombreProducto.Text = "";
                                this.textBox_F_Cantidad.Text = "1";
                                this.textBox_F_CodigoProducto.Focus();

                                FactImagen.cambio_pictureBox(dRow.ItemArray.GetValue(14).ToString());
                            }
                            else MessageBox.Show(validStock, "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Si el producto ya existe en la lista sumo la cantidad nomas
                            int cantidadRows = dataGridView1.Rows.Count;
                            int cantidadArticulosNuevos = Convert.ToInt32(this.textBox_F_Cantidad.Text);
                            int cantidadArticulosExistentes = 0;
                            int cantidadArticulosTotales = 0;
                            int flagExiste = 0;

                            for (int i = 0; i < cantidadRows; i++)
                            {
                                // Si existe en la grilla actualizo la cantidad si no lo agrego
                                if (dRow.ItemArray.GetValue(3).ToString() == dataGridView1.Rows[i].Cells[1].Value.ToString())
                                {
                                    cantidadArticulosExistentes = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                                    cantidadArticulosTotales = cantidadArticulosExistentes + cantidadArticulosNuevos;
                                    dataGridView1.Rows[i].Cells[0].Value = cantidadArticulosTotales;
                                    flagExiste = 1;
                                }
                            }
                            // Si despues de revisar toda la datagrid no encontro el producto no puso a flagExiste en 1 (no existe el articulo en la lista)
                            if (cantidadRows != 0 && flagExiste == 0)
                            {
                                cantidadArticulosTotales = cantidadArticulosNuevos;
                                dataGridView1.Rows.Add(cantidadArticulosTotales, dRow.ItemArray.GetValue(3).ToString(), precio, dRow.ItemArray.GetValue(13).ToString(), "", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
                            }
                            // Si no hay productos en la lista agrego el primero
                            if (cantidadRows == 0)
                            {
                                dataGridView1.Rows.Add(this.textBox_F_Cantidad.Text, dRow.ItemArray.GetValue(3).ToString(), precio, dRow.ItemArray.GetValue(13).ToString(), "", Math.Round(importe, 2, MidpointRounding.AwayFromZero));
                                Calculo_Importes();
                            }
                            else
                            {
                                RecalculoImportes();
                            }

                            this.label_F_Items.Text = dataGridView1.Rows.Count.ToString();
                            this.textBox_F_CodigoProducto.Text = "";
                            this.textBox_F_NombreProducto.Text = "";
                            this.textBox_F_Cantidad.Text = "1";
                            this.textBox_F_CodigoProducto.Focus();

                            FactImagen.cambio_pictureBox(dRow.ItemArray.GetValue(14).ToString());
                        }
                    }
                    else MessageBox.Show("El producto no existe","ATTENCION",MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    em.sendmail(ex, "Error: F-FA1-008");
                }
            }
        }

        private void Abro_FormStock(object sender, EventArgs e)
        {
            try
            {
                //Form_Articulos Articulos = new Form_Articulos();
                //Articulos.Owner = this;
                //Articulos.Show();
                Form_Articulos.DefInstance.BringToFront();
                Form_Articulos.DefInstance.Owner = this;
                Form_Articulos.DefInstance.Show();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-009");
            }
        }

        public void Calculo_Importes()
        {
            try
            {
                int cantidadRows = 0;
                decimal importeParcial = 0;
                decimal Subtotal1 = 0;
                decimal Descuento = 0;
                decimal Subtotal2 = 0;
                decimal Impuestos = 0;
                decimal totalIva = 0;
                decimal ivaParcial = 0;

                //Genero el Subtotal 1
                cantidadRows = dataGridView1.Rows.Count;
                if (cantidadRows > 0)
                {
                    for (int i = 0; i < cantidadRows; i++)
                    {
                        importeParcial = Math.Round(Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value.ToString()), 2);
                        Subtotal1 = Math.Round(Subtotal1 + importeParcial, 2);
                    }
                    this.label_F_Subtotal1.Text = Subtotal1.ToString();

                    //Calculo Descuento si lo hay
                    if (textBox_F_Descuento.Text != "")
                    {
                        Descuento = Math.Round((Subtotal1 * Convert.ToDecimal(this.textBox_F_Descuento.Text)) / 100, 2);
                        this.label_F_TDesc.Text = Descuento.ToString();
                    }
                    else this.label_F_TDesc.Text = "0.00";

                    //Calculo Subtotal2
                    Subtotal2 = Math.Round(Subtotal1 + Impuestos - Descuento, 2);
                    this.label_F_Subtotal2.Text = Subtotal2.ToString();

                    if (IVASI == 1)//si el checkbox esta activo o no
                    {
                        for (int i = 0; i < cantidadRows; i++)
                        {
                            ivaParcial = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value.ToString()) - (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString()) * Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            totalIva = Math.Round(totalIva + ivaParcial, 2);
                        }
                        //totalIva = Math.Round(Math.Truncate((totalIva * 1) / 100), 2);
                        this.label_F_TIva.Text = totalIva.ToString();
                        this.label_F_TOTAL.Text = Math.Round(Subtotal2, 2).ToString();
                    }
                    else
                    {
                        for (int i = 0; i < cantidadRows; i++)
                        {
                            ivaParcial = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value.ToString()) - (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString()) * Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                            totalIva = Math.Round(totalIva + ivaParcial, 2);
                        }
                        this.label_F_TIva.Text = totalIva.ToString();
                        this.label_F_TOTAL.Text = Math.Round(Subtotal2 - totalIva, 2).ToString();
                    }

                }

            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-010");
            }
        }

        private void button_F_EliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                this.textBox_F_CodigoProducto.Focus();
                this.label_F_Items.Text = dataGridView1.Rows.Count.ToString();
                Calculo_Importes();
                if (dataGridView1.Rows.Count == 0)
                {
                    this.label_F_ValorDolar.Text = ConfigurationManager.AppSettings["textBox_Cot_Dolar"];
                    this.label_F_Subtotal1.Text = "0.00";
                    this.label_F_Impuestos.Text = "0.00";
                    this.label_F_TDesc.Text = "0.00";
                    this.label_F_Subtotal2.Text = "0.00";
                    this.label_F_TIva.Text = "0.00";
                    this.label_F_TOTAL.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-011");
            }
        }

        private void abro_VentanaImagen(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBox_F_VerImagen.Checked == true)
                {
                    //FactImagen = new Form_FacturadorImagen();
                    //FactImagen.FormClosed += new FormClosedEventHandler(ChildFormClosed);
                    //FactImagen.Show();
                    Form_FacturadorImagen.DefInstance.BringToFront();
                    Form_FacturadorImagen.DefInstance.Owner = this;
                    Form_FacturadorImagen.DefInstance.Show();
                }
                else
                {
                    Form_FacturadorImagen.DefInstance.Close();
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-012");
            }
        }
        
        void ChildFormClosed(object sender, FormClosedEventArgs e)
        {
            this.checkBox_F_VerImagen.Checked = false;
        }

        public void imprimoFactura()
        {
            try
            {
                Factura factura = new Factura();
                string[] DateArray = DateTime.Now.ToShortDateString().Split('/');
                
                //Datos de Factura
                // Aca habria que cambiar la imagen de factura segun el comprobante seleccionado
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "A")
                {
                    if (ConfigurationManager.AppSettings["textBox_DE_facturaImagenA"] != "") factura.AddImages(ConfigurationManager.AppSettings["textBox_DE_facturaImagenA"], 0, 0);
                    factura.AddDatos(DateArray[0], ConfigurationManager.AppSettings["textBox_ImpDiaX"], ConfigurationManager.AppSettings["textBox_ImpDiaY"]);
                    factura.AddDatos(DateArray[1], ConfigurationManager.AppSettings["textBox_ImpMesX"], ConfigurationManager.AppSettings["textBox_ImpMesY"]);
                    factura.AddDatos(DateArray[2], ConfigurationManager.AppSettings["textBox_ImpAnoX"], ConfigurationManager.AppSettings["textBox_ImpAnoY"]);
                    factura.AddDatos(DateTime.Now.ToShortTimeString(), ConfigurationManager.AppSettings["textBox_ImpHorX"], ConfigurationManager.AppSettings["textBox_ImpHorY"]);
                    factura.AddDatos(this.textBox_F_RazonSocial.Text, ConfigurationManager.AppSettings["textBox_ImpSenX"], ConfigurationManager.AppSettings["textBox_ImpSenY"]);
                    factura.AddDatos(this.textBox_F_ClienteDomicilio.Text, ConfigurationManager.AppSettings["textBox_ImpDomX"], ConfigurationManager.AppSettings["textBox_ImpDomY"]);
                    factura.AddDatos(this.textBox_F_Localidad.Text, ConfigurationManager.AppSettings["textBox_ImpLocX"], ConfigurationManager.AppSettings["textBox_ImpLocY"]);
                    if (this.radioButton_F_IvaRI.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRiX"], ConfigurationManager.AppSettings["textBox_ImpRiY"]);
                    if (this.radioButton_F_IvaCF.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpCfX"], ConfigurationManager.AppSettings["textBox_ImpCfY"]);
                    if (this.radioButton_F_IvaRNI.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpNorX"], ConfigurationManager.AppSettings["textBox_ImpNorY"]);
                    if (this.radioButton_F_IvaEXE.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpExeX"], ConfigurationManager.AppSettings["textBox_ImpExeY"]);
                    factura.AddDatos(this.textBox_F_ClienteCuit.Text, ConfigurationManager.AppSettings["textBox_ImpCuiX"], ConfigurationManager.AppSettings["textBox_ImpCuiY"]);
                    factura.AddDatos("", ConfigurationManager.AppSettings["textBox_ImpRemX"], ConfigurationManager.AppSettings["textBox_ImpRemY"]);
                    if (this.comboBox_F_CondVenta.Text == "Contado") factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpConX"], ConfigurationManager.AppSettings["textBox_ImpConY"]);
                    if (this.comboBox_F_CondVenta.Text == "Cuenta Corriente") factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpCcoX"], ConfigurationManager.AppSettings["textBox_ImpCcoY"]);

                    //Items
                    int cantidadItems = 0;
                    cantidadItems = dataGridView1.Rows.Count;
                    for (int i = 0; i < cantidadItems; i++)
                    {
                        //factura.AddItems(dataGridView1.Rows[i].Cells[0].Value.ToString() + "," + dataGridView1.Rows[i].Cells[1].Value.ToString() + "," + dataGridView1.Rows[i].Cells[2].Value.ToString() + "," + dataGridView1.Rows[i].Cells[3].Value.ToString() + "," + dataGridView1.Rows[i].Cells[4].Value.ToString() + "," + dataGridView1.Rows[i].Cells[5].Value.ToString());
                    }

                    //Totales
                    factura.AddDatos(this.label_F_Subtotal1.Text, ConfigurationManager.AppSettings["textBox_ImpSu1X"], ConfigurationManager.AppSettings["textBox_ImpSu1Y"]);
                    factura.AddDatos(this.label_F_TDesc.Text, ConfigurationManager.AppSettings["textBox_ImpDesX"], ConfigurationManager.AppSettings["textBox_ImpDesY"]);
                    factura.AddDatos(this.label_F_Impuestos.Text, ConfigurationManager.AppSettings["textBox_ImpIpsX"], ConfigurationManager.AppSettings["textBox_ImpIpsY"]);
                    factura.AddDatos(this.label_F_Subtotal2.Text, ConfigurationManager.AppSettings["textBox_ImpSu2X"], ConfigurationManager.AppSettings["textBox_ImpSu2Y"]);
                    factura.AddDatos(this.label_F_TIva.Text, ConfigurationManager.AppSettings["textBox_ImpIvaX"], ConfigurationManager.AppSettings["textBox_ImpIvaY"]);
                    factura.AddDatos(this.label_F_TOTAL.Text, ConfigurationManager.AppSettings["textBox_ImpTotX"], ConfigurationManager.AppSettings["textBox_ImpTotY"]);
                }
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "B")
                {
                    if (ConfigurationManager.AppSettings["textBox_DE_facturaImagenB"] != "") factura.AddImages(ConfigurationManager.AppSettings["textBox_DE_facturaImagenB"], 0, 0);
                    factura.AddDatos(DateArray[0], ConfigurationManager.AppSettings["textBox_ImpDiaX"], ConfigurationManager.AppSettings["textBox_ImpDiaY"]);
                    factura.AddDatos(DateArray[1], ConfigurationManager.AppSettings["textBox_ImpMesX"], ConfigurationManager.AppSettings["textBox_ImpMesY"]);
                    factura.AddDatos(DateArray[2], ConfigurationManager.AppSettings["textBox_ImpAnoX"], ConfigurationManager.AppSettings["textBox_ImpAnoY"]);
                    factura.AddDatos(DateTime.Now.ToShortTimeString(), ConfigurationManager.AppSettings["textBox_ImpHorX"], ConfigurationManager.AppSettings["textBox_ImpHorY"]);
                    factura.AddDatos(this.textBox_F_RazonSocial.Text, ConfigurationManager.AppSettings["textBox_ImpSenX"], ConfigurationManager.AppSettings["textBox_ImpSenY"]);
                    factura.AddDatos(this.textBox_F_ClienteDomicilio.Text, ConfigurationManager.AppSettings["textBox_ImpDomX"], ConfigurationManager.AppSettings["textBox_ImpDomY"]);
                    factura.AddDatos(this.textBox_F_Localidad.Text, ConfigurationManager.AppSettings["textBox_ImpLocX"], ConfigurationManager.AppSettings["textBox_ImpLocY"]);
                    if (this.radioButton_F_IvaRI.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRiX"], ConfigurationManager.AppSettings["textBox_ImpRiY"]);
                    if (this.radioButton_F_IvaCF.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpCfX"], ConfigurationManager.AppSettings["textBox_ImpCfY"]);
                    if (this.radioButton_F_IvaRNI.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpNorX"], ConfigurationManager.AppSettings["textBox_ImpNorY"]);
                    if (this.radioButton_F_IvaEXE.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpExeX"], ConfigurationManager.AppSettings["textBox_ImpExeY"]);
                    factura.AddDatos(this.textBox_F_ClienteCuit.Text, ConfigurationManager.AppSettings["textBox_ImpCuiX"], ConfigurationManager.AppSettings["textBox_ImpCuiY"]);
                    factura.AddDatos("", ConfigurationManager.AppSettings["textBox_ImpRemX"], ConfigurationManager.AppSettings["textBox_ImpRemY"]);
                    if (this.comboBox_F_CondVenta.Text == "Contado") factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpConX"], ConfigurationManager.AppSettings["textBox_ImpConY"]);
                    if (this.comboBox_F_CondVenta.Text == "Cuenta Corriente") factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpCcoX"], ConfigurationManager.AppSettings["textBox_ImpCcoY"]);

                    //Items
                    int cantidadItems = 0;
                    cantidadItems = dataGridView1.Rows.Count;
                    for (int i = 0; i < cantidadItems; i++)
                    {
                        //factura.AddItems(dataGridView1.Rows[i].Cells[0].Value.ToString() + "," + dataGridView1.Rows[i].Cells[1].Value.ToString() + "," + dataGridView1.Rows[i].Cells[2].Value.ToString() + "," + dataGridView1.Rows[i].Cells[3].Value.ToString() + "," + dataGridView1.Rows[i].Cells[4].Value.ToString() + "," + dataGridView1.Rows[i].Cells[5].Value.ToString());
                    }

                    //Totales
                    factura.AddDatos(this.label_F_Subtotal1.Text, ConfigurationManager.AppSettings["textBox_ImpSu1X"], ConfigurationManager.AppSettings["textBox_ImpSu1Y"]);
                    factura.AddDatos(this.label_F_TDesc.Text, ConfigurationManager.AppSettings["textBox_ImpDesX"], ConfigurationManager.AppSettings["textBox_ImpDesY"]);
                    factura.AddDatos(this.label_F_Impuestos.Text, ConfigurationManager.AppSettings["textBox_ImpIpsX"], ConfigurationManager.AppSettings["textBox_ImpIpsY"]);
                    factura.AddDatos(this.label_F_Subtotal2.Text, ConfigurationManager.AppSettings["textBox_ImpSu2X"], ConfigurationManager.AppSettings["textBox_ImpSu2Y"]);
                    factura.AddDatos(this.label_F_TIva.Text, ConfigurationManager.AppSettings["textBox_ImpIvaX"], ConfigurationManager.AppSettings["textBox_ImpIvaY"]);
                    factura.AddDatos(this.label_F_TOTAL.Text, ConfigurationManager.AppSettings["textBox_ImpTotX"], ConfigurationManager.AppSettings["textBox_ImpTotY"]);
                }
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "C")
                {
                    if (ConfigurationManager.AppSettings["textBox_DE_facturaImagenC"] != "") factura.AddImages(ConfigurationManager.AppSettings["textBox_DE_facturaImagenC"], 0, 0);
                    factura.AddDatos(DateArray[0], ConfigurationManager.AppSettings["textBox_ImpDiaX"], ConfigurationManager.AppSettings["textBox_ImpDiaY"]);
                    factura.AddDatos(DateArray[1], ConfigurationManager.AppSettings["textBox_ImpMesX"], ConfigurationManager.AppSettings["textBox_ImpMesY"]);
                    factura.AddDatos(DateArray[2], ConfigurationManager.AppSettings["textBox_ImpAnoX"], ConfigurationManager.AppSettings["textBox_ImpAnoY"]);
                    factura.AddDatos(DateTime.Now.ToShortTimeString(), ConfigurationManager.AppSettings["textBox_ImpHorX"], ConfigurationManager.AppSettings["textBox_ImpHorY"]);
                    factura.AddDatos(this.textBox_F_RazonSocial.Text, ConfigurationManager.AppSettings["textBox_ImpSenX"], ConfigurationManager.AppSettings["textBox_ImpSenY"]);
                    factura.AddDatos(this.textBox_F_ClienteDomicilio.Text, ConfigurationManager.AppSettings["textBox_ImpDomX"], ConfigurationManager.AppSettings["textBox_ImpDomY"]);
                    factura.AddDatos(this.textBox_F_Localidad.Text, ConfigurationManager.AppSettings["textBox_ImpLocX"], ConfigurationManager.AppSettings["textBox_ImpLocY"]);
                    if (this.radioButton_F_IvaRI.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRiX"], ConfigurationManager.AppSettings["textBox_ImpRiY"]);
                    if (this.radioButton_F_IvaCF.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpCfX"], ConfigurationManager.AppSettings["textBox_ImpCfY"]);
                    if (this.radioButton_F_IvaRNI.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpNorX"], ConfigurationManager.AppSettings["textBox_ImpNorY"]);
                    if (this.radioButton_F_IvaEXE.Checked == true) factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpExeX"], ConfigurationManager.AppSettings["textBox_ImpExeY"]);
                    factura.AddDatos(this.textBox_F_ClienteCuit.Text, ConfigurationManager.AppSettings["textBox_ImpCuiX"], ConfigurationManager.AppSettings["textBox_ImpCuiY"]);
                    factura.AddDatos("", ConfigurationManager.AppSettings["textBox_ImpRemX"], ConfigurationManager.AppSettings["textBox_ImpRemY"]);
                    if (this.comboBox_F_CondVenta.Text == "Contado") factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpConX"], ConfigurationManager.AppSettings["textBox_ImpConY"]);
                    if (this.comboBox_F_CondVenta.Text == "Cuenta Corriente") factura.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpCcoX"], ConfigurationManager.AppSettings["textBox_ImpCcoY"]);

                    //Items
                    int cantidadItems = 0;
                    cantidadItems = dataGridView1.Rows.Count;
                    for (int i = 0; i < cantidadItems; i++)
                    {
                        /*
                        remito.AddItem(ConfigurationManager.AppSettings["textBox_ImpRCanX"], ConfigurationManager.AppSettings["textBox_ImpRCanY"], ConfigurationManager.AppSettings["textBox_ImpRCanMC"], dataGridView1.Rows[i].Cells[0].Value.ToString());
                        remito.AddItem(ConfigurationManager.AppSettings["textBox_ImpRDetX"], ConfigurationManager.AppSettings["textBox_ImpRDetY"], ConfigurationManager.AppSettings["textBox_ImpRDetMC"], dataGridView1.Rows[i].Cells[1].Value.ToString());
                        remito.AddItem(ConfigurationManager.AppSettings["textBox_ImpRPreX"], ConfigurationManager.AppSettings["textBox_ImpRPreY"], ConfigurationManager.AppSettings["textBox_ImpRPreMC"], dataGridView1.Rows[i].Cells[2].Value.ToString());
                        remito.AddItem(ConfigurationManager.AppSettings["textBox_ImpRAliX"], ConfigurationManager.AppSettings["textBox_ImpRAliY"], ConfigurationManager.AppSettings["textBox_ImpRAliMC"], dataGridView1.Rows[i].Cells[3].Value.ToString());
                        remito.AddItem(ConfigurationManager.AppSettings["textBox_ImpRBivX"], ConfigurationManager.AppSettings["textBox_ImpRBivY"], ConfigurationManager.AppSettings["textBox_ImpRBivMC"], dataGridView1.Rows[i].Cells[4].Value.ToString());
                        remito.AddItem(ConfigurationManager.AppSettings["textBox_ImpRImpX"], ConfigurationManager.AppSettings["textBox_ImpRImpY"], ConfigurationManager.AppSettings["textBox_ImpRImpMC"], dataGridView1.Rows[i].Cells[5].Value.ToString());
                        factura.AddItems(dataGridView1.Rows[i].Cells[0].Value.ToString() + "," + dataGridView1.Rows[i].Cells[1].Value.ToString() + "," + dataGridView1.Rows[i].Cells[2].Value.ToString() + "," + dataGridView1.Rows[i].Cells[3].Value.ToString() + "," + dataGridView1.Rows[i].Cells[4].Value.ToString() + "," + dataGridView1.Rows[i].Cells[5].Value.ToString());
                         * */
                    }

                    //Totales
                    factura.AddDatos(this.label_F_Subtotal1.Text, ConfigurationManager.AppSettings["textBox_ImpSu1X"], ConfigurationManager.AppSettings["textBox_ImpSu1Y"]);
                    factura.AddDatos(this.label_F_TDesc.Text, ConfigurationManager.AppSettings["textBox_ImpDesX"], ConfigurationManager.AppSettings["textBox_ImpDesY"]);
                    factura.AddDatos(this.label_F_Impuestos.Text, ConfigurationManager.AppSettings["textBox_ImpIpsX"], ConfigurationManager.AppSettings["textBox_ImpIpsY"]);
                    factura.AddDatos(this.label_F_Subtotal2.Text, ConfigurationManager.AppSettings["textBox_ImpSu2X"], ConfigurationManager.AppSettings["textBox_ImpSu2Y"]);
                    factura.AddDatos(this.label_F_TIva.Text, ConfigurationManager.AppSettings["textBox_ImpIvaX"], ConfigurationManager.AppSettings["textBox_ImpIvaY"]);
                    factura.AddDatos(this.label_F_TOTAL.Text, ConfigurationManager.AppSettings["textBox_ImpTotX"], ConfigurationManager.AppSettings["textBox_ImpTotY"]);
                }

                
                //Mando a Imprimir
                factura.PrintFactura(ConfigurationManager.AppSettings["textBox_ImpNOMBRE"]);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-013");
            }
        }

        private void imprimoRemito()
        {
            try
            {
                Factura remito = new Factura();
                string[] DateArray = DateTime.Now.ToShortDateString().Split('/');

                //Datos de Remito
                if (ConfigurationManager.AppSettings["textBox_DE_facturaImagenR"] != "")
                {
                    int numero = Convert.ToInt32(ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialR"]);
                    remito.AddImages(ConfigurationManager.AppSettings["textBox_DE_facturaImagenR"], 0, 0);
                    remito.AddDatos(this.comboBox_F_PuntoVenta.Text + "-" + numero.ToString("00000000"), ConfigurationManager.AppSettings["textBox_ImpRNumX"], ConfigurationManager.AppSettings["textBox_ImpRNumY"]);
                }
                remito.AddDatos(DateArray[0], ConfigurationManager.AppSettings["textBox_ImpRDiaX"], ConfigurationManager.AppSettings["textBox_ImpRDiaY"]);
                remito.AddDatos(DateArray[1], ConfigurationManager.AppSettings["textBox_ImpRMesX"], ConfigurationManager.AppSettings["textBox_ImpRMesY"]);
                remito.AddDatos(DateArray[2], ConfigurationManager.AppSettings["textBox_ImpRAnoX"], ConfigurationManager.AppSettings["textBox_ImpRAnoY"]);
                remito.AddDatos(this.textBox_F_RazonSocial.Text, ConfigurationManager.AppSettings["textBox_ImpRSenX"], ConfigurationManager.AppSettings["textBox_ImpRSenY"]);
                remito.AddDatos(this.textBox_F_ClienteDomicilio.Text, ConfigurationManager.AppSettings["textBox_ImpRDomX"], ConfigurationManager.AppSettings["textBox_ImpRDomY"]);
                remito.AddDatos(this.textBox_F_Localidad.Text, ConfigurationManager.AppSettings["textBox_ImpRLocX"], ConfigurationManager.AppSettings["textBox_ImpRLocY"]);
                if (this.radioButton_F_IvaRI.Checked == true) remito.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRRiX"], ConfigurationManager.AppSettings["textBox_ImpRRiY"]);
                if (this.radioButton_F_IvaCF.Checked == true) remito.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRCfX"], ConfigurationManager.AppSettings["textBox_ImpRCfY"]);
                if (this.radioButton_F_IvaRNI.Checked == true) remito.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRNorX"], ConfigurationManager.AppSettings["textBox_ImpRNorY"]);
                if (this.radioButton_F_IvaEXE.Checked == true) remito.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRExeX"], ConfigurationManager.AppSettings["textBox_ImpRExeY"]);
                if (this.radioButton_F_IvaMT.Checked == true) remito.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRMtX"], ConfigurationManager.AppSettings["textBox_ImpRMtY"]);
                remito.AddDatos(this.textBox_F_ClienteCuit.Text, ConfigurationManager.AppSettings["textBox_ImpRCuiX"], ConfigurationManager.AppSettings["textBox_ImpRCuiY"]);
                if (this.comboBox_F_CondVenta.Text == "Contado") remito.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRConX"], ConfigurationManager.AppSettings["textBox_ImpRConY"]);
                if (this.comboBox_F_CondVenta.Text == "Cuenta Corriente") remito.AddDatos("X", ConfigurationManager.AppSettings["textBox_ImpRCcoX"], ConfigurationManager.AppSettings["textBox_ImpRCcoY"]);

                //Items
                int cantidadItems = 0;
                cantidadItems = dataGridView1.Rows.Count;
                for (int i = 0; i < cantidadItems; i++)
                {
                    remito.contador_numero_item = i;
                    remito.AddItem(ConfigurationManager.AppSettings["textBox_ImpRCanX"], ConfigurationManager.AppSettings["textBox_ImpRCanY"], ConfigurationManager.AppSettings["textBox_ImpRCanMC"], dataGridView1.Rows[i].Cells[0].Value.ToString());
                    remito.AddItem(ConfigurationManager.AppSettings["textBox_ImpRDetX"], ConfigurationManager.AppSettings["textBox_ImpRDetY"], ConfigurationManager.AppSettings["textBox_ImpRDetMC"], dataGridView1.Rows[i].Cells[1].Value.ToString());
                }

                //Mando a Imprimir
                remito.PrintFactura(ConfigurationManager.AppSettings["textBox_ImpNOMBRE"]);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-013");
            }
        }

        private void imprimoMovimientoStock()
        {
            try
            {
                Factura mstock = new Factura();
                string[] DateArray = DateTime.Now.ToShortDateString().Split('/');

                //Datos de MovStock
                int numero = Convert.ToInt32(ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialNP"]);
                mstock.AddDatos(this.comboBox_F_PuntoVenta.Text + "-" + numero.ToString("00000000"), "50", "10");

                mstock.AddDatos(DateArray[0], "10", "10");
                mstock.AddDatos(DateArray[1], "20", "10");
                mstock.AddDatos(DateArray[2], "30", "10");
                mstock.AddDatos(this.textBox_F_RazonSocial.Text, "10", "20");
                mstock.AddDatos(this.textBox_F_ClienteDomicilio.Text, "10", "30");
                mstock.AddDatos(this.textBox_F_Localidad.Text, "10", "40");
                
                mstock.AddDatos(this.textBox_F_ClienteCuit.Text, "10", "50");
                if (this.comboBox_F_CondVenta.Text == "Contado") mstock.AddDatos("Contado", "10", "60");
                if (this.comboBox_F_CondVenta.Text == "Cuenta Corriente") mstock.AddDatos("Cuenta Corriente", "10", "60");

                //Items
                int cantidadItems = 0;
                cantidadItems = dataGridView1.Rows.Count;
                for (int i = 0; i < cantidadItems; i++)
                {
                    mstock.contador_numero_item = i;
                    mstock.AddItem("10", "70", "4", dataGridView1.Rows[i].Cells[0].Value.ToString());
                    mstock.AddItem("20", "70", "40", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    mstock.AddItem("100", "70", "8", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    mstock.AddItem("120", "70", "8", dataGridView1.Rows[i].Cells[3].Value.ToString());
                    mstock.AddItem("140", "70", "8", dataGridView1.Rows[i].Cells[4].Value.ToString());
                    mstock.AddItem("160", "70", "10", dataGridView1.Rows[i].Cells[5].Value.ToString());
                }

                //Mando a Imprimir
                mstock.PrintFactura(ConfigurationManager.AppSettings["textBox_ImpNOMBRE"]);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-013");
            }
        }

        private void imprimoNotaDePedido()
        {
            try
            {
                Factura notaDePedido = new Factura();
                string[] DateArray = DateTime.Now.ToShortDateString().Split('/');

                //Datos de Presupuesto
                if (ConfigurationManager.AppSettings["textBox_DE_facturaImagenNP"] != "")
                {
                    int numero = Convert.ToInt32(ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialNP"]);
                    notaDePedido.AddImages(ConfigurationManager.AppSettings["textBox_DE_facturaImagenNP"], 0, 0);
                    notaDePedido.AddDatos(this.comboBox_F_PuntoVenta.Text + "-" + numero.ToString("00000000"), ConfigurationManager.AppSettings["textBox_ImpNPNumX"], ConfigurationManager.AppSettings["textBox_ImpNPNumY"]);
                }
                notaDePedido.AddDatos(DateArray[0], ConfigurationManager.AppSettings["textBox_ImpNPDiaX"], ConfigurationManager.AppSettings["textBox_ImpNPDiaY"]);
                notaDePedido.AddDatos(DateArray[1], ConfigurationManager.AppSettings["textBox_ImpNPMesX"], ConfigurationManager.AppSettings["textBox_ImpNPMesY"]);
                notaDePedido.AddDatos(DateArray[2], ConfigurationManager.AppSettings["textBox_ImpNPAnoX"], ConfigurationManager.AppSettings["textBox_ImpNPAnoY"]);
                notaDePedido.AddDatos(this.textBox_F_RazonSocial.Text, ConfigurationManager.AppSettings["textBox_ImpNPSenX"], ConfigurationManager.AppSettings["textBox_ImpNPSenY"]);
                notaDePedido.AddDatos(this.textBox_F_ClienteDomicilio.Text, ConfigurationManager.AppSettings["textBox_ImpNPDomX"], ConfigurationManager.AppSettings["textBox_ImpNPDomY"]);
                notaDePedido.AddDatos(this.textBox_F_Localidad.Text, ConfigurationManager.AppSettings["textBox_ImpNPLocX"], ConfigurationManager.AppSettings["textBox_ImpNPLocY"]);
                //Items
                int cantidadItems = 0;
                cantidadItems = dataGridView1.Rows.Count;
                for (int i = 0; i < cantidadItems; i++)
                {
                    notaDePedido.contador_numero_item = i;
                    notaDePedido.AddItem(ConfigurationManager.AppSettings["textBox_ImpNPCanX"], ConfigurationManager.AppSettings["textBox_ImpNPCanY"], ConfigurationManager.AppSettings["textBox_ImpNPCanMC"], dataGridView1.Rows[i].Cells[0].Value.ToString());
                    notaDePedido.AddItem(ConfigurationManager.AppSettings["textBox_ImpNPDetX"], ConfigurationManager.AppSettings["textBox_ImpNPDetY"], ConfigurationManager.AppSettings["textBox_ImpNPDetMC"], dataGridView1.Rows[i].Cells[1].Value.ToString());
                    notaDePedido.AddItem(ConfigurationManager.AppSettings["textBox_ImpNPPreX"], ConfigurationManager.AppSettings["textBox_ImpNPPreY"], ConfigurationManager.AppSettings["textBox_ImpNPPreMC"], dataGridView1.Rows[i].Cells[2].Value.ToString());
                    notaDePedido.AddItem(ConfigurationManager.AppSettings["textBox_ImpNPImpX"], ConfigurationManager.AppSettings["textBox_ImpNPImpY"], ConfigurationManager.AppSettings["textBox_ImpNPImpMC"], dataGridView1.Rows[i].Cells[5].Value.ToString());                    
                }
                //Totales
                notaDePedido.AddDatos(this.label_F_TOTAL.Text, ConfigurationManager.AppSettings["textBox_ImpNPTotX"], ConfigurationManager.AppSettings["textBox_ImpNPTotY"]);
                //Mando a Imprimir
                notaDePedido.PrintFactura(ConfigurationManager.AppSettings["textBox_ImpNOMBRE"]);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-013");
            }
        }

        private void imprimoPresupuesto()
        {
            try
            {
                Factura presupuesto = new Factura();
                string[] DateArray = DateTime.Now.ToShortDateString().Split('/');

                //Datos de Presupuesto
                if (ConfigurationManager.AppSettings["textBox_DE_facturaImagenP"] != "")
                {
                    int numero = Convert.ToInt32(ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialP"]);
                    presupuesto.AddImages(ConfigurationManager.AppSettings["textBox_DE_facturaImagenP"], 0, 0);
                    presupuesto.AddDatos(this.comboBox_F_PuntoVenta.Text + "-" + numero.ToString("00000000") , ConfigurationManager.AppSettings["textBox_ImpPNumX"], ConfigurationManager.AppSettings["textBox_ImpPNumY"]);
                }
                presupuesto.AddDatos(DateArray[0], ConfigurationManager.AppSettings["textBox_ImpPDiaX"], ConfigurationManager.AppSettings["textBox_ImpPDiaY"]);
                presupuesto.AddDatos(DateArray[1], ConfigurationManager.AppSettings["textBox_ImpPMesX"], ConfigurationManager.AppSettings["textBox_ImpPMesY"]);
                presupuesto.AddDatos(DateArray[2], ConfigurationManager.AppSettings["textBox_ImpPAnoX"], ConfigurationManager.AppSettings["textBox_ImpPAnoY"]); 
                presupuesto.AddDatos(this.textBox_F_RazonSocial.Text, ConfigurationManager.AppSettings["textBox_ImpPSenX"], ConfigurationManager.AppSettings["textBox_ImpPSenY"]);
                presupuesto.AddDatos(this.textBox_F_ClienteDomicilio.Text, ConfigurationManager.AppSettings["textBox_ImpPDomX"], ConfigurationManager.AppSettings["textBox_ImpPDomY"]);
                presupuesto.AddDatos(this.textBox_F_Localidad.Text, ConfigurationManager.AppSettings["textBox_ImpPLocX"], ConfigurationManager.AppSettings["textBox_ImpPLocY"]);
                //Items
                int cantidadItems = 0;
                cantidadItems = dataGridView1.Rows.Count;
                for (int i = 0; i < cantidadItems; i++)
                {
                    presupuesto.contador_numero_item = i;
                    presupuesto.AddItem(ConfigurationManager.AppSettings["textBox_ImpPCanX"], ConfigurationManager.AppSettings["textBox_ImpPCanY"], ConfigurationManager.AppSettings["textBox_ImpPCanMC"], dataGridView1.Rows[i].Cells[0].Value.ToString());
                    presupuesto.AddItem(ConfigurationManager.AppSettings["textBox_ImpPDetX"], ConfigurationManager.AppSettings["textBox_ImpPDetY"], ConfigurationManager.AppSettings["textBox_ImpPDetMC"], dataGridView1.Rows[i].Cells[1].Value.ToString());
                    presupuesto.AddItem(ConfigurationManager.AppSettings["textBox_ImpPPreX"], ConfigurationManager.AppSettings["textBox_ImpPPreY"], ConfigurationManager.AppSettings["textBox_ImpPPreMC"], dataGridView1.Rows[i].Cells[2].Value.ToString());
                    presupuesto.AddItem(ConfigurationManager.AppSettings["textBox_ImpPImpX"], ConfigurationManager.AppSettings["textBox_ImpPImpY"], ConfigurationManager.AppSettings["textBox_ImpPImpMC"], dataGridView1.Rows[i].Cells[5].Value.ToString());                    
                }
                //Totales
                presupuesto.AddDatos(this.label_F_TOTAL.Text, ConfigurationManager.AppSettings["textBox_ImpPTotX"], ConfigurationManager.AppSettings["textBox_ImpPTotY"]);
                //Mando a Imprimir
                presupuesto.PrintFactura(ConfigurationManager.AppSettings["textBox_ImpNOMBRE"]);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-013");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Ejecuto recalculo de stock;
        }

        private void IVA_change(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBox_F_IVASI.Checked == true)
                {
                    IVASI = 1;
                }
                else
                {
                    IVASI = 0;
                }
                Calculo_Importes();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-014");
            }
        }

        private void AutoCompleta_RazonSocial(object sender, EventArgs e)
        {
            try
            {
                this.textBox_F_RazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                this.textBox_F_RazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT [numero_id],[razon_social] FROM cliente_proveedor WHERE upper(razon_social) LIKE upper('%" + this.textBox_F_RazonSocial.Text + "%') ORDER BY razon_social DESC";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "cliente_proveedor");
                int rowsCount = sgdbDataSet.Tables["cliente_proveedor"].Rows.Count;

                for (int i = 0; i < rowsCount; i++)
                {
                    DataRow dRow = sgdbDataSet.Tables["cliente_proveedor"].Rows[i];
                    data.Add(dRow.ItemArray.GetValue(1).ToString());
                }
                conexion.Close();

                this.textBox_F_RazonSocial.AutoCompleteCustomSource = data;
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-015");
            }
        }

        private void AutoCompleta_NombreProducto(object sender, EventArgs e)
        {
            try
            {
                this.textBox_F_NombreProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                this.textBox_F_NombreProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();

                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT [descripcion] FROM articulos WHERE upper(descripcion) LIKE upper('%" + this.textBox_F_NombreProducto.Text + "%') ORDER BY descripcion DESC";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "articulos");
                int rowsCount = sgdbDataSet.Tables["articulos"].Rows.Count;

                for (int i = 0; i < rowsCount; i++)
                {
                    DataRow dRow = sgdbDataSet.Tables["articulos"].Rows[i];

                    data.Add(dRow.ItemArray.GetValue(0).ToString());
                }
                conexion.Close();

                this.textBox_F_NombreProducto.AutoCompleteCustomSource = data;
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-016");
            }
        }

        private string verifico_stock(string id, string cantidadAComprar)
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT stock FROM articulos WHERE upper(codigo_barra) = upper('" + id + "') OR upper(codigo_interno) = upper('" + id + "') OR upper(descripcion) = upper('" + id + "')";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "articulos");
                int rowsCount = sgdbDataSet.Tables["articulos"].Rows.Count;

                if (rowsCount > 0)
                {
                    DataRow dRow = sgdbDataSet.Tables["articulos"].Rows[0];
                    string cantidadEnStock = dRow.ItemArray.GetValue(0).ToString();
                    if (Convert.ToInt32(cantidadEnStock) >= Convert.ToInt32(cantidadAComprar))
                    {
                        return "1";
                    }
                    else return "La cantidad de productos disponibles es:" + dRow.ItemArray.GetValue(0).ToString() + "\nDebe ingresar un valor menor o igual.";
                }
                else return "Verifique que el código del producto sea correcto y que la cantidad de productos sea menor a la disponible.";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-017");
                return "Verifique que el código del producto sea correcto y que la cantidad de productos sea menor a la disponible.\n\n";
            }
        }

        

        private void Recalculo_Importes(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal subTotalProd = 0;
                decimal iva = 0;
                string validStock = "";
                int cantProd = 0;
                decimal valorInicial = 0;

                valorInicial = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                cantProd = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                dataGridView1.Rows[e.RowIndex].Cells[5].Value = "";
                iva = (valorInicial * cantProd) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()) / 100;
                subTotalProd = valorInicial * cantProd + iva;
                dataGridView1.Rows[e.RowIndex].Cells[5].Value = Math.Round(subTotalProd, 2);

                validStock = verifico_stock(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), cantProd.ToString());
                if (validStock == "1")
                {
                    Calculo_Importes();
                }
                else
                {
                    Calculo_Importes();
                    MessageBox.Show(validStock, "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-018");
            }
        }

        private void RecalculoImportes()
        {
            try
            {
                decimal subTotalProd = 0;
                decimal iva = 0;
                string validStock = "";
                int cantProd = 0;
                decimal valorInicial = 0;
                int numRows = 0;
                numRows = dataGridView1.Rows.Count;
                for (int i = 0; i < numRows; i++)
                {
                    valorInicial = Math.Round(Convert.ToDecimal(dataGridView1.Rows[i].Cells[2].Value.ToString()), 2);
                    cantProd = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    dataGridView1.Rows[i].Cells[5].Value = "";
                    iva = Math.Round((valorInicial * cantProd) * Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value.ToString()) / 100, 2);
                    subTotalProd = Math.Round(valorInicial * cantProd + iva, 2);
                    dataGridView1.Rows[i].Cells[5].Value = Math.Round(subTotalProd, 2);

                    validStock = verifico_stock(dataGridView1.Rows[i].Cells[1].Value.ToString(), cantProd.ToString());
                    if (validStock == "1")
                    {
                        Calculo_Importes();
                    }
                    else
                    {
                        Calculo_Importes();
                        MessageBox.Show(validStock, "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-019");
            }
        }

        private void aplicoDescuento(object sender, EventArgs e)
        {
            Calculo_Importes();
        }

        private void button_F_nuevo_Click(object sender, EventArgs e)
        {
            Limpio_Facturador();
        }

        private void button_F_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_F_guardar_Click(object sender, EventArgs e)
        {
            guardoFactura("Guardado");
        }

        private void facturo()
        {
            try
            {
                //Validar que no exista ya el numero de factura
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() != "")
                {
                    int iva = 0;
                    int lista_fac = 0;
                    string status = "true";
                    if (this.radioButton_F_Fact1.Checked == true) lista_fac = 1;
                    if (this.radioButton_F_Fact2.Checked == true) lista_fac = 2;
                    if (this.radioButton_F_Fact3.Checked == true) lista_fac = 3;
                    if (this.radioButton_F_IvaRNI.Checked == true) iva = 1;
                    if (this.radioButton_F_IvaRI.Checked == true) iva = 2;
                    if (this.radioButton_F_IvaCF.Checked == true) iva = 3;
                    if (this.radioButton_F_IvaEXE.Checked == true) iva = 4;
                    if (this.radioButton_F_IvaNR.Checked == true) iva = 5;
                    if (this.radioButton_F_IvaMT.Checked == true) iva = 6;
                    if (this.radioButton_F_IvaSC.Checked == true) iva = 7;
                    
                    string sql = "INSERT INTO facturas (f_tipo, f_vendedor, f_punto_venta, f_numero, f_fecha, f_c_codigo, f_c_razon_social, f_c_cuit, f_c_domicilio, f_c_condicion, f_c_localidad, f_c_descuento, f_c_lista, f_c_iva, fi_dolar, fi_subtotal1, fi_impuestos, fi_descuento, fi_subtotal2, fi_iva, fi_total, f_status) VALUES ('" + this.comboBox_F_TipoFactura.SelectedItem.ToString() +
                        "', '" + SG.MDIParentPadre.UserID +
                        "', '" + cambioMaskStringToInt(this.comboBox_F_PuntoVenta.SelectedItem.ToString()).ToString() +
                        "', '" + cambioMaskStringToInt(this.maskedTextBox_F_Numero.Text).ToString() +
                        "', '" + this.dateTimePicker_F_Fecha.Text +
                        "', '" + this.textBox_F_ClienteCodigo.Text +
                        "', '" + this.textBox_F_RazonSocial.Text +
                        "', '" + this.textBox_F_ClienteCuit.Text +
                        "', '" + this.textBox_F_ClienteDomicilio.Text +
                        "', '" + this.comboBox_F_CondVenta.SelectedItem.ToString() +
                        "', '" + this.textBox_F_Localidad.Text +
                        "', '" + this.textBox_F_Descuento.Text +
                        "', '" + lista_fac +
                        "', '" + iva +
                        "', '" + this.label_F_ValorDolar.Text +
                        "', '" + this.label_F_Subtotal1.Text +
                        "', '" + this.label_F_Impuestos.Text +
                        "', '" + this.label_F_TDesc.Text +
                        "', '" + this.label_F_Subtotal2.Text +
                        "', '" + this.label_F_TIva.Text +
                        "', '" + this.label_F_TOTAL.Text +
                        "', '" + status +
                        "')";
                    
                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    //Aca guardo el detalle
                    guardoDetalle(this.comboBox_F_TipoFactura.SelectedItem.ToString());

                    //MessageBox.Show("Se guardó correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un tipo de factura.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.comboBox_F_TipoFactura.Focus();
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-020");
            }
        }

        private void guardoFactura(string tipo)
        {
            try
            {
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() != "")
                {
                    int iva = 0;
                    int lista_fac = 0;
                    if (this.radioButton_F_Fact1.Checked == true) lista_fac = 1;
                    if (this.radioButton_F_Fact2.Checked == true) lista_fac = 2;
                    if (this.radioButton_F_Fact3.Checked == true) lista_fac = 3;
                    if (this.radioButton_F_IvaRNI.Checked == true) iva = 1;
                    if (this.radioButton_F_IvaRI.Checked == true) iva = 2;
                    if (this.radioButton_F_IvaCF.Checked == true) iva = 3;
                    if (this.radioButton_F_IvaEXE.Checked == true) iva = 4;
                    if (this.radioButton_F_IvaNR.Checked == true) iva = 5;
                    if (this.radioButton_F_IvaMT.Checked == true) iva = 6;
                    if (this.radioButton_F_IvaSC.Checked == true) iva = 7;

                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    string sql = "INSERT INTO facturas (f_tipo, f_vendedor, f_punto_venta, f_numero, f_fecha, f_c_codigo, f_c_razon_social, f_c_cuit, f_c_domicilio, f_c_condicion, f_c_localidad, f_c_descuento, f_c_lista, f_c_iva, fi_dolar, fi_subtotal1, fi_impuestos, fi_descuento, fi_subtotal2, fi_iva, fi_total) VALUES ('" + tipo +
                        "', '" + SG.MDIParentPadre.UserID +
                        "', '" + cambioMaskStringToInt(this.comboBox_F_PuntoVenta.SelectedItem.ToString()).ToString() +
                        "', '" + cambioMaskStringToInt(this.maskedTextBox_F_Numero.Text).ToString() +
                        "', '" + this.dateTimePicker_F_Fecha.Text +
                        "', '" + this.textBox_F_ClienteCodigo.Text +
                        "', '" + this.textBox_F_RazonSocial.Text +
                        "', '" + this.textBox_F_ClienteCuit.Text +
                        "', '" + this.textBox_F_ClienteDomicilio.Text +
                        "', '" + this.comboBox_F_CondVenta.SelectedItem.ToString() +
                        "', '" + this.textBox_F_Localidad.Text +
                        "', '" + this.textBox_F_Descuento.Text +
                        "', '" + lista_fac +
                        "', '" + iva +
                        "', '" + this.label_F_ValorDolar.Text +
                        "', '" + this.label_F_Subtotal1.Text +
                        "', '" + this.label_F_Impuestos.Text +
                        "', '" + this.label_F_TDesc.Text +
                        "', '" + this.label_F_Subtotal2.Text +
                        "', '" + this.label_F_TIva.Text +
                        "', '" + this.label_F_TOTAL.Text +
                        "')";
                    SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    //Aca guardo el detalle
                    guardoDetalle(tipo);

                    //MessageBox.Show("Se guardó correctamente.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un tipo de factura.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.comboBox_F_TipoFactura.Focus();
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-020");
            }
        }

        private void guardoDetalle(string tipo)
        {
            try
            {
                //Items
                int cantidadItems = 0;
                cantidadItems = dataGridView1.Rows.Count;
                if (cantidadItems > 0)
                {
                    for (int i = 0; i < cantidadItems; i++)
                    {
                        SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                        string sql = "INSERT INTO facturas_detalles (fd_tipo, fd_punto_venta, fd_factura, fd_cantidad, fd_detalle, fd_precio_unitario, fd_alicuota, fd_base_iva, fd_importe, fd_idproducto) VALUES ('" + tipo +
                            "', '" + cambioMaskStringToInt(this.comboBox_F_PuntoVenta.SelectedItem.ToString()).ToString() +
                            "', '" + cambioMaskStringToInt(this.maskedTextBox_F_Numero.Text).ToString() +
                            "', '" + Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString()) + // Cantidad
                            "', '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + //Detalle
                            "', '" + dataGridView1.Rows[i].Cells[2].Value.ToString() + //Precio Unitario
                            "', '" + dataGridView1.Rows[i].Cells[3].Value.ToString() + //Alicuota
                            "', '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + //Base IVA
                            "', '" + dataGridView1.Rows[i].Cells[5].Value.ToString() + //Importe
                            "', '" + getArticuloID(dataGridView1.Rows[i].Cells[1].Value.ToString()) + // ID producto
                            "')";
                        SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-021");
            }
            
        }

        private int getArticuloID(string descripOrCode)
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT id FROM articulos WHERE upper(codigo_barra) = upper('" + descripOrCode + "') OR upper(codigo_interno) = upper('" + descripOrCode + "') OR upper(descripcion) = upper('" + descripOrCode + "')";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "articulos");
                int rowsCount = sgdbDataSet.Tables["articulos"].Rows.Count;

                if (rowsCount > 0)
                {
                    DataRow dRow = sgdbDataSet.Tables["articulos"].Rows[0];
                    if (dRow.ItemArray.GetValue(0).ToString() != "") return Convert.ToInt32(dRow.ItemArray.GetValue(0).ToString());
                    else return 0;
                }
                else return 0;
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-022");
                return 0;
            }
        }

        private void button_F_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Form_FacturadorBuscar buscar = new Form_FacturadorBuscar();
                //buscar.Owner = this;
                //buscar.Show();
                Form_FacturadorBuscar.DefInstance.BringToFront();
                Form_FacturadorBuscar.DefInstance.Owner = this;
                Form_FacturadorBuscar.DefInstance.Show();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-023");
            }
        }

        private void button_F_movStock_Click(object sender, EventArgs e)
        {
        }

        private void button_F_imprimir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0) //Si hay items en la factura dejo imprimir
            {
                imprimir();
            }
            else 
            {
                if (MessageBox.Show("Esta por facturar sin ningun item.\nEstá seguro que desea imprimir la factura de todos modos?","ATENCION",MessageBoxButtons.OKCancel,MessageBoxIcon.Hand) == DialogResult.OK) //si acepto osea OK en el formulario
                {
                    imprimir();
                }
            }
        }

        private void imprimir()
        {
            try 
            {
                int flag = 0;
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() != "")
                {
                    switch (this.comboBox_F_TipoFactura.SelectedItem.ToString())
                    {
                        case "A": //Antes de imprimir guarda y actualiza stocks y si guardó bien imprimo.
                            if (actualizoStock())
                            {
                                facturo(); //Guarda en db datos de la factura
                                actualizoNumeroFactura(); //actualiza el numero de factura en el app.config
                                int cantidadCopias = Convert.ToInt32(ConfigurationManager.AppSettings["textBox_DE_facturaCopiasA"]);
                                for (int i = 0; i < cantidadCopias; i++) imprimoFactura(); //Imprimo candidad de copias espicificadas en app.config
                                flag = 1;
                            }
                            break;
                        case "B": //Antes de imprimir guarda y actualiza stocks y si guardó bien imprimo.
                            if (actualizoStock())
                            {
                                facturo(); //Guarda en db datos de la factura
                                actualizoNumeroFactura(); //actualiza el numero de factura en el app.config
                                int cantidadCopias = Convert.ToInt32(ConfigurationManager.AppSettings["textBox_DE_facturaCopiasB"]);
                                for (int i = 0; i < cantidadCopias; i++) imprimoFactura(); //Imprimo candidad de copias espicificadas en app.config
                                flag = 1;
                            }
                            break;
                        case "C": //Antes de imprimir guarda y actualiza stocks y si guardó bien imprimo.
                            if (actualizoStock())
                            {
                                facturo(); //Guarda en db datos de la factura
                                actualizoNumeroFactura(); //actualiza el numero de factura en el app.config
                                int cantidadCopias = Convert.ToInt32(ConfigurationManager.AppSettings["textBox_DE_facturaCopiasC"]);
                                for (int i = 0; i < cantidadCopias; i++) imprimoFactura(); //Imprimo candidad de copias espicificadas en app.config
                                flag = 1;
                            }
                            break;
                        case "Ticket": //Antes de imprimir guarda y actualiza stocks y si guardó bien imprimo.
                            if (actualizoStock())
                            {
                                facturo(); //Guarda en db datos de la factura
                                actualizoNumeroFactura(); //actualiza el numero de factura en el app.config
                                int cantidadCopias = Convert.ToInt32(ConfigurationManager.AppSettings["textBox_DE_facturaCopiasT"]);
                                for (int i = 0; i < cantidadCopias; i++) imprimoFactura(); //Imprimo candidad de copias espicificadas en app.config
                                flag = 1;
                            }
                            break;
                        case "MovStock": //Antes de imprimir guarda y actualiza stocks y si guardó bien imprimo.
                            if (actualizoStock())
                            {
                                guardoFactura("MovStock"); //Guarda en db datos de la factura pero no Guarda numero de factura ni actualiza el numero en el app.config
                                int cantidadCopias = 1;
                                for (int i = 0; i < cantidadCopias; i++) imprimoMovimientoStock(); //Imprimo candidad de copias espicificadas en app.config
                                flag = 1;
                            }
                            break;
                        case "NC": //Antes de imprimir guarda y actualiza stocks y si guardó bien imprimo.
                            //Verifico que el numero de factura a la cual se le hace la nota de credito exista y que ademas lo haya completado
                            string factNumero = cambioMaskStringToInt(this.maskedTextBox_F_numeroFacturaNC.Text).ToString();
                            string puntoVenta = cambioMaskStringToInt(this.maskedTextBox_F_puntoVentaNC.Text).ToString();
                            string tipoFactura = this.comboBox_F_TipoFacturaNC.SelectedItem.ToString();

                            string facturaNC = tipoFactura + "-" + puntoVenta + "-" + factNumero;

                            if (verificoFactura(facturaNC) && (this.maskedTextBox_F_puntoVentaNC.ToString() != "0000" || this.maskedTextBox_F_numeroFacturaNC.ToString() != "00000000"))
                            {
                                if (actualizoStock())
                                {
                                    facturo(); //Guarda en db datos de la factura
                                    actualizoNumeroFactura(); //actualiza el numero de factura en el app.config
                                    int cantidadCopias = Convert.ToInt32(ConfigurationManager.AppSettings["textBox_DE_facturaCopiasNC"]);
                                    for (int i = 0; i < cantidadCopias; i++) imprimoFactura(); //Imprimo candidad de copias espicificadas en app.config
                                    flag = 1;
                                }
                            }
                            else
                            {
                                MessageBox.Show("En numero de factura no existe o no ha sido completado", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.maskedTextBox_F_numeroFacturaNC.Focus();
                            }
                            break;
                        case "Remito": //Antes de imprimir guarda y actualiza stocks y si guardó bien imprimo.
                            if (actualizoStock())
                            {
                                guardoFactura("Remito"); //Guarda en db datos de la factura pero no Guarda numero de factura ni actualiza el numero en el app.config
                                actualizoNumeroFactura(); //actualiza el numero de factura en el app.config
                                int cantidadCopias = Convert.ToInt32(ConfigurationManager.AppSettings["textBox_DE_facturaCopiasR"]);
                                for (int i = 0; i < cantidadCopias; i++) imprimoRemito(); //Imprimo candidad de copias espicificadas en app.config
                                flag = 1;
                            }
                            break;
                        case "NP": //Antes de imprimir guarda y actualiza stocks y si guardó bien imprimo.
                            if (actualizoStock())
                            {
                                guardoFactura("NP"); //Guarda en db datos de la factura pero no Guarda numero de factura ni actualiza el numero en el app.config
                                actualizoNumeroFactura(); //actualiza el numero de factura en el app.config
                                int cantidadCopias = Convert.ToInt32(ConfigurationManager.AppSettings["textBox_DE_facturaCopiasNP"]);
                                for (int i = 0; i < cantidadCopias; i++) imprimoNotaDePedido(); //Imprimo candidad de copias espicificadas en app.config
                                flag = 1;
                            }
                            break;
                        case "Presupuesto": //Antes de imprimir guarda y actualiza stocks y si guardó bien imprimo.
                            {
                                guardoFactura("Presupuesto"); //Guarda en db datos de la factura pero no Guarda numero de factura ni actualiza el numero en el app.config
                                actualizoNumeroFactura(); //actualiza el numero de factura en el app.config
                                int cantidadCopias = Convert.ToInt32(ConfigurationManager.AppSettings["textBox_DE_facturaCopiasP"]);
                                for (int i = 0; i < cantidadCopias; i++) imprimoPresupuesto(); //Imprimo candidad de copias espicificadas en app.config
                                flag = 1;
                            }
                            break;
                        default: break;
                    }

                    if (flag == 1)
                    {
                        Limpio_Facturador();
                        //MessageBox.Show("Imprimiendo...", "IMPRIMIR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un tipo de factura.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.comboBox_F_TipoFactura.Focus();
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-024");
            }
        }

        private void acciones_BotonesF(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1) Limpio_Facturador();
            if (e.KeyData == Keys.F9) button_F_imprimir_Click(sender, e);
            if (e.KeyData == Keys.F5) button_F_guardar_Click(sender, e);
        }

        private void actualizoNumeroFactura()
        {
            try
            {
                int numNuevo = 0;
                int flag = 0;
                string realNumViejo = "";
                string realNumNuevo = "";
                char[] numViejo = this.maskedTextBox_F_Numero.Text.ToCharArray(); //Leo
                int countNumViejo = numViejo.Count();
                for (int i = 0; i < countNumViejo; i++)
                {
                    if (numViejo[i] != '0')
                    {
                        realNumViejo += numViejo[i].ToString();
                        flag = 1;
                    }
                }
                // si el numero es distinto de 00000000
                if (flag == 1) numNuevo = Convert.ToInt32(realNumViejo) + 1;
                else numNuevo = 1;
                realNumNuevo = String.Format("{0:00000000}", numNuevo);

                //Guardo
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                switch (this.comboBox_F_TipoFactura.SelectedItem.ToString())
                {
                    case "A": config.AppSettings.Settings.Remove("maskedTextBox_DE_facturaInicialA");
                        config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialA", realNumNuevo);
                        break;

                    case "B": config.AppSettings.Settings.Remove("maskedTextBox_DE_facturaInicialB");
                        config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialB", realNumNuevo);
                        break;

                    case "C": config.AppSettings.Settings.Remove("maskedTextBox_DE_facturaInicialC");
                        config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialC", realNumNuevo);
                        break;

                    case "Ticket": config.AppSettings.Settings.Remove("maskedTextBox_DE_facturaInicialT");
                        config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialT", realNumNuevo);
                        break;

                    case "Remito": config.AppSettings.Settings.Remove("maskedTextBox_DE_facturaInicialR");
                        config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialR", realNumNuevo);
                        break;

                    case "NC": config.AppSettings.Settings.Remove("maskedTextBox_DE_facturaInicialNC");
                        config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialNC", realNumNuevo);
                        break;

                    case "NP": config.AppSettings.Settings.Remove("maskedTextBox_DE_facturaInicialNP");
                        config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialNP", realNumNuevo);
                        break;

                    case "Presupuesto": config.AppSettings.Settings.Remove("maskedTextBox_DE_facturaInicialP");
                        config.AppSettings.Settings.Add("maskedTextBox_DE_facturaInicialP", realNumNuevo);
                        break;

                    default: break;
                }
                // Guardo la Configuarcion en el Archivo
                config.Save(ConfigurationSaveMode.Modified);
                // Fuerzo a releer los cambios
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-025");
            }
        }

        private bool actualizoStock()
        {
            try
            {
                int productoID = 0;
                int cantidadStock = 0;
                int stock = 0;
                int countRows = dataGridView1.Rows.Count;
                for (int i = 0; i < countRows; i++)
                {
                    productoID = getArticuloID(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    cantidadStock = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);

                    // Me conecto
                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    DataSet DS = new DataSet();
                    SqlCeCommand cmd = new SqlCeCommand();
                    string sql = "SELECT stock FROM articulos WHERE upper(id) = upper('" + productoID + "')";
                    SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                    da.Fill(DS, "articulos");
                    DataRow dRow = DS.Tables["articulos"].Rows[0];

                    stock = Convert.ToInt32(dRow.ItemArray.GetValue(0).ToString()) - cantidadStock;

                    string SQL = "UPDATE articulos SET stock = '" + stock + "' WHERE id = '" + productoID + "'";
                    SqlCeCommand CMD = new SqlCeCommand(SQL, conexion);
                    CMD.Connection.Open();
                    CMD.ExecuteNonQuery();
                    CMD.Connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-026");
                return false;
            }
        }

        private void completoDatos(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter && this.textBox_F_ClienteCodigo.Text != "")
                {
                    this.textBox_F_RazonSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
                    this.textBox_F_RazonSocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection data = new AutoCompleteStringCollection();

                    // Me conecto
                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    DataSet sgdbDataSet = new DataSet();
                    SqlCeCommand cmd = new SqlCeCommand();
                    string sql = "SELECT numero_id FROM cliente_proveedor WHERE upper(razon_social) = upper('" + this.textBox_F_RazonSocial.Text + "')";
                    SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                    da.Fill(sgdbDataSet, "cliente_proveedor");
                    int rowsCount = sgdbDataSet.Tables["cliente_proveedor"].Rows.Count;

                    if (rowsCount > 0)
                    {
                        DataRow dRow = sgdbDataSet.Tables["cliente_proveedor"].Rows[0];
                        this.textBox_F_ClienteCodigo.Text = dRow.ItemArray.GetValue(0).ToString();
                    }
                    conexion.Close();
                    Busco_Cliente();
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-027");
            }
        }

        private void actualizoNumero(object sender, EventArgs e)
        {
            try
            {
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "A") this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialA"];
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "B") this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialB"];
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "C") this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialC"];
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "Ticket") this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialT"];
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "Remito") this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialR"];
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "MovStock") this.maskedTextBox_F_Numero.Text = "XXXXXXXX";
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "NC")
                {
                    this.maskedTextBox_F_numeroFacturaNC.Visible = true;
                    this.maskedTextBox_F_puntoVentaNC.Visible = true;
                    this.comboBox_F_TipoFacturaNC.Visible = true;
                    this.comboBox_F_TipoFacturaNC.SelectedIndex = 0;
                    this.label23.Visible = true;
                    this.label25.Visible = true;
                    this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialNC"];
                }
                else
                {
                    this.maskedTextBox_F_numeroFacturaNC.Text = "00000000";
                    this.maskedTextBox_F_numeroFacturaNC.Visible = false;
                    this.maskedTextBox_F_puntoVentaNC.Text = "0000";
                    this.maskedTextBox_F_puntoVentaNC.Visible = false;
                    this.comboBox_F_TipoFacturaNC.SelectedIndex = 0;
                    this.comboBox_F_TipoFacturaNC.Visible = false;
                    this.label23.Visible = false;
                    this.label25.Visible = false;
                }
                if (this.comboBox_F_TipoFactura.SelectedItem.ToString() == "Presupuesto") this.maskedTextBox_F_Numero.Text = ConfigurationManager.AppSettings["maskedTextBox_DE_facturaInicialP"];
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-028");
            }
        }

        private bool verificoFactura(string numeroFacturaNC)
        {
            try
            {
                string[] fact = numeroFacturaNC.Split('-');
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet DS = new DataSet();
                string SQL = "SELECT f_id FROM facturas WHERE f_tipo = '" + fact[0] + "' AND f_punto_venta = '" + fact[1] + "' AND f_numero = '" + fact[2] + "'";
                SqlCeDataAdapter DA = new SqlCeDataAdapter(SQL, conexion);

                DA.Fill(DS, "facturas");
                int rowsCount = DS.Tables["facturas"].Rows.Count;

                if (rowsCount > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-FA1-029");
                return false;
            }
        }

        public int cambioMaskStringToInt(string str)
        {
            int numNuevo = 0;
            int flag = 0;
            string realNumViejo = "";
            char[] numViejo = str.ToCharArray(); //Leo
            int countNumViejo = numViejo.Count();
            for (int i = 0; i < countNumViejo; i++)
            {
                if (!char.IsWhiteSpace(numViejo[i]))
                {
                    realNumViejo += numViejo[i].ToString();
                    flag = 1;
                }
            }
            // si el numero es distinto de 00000000 o null y un numero
            if (flag == 1) numNuevo = Convert.ToInt32(realNumViejo);
            else numNuevo = 1;
            return numNuevo;
        }
    }
}
