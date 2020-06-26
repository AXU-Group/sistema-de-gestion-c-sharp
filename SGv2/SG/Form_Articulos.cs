using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data.SqlServerCe;
using manten;
using System.Threading;
using nmExcel = Microsoft.Office.Interop.Excel;

namespace SG
{
    public partial class Form_Articulos : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_Articulos m_FormDefInstance;
        public static Form_Articulos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_Articulos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public Form_Articulos()
        {
            InitializeComponent();
        }

        private void button_A_AgregarImagen_Click(object sender, EventArgs e)
        {
            if (this.textBox_A_CodigoBarras.Text != "")
            {
                Stream myStream = null;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
                
                openFileDialog1.Filter = "Archivos de imagen(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png|Todos los archivos (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((myStream = openFileDialog1.OpenFile()) != null)
                        {
                            using (myStream)
                            {
                                // Insert code to read the stream here.
                                this.pictureBox_A_Imagen.Image = Image.FromStream(Redimensiona(myStream, 200, 200, 300));
                                //this.pictureBox_A_Imagen.Image.Save(Environment.CurrentDirectory + @"\articulos\" + this.textBox_A_CodigoBarras.Text + ".jpg",ImageFormat.Jpeg);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        em.sendmail(ex, "Error: F-AR1-001");
                    }
                }

            }
            else MessageBox.Show("Error: Se debe ingresar primero el codigo de barras del producto.", "Error: F-AR1-002",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public static MemoryStream Redimensiona(Stream imagen, int targetW, int targetH, int resolucion)
        {
            try
            {
                System.Drawing.Image original = System.Drawing.Image.FromStream(imagen);
                System.Drawing.Image imgPhoto = System.Drawing.Image.FromStream(imagen);

                int diferencia = 0;
                int difPorcent = 0;
                int WdifPerc = 0;
                int HdifPerc = 0;

                //Si el ancho es menor que el alto y el alto es mayor o igual que nuestro valor H .. si se cumple esto achicamos manteniendo la proporcion
                if ((original.Width < original.Height) && (original.Height >= targetH))
                {
                    diferencia = original.Height - targetH;
                    difPorcent = (diferencia * 100) / original.Height;
                    targetH = original.Height - diferencia;
                    WdifPerc = (difPorcent * original.Width) / 100;
                    targetW = original.Width - WdifPerc;
                }
                //Si el ancho es mayor que el alto y el ancho es mayor o igual que nuestro valor W .. si se cumple esto achicamos manteniendo la proporcion
                if ((original.Width > original.Height) && (original.Width >= targetW))
                {
                    diferencia = original.Width - targetW;
                    difPorcent = (diferencia * 100) / original.Width;
                    targetW = original.Width - diferencia;
                    HdifPerc = (difPorcent * original.Height) / 100;
                    targetH = original.Height - HdifPerc;
                }
                //Si los anchos son iguales y mayores a nuestros valores W y H los achicamos manteniendo la proporcion cuadrada
                if ((original.Width == original.Height) && (original.Width >= targetW) && (original.Height >= targetH))
                {
                    diferencia = original.Width - targetW;
                    targetW = original.Width - diferencia;
                    targetH = original.Height - diferencia;
                }

                Bitmap bmPhoto = new Bitmap(targetW, targetH, PixelFormat.Format24bppRgb);

                // No vamos a permitir dar una resolución mayor de la que tiene
                resolucion = resolucion <= Convert.ToInt32(bmPhoto.HorizontalResolution) ? resolucion : Convert.ToInt32(bmPhoto.HorizontalResolution);
                resolucion = resolucion <= Convert.ToInt32(bmPhoto.VerticalResolution) ? resolucion : Convert.ToInt32(bmPhoto.VerticalResolution);

                bmPhoto.SetResolution(resolucion, resolucion);
                Graphics grPhoto = Graphics.FromImage(bmPhoto);

                grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
                grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, targetW, targetH), new Rectangle(0, 0, original.Width, original.Height), GraphicsUnit.Pixel);

                MemoryStream mm = new MemoryStream();
                bmPhoto.Save(mm, System.Drawing.Imaging.ImageFormat.Jpeg);

                original.Dispose();
                imgPhoto.Dispose();
                bmPhoto.Dispose();
                grPhoto.Dispose();

                return mm;
            }
            catch (Exception ex)
            {
                enviamail em = new enviamail();
                em.sendmail(ex, "Error: F-AR1-003");
                return null;
            }
        }

        private void convierto_Amoneda(object sender, EventArgs e)
        {
            try
            {
                string texto = ((TextBox)sender).Text;
                string[] txt = texto.Split('.',',');
                 

                if (txt.Length == 1 && txt[0] != "") // Ej: 10
                {
                    ((TextBox)sender).Text = txt[0] + ".00"; // Convierte a 10,00
                }
                if (txt.Length == 1 && txt[0] == "") // Ej: campo vacio
                {
                    ((TextBox)sender).Text = txt[0] + "0.00"; // Convierte a 0,00
                }
                if (txt.Length == 2 && txt[0] != "" && txt[1] != "") // Ej: 10.10
                {
                    if (txt[1].Length == 1) // Ej: 10.8
                    {
                        ((TextBox)sender).Text = txt[0] + "." + txt[1] + "0"; // Convierte a 10,80
                    }
                    else ((TextBox)sender).Text = txt[0] + "." + txt[1]; // Convierte a 10,10
                }
                if (txt.Length == 2 && txt[0] == "" && txt[1] == "") // Ej: "." o "," solo
                {
                    ((TextBox)sender).Text = "0.00"; // Convierte a 0,00
                }
                if (txt.Length == 2 && txt[0] == "" && txt[1] != "") // Ej: .99
                {
                    if (txt[1].Length == 1) // Ej: .9
                    {
                        ((TextBox)sender).Text = "0." + txt[1] + "0"; // Convierte a 0,90
                    }
                    else ((TextBox)sender).Text = "0." + txt[1]; // Convierte a 0,99
                }
                if (txt.Length == 2 && txt[0] != "" && txt[1] == "") // Ej: 10.
                {
                    ((TextBox)sender).Text = txt[0] + ".00"; // Convierte a 10,00
                }
                if (txt.Length > 2)
                {
                    MessageBox.Show("Error: El formato de la celda es incorrecto.\nSe aceptan solo numeros, punto o coma en este casillero.", "Error: F-AR1-004",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-005");
            }

        }

        private void Verifica_Teclas(object sender, KeyEventArgs e)
        {
            if ((e.KeyData != Keys.D0) && (e.KeyData != Keys.D1) && (e.KeyData != Keys.D2) && (e.KeyData != Keys.D3) && (e.KeyData != Keys.D4) && (e.KeyData != Keys.D5) && (e.KeyData != Keys.D6) && (e.KeyData != Keys.D7) && (e.KeyData != Keys.D8) && (e.KeyData != Keys.D9) && (e.KeyData != Keys.Back) && (e.KeyData != Keys.Delete) && (e.KeyData != Keys.NumPad0) && (e.KeyData != Keys.NumPad1) && (e.KeyData != Keys.NumPad2) && (e.KeyData != Keys.NumPad3) && (e.KeyData != Keys.NumPad4) && (e.KeyData != Keys.NumPad5) && (e.KeyData != Keys.NumPad6) && (e.KeyData != Keys.NumPad7) && (e.KeyData != Keys.NumPad8) && (e.KeyData != Keys.NumPad9) && (e.KeyData != Keys.Enter) && (e.KeyData != Keys.Decimal) && (e.KeyData != Keys.Oemcomma) && (e.KeyData != Keys.Up) && (e.KeyData != Keys.Left) && (e.KeyData != Keys.Right) && (e.KeyData != Keys.Down) && (e.KeyData != Keys.Tab))
            {
                if (e.KeyData != Keys.Tab) { }
                else
                {
                    int cantLetras = ((TextBox)sender).Text.Length;
                    ((TextBox)sender).Text = ((TextBox)sender).Text.Substring(0, cantLetras - 1);
                    MessageBox.Show("Error: Se aceptan solo numeros, punto o coma en este casillero.", "Error: F-AR1-006", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
                em.sendmail(ex, "Error: F-AR1-007");
            }
        }

        private void button_A_Precio_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Costo = Convert.ToDecimal(this.textBox_A_PrecioCompra.Text);

                decimal Utilidad1 = Convert.ToDecimal(this.textBox_A_Utilidad1.Text);
                this.textBox_A_PrecioVenta1.Text = Convert.ToString(Costo + Utilidad1);
                decimal Utilidad2 = Convert.ToDecimal(this.textBox_A_Utilidad2.Text);
                this.textBox_A_PrecioVenta2.Text = Convert.ToString(Costo + Utilidad2);
                decimal Utilidad3 = Convert.ToDecimal(this.textBox_A_Utilidad3.Text);
                this.textBox_A_PrecioVenta3.Text = Convert.ToString(Costo + Utilidad3);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-008");
            }
        }

        private void button_A_Utilidad_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Costo = Convert.ToDecimal(this.textBox_A_PrecioCompra.Text);

                decimal Precio1 = Convert.ToDecimal(this.textBox_A_PrecioVenta1.Text);
                this.textBox_A_Utilidad1.Text = Convert.ToString(Precio1 - Costo);
                convierto_Amoneda(this.textBox_A_Utilidad1, e);
                decimal Precio2 = Convert.ToDecimal(this.textBox_A_PrecioVenta2.Text);
                this.textBox_A_Utilidad2.Text = Convert.ToString(Precio2 - Costo);
                convierto_Amoneda(this.textBox_A_Utilidad2, e);
                decimal Precio3 = Convert.ToDecimal(this.textBox_A_PrecioVenta3.Text);
                this.textBox_A_Utilidad3.Text = Convert.ToString(Precio3 - Costo);
                convierto_Amoneda(this.textBox_A_Utilidad3, e);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-009");
            }
        }

        private void button_E_Precio_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Costo = Convert.ToDecimal(this.textBox_E_PrecioCompra.Text);

                decimal Utilidad1 = Convert.ToDecimal(this.textBox_E_Utilidad1.Text);
                this.textBox_E_PrecioVenta1.Text = Convert.ToString(Costo + Utilidad1);
                decimal Utilidad2 = Convert.ToDecimal(this.textBox_E_Utilidad2.Text);
                this.textBox_E_PrecioVenta2.Text = Convert.ToString(Costo + Utilidad2);
                decimal Utilidad3 = Convert.ToDecimal(this.textBox_E_Utilidad3.Text);
                this.textBox_E_PrecioVenta3.Text = Convert.ToString(Costo + Utilidad3);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-010");
            }
        }

        private void button_E_Utilidad_Click(object sender, EventArgs e)
        {
            try
            {
                decimal Costo = Convert.ToDecimal(this.textBox_E_PrecioCompra.Text);

                decimal Precio1 = Convert.ToDecimal(this.textBox_E_PrecioVenta1.Text);
                this.textBox_E_Utilidad1.Text = Convert.ToString(Precio1 - Costo);
                convierto_Amoneda(this.textBox_E_Utilidad1, e);
                decimal Precio2 = Convert.ToDecimal(this.textBox_E_PrecioVenta2.Text);
                this.textBox_E_Utilidad2.Text = Convert.ToString(Precio2 - Costo);
                convierto_Amoneda(this.textBox_E_Utilidad2, e);
                decimal Precio3 = Convert.ToDecimal(this.textBox_E_PrecioVenta3.Text);
                this.textBox_E_Utilidad3.Text = Convert.ToString(Precio3 - Costo);
                convierto_Amoneda(this.textBox_E_Utilidad3, e);
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-011");
            }
        }

        private void button_A_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dir_articulos = new DirectoryInfo(Environment.CurrentDirectory + @"\articulos\");

                if (!dir_articulos.Exists)
                {
                    dir_articulos.Create(); // creo el directorio ARTICULOS
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-012");
            }
            try
            {
                if (this.textBox_A_Descripcion.Text == "" || this.textBox_A_PrecioCompra.Text == "" || this.textBox_A_PrecioVenta1.Text == "0.00")
                {
                    MessageBox.Show("ATENCION: Debe conpletar todos los casilleros marcados con (*)", "Error: F-AR1-013", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int esDolar = 0;
                    string carpeta = "";
                    string url = null;
                    if (this.radioButton_A_esPeso.Checked == true) esDolar = 0;
                    if (this.radioButton_A_esDolar.Checked == true) esDolar = 1;
                    if (this.radioButton_A_esEuro.Checked == true) esDolar = 2;
                    if (this.pictureBox_A_Imagen.Image != null)
                    {
                        carpeta = Environment.CurrentDirectory + @"\articulos\";
                        url = Environment.CurrentDirectory + @"\articulos\" + this.textBox_A_CodigoBarras.Text + ".jpg";
                        // Guardo la imagen en el disco.
                        Directory.CreateDirectory(carpeta);
                        this.pictureBox_A_Imagen.Image.Save(url, ImageFormat.Jpeg);
                    }
                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    string sql = "INSERT INTO articulos (codigo_barra,codigo_interno,descripcion,marca,modelo,stock,unidad,precio_compra,precio_venta1,precio_venta2,precio_venta3,utilidad1,utilidad2,utilidad3,iva,foto_url,es_dolar,codigo_proveedor,razon_social,cod_prod_prov,familia,orden) VALUES ('" + this.textBox_A_CodigoBarras.Text +
                        "', '" + this.textBox_A_CodigoInterno.Text +
                        "', '" + this.textBox_A_Descripcion.Text +
                        "', '" + this.textBox_A_Marca.Text +
                        "', '" + this.textBox_A_Modelo.Text +
                        "', '" + this.textBox_A_Stock.Text +
                        "', '" + this.textBox_A_Unidad.Text +
                        "', '" + this.textBox_A_PrecioCompra.Text +
                        "', '" + this.textBox_A_PrecioVenta1.Text +
                        "', '" + this.textBox_A_PrecioVenta2.Text +
                        "', '" + this.textBox_A_PrecioVenta3.Text +
                        "', '" + this.textBox_A_Utilidad1.Text +
                        "', '" + this.textBox_A_Utilidad2.Text +
                        "', '" + this.textBox_A_Utilidad3.Text +
                        "', '" + this.textBox_A_IVA.Text +
                        "', '" + url +
                        "', '" + esDolar +
                        "', '" + this.textBox_A_CodProv.Text +
                        "', '" + this.textBox_A_RazonSocial.Text +
                        "', '" + this.textBox_A_CodProdProv.Text +
                        "', '" + this.textBox_A_Familia.Text +
                        "', '" + this.textBox_A_Orden.Text +
                        "')";
                    SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    MessageBox.Show("El articulo se ingreso correctamente.");
                    Limpiar_Formulario_Agregar();
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-014");
            }
        }

        private void buscar_Articulo(object sender, EventArgs e)
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT * FROM articulos WHERE upper(codigo_barra) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(codigo_interno) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(descripcion) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(codigo_proveedor) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(razon_social) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(cod_prod_prov) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(familia) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') ORDER BY codigo_barra DESC";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "articulos");

                BindingSource bindingSource = new BindingSource(sgdbDataSet.Tables[0], null);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear(); //Borro todas las columnas de dataGridView1

                dataGridView1.Columns.Add("id", "ID");
                dataGridView1.Columns.Add("codbar", "Codigo de Barras"); //(nombre de la columna,Titulo de la columna)
                dataGridView1.Columns.Add("codint", "Codigo Interno");
                dataGridView1.Columns.Add("desc", "Descripcion");
                dataGridView1.Columns.Add("precioV1", "Precio Venta 1");
                dataGridView1.Columns.Add("stock", "Stock");
                dataGridView1.Columns.Add("marca", "Marca");
                dataGridView1.Columns.Add("modelo", "Modelo");
                dataGridView1.Columns.Add("codprov", "Codigo Proveedor");
                dataGridView1.Columns.Add("razonsocial", "Razon social");
                dataGridView1.Columns.Add("codprodprov", "Codigo Segun Proveedor");
                dataGridView1.Columns.Add("familia", "Familia");
                dataGridView1.Columns.Add("orden", "Orden");

                //dataGridView1.Columns[0].Width = 110; // ancho de la columna
                //dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[0].DataPropertyName = "id";
                dataGridView1.Columns[1].DataPropertyName = "codigo_barra"; //son los campos de la base de datos
                dataGridView1.Columns[2].DataPropertyName = "codigo_interno";
                dataGridView1.Columns[3].DataPropertyName = "descripcion";
                dataGridView1.Columns[4].DataPropertyName = "precio_venta1"; 
                dataGridView1.Columns[5].DataPropertyName = "stock";
                dataGridView1.Columns[6].DataPropertyName = "marca";
                dataGridView1.Columns[7].DataPropertyName = "modelo";
                dataGridView1.Columns[8].DataPropertyName = "codigo_proveedor";
                dataGridView1.Columns[9].DataPropertyName = "razon_social";
                dataGridView1.Columns[10].DataPropertyName = "cod_prod_prov";
                dataGridView1.Columns[11].DataPropertyName = "familia";
                dataGridView1.Columns[12].DataPropertyName = "orden";

                dataGridView1.DataSource = bindingSource;
                bindingNavigator1.BindingSource = bindingSource;
                conexion.Close();

                if (this.bindingNavigatorPositionItem.Enabled == true)
                {
                    this.toolStripButton_Eliminar.Enabled = true;
                    this.toolStripButton_Editar.Enabled = true;
                    this.toolStripButton_Nuevo.Enabled = true;
                }
                else
                {
                    this.toolStripButton_Eliminar.Enabled = false;
                    this.toolStripButton_Editar.Enabled = false;
                    this.toolStripButton_Nuevo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-015");
            }
        }

        private void toolStripButton_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea borrar el articulo?", "¡¡Atención!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i=0; i < dataGridView1.SelectedCells.Count; i++)
                    {                        
                        SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                        string sql = "DELETE FROM articulos WHERE id = '" + dataGridView1.SelectedCells[i].OwningRow.Cells[0].Value.ToString() + "'";

                        SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    buscar_Articulo(sender,e);

                    MessageBox.Show("Articulos borrados correctamente", "Listo!");
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-016");
            }
        }

        private void toolStripButton_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl.SelectedTab = tabPage_Editar;
                Limpiar_Formulario_Editar();
                this.textBox_E_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.textBox_E_CodigoBarras.Select();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-017");
            }
        }

        private void toolStripButton_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar_Formulario_Agregar();
                this.tabControl.SelectedTab = tabPage_Agregar;
                this.textBox_A_CodigoBarras.Select();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-018");
            }
        }

        public void Limpiar_Formulario_Agregar()
        {
            try
            {
                this.textBox_A_CodigoBarras.Text = "";
                this.textBox_A_CodigoInterno.Text = "";
                this.textBox_A_Descripcion.Text = "";
                this.textBox_A_Marca.Text = "";
                this.textBox_A_Modelo.Text = "";
                this.textBox_A_Stock.Text = "";
                this.textBox_A_Unidad.Text = "";
                this.textBox_A_PrecioCompra.Text = "0.00";
                this.textBox_A_PrecioVenta1.Text = "0.00";
                this.textBox_A_PrecioVenta2.Text = "0.00";
                this.textBox_A_PrecioVenta3.Text = "0.00";
                this.textBox_A_Utilidad1.Text = "0.00";
                this.textBox_A_Utilidad2.Text = "0.00";
                this.textBox_A_Utilidad3.Text = "0.00";
                this.textBox_A_IVA.Text = "21.00";
                this.radioButton_A_esPeso.Checked = true;
                this.radioButton_A_esDolar.Checked = false;
                this.radioButton_A_esEuro.Checked = false;
                this.pictureBox_A_Imagen.Image = null;
                this.textBox_A_CodProv.Text = "";
                this.textBox_A_RazonSocial.Text = "";
                this.textBox_A_CodProdProv.Text = "";
                this.textBox_A_Familia.Text = "";
                this.textBox_A_Orden.Text = "";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-019");
            }
        }

        public void Limpiar_Formulario_Editar()
        {
            try
            {
                this.textBox_E_CodigoBarras.Text = "";
                this.textBox_E_CodigoInterno.Text = "";
                this.textBox_E_Descripcion.Text = "";
                this.textBox_E_Marca.Text = "";
                this.textBox_E_Modelo.Text = "";
                this.textBox_E_Stock.Text = "";
                this.textBox_A_Unidad.Text = "";
                this.textBox_E_PrecioCompra.Text = "0.00";
                this.textBox_E_PrecioVenta1.Text = "0.00";
                this.textBox_E_PrecioVenta2.Text = "0.00";
                this.textBox_E_PrecioVenta3.Text = "0.00";
                this.textBox_E_Utilidad1.Text = "0.00";
                this.textBox_E_Utilidad2.Text = "0.00";
                this.textBox_E_Utilidad3.Text = "0.00";
                this.textBox_E_IVA.Text = "21.00";
                this.radioButton_E_esPeso.Checked = true;
                this.radioButton_E_esDolar.Checked = false;
                this.radioButton_E_esEuro.Checked = false;
                this.pictureBox_E_Imagen.Image = null;
                this.textBox_E_CodProv.Text = "";
                this.textBox_E_RazonSocial.Text = "";
                this.textBox_E_CodProdProv.Text = "";
                this.textBox_E_Familia.Text = "";
                this.textBox_E_Orden.Text = "";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-020");
            }
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar_Formulario_Agregar();
        }

        private void Llena_Campos(object sender, EventArgs e)
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT * FROM articulos WHERE upper(id) LIKE upper('" + this.textBox_E_ID.Text + "')";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "articulos");
                DataRow dRow = sgdbDataSet.Tables["articulos"].Rows[0];
                
                this.textBox_E_CodigoBarras.Text = dRow.ItemArray.GetValue(1).ToString();
                this.textBox_E_CodigoInterno.Text = dRow.ItemArray.GetValue(2).ToString();
                this.textBox_E_Descripcion.Text = dRow.ItemArray.GetValue(3).ToString();
                this.textBox_E_Marca.Text = dRow.ItemArray.GetValue(20).ToString();
                this.textBox_E_Modelo.Text = dRow.ItemArray.GetValue(21).ToString();
                this.textBox_E_Stock.Text = dRow.ItemArray.GetValue(4).ToString();
                this.textBox_E_Unidad.Text = dRow.ItemArray.GetValue(5).ToString();
                this.textBox_E_PrecioCompra.Text = dRow.ItemArray.GetValue(6).ToString();
                this.textBox_E_PrecioVenta1.Text = dRow.ItemArray.GetValue(7).ToString();
                this.textBox_E_PrecioVenta2.Text = dRow.ItemArray.GetValue(8).ToString();
                this.textBox_E_PrecioVenta3.Text = dRow.ItemArray.GetValue(9).ToString();
                this.textBox_E_Utilidad1.Text = dRow.ItemArray.GetValue(10).ToString();
                this.textBox_E_Utilidad2.Text = dRow.ItemArray.GetValue(11).ToString();
                this.textBox_E_Utilidad3.Text = dRow.ItemArray.GetValue(12).ToString();
                this.textBox_E_IVA.Text = dRow.ItemArray.GetValue(13).ToString();
                if (dRow.ItemArray.GetValue(14).ToString() != "")
                {
                    this.pictureBox_E_Imagen.Image = Image.FromFile(dRow.ItemArray.GetValue(14).ToString());
                }
                else this.pictureBox_E_Imagen.Image = null;
                if ("1" == dRow.ItemArray.GetValue(15).ToString()) this.radioButton_E_esDolar.Checked = true;
                if ("2" == dRow.ItemArray.GetValue(15).ToString()) this.radioButton_E_esEuro.Checked = true;
                this.textBox_E_CodProv.Text = dRow.ItemArray.GetValue(16).ToString();
                this.textBox_E_RazonSocial.Text = dRow.ItemArray.GetValue(17).ToString();
                this.textBox_E_CodProdProv.Text = dRow.ItemArray.GetValue(18).ToString();
                this.textBox_E_Familia.Text = dRow.ItemArray.GetValue(19).ToString();
                this.textBox_E_Orden.Text = dRow.ItemArray.GetValue(22).ToString();
                conexion.Close();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-021");
            }
        }

        private void button_E_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox_E_Descripcion.Text == "" || this.textBox_E_PrecioCompra.Text == "" || this.textBox_E_PrecioVenta1.Text == "0.00")
                {
                    MessageBox.Show("ATENCION: Debe conpletar todos los casilleros marcados con (*)", "Error: F-AR1-022", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int esDolar = 0;
                    if (this.radioButton_E_esPeso.Checked == true) esDolar = 0;
                    if (this.radioButton_E_esDolar.Checked == true) esDolar = 1;
                    if (this.radioButton_E_esEuro.Checked == true) esDolar = 2;

                    string carpeta = "";
                    string url = "";
                    if (this.pictureBox_E_Imagen.Image != null)
                    {
                        carpeta = Environment.CurrentDirectory + @"\articulos\";
                        url = Environment.CurrentDirectory + @"\articulos\" + this.textBox_E_CodigoBarras.Text + ".jpg";
                        // Guardo la imagen en el disco.
                        Directory.CreateDirectory(carpeta);
                        this.pictureBox_E_Imagen.Image.Save(url, ImageFormat.Jpeg);
                    }
                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    string sql = "UPDATE articulos SET codigo_barra = '" + this.textBox_E_CodigoBarras.Text +
                        "', codigo_interno = '" + this.textBox_E_CodigoInterno.Text +
                        "', descripcion = '" + this.textBox_E_Descripcion.Text +
                        "', marca = '" + this.textBox_E_Marca.Text +
                        "', modelo = '" + this.textBox_E_Modelo.Text +
                        "', stock = '" + this.textBox_E_Stock.Text +
                        "', unidad = '" + this.textBox_E_Unidad.Text +
                        "', precio_compra = '" + this.textBox_E_PrecioCompra.Text +
                        "', precio_venta1 = '" + this.textBox_E_PrecioVenta1.Text +
                        "', precio_venta2 = '" + this.textBox_E_PrecioVenta2.Text +
                        "', precio_venta3 = '" + this.textBox_E_PrecioVenta3.Text +
                        "', utilidad1 = '" + this.textBox_E_Utilidad1.Text +
                        "', utilidad2 = '" + this.textBox_E_Utilidad2.Text +
                        "', utilidad3 = '" + this.textBox_E_Utilidad3.Text +
                        "', iva = '" + this.textBox_E_IVA.Text +
                        "', foto_url = '" + url +
                        "', es_dolar = '" + esDolar +
                        "', codigo_proveedor = '" + this.textBox_E_CodProv.Text +
                        "', razon_social = '" + this.textBox_E_RazonSocial.Text +
                        "', cod_prod_prov = '" + this.textBox_E_CodProdProv.Text +
                        "', familia = '" + this.textBox_E_Familia.Text +
                        "', orden = '" + this.textBox_E_Orden.Text +
                        "' WHERE id = '" + this.textBox_E_ID.Text + "'";

                    SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    MessageBox.Show("El artículo se actualizó correctamente.");
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-023");
            }
        }

        private void button_E_AgregarImagen_Click(object sender, EventArgs e)
        {
            if (this.textBox_E_CodigoBarras.Text != "")
            {
                Stream myStream = null;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

                openFileDialog1.Filter = "Archivos de imagen(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png|Todos los archivos (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((myStream = openFileDialog1.OpenFile()) != null)
                        {
                            using (myStream)
                            {
                                // Insert code to read the stream here.
                                this.pictureBox_E_Imagen.Image = Image.FromStream(Redimensiona(myStream, 200, 200, 300));
                                //this.pictureBox_E_Imagen.Image.Save(Environment.CurrentDirectory + @"\articulos\" + this.textBox_E_CodigoBarras.Text + ".jpg",ImageFormat.Jpeg);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        em.sendmail(ex, "Error: F-AR1-024");
                    }
                }

            }
            else MessageBox.Show("Error: Se debe ingresar primero el codigo de barras del producto.", "Error: F-AR1-025", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_A_BorrarImagen_Click(object sender, EventArgs e)
        {
            this.pictureBox_A_Imagen.Image = null;
        }

        private void button_E_BorrarImagen_Click(object sender, EventArgs e)
        {
            this.pictureBox_E_Imagen.Image = null;
        }

        private void Busco_A_Proveedor(object sender, EventArgs e)
        {
            if (this.textBox_A_CodProv.Text != "")
            {
                try
                {
                    // Me conecto
                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    DataSet sgdbDataSet = new DataSet();
                    SqlCeCommand cmd = new SqlCeCommand();
                    string sql = "SELECT razon_social FROM cliente_proveedor WHERE upper(numero_id) LIKE upper('" + this.textBox_A_CodProv.Text + "')";
                    SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                    da.Fill(sgdbDataSet, "cliente_proveedor");
                    DataRow dRow = sgdbDataSet.Tables["cliente_proveedor"].Rows[0];

                    this.textBox_A_RazonSocial.Text = dRow.ItemArray.GetValue(0).ToString();

                    conexion.Close();
                }
                catch (Exception ex)
                {
                    em.sendmail(ex, "Error: F-AR1-026");
                }
            }
            else this.textBox_A_RazonSocial.Text = "";
        }

        private void Busco_E_Proveedor(object sender, EventArgs e)
        {
            if (this.textBox_E_CodProv.Text != "")
            {
                try
                {
                    // Me conecto
                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    DataSet sgdbDataSet = new DataSet();
                    SqlCeCommand cmd = new SqlCeCommand();
                    string sql = "SELECT razon_social FROM cliente_proveedor WHERE upper(numero_id) LIKE upper('" + this.textBox_E_CodProv.Text + "')";
                    SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                    da.Fill(sgdbDataSet, "cliente_proveedor");
                    DataRow dRow = sgdbDataSet.Tables["cliente_proveedor"].Rows[0];

                    this.textBox_E_RazonSocial.Text = dRow.ItemArray.GetValue(0).ToString();

                    conexion.Close();
                }
                catch (Exception ex)
                {
                    em.sendmail(ex, "Error: F-AR1-027");
                }
            }
            else this.textBox_E_RazonSocial.Text = "";
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button_I_buscarArchivo_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog2 = new OpenFileDialog();

            openFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);

            openFileDialog2.Filter = "Libro de Excel 97-2003 (*.xls)|*.xls";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog2.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            this.textBox_I_buscarArchivo.Text = openFileDialog2.FileName.ToString();

                            //En DataSource especificas la ruta del archivo
                            string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=" + openFileDialog2.FileName.ToString() + ";" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES" + '"';
                            // Para x86, @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=" + openFileDialog2.FileName.ToString() + ";" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES" + '"';
                            // Para x64, @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + openFileDialog2.FileName.ToString() + ";" + @"Extended Properties=" + '"' + "Excel 14.0;HDR=YES" + '"';
                            // www.microsoft.com/downloads/es-es/details.aspx?familyid=c06b8369-60dd-4b64-a44b-84b371ede16d&displaylang=es
                            OleDbConnection con = new OleDbConnection(CadenaConexion);

                            //codigo_interno,descripcion son columnas en la hoja de excel se maneja igual que una tabla sql
                            string strSQL = "SELECT codigo_barra,codigo_interno,descripcion,marca,modelo,stock,unidad,precio_compra,precio_venta1,precio_venta2,precio_venta3,utilidad1,utilidad2,utilidad3,iva,foto_url,es_dolar,codigo_proveedor,razon_social,cod_prod_prov,familia,orden FROM [hoja1$]";

                            OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);

                            DataSet ds = new DataSet();

                            //da.Fill(ds);
                            da.Fill(ds, "[hoja1$]");
                            DataRow dRow = ds.Tables["[hoja1$]"].Rows[0];
                            //this.label68.Text = dRow.ItemArray.GetValue(0).ToString();
                            this.pictureBox5.Image = SG.Properties.Resources.success;
                            this.label68.Visible = true;
                            this.button_I_importarArchivo.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    em.sendmail(ex, "Error: F-AR1-028");
                }
            }
        }

        private void porcentajeProgressBarImportar(int actual, int max)
        {
            try
            {
                if (this == null) return;
                int porcentaje = Convert.ToInt32(actual * 100 / max);
                this.progressBar_I_importFile.Value = porcentaje;
                this.label69.Text = "Completado: " + porcentaje.ToString() + "%";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-029");
            }
        }

        private void porcentajeProgressBarExportar(int actual, int max)
        {
            try
            {
                if (this == null) return;
                int porcentaje = Convert.ToInt32(actual * 100 / max);
                this.progressBar_E_exportFile.Value = porcentaje;
                this.label69.Text = "Completado: " + porcentaje.ToString() + "%";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-029");
            }
        }

        private void button_I_importarArchivo_Click(object sender, EventArgs e)
        {
            //Thread thread = new Thread(new ThreadStart(importarArchivo));
            //thread.SetApartmentState(ApartmentState.STA);
            //thread.Start();
            importarArchivo();
        }

        private void importarArchivo()
        {
            if(this.radioButton_I_agregar.Checked == true)
            {
                // Los datos repetidos no los deberia agregar
                try
                {
                    this.label69.Visible = true;
                    //En DataSource especificas la ruta del archivo
                    //string HDR = hasHeaders ? "Yes" : "No"; // Si uso la importacion con headears
                    string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=" + this.textBox_I_buscarArchivo.Text.ToString() + ";" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES" + '"';
                    // Para x86, @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=" + openFileDialog2.FileName.ToString() + ";" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES" + '"';
                    // Para x64, @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=" + openFileDialog2.FileName.ToString() + ";" + @"Extended Properties=" + '"' + "Excel 14.0;HDR=YES" + '"';
                    // www.microsoft.com/downloads/es-es/details.aspx?familyid=c06b8369-60dd-4b64-a44b-84b371ede16d&displaylang=es
                    OleDbConnection con = new OleDbConnection(CadenaConexion);

                    //codigo_interno,descripcion son columnas en la hoja de excel se maneja igual que una tabla sql
                    string strSQL = "SELECT codigo_barra,codigo_interno,descripcion,marca,modelo,stock,unidad,precio_compra,precio_venta1,precio_venta2,precio_venta3,utilidad1,utilidad2,utilidad3,iva,foto_url,es_dolar,codigo_proveedor,razon_social,cod_prod_prov,familia,orden FROM [hoja1$] WHERE NOT ([descripcion]='')";

                    OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);
                    DataSet ds = new DataSet();

                    //da.Fill(ds);
                    da.Fill(ds, "[hoja1$]");

                    // SQL del INSERT de ARTICULOS
                    string sql = "";
                    int i;

                    // para la barra de progreso
                    int maxVal = ds.Tables["[hoja1$]"].Rows.Count;
                    // Barra de progreso
                    this.progressBar_I_importFile.Maximum = maxVal;

                    MessageBox.Show("Se van a importar " + maxVal + " registros.");
                    for (i = 1; i <= maxVal; i++)
                    {
                        // Barra de progreso
                        porcentajeProgressBarImportar(i, maxVal);

                        DataRow dRow = ds.Tables["[hoja1$]"].Rows[i - 1]; // saco la primera linea que son los nombres de columnas.

                        if (dRow.ItemArray.GetValue(0).ToString() != "" || dRow.ItemArray.GetValue(1).ToString() != "" || dRow.ItemArray.GetValue(2).ToString() != "" || dRow.ItemArray.GetValue(5).ToString() != "" || dRow.ItemArray.GetValue(8).ToString() != "" || dRow.ItemArray.GetValue(9).ToString() != "")
                        {
                            sql = "INSERT INTO articulos (codigo_barra,codigo_interno,descripcion,marca,modelo,stock,unidad,precio_compra,precio_venta1,precio_venta2,precio_venta3,utilidad1,utilidad2,utilidad3,iva,foto_url,es_dolar,codigo_proveedor,razon_social,cod_prod_prov,familia,orden) VALUES (upper('" + dRow.ItemArray.GetValue(0).ToString() +
                                "'), upper('" + dRow.ItemArray.GetValue(1).ToString() +
                                "'), upper('" + dRow.ItemArray.GetValue(2).ToString() +
                                "'), upper('" + dRow.ItemArray.GetValue(3).ToString() +
                                "'), upper('" + dRow.ItemArray.GetValue(4).ToString() +
                                "'), '" + dRow.ItemArray.GetValue(5).ToString() +
                                "', '" + dRow.ItemArray.GetValue(6).ToString() +
                                "', '" + dRow.ItemArray.GetValue(7).ToString() +
                                "', '" + dRow.ItemArray.GetValue(8).ToString() +
                                "', '" + dRow.ItemArray.GetValue(9).ToString() +
                                "', '" + dRow.ItemArray.GetValue(10).ToString() +
                                "', '" + dRow.ItemArray.GetValue(11).ToString() +
                                "', '" + dRow.ItemArray.GetValue(12).ToString() +
                                "', upper('" + dRow.ItemArray.GetValue(13).ToString() +
                                "'), upper('" + dRow.ItemArray.GetValue(14).ToString() +
                                "'), '" + dRow.ItemArray.GetValue(15).ToString() +
                                "', '" + dRow.ItemArray.GetValue(16).ToString() +
                                "', upper('" + dRow.ItemArray.GetValue(17).ToString() +
                                "'), upper('" + dRow.ItemArray.GetValue(18).ToString() +
                                "'), upper('" + dRow.ItemArray.GetValue(19).ToString() +
                                "'), upper('" + dRow.ItemArray.GetValue(20).ToString() +
                                "'), '" + dRow.ItemArray.GetValue(21).ToString() +
                                "');";

                            SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                            SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            sql = "";
                            cmd.Connection.Close();
                        }
                            
                    }
                    MessageBox.Show("Se importaron "+ (i-1) + " registros.");
                }
                catch (Exception ex)
                {
                    em.sendmail(ex, "Error: F-AR1-030");
                }
            }

            // Remplazo los existentes
            if (this.radioButton_I_reemplazar.Checked == true)
            {
                // Los tados que no estan los deberia agregar
                try
                {
                    int actualizados = 0;
                    string UpdateSql = "";

                    this.label69.Visible = true;
                    string CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;" + @"Data Source=" + this.textBox_I_buscarArchivo.Text.ToString() + ";" + @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES" + '"';
                    OleDbConnection con = new OleDbConnection(CadenaConexion);

                    //codigo_interno,descripcion son columnas en la hoja de excel se maneja igual que una tabla sql
                    string strSQL = "SELECT codigo_barra, codigo_interno, descripcion, marca, modelo, stock, unidad, precio_compra, precio_venta1, precio_venta2, precio_venta3, utilidad1, utilidad2, utilidad3, iva, foto_url, es_dolar, codigo_proveedor, razon_social, cod_prod_prov, familia, orden FROM [hoja1$] WHERE NOT ([descripcion]='')";
                    OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);
                    DataSet ds = new DataSet();
                    //da.Fill(ds);
                    da.Fill(ds, "[hoja1$]");

                    // para la barra de progreso
                    int maxVal = ds.Tables["[hoja1$]"].Rows.Count;
                    for (int i = 1; i <= maxVal; i++)
                    {
                        // Barra de progreso
                        porcentajeProgressBarImportar(i, maxVal);

                        // Articulos que tiene la planilla de excel
                        DataRow dRow = ds.Tables["[hoja1$]"].Rows[i - 1];

                        // articulos existentes
                        // Me conecto
                        SqlCeConnection CAE = new SqlCeConnection(MDIParentPadre.st_conexion);
                        DataSet dsCAE = new DataSet();
                        SqlCeCommand cmdCAE = new SqlCeCommand();
                        string sqlCAE = "SELECT id, descripcion FROM articulos WHERE upper(descripcion)=upper('" + dRow.ItemArray.GetValue(2).ToString() + "')";
                        SqlCeDataAdapter daCAE = new SqlCeDataAdapter(sqlCAE, CAE);

                        daCAE.Fill(dsCAE, "articulos");
                        int rowsCount = dsCAE.Tables["articulos"].Rows.Count;

                        if (rowsCount > 0)
                        {
                            // Si existe el articulo en la taba Articulos la actualizo
                            string iva = "";
                            if (dRow.ItemArray.GetValue(14).ToString() != "") Math.Round(Convert.ToDecimal(dRow.ItemArray.GetValue(14).ToString()), 2).ToString();

                            UpdateSql = "UPDATE articulos SET codigo_barra = upper('" + dRow.ItemArray.GetValue(0).ToString() +
                            "'), codigo_interno = upper('" + dRow.ItemArray.GetValue(1).ToString() +
                            "'), descripcion = upper('" + dRow.ItemArray.GetValue(2).ToString() +
                            "'), marca = upper('" + dRow.ItemArray.GetValue(3).ToString() +
                            "'), modelo = upper('" + dRow.ItemArray.GetValue(4).ToString() +
                            "'), stock = '" + dRow.ItemArray.GetValue(5).ToString() +
                            "', unidad = '" + dRow.ItemArray.GetValue(6).ToString() +
                            "', precio_compra = '" + dRow.ItemArray.GetValue(7).ToString() +
                            "', precio_venta1 = '" + dRow.ItemArray.GetValue(8).ToString() +
                            "', precio_venta2 = '" + dRow.ItemArray.GetValue(9).ToString() +
                            "', precio_venta3 = '" + dRow.ItemArray.GetValue(10).ToString() +
                            "', utilidad1 = '" + dRow.ItemArray.GetValue(11).ToString() +
                            "', utilidad2 = '" + dRow.ItemArray.GetValue(12).ToString() +
                            "', utilidad3 = '" + dRow.ItemArray.GetValue(13).ToString() +
                            "', iva = '" + iva +
                            "', foto_url = upper('" + dRow.ItemArray.GetValue(15).ToString() +
                            "'), es_dolar = '" + dRow.ItemArray.GetValue(16).ToString() +
                            "', codigo_proveedor = upper('" + dRow.ItemArray.GetValue(17).ToString() +
                            "'), razon_social = upper('" + dRow.ItemArray.GetValue(18).ToString() +
                            "'), cod_prod_prov = upper('" + dRow.ItemArray.GetValue(19).ToString() +
                            "'), familia = upper('" + dRow.ItemArray.GetValue(20).ToString() +
                            "'), orden = '" + dRow.ItemArray.GetValue(21).ToString() +
                            "' WHERE UPPER(descripcion) = UPPER('" + dRow.ItemArray.GetValue(2).ToString() + "')";
                            
                            SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                            SqlCeCommand cmd = new SqlCeCommand(UpdateSql, conexion);
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                            actualizados++;
                        }
                        CAE.Close();
                    }
                    MessageBox.Show("Se actualizaron " + actualizados + " articulos de " + maxVal + " existentes en la planilla excel.");
                }
                catch (Exception ex)
                {
                    em.sendmail(ex, "Error: F-AR1-031");
                }
            }
        }

        private void toolStripButton_Exportar_a_Excel_Click(object sender, EventArgs e)
        {
            /*
            Thread thread = new Thread(new ThreadStart(exportoSeleccionArticulos));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            */
            exportoSeleccionArticulos();
        }

        private void exportoSeleccionArticulos()
        {
            try
            {
                /*
                nmExcel.Application ExcelApp = new nmExcel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 12;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow Fila = dataGridView1.Rows[i];
                    for (int j = 0; j < Fila.Cells.Count; j++)
                    {
                        ExcelApp.Cells[i + 1, j + 1] = Fila.Cells[j].Value;
                    }
                }
                */
                nmExcel.Application ExcelApp = new nmExcel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 12;

                //Agrego los nombres de las columnas
                ExcelApp.Cells[1, 1] = "codigo_barra";
                ExcelApp.Cells[1, 2] = "codigo_interno";
                ExcelApp.Cells[1, 3] = "descripcion";
                ExcelApp.Cells[1, 4] = "marca";
                ExcelApp.Cells[1, 5] = "modelo";
                ExcelApp.Cells[1, 6] = "stock";
                ExcelApp.Cells[1, 7] = "unidad";
                ExcelApp.Cells[1, 8] = "precio_compra";
                ExcelApp.Cells[1, 9] = "precio_venta1";
                ExcelApp.Cells[1, 10] = "precio_venta2";
                ExcelApp.Cells[1, 11] = "precio_venta3";
                ExcelApp.Cells[1, 12] = "utilidad1";
                ExcelApp.Cells[1, 13] = "utilidad2";
                ExcelApp.Cells[1, 14] = "utilidad3";
                ExcelApp.Cells[1, 15] = "iva";
                ExcelApp.Cells[1, 16] = "foto_url";
                ExcelApp.Cells[1, 17] = "es_dolar";
                ExcelApp.Cells[1, 18] = "codigo_proveedor";
                ExcelApp.Cells[1, 19] = "razon_social";
                ExcelApp.Cells[1, 20] = "cod_prod_prov";
                ExcelApp.Cells[1, 21] = "familia";
                ExcelApp.Cells[1, 22] = "orden";


                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT codigo_barra, codigo_interno, descripcion, marca, modelo, stock, unidad, precio_compra, precio_venta1, precio_venta2, precio_venta3, utilidad1, utilidad2, utilidad3, iva, foto_url, es_dolar, codigo_proveedor, razon_social, cod_prod_prov, familia, orden FROM articulos WHERE upper(codigo_barra) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(codigo_interno) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(descripcion) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(codigo_proveedor) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(razon_social) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(cod_prod_prov) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(familia) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') ORDER BY descripcion DESC";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "articulos");

                int colsCount = sgdbDataSet.Tables["articulos"].Columns.Count;
                int rowsCount = sgdbDataSet.Tables["articulos"].Rows.Count;

                for (int i = 0; i < rowsCount; i++)
                {
                    DataRow dRow = sgdbDataSet.Tables["articulos"].Rows[i];
                    for (int j = 0; j < colsCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dRow.ItemArray.GetValue(j).ToString();
                    }
                    // Barra de progreso
                    porcentajeProgressBarExportar(i, rowsCount);
                }
                // ---------- cuadro de dialogo para Guardar
                SaveFileDialog CuadroDialogo = new SaveFileDialog();
                CuadroDialogo.DefaultExt = "xls";
                CuadroDialogo.Filter = "Libro de Excel 97-2003 (*.xls)|*.xls";
                CuadroDialogo.AddExtension = true;
                CuadroDialogo.RestoreDirectory = true;
                CuadroDialogo.Title = "Guardar";
                CuadroDialogo.InitialDirectory = @"c:\";
                if (CuadroDialogo.ShowDialog() == DialogResult.OK)
                {
                    ExcelApp.ActiveWorkbook.SaveCopyAs(CuadroDialogo.FileName);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    CuadroDialogo.Dispose();
                    CuadroDialogo = null;
                    ExcelApp.Quit();
                    MessageBox.Show("Listo, se exportaron los articulos correctamente.");
                }
                else
                {
                    MessageBox.Show("No se guardaron los datos.");
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-AR1-032");
            }
        }

        private void button_EX_Exportar_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(exportoTodoArticulos));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();            
        }

        private void exportoTodoArticulos()
        {
            string filename = "";

            try
            {
                nmExcel.Application ExcelApp = new nmExcel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);
                ExcelApp.Columns.ColumnWidth = 12;

                //Agrego los nombres de las columnas
                ExcelApp.Cells[1, 1] = "codigo_barra";
                ExcelApp.Cells[1, 2] = "codigo_interno";
                ExcelApp.Cells[1, 3] = "descripcion";
                ExcelApp.Cells[1, 4] = "marca";
                ExcelApp.Cells[1, 5] = "modelo";
                ExcelApp.Cells[1, 6] = "stock";
                ExcelApp.Cells[1, 7] = "unidad";
                ExcelApp.Cells[1, 8] = "precio_compra";
                ExcelApp.Cells[1, 9] = "precio_venta1";
                ExcelApp.Cells[1, 10] = "precio_venta2";
                ExcelApp.Cells[1, 11] = "precio_venta3";
                ExcelApp.Cells[1, 12] = "utilidad1";
                ExcelApp.Cells[1, 13] = "utilidad2";
                ExcelApp.Cells[1, 14] = "utilidad3";
                ExcelApp.Cells[1, 15] = "iva";
                ExcelApp.Cells[1, 16] = "foto_url";
                ExcelApp.Cells[1, 17] = "es_dolar";
                ExcelApp.Cells[1, 18] = "codigo_proveedor";
                ExcelApp.Cells[1, 19] = "razon_social";
                ExcelApp.Cells[1, 20] = "cod_prod_prov";
                ExcelApp.Cells[1, 21] = "familia";
                ExcelApp.Cells[1, 22] = "orden";

                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT codigo_barra, codigo_interno, descripcion, marca, modelo, stock, unidad, precio_compra, precio_venta1, precio_venta2, precio_venta3, utilidad1, utilidad2, utilidad3, iva, foto_url, es_dolar, codigo_proveedor, razon_social, cod_prod_prov, familia, orden FROM articulos ORDER BY descripcion";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "articulos");

                int colsCount = sgdbDataSet.Tables["articulos"].Columns.Count;
                int rowsCount = sgdbDataSet.Tables["articulos"].Rows.Count;

                for (int i = 0; i < rowsCount; i++)
                {
                    DataRow dRow = sgdbDataSet.Tables["articulos"].Rows[i];
                    for (int j = 0; j < colsCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = dRow.ItemArray.GetValue(j).ToString();
                    }
                    // Barra de progreso
                    porcentajeProgressBarExportar(i, rowsCount);
                }
                // ---------- cuadro de dialogo para Guardar
                SaveFileDialog CuadroDialogo = new SaveFileDialog();
                CuadroDialogo.DefaultExt = "xls";
                CuadroDialogo.Filter = "Libro de Excel 97-2003 (*.xls)|*.xls";
                CuadroDialogo.AddExtension = true;
                CuadroDialogo.RestoreDirectory = true;
                CuadroDialogo.Title = "Guardar";
                CuadroDialogo.InitialDirectory = @"c:\";
                if (CuadroDialogo.ShowDialog() == DialogResult.OK)
                {
                    filename = CuadroDialogo.FileName;
                    ExcelApp.ActiveWorkbook.SaveCopyAs(CuadroDialogo.FileName);
                    ExcelApp.ActiveWorkbook.Saved = true;
                    CuadroDialogo.Dispose();
                    CuadroDialogo = null;
                    ExcelApp.Quit();
                    MessageBox.Show("Listo, se exportaron los articulos correctamente.");
                }
                else
                {
                    MessageBox.Show("No se guardaron los datos.");
                }
            }
            catch (Exception ex)
            {
                String[] msj = filename.Split('\\');

                if (ex.Message == "Cannot access '" + msj[msj.Length - 1] + "'.")
                {
                    MessageBox.Show("El archivo \"" + msj[msj.Length - 1] + "\" ya se encuentra abierto o es de solo lectura.");
                }
                else
                {
                    em.sendmail(ex, "Error: F-AR1-033");
                }
            }
        }

        bool fileCanReadAndWrite(string path)
        {
            var perm = new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write | System.Security.Permissions.FileIOPermissionAccess.Read, path);
            try
            {
                perm.Demand();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Form_Articulos_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

    }
}
