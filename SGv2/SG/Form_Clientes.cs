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
    public partial class Form_Clientes : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_Clientes m_FormDefInstance;
        public static Form_Clientes DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_Clientes();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public Form_Clientes()
        {
            InitializeComponent();
            buscoUltimoID();
        }
        private void buscoUltimoID()
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT id_cp FROM cliente_proveedor ORDER BY id_cp DESC";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);
                da.Fill(sgdbDataSet, "cliente_proveedor");
                DataRow dRow = sgdbDataSet.Tables["cliente_proveedor"].Rows[0];
                this.textBox_A_ID.Text = (Convert.ToInt32(dRow.ItemArray.GetValue(0)) + 1).ToString();
            }
            catch (Exception ex)
            {
                
                em.sendmail(ex, "Error: F-CL1-000");
            }
        }
        private void buscarCp(object sender, EventArgs e)
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT [numero_id],[razon_social],[tel1],[email1] FROM cliente_proveedor WHERE numero_id LIKE '%" + this.toolStripTextBox_Buscar.Text + "%' OR upper(razon_social) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR tel1 LIKE '%" + this.toolStripTextBox_Buscar.Text + "%' OR email1 LIKE '%" + this.toolStripTextBox_Buscar.Text + "%' ORDER BY numero_id DESC";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "cliente_proveedor");

                BindingSource bindingSource = new BindingSource(sgdbDataSet.Tables[0], null);


                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear(); //Borro todas las columnas de dataGridView1

                dataGridView1.Columns.Add("ncliente", "Numero Cliente"); //(nombre de la columna,Titulo de la columna)
                dataGridView1.Columns.Add("RazonSocial", "Razon Social");
                dataGridView1.Columns.Add("Tel1", "Tel 1");
                dataGridView1.Columns.Add("Email1", "Email 1");

                dataGridView1.Columns[0].Width = 110; // ancho de la columna
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[0].DataPropertyName = "numero_id"; //son los campos de la base de datos
                dataGridView1.Columns[1].DataPropertyName = "razon_social";
                dataGridView1.Columns[2].DataPropertyName = "tel1";
                dataGridView1.Columns[3].DataPropertyName = "email1";

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
                em.sendmail(ex, "Error: F-CL1-001");
            }
        }

        private void button_A_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                int lista_fac = 0;
                int iva = 0;
                int habilitado = 1;
                int esCliente = 0;
                int esProveedor = 0;
                string DiaHora = DateTime.Today.ToString();
                if (this.radioButton_A_Fact1.Checked == true) lista_fac = 1;
                if (this.radioButton_A_Fact2.Checked == true) lista_fac = 2;
                if (this.radioButton_A_Fact3.Checked == true) lista_fac = 3;
                if (this.radioButton_A_HabSI.Checked == true) habilitado = 1;
                if (this.radioButton_A_HabNO.Checked == true) habilitado = 0;
                if (this.checkBox_A_Cliente.Checked == true) esCliente = 1;
                if (this.checkBox_A_Proveedor.Checked == true) esProveedor = 1;
                if (this.radioButton_A_IvaRNI.Checked == true) iva = 1;
                if (this.radioButton_A_IvaRI.Checked == true) iva = 2;
                if (this.radioButton_A_IvaCF.Checked == true) iva = 3;
                if (this.radioButton_A_IvaEXE.Checked == true) iva = 4;
                if (this.radioButton_A_IvaNR.Checked == true) iva = 5;
                if (this.radioButton_A_IvaMT.Checked == true) iva = 6;
                if (this.radioButton_A_IvaSC.Checked == true) iva = 7;
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                string sql = "INSERT INTO cliente_proveedor (numero_id,razon_social,tel1,tel2,tel3,fax1,fax2,fax3,cel1,domicilio_calle,domicilio_numero,domicilio_piso,domicilio_localidad,domicilio_cod_post,domicilio_provincia,email1,email2,email3,cuit,dni,fecha_nacimiento,fecha_alta,lista_facturacion,limite_credito,descuento,condicion_venta,transporte,observaciones,habilitado,creado_x_nombre,creado_x_fecha,editado_x_nombre,editado_x_fecha,domicilio_pais,es_cliente,es_proveedor,iva) VALUES ('" + Int32.Parse(this.textBox_A_ID.Text) +
                    "', '" + this.textBox_A_RazonSocial.Text +
                    "', '" + this.textBox_A_Tel1.Text +
                    "', '" + this.textBox_A_Tel2.Text +
                    "', '" + this.textBox_A_Tel3.Text +
                    "', '" + this.textBox_A_Fax1.Text +
                    "', '" + this.textBox_A_Fax2.Text +
                    "', '" + this.textBox_A_Fax3.Text +
                    "', '" + this.textBox_A_Cel1.Text +
                    "', '" + this.textBox_A_Calle.Text +
                    "', '" + this.textBox_A_Num.Text +
                    "', '" + this.textBox_A_Piso.Text +
                    "', '" + this.comboBox_A_Loc.Text +
                    "', '" + this.textBox_A_CodPos.Text +
                    "', '" + this.comboBox_A_Prov.Text +
                    "', '" + this.textBox_A_Email1.Text +
                    "', '" + this.textBox_A_Email2.Text +
                    "', '" + this.textBox_A_Email3.Text +
                    "', '" + this.textBox_A_CUIT.Text +
                    "', '" + this.textBox_A_DNI.Text +
                    "', '" + this.dateTimePicker_A_FechaNac.Text +
                    "', '" + this.dateTimePicker_A_FechaAlta.Text +
                    "', '" + lista_fac +
                    "', '" + this.textBox_A_LimiteCredito.Text +
                    "', '" + this.textBox_A_Desc.Text +
                    "', '" + this.textBox_A_CondVenta.Text +
                    "', '" + this.textBox_A_Transporte.Text +
                    "', '" + this.textBox_A_Obs.Text +
                    "', '" + habilitado +
                    "', '" + MDIParentPadre.MiVariable +
                    "', '" + DateTime.Now.ToString() +
                    "', '" + MDIParentPadre.MiVariable +
                    "', '" + DateTime.Now.ToString() +
                    "', '" + this.comboBox_A_Pais.Text +
                    "', '" + esCliente +
                    "', '" + esProveedor +
                    "', '" + iva +
                    "')";
                SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                MessageBox.Show("Registro Actualizado Correctamente.");
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-002");
            }
        }

        private void button_A_Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar_Formulario_Agregar();           
        }
        
        public void Limpiar_Formulario_Agregar()
        {
            try
            {
                this.textBox_A_Calle.Clear();
                this.textBox_A_CodPos.Clear();
                this.textBox_A_CondVenta.Clear();
                this.textBox_A_CUIT.Clear();
                this.textBox_A_Desc.Clear();
                this.textBox_A_DNI.Clear();
                this.textBox_A_Email1.Clear();
                this.textBox_A_Email2.Clear();
                this.textBox_A_Email3.Clear();
                this.textBox_A_Fax1.Clear();
                this.textBox_A_Fax2.Clear();
                this.textBox_A_Fax3.Clear();
                this.textBox_A_ID.Clear();
                this.textBox_A_LimiteCredito.Clear();
                this.textBox_A_Num.Clear();
                this.textBox_A_Obs.Clear();
                this.textBox_A_Piso.Clear();
                this.textBox_A_RazonSocial.Clear();
                this.textBox_A_Tel1.Clear();
                this.textBox_A_Tel2.Clear();
                this.textBox_A_Tel3.Clear();
                this.textBox_A_Transporte.Clear();
                this.radioButton_A_Fact1.Checked = true;
                this.radioButton_A_IvaCF.Checked = true;
                this.radioButton_A_HabSI.Checked = true;
                this.checkBox_A_Cliente.Checked = true;
                this.checkBox_A_Proveedor.Checked = false;
                this.dateTimePicker_A_FechaAlta.Text = "";
                this.dateTimePicker_A_FechaNac.Text = "";
                this.comboBox_A_Loc.Text = "";
                this.comboBox_A_Pais.Text = "";
                this.comboBox_A_Prov.Text = "";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-003");
            }
        }

        public void Limpiar_Formulario_Editar()
        {
            try
            {
                this.textBox_E_Calle.Clear();
                this.textBox_E_CodPos.Clear();
                this.textBox_E_CondVenta.Clear();
                this.textBox_E_CUIT.Clear();
                this.textBox_E_Desc.Clear();
                this.textBox_E_DNI.Clear();
                this.textBox_E_Email1.Clear();
                this.textBox_E_Email2.Clear();
                this.textBox_E_Email3.Clear();
                this.textBox_E_Fax1.Clear();
                this.textBox_E_Fax2.Clear();
                this.textBox_E_Fax3.Clear();
                this.textBox_E_ID.Clear();
                this.textBox_E_LimiteCredito.Clear();
                this.textBox_E_Num.Clear();
                this.textBox_E_Obs.Clear();
                this.textBox_E_Piso.Clear();
                this.textBox_E_RazonSocial.Clear();
                this.textBox_E_Tel1.Clear();
                this.textBox_E_Tel2.Clear();
                this.textBox_E_Tel3.Clear();
                this.textBox_E_Transporte.Clear();
                this.radioButton_E_Fac1.Checked = true;
                this.radioButton_E_IvaCF.Checked = true;
                this.radioButton_E_HabSI.Checked = true;
                this.checkBox_E_Cliente.Checked = true;
                this.checkBox_E_Proveedor.Checked = false;
                this.dateTimePicker_E_FechaAlta.Text = "";
                this.dateTimePicker_E_FechaNac.Text = "";
                this.comboBox_E_Loc.Text = "";
                this.comboBox_E_Pais.Text = "";
                this.comboBox_E_Prov.Text = "";
                this.label_E_CreXFecha.Text = "";
                this.label_E_CreXNom.Text = "";
                this.label_E_EditXFecha.Text = "";
                this.label_E_EditXNom.Text = "";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-004");
            }
        }

        private void Llena_Campos(object sender, EventArgs e)
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT * FROM cliente_proveedor WHERE numero_id = '" + this.textBox_E_ID.Text + "'";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "cliente_proveedor");
                DataRow dRow = sgdbDataSet.Tables["cliente_proveedor"].Rows[0];

                this.textBox_E_RazonSocial.Text = dRow.ItemArray.GetValue(1).ToString();
                this.textBox_E_Tel1.Text = dRow.ItemArray.GetValue(2).ToString();
                this.textBox_E_Tel2.Text = dRow.ItemArray.GetValue(3).ToString();
                this.textBox_E_Tel3.Text = dRow.ItemArray.GetValue(4).ToString();
                this.textBox_E_Fax1.Text = dRow.ItemArray.GetValue(5).ToString();
                this.textBox_E_Fax2.Text = dRow.ItemArray.GetValue(6).ToString();
                this.textBox_E_Fax3.Text = dRow.ItemArray.GetValue(7).ToString();
                this.textBox_E_Cel1.Text = dRow.ItemArray.GetValue(8).ToString();
                this.textBox_E_Calle.Text = dRow.ItemArray.GetValue(11).ToString();
                this.textBox_E_Num.Text = dRow.ItemArray.GetValue(12).ToString();
                this.textBox_E_Piso.Text = dRow.ItemArray.GetValue(13).ToString();
                this.comboBox_E_Loc.Text = dRow.ItemArray.GetValue(14).ToString();
                this.textBox_E_CodPos.Text = dRow.ItemArray.GetValue(15).ToString();
                this.comboBox_E_Prov.Text = dRow.ItemArray.GetValue(16).ToString();
                this.textBox_E_Email1.Text = dRow.ItemArray.GetValue(17).ToString();
                this.textBox_E_Email2.Text = dRow.ItemArray.GetValue(18).ToString();
                this.textBox_E_Email3.Text = dRow.ItemArray.GetValue(19).ToString();
                this.textBox_E_CUIT.Text = dRow.ItemArray.GetValue(20).ToString();
                this.textBox_E_DNI.Text = dRow.ItemArray.GetValue(21).ToString();
                this.dateTimePicker_E_FechaNac.Text = dRow.ItemArray.GetValue(22).ToString();
                this.dateTimePicker_E_FechaAlta.Text = dRow.ItemArray.GetValue(23).ToString();
                switch (Int32.Parse(dRow.ItemArray.GetValue(24).ToString()))
                {
                    case 1: this.radioButton_E_Fac1.Checked = true; break;
                    case 2: this.radioButton_E_Fac2.Checked = true; break;
                    case 3: this.radioButton_E_Fac3.Checked = true; break;
                    default: break;
                }
                this.textBox_E_LimiteCredito.Text = dRow.ItemArray.GetValue(25).ToString();
                this.textBox_E_Desc.Text = dRow.ItemArray.GetValue(26).ToString();
                this.textBox_E_CondVenta.Text = dRow.ItemArray.GetValue(27).ToString();
                this.textBox_E_Transporte.Text = dRow.ItemArray.GetValue(28).ToString();
                this.textBox_E_Obs.Text = dRow.ItemArray.GetValue(29).ToString();
                switch (Int32.Parse(dRow.ItemArray.GetValue(30).ToString()))
                {
                    case 1: this.radioButton_E_HabSI.Checked = true; break;
                    case 0: this.radioButton_E_HabNO.Checked = true; break;
                    default: break;
                }
                this.label_E_CreXNom.Text = dRow.ItemArray.GetValue(31).ToString();
                this.label_E_CreXFecha.Text = dRow.ItemArray.GetValue(32).ToString();
                this.label_E_EditXNom.Text = dRow.ItemArray.GetValue(33).ToString();
                this.label_E_EditXFecha.Text = dRow.ItemArray.GetValue(34).ToString();
                this.comboBox_E_Pais.Text = dRow.ItemArray.GetValue(35).ToString();
                if (Int32.Parse(dRow.ItemArray.GetValue(36).ToString()) == 1)
                    this.checkBox_E_Cliente.Checked = true;
                else this.checkBox_E_Cliente.Checked = false;
                if (Int32.Parse(dRow.ItemArray.GetValue(37).ToString()) == 1)
                    this.checkBox_E_Proveedor.Checked = true;
                else this.checkBox_E_Proveedor.Checked = false;
                switch (Int32.Parse(dRow.ItemArray.GetValue(39).ToString()))
                {
                    case 1: this.radioButton_E_IvaRNI.Checked = true; break;
                    case 2: this.radioButton_E_IvaRI.Checked = true; break;
                    case 3: this.radioButton_E_IvaCF.Checked = true; break;
                    case 4: this.radioButton_E_IvaEXE.Checked = true; break;
                    case 5: this.radioButton_E_IvaNR.Checked = true; break;
                    case 6: this.radioButton_E_IvaMT.Checked = true; break;
                    case 7: this.radioButton_E_IvaSC.Checked = true; break;
                    default: break;
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-005");
            }
        }

        private void button_E_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int lista_fac = 0;
                int iva = 0;
                int habilitado = 1;
                int esCliente = 0;
                int esProveedor = 0;
                string DiaHora = DateTime.Today.ToString();
                if (this.radioButton_E_Fac1.Checked == true) lista_fac = 1;
                if (this.radioButton_E_Fac2.Checked == true) lista_fac = 2;
                if (this.radioButton_E_Fac3.Checked == true) lista_fac = 3;
                if (this.radioButton_E_HabSI.Checked == true) habilitado = 1;
                if (this.radioButton_E_HabNO.Checked == true) habilitado = 0;
                if (this.checkBox_E_Cliente.Checked == true) esCliente = 1;
                if (this.checkBox_E_Proveedor.Checked == true) esProveedor = 1;
                if (this.radioButton_E_IvaRNI.Checked == true) iva = 1;
                if (this.radioButton_E_IvaRI.Checked == true) iva = 2;
                if (this.radioButton_E_IvaCF.Checked == true) iva = 3;
                if (this.radioButton_E_IvaEXE.Checked == true) iva = 4;
                if (this.radioButton_E_IvaNR.Checked == true) iva = 5;
                if (this.radioButton_E_IvaMT.Checked == true) iva = 6;
                if (this.radioButton_E_IvaSC.Checked == true) iva = 7;
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                string sql = "UPDATE cliente_proveedor SET razon_social ='" + this.textBox_E_RazonSocial.Text +
                    "', tel1='" + this.textBox_E_Tel1.Text +
                    "', tel2='" + this.textBox_E_Tel2.Text +
                    "', tel3='" + this.textBox_E_Tel3.Text +
                    "', fax1='" + this.textBox_E_Fax1.Text +
                    "', fax2='" + this.textBox_E_Fax2.Text +
                    "', fax3='" + this.textBox_E_Fax3.Text +
                    "', cel1='" + this.textBox_E_Cel1.Text +
                    "', domicilio_calle='" + this.textBox_E_Calle.Text +
                    "', domicilio_numero='" + this.textBox_E_Num.Text +
                    "', domicilio_piso='" + this.textBox_E_Piso.Text +
                    "', domicilio_localidad='" + this.comboBox_E_Loc.Text +
                    "', domicilio_cod_post='" + this.textBox_E_CodPos.Text +
                    "', domicilio_provincia='" + this.comboBox_E_Prov.Text +
                    "', email1='" + this.textBox_E_Email1.Text +
                    "', email2='" + this.textBox_E_Email2.Text +
                    "', email3='" + this.textBox_E_Email3.Text +
                    "', cuit='" + this.textBox_E_CUIT.Text +
                    "', dni='" + this.textBox_E_DNI.Text +
                    "', fecha_nacimiento='" + this.dateTimePicker_E_FechaNac.Text +
                    "', fecha_alta='" + this.dateTimePicker_E_FechaAlta.Text +
                    "', lista_facturacion='" + lista_fac +
                    "', limite_credito='" + this.textBox_E_LimiteCredito.Text +
                    "', descuento='" + this.textBox_E_Desc.Text +
                    "', condicion_venta='" + this.textBox_E_CondVenta.Text +
                    "', transporte='" + this.textBox_E_Transporte.Text +
                    "', observaciones='" + this.textBox_E_Obs.Text +
                    "', habilitado='" + habilitado +
                    "', creado_x_nombre='" + this.label_E_CreXNom.Text +
                    "', creado_x_fecha='" + this.label_E_CreXFecha.Text +
                    "', editado_x_nombre='" + MDIParentPadre.MiVariable +
                    "', editado_x_fecha='" + DateTime.Now +
                    "', domicilio_pais='" + this.comboBox_E_Pais.Text +
                    "', es_cliente='" + esCliente +
                    "', es_proveedor='" + esProveedor +
                    "', iva='" + iva +
                    "' WHERE numero_id = '" + this.textBox_E_ID.Text + "'";
                SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                MessageBox.Show("Registro Actualizado Correctamente.");
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-006");
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl.SelectedTab = tabPage_Editar;
                Limpiar_Formulario_Editar();
                this.textBox_E_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.textBox_E_ID.Select();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-007");
            }
        }

        private void toolStripButton_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea borrar el Cliente/Proveedor?", "¡¡Atención!!", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                    string sql = "DELETE FROM cliente_proveedor WHERE numero_id = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                    SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    MessageBox.Show("Articulo borrado correctamente");
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-008");
            }
        }

        private void toolStripButton_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl.SelectedTab = tabPage_Agregar;
                Limpiar_Formulario_Agregar();
                textBox_A_ID.Select();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-009");
            }
        }

        private void Lleno_ComboBoxPais()
        {
            try // para Paises
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                
                string sql = "SELECT [nombre_pais] FROM Paises";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "Paises");
                int cantidad = sgdbDataSet.Tables["Paises"].Rows.Count;

                if (cantidad != 0)
                {
                    for (int i = 0; i < cantidad; i++)
                    {
                        this.comboBox_A_Pais.Items.AddRange(new object[] {
                        sgdbDataSet.Tables["Paises"].Rows[i]["nombre_pais"]});
                        this.comboBox_E_Pais.Items.AddRange(new object[] {
                        sgdbDataSet.Tables["Paises"].Rows[i]["nombre_pais"]}); 
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-010");
            }            
        }

        private void Lleno_ComboBoxProvincia(string Pais, object sender)
        {
            try // para Provincias
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();

                string sql = "SELECT [codigo_pais] FROM Paises WHERE nombre_pais = '" + Pais + "'";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "Paises");
                DataRow dRow = sgdbDataSet.Tables["Paises"].Rows[0];

                sql = "SELECT [nombre_provincia] FROM Provincias WHERE pais = '" + dRow.ItemArray.GetValue(0).ToString() + "'";
                da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "Provincias");
                int cantidad = sgdbDataSet.Tables["Provincias"].Rows.Count;

                if (cantidad != 0)
                {
                    for (int i = 0; i < cantidad; i++)
                    {
                        if (sender == this.comboBox_A_Pais)
                        {
                            this.comboBox_A_Prov.Items.AddRange(new object[] {
                            sgdbDataSet.Tables["Provincias"].Rows[i]["nombre_provincia"]});
                        }
                        if (sender == this.comboBox_E_Pais)
                        {
                            this.comboBox_E_Prov.Items.AddRange(new object[] {
                            sgdbDataSet.Tables["Provincias"].Rows[i]["nombre_provincia"]});
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-011");
            }
        }

        private void Lleno_ComboBoxLocalidades()
        {
            try // para Localidades
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();

                string sql = "SELECT [nombre_pais] FROM Paises";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "Paises");
                int cantidad = sgdbDataSet.Tables["Paises"].Rows.Count;

                if (cantidad != 0)
                {
                    for (int i = 0; i < cantidad; i++)
                    {
                        this.comboBox_A_Pais.Items.AddRange(new object[] {
                    sgdbDataSet.Tables["Paises"].Rows[i]["nombre_pais"]});
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-CL1-012");
            }
        }
        
        private void Form_Clientes_Load(object sender, EventArgs e)
        {
            Lleno_ComboBoxPais();
        }

        private void Busco_Provincia(object sender, EventArgs e)
        {
            if (sender == this.comboBox_A_Pais)
            {
                this.comboBox_A_Prov.Items.Clear();
                this.comboBox_A_Prov.Text = "";
                Lleno_ComboBoxProvincia(this.comboBox_A_Pais.Text, this.comboBox_A_Pais);
            }
            if (sender == this.comboBox_E_Pais)
            {
                this.comboBox_E_Prov.Items.Clear();
                this.comboBox_E_Prov.Text = "";
                Lleno_ComboBoxProvincia(this.comboBox_E_Pais.Text, this.comboBox_E_Pais);
            }
        }
    }
}
