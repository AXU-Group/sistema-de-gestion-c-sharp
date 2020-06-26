using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using manten;

namespace SG
{
    public partial class Form_Usuarios : Form
    {
        enviamail em = new enviamail();
        // Desde aca es el codigo para que se pueda abrir una sola vez este form
        private static Form_Usuarios m_FormDefInstance;
        public static Form_Usuarios DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Form_Usuarios();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        //Hasta aca

        public Form_Usuarios()
        {
            InitializeComponent();
        }

        private void button_A_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.textBox_A_Nombre.Text == "" || this.textBox_A_Apellido.Text == "" || this.textBox_A_Usuario.Text == "" || this.textBox_A_Clave.Text == "" || this.textBox_A_Clave2.Text == "" || this.comboBox_A_Nivel.Text == "" || this.textBox_A_Telefono.Text == "" || this.textBox_A_Celular.Text == "")
                {
                    MessageBox.Show("ATENCION: Debe conpletar todos los casilleros marcados con (*)", "Error: F-US1-002", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if(this.textBox_A_Clave.Text == this.textBox_A_Clave2.Text)
                    {
                        SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                        string sql = "INSERT INTO data_usuarios (nombre,apellido,login,password,usertype,tel_casa,tel_cel) VALUES ('" + this.textBox_A_Nombre.Text +
                            "', '" + this.textBox_A_Apellido.Text +
                            "', '" + this.textBox_A_Usuario.Text +
                            "', '" + this.textBox_A_Clave.Text +
                            "', '" + this.comboBox_A_Nivel.Text +
                            "', '" + this.textBox_A_Telefono.Text +
                            "', '" + this.textBox_A_Celular.Text +
                            "')";
                        SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();

                        MessageBox.Show("El usuario se ingreso correctamente.");
                        Limpiar_Formulario_Agregar();
                    }
                    else
                    {
                        MessageBox.Show("ATENCION: La verificación de la clave es incorrecta", "Error: F-US1-003", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-US1-004");
            }
        }

        private void button_E_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox_E_Nombre.Text == "" || this.textBox_E_Apellido.Text == "" || this.textBox_E_Usuario.Text == "" || this.textBox_E_Clave.Text == "" || this.textBox_E_Clave2.Text == "" || this.comboBox_E_Nivel.Text == "" || this.textBox_E_Telefono.Text == "" || this.textBox_E_Celular.Text == "")
                {
                    MessageBox.Show("ATENCION: Debe conpletar todos los casilleros marcados con (*)", "Error: F-US1-014", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (this.textBox_E_Clave.Text == this.textBox_E_Clave2.Text)
                    {
                        SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                        string sql = "UPDATE data_usuarios SET nombre = '" + this.textBox_E_Nombre.Text +
                        "', apellido = '" + this.textBox_E_Apellido.Text +
                        "', login = '" + this.textBox_E_Usuario.Text +
                        "', password = '" + this.textBox_E_Clave.Text +
                        "', usertype = '" + this.comboBox_E_Nivel.Text +
                        "', tel_casa = '" + this.textBox_E_Telefono.Text +
                        "', tel_cel = '" + this.textBox_E_Celular.Text +
                        "'";
                        SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();

                        MessageBox.Show("El usuario se actualizó correctamente.");
                        //Limpiar_Formulario_Editar();
                    }
                    else
                    {
                        MessageBox.Show("ATENCION: La verificación de la clave es incorrecta", "Error: F-US1-015", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-US1-016");
            }
        }

        private void buscar_Usuario(object sender, EventArgs e)
        {
            try
            {
                // Me conecto
                SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                DataSet sgdbDataSet = new DataSet();
                SqlCeCommand cmd = new SqlCeCommand();
                string sql = "SELECT id_usuario,nombre,apellido,login,password,usertype,tel_casa,tel_cel FROM data_usuarios WHERE upper(nombre) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(apellido) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(login) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(usertype) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(tel_cel) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') OR upper(tel_casa) LIKE upper('%" + this.toolStripTextBox_Buscar.Text + "%') AND usertype!='Root' ORDER BY nombre DESC";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "data_usuarios");

                BindingSource bindingSource = new BindingSource(sgdbDataSet.Tables[0], null);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Clear(); //Borro todas las columnas de dataGridView1

                dataGridView1.Columns.Add("VendedorNumero", "Vendedor N°"); //(nombre de la columna,Titulo de la columna)
                dataGridView1.Columns.Add("Nombre", "Nombre");
                dataGridView1.Columns.Add("Apellido", "Apellido");
                dataGridView1.Columns.Add("Usuario", "Usuario");
                dataGridView1.Columns.Add("Clave", "Clave");
                dataGridView1.Columns.Add("Nivel", "Nivel");
                dataGridView1.Columns.Add("Tel. Fijo", "Tel. Fijo");
                dataGridView1.Columns.Add("Tel. Celular", "Tel. Celular");

                //dataGridView1.Columns[0].Width = 110; // ancho de la columna
                //dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[0].DataPropertyName = "id_usuario"; //son los campos de la base de datos
                dataGridView1.Columns[1].DataPropertyName = "nombre";
                dataGridView1.Columns[2].DataPropertyName = "apellido";
                dataGridView1.Columns[3].DataPropertyName = "login";
                dataGridView1.Columns[4].DataPropertyName = "password";
                dataGridView1.Columns[5].DataPropertyName = "usertype";
                dataGridView1.Columns[6].DataPropertyName = "tel_casa";
                dataGridView1.Columns[7].DataPropertyName = "tel_cel";

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
                em.sendmail(ex, "Error: F-US1-007");
            }
        }

        private void toolStripButton_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea borrar el usuario?", "¡¡Atención!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                    {
                        SqlCeConnection conexion = new SqlCeConnection(MDIParentPadre.st_conexion);
                        string sql = "DELETE FROM data_usuarios WHERE id = '" + dataGridView1.SelectedCells[i].OwningRow.Cells[0].Value.ToString() + "'";

                        SqlCeCommand cmd = new SqlCeCommand(sql, conexion);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    buscar_Usuario(sender, e);

                    MessageBox.Show("Usuarios borrados correctamente", "Listo!");
                }
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-US1-008");
            }
        }

        private void toolStripButton_Editar_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabControl.SelectedTab = tabPage_Editar;
                Limpiar_Formulario_Editar();
                this.textBox_E_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.textBox_E_Nombre.Select();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-US1-009");
            }
        }

        private void toolStripButton_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar_Formulario_Agregar();
                this.tabControl.SelectedTab = tabPage_Agregar;
                this.textBox_A_Nombre.Select();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-US1-010");
            }
        }

        public void Limpiar_Formulario_Agregar()
        {
            try
            {
                this.textBox_A_Nombre.Text = "";
                this.textBox_A_Apellido.Text = "";
                this.textBox_A_Usuario.Text = "";
                this.textBox_A_Clave.Text = "";
                this.textBox_A_Clave2.Text = "";
                this.comboBox_A_Nivel.Text = "";
                this.textBox_A_Telefono.Text = "";
                this.textBox_A_Celular.Text = "";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-US1-005");
            }
        }

        public void Limpiar_Formulario_Editar()
        {
            try
            {
                this.textBox_E_Nombre.Text = "";
                this.textBox_E_Apellido.Text = "";
                this.textBox_E_Usuario.Text = "";
                this.textBox_E_Clave.Text = "";
                this.textBox_E_Clave2.Text = "";
                this.comboBox_E_Nivel.Text = "";
                this.textBox_E_Telefono.Text = "";
                this.textBox_E_Celular.Text = "";
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-US1-006");
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
                string sql = "SELECT nombre,apellido,login,password,usertype,tel_casa,tel_cel FROM data_usuarios WHERE upper(id_usuario) LIKE upper('" + this.textBox_E_ID.Text + "')";
                SqlCeDataAdapter da = new SqlCeDataAdapter(sql, conexion);

                da.Fill(sgdbDataSet, "data_usuarios");
                DataRow dRow = sgdbDataSet.Tables["data_usuarios"].Rows[0];

                this.textBox_E_Nombre.Text = dRow.ItemArray.GetValue(0).ToString();
                this.textBox_E_Apellido.Text = dRow.ItemArray.GetValue(1).ToString();
                this.textBox_E_Usuario.Text = dRow.ItemArray.GetValue(2).ToString();
                this.textBox_E_Clave.Text = dRow.ItemArray.GetValue(3).ToString();
                this.comboBox_E_Nivel.Text = dRow.ItemArray.GetValue(4).ToString();
                this.textBox_E_Telefono.Text = dRow.ItemArray.GetValue(5).ToString();
                this.textBox_E_Celular.Text = dRow.ItemArray.GetValue(6).ToString();
                conexion.Close();
            }
            catch (Exception ex)
            {
                em.sendmail(ex, "Error: F-US1-011");
            }
        }

        

    }
}
