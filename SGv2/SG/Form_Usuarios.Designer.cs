namespace SG
{
    partial class Form_Usuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Usuarios));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_Buscar = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_Buscar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Eliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Editar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Nuevo = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabPage_Agregar = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_A_Nivel = new System.Windows.Forms.ComboBox();
            this.textBox_A_Celular = new System.Windows.Forms.TextBox();
            this.label121 = new System.Windows.Forms.Label();
            this.textBox_A_Usuario = new System.Windows.Forms.TextBox();
            this.textBox_A_Clave2 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button_A_Guardar = new System.Windows.Forms.Button();
            this.textBox_A_Telefono = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_A_Clave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_A_Apellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_A_Nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_Editar = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_E_Nivel = new System.Windows.Forms.ComboBox();
            this.textBox_E_ID = new System.Windows.Forms.TextBox();
            this.textBox_E_Celular = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_E_Usuario = new System.Windows.Forms.TextBox();
            this.textBox_E_Clave2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_E_Guardar = new System.Windows.Forms.Button();
            this.textBox_E_Telefono = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_E_Clave = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_E_Apellido = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_E_Nombre = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage_Buscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.tabPage_Agregar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_Editar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_Buscar);
            this.tabControl.Controls.Add(this.tabPage_Agregar);
            this.tabControl.Controls.Add(this.tabPage_Editar);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeftLayout = true;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(350, 299);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage_Buscar
            // 
            this.tabPage_Buscar.Controls.Add(this.dataGridView1);
            this.tabPage_Buscar.Controls.Add(this.bindingNavigator1);
            this.tabPage_Buscar.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Buscar.Name = "tabPage_Buscar";
            this.tabPage_Buscar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Buscar.Size = new System.Drawing.Size(342, 273);
            this.tabPage_Buscar.TabIndex = 0;
            this.tabPage_Buscar.Text = "Buscar - Editar - Eliminar";
            this.tabPage_Buscar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.Size = new System.Drawing.Size(336, 242);
            this.dataGridView1.TabIndex = 1;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox_Buscar,
            this.toolStripSeparator1,
            this.bindingNavigatorSeparator,
            this.toolStripButton_Eliminar,
            this.toolStripButton_Editar,
            this.toolStripButton_Nuevo,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorSeparator1});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 3);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.bindingNavigator1.Size = new System.Drawing.Size(336, 25);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Buscar";
            // 
            // toolStripTextBox_Buscar
            // 
            this.toolStripTextBox_Buscar.Name = "toolStripTextBox_Buscar";
            this.toolStripTextBox_Buscar.Size = new System.Drawing.Size(150, 25);
            this.toolStripTextBox_Buscar.TextChanged += new System.EventHandler(this.buscar_Usuario);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_Eliminar
            // 
            this.toolStripButton_Eliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Eliminar.Enabled = false;
            this.toolStripButton_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Eliminar.Image")));
            this.toolStripButton_Eliminar.Name = "toolStripButton_Eliminar";
            this.toolStripButton_Eliminar.RightToLeftAutoMirrorImage = true;
            this.toolStripButton_Eliminar.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Eliminar.Text = "Eliminar Usuario";
            this.toolStripButton_Eliminar.Click += new System.EventHandler(this.toolStripButton_Eliminar_Click);
            // 
            // toolStripButton_Editar
            // 
            this.toolStripButton_Editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Editar.Enabled = false;
            this.toolStripButton_Editar.Image = global::SG.Properties.Resources.b_edit;
            this.toolStripButton_Editar.Name = "toolStripButton_Editar";
            this.toolStripButton_Editar.RightToLeftAutoMirrorImage = true;
            this.toolStripButton_Editar.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Editar.Text = "Editar Usuario";
            this.toolStripButton_Editar.Click += new System.EventHandler(this.toolStripButton_Editar_Click);
            // 
            // toolStripButton_Nuevo
            // 
            this.toolStripButton_Nuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Nuevo.Enabled = false;
            this.toolStripButton_Nuevo.Image = global::SG.Properties.Resources.b_ver;
            this.toolStripButton_Nuevo.Name = "toolStripButton_Nuevo";
            this.toolStripButton_Nuevo.RightToLeftAutoMirrorImage = true;
            this.toolStripButton_Nuevo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Nuevo.Text = "Nuevo Usuario";
            this.toolStripButton_Nuevo.Click += new System.EventHandler(this.toolStripButton_Nuevo_Click);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(30, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tabPage_Agregar
            // 
            this.tabPage_Agregar.Controls.Add(this.groupBox1);
            this.tabPage_Agregar.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Agregar.Name = "tabPage_Agregar";
            this.tabPage_Agregar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Agregar.Size = new System.Drawing.Size(342, 273);
            this.tabPage_Agregar.TabIndex = 1;
            this.tabPage_Agregar.Text = "Agregar Articulo";
            this.tabPage_Agregar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_A_Nivel);
            this.groupBox1.Controls.Add(this.textBox_A_Celular);
            this.groupBox1.Controls.Add(this.label121);
            this.groupBox1.Controls.Add(this.textBox_A_Usuario);
            this.groupBox1.Controls.Add(this.textBox_A_Clave2);
            this.groupBox1.Controls.Add(this.label65);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.button_A_Guardar);
            this.groupBox1.Controls.Add(this.textBox_A_Telefono);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_A_Clave);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_A_Apellido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_A_Nombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 267);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox_A_Nivel
            // 
            this.comboBox_A_Nivel.FormattingEnabled = true;
            this.comboBox_A_Nivel.Items.AddRange(new object[] {
            "Administrador",
            "Vendedor"});
            this.comboBox_A_Nivel.Location = new System.Drawing.Point(83, 146);
            this.comboBox_A_Nivel.Name = "comboBox_A_Nivel";
            this.comboBox_A_Nivel.Size = new System.Drawing.Size(233, 21);
            this.comboBox_A_Nivel.TabIndex = 6;
            // 
            // textBox_A_Celular
            // 
            this.textBox_A_Celular.Location = new System.Drawing.Point(83, 199);
            this.textBox_A_Celular.Name = "textBox_A_Celular";
            this.textBox_A_Celular.Size = new System.Drawing.Size(233, 20);
            this.textBox_A_Celular.TabIndex = 8;
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(6, 203);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(60, 13);
            this.label121.TabIndex = 53;
            this.label121.Text = "Tel. Celular";
            // 
            // textBox_A_Usuario
            // 
            this.textBox_A_Usuario.Location = new System.Drawing.Point(83, 65);
            this.textBox_A_Usuario.MaxLength = 100;
            this.textBox_A_Usuario.Name = "textBox_A_Usuario";
            this.textBox_A_Usuario.Size = new System.Drawing.Size(233, 20);
            this.textBox_A_Usuario.TabIndex = 3;
            // 
            // textBox_A_Clave2
            // 
            this.textBox_A_Clave2.Location = new System.Drawing.Point(83, 120);
            this.textBox_A_Clave2.MaxLength = 100;
            this.textBox_A_Clave2.Name = "textBox_A_Clave2";
            this.textBox_A_Clave2.PasswordChar = '*';
            this.textBox_A_Clave2.Size = new System.Drawing.Size(233, 20);
            this.textBox_A_Clave2.TabIndex = 5;
            this.textBox_A_Clave2.UseSystemPasswordChar = true;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(7, 70);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(43, 13);
            this.label65.TabIndex = 44;
            this.label65.Text = "Usuario";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 124);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 13);
            this.label19.TabIndex = 43;
            this.label19.Text = "Repetir clave";
            // 
            // button_A_Guardar
            // 
            this.button_A_Guardar.Location = new System.Drawing.Point(213, 225);
            this.button_A_Guardar.Name = "button_A_Guardar";
            this.button_A_Guardar.Size = new System.Drawing.Size(103, 23);
            this.button_A_Guardar.TabIndex = 22;
            this.button_A_Guardar.Text = "Guardar Usuario";
            this.button_A_Guardar.UseVisualStyleBackColor = true;
            this.button_A_Guardar.Click += new System.EventHandler(this.button_A_Guardar_Click);
            // 
            // textBox_A_Telefono
            // 
            this.textBox_A_Telefono.Location = new System.Drawing.Point(83, 173);
            this.textBox_A_Telefono.MaxLength = 50;
            this.textBox_A_Telefono.Name = "textBox_A_Telefono";
            this.textBox_A_Telefono.Size = new System.Drawing.Size(233, 20);
            this.textBox_A_Telefono.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tel. Fijo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nivel";
            // 
            // textBox_A_Clave
            // 
            this.textBox_A_Clave.Location = new System.Drawing.Point(83, 93);
            this.textBox_A_Clave.MaxLength = 300;
            this.textBox_A_Clave.Name = "textBox_A_Clave";
            this.textBox_A_Clave.PasswordChar = '*';
            this.textBox_A_Clave.Size = new System.Drawing.Size(233, 20);
            this.textBox_A_Clave.TabIndex = 4;
            this.textBox_A_Clave.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Clave";
            // 
            // textBox_A_Apellido
            // 
            this.textBox_A_Apellido.Location = new System.Drawing.Point(83, 39);
            this.textBox_A_Apellido.MaxLength = 100;
            this.textBox_A_Apellido.Name = "textBox_A_Apellido";
            this.textBox_A_Apellido.Size = new System.Drawing.Size(233, 20);
            this.textBox_A_Apellido.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // textBox_A_Nombre
            // 
            this.textBox_A_Nombre.Location = new System.Drawing.Point(83, 13);
            this.textBox_A_Nombre.MaxLength = 100;
            this.textBox_A_Nombre.Name = "textBox_A_Nombre";
            this.textBox_A_Nombre.Size = new System.Drawing.Size(233, 20);
            this.textBox_A_Nombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // tabPage_Editar
            // 
            this.tabPage_Editar.Controls.Add(this.groupBox2);
            this.tabPage_Editar.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Editar.Name = "tabPage_Editar";
            this.tabPage_Editar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Editar.Size = new System.Drawing.Size(342, 273);
            this.tabPage_Editar.TabIndex = 2;
            this.tabPage_Editar.Text = "Editar";
            this.tabPage_Editar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_E_Nivel);
            this.groupBox2.Controls.Add(this.textBox_E_ID);
            this.groupBox2.Controls.Add(this.textBox_E_Celular);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_E_Usuario);
            this.groupBox2.Controls.Add(this.textBox_E_Clave2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.button_E_Guardar);
            this.groupBox2.Controls.Add(this.textBox_E_Telefono);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox_E_Clave);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox_E_Apellido);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox_E_Nombre);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(7, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 267);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // comboBox_E_Nivel
            // 
            this.comboBox_E_Nivel.FormattingEnabled = true;
            this.comboBox_E_Nivel.Items.AddRange(new object[] {
            "Administrador",
            "Vendedor"});
            this.comboBox_E_Nivel.Location = new System.Drawing.Point(83, 146);
            this.comboBox_E_Nivel.Name = "comboBox_E_Nivel";
            this.comboBox_E_Nivel.Size = new System.Drawing.Size(233, 21);
            this.comboBox_E_Nivel.TabIndex = 6;
            // 
            // textBox_E_ID
            // 
            this.textBox_E_ID.Location = new System.Drawing.Point(83, 227);
            this.textBox_E_ID.Name = "textBox_E_ID";
            this.textBox_E_ID.ReadOnly = true;
            this.textBox_E_ID.Size = new System.Drawing.Size(91, 20);
            this.textBox_E_ID.TabIndex = 55;
            // 
            // textBox_E_Celular
            // 
            this.textBox_E_Celular.Location = new System.Drawing.Point(83, 199);
            this.textBox_E_Celular.Name = "textBox_E_Celular";
            this.textBox_E_Celular.Size = new System.Drawing.Size(233, 20);
            this.textBox_E_Celular.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Tel. Celular";
            // 
            // textBox_E_Usuario
            // 
            this.textBox_E_Usuario.Location = new System.Drawing.Point(83, 65);
            this.textBox_E_Usuario.MaxLength = 100;
            this.textBox_E_Usuario.Name = "textBox_E_Usuario";
            this.textBox_E_Usuario.Size = new System.Drawing.Size(233, 20);
            this.textBox_E_Usuario.TabIndex = 3;
            // 
            // textBox_E_Clave2
            // 
            this.textBox_E_Clave2.Location = new System.Drawing.Point(83, 120);
            this.textBox_E_Clave2.MaxLength = 100;
            this.textBox_E_Clave2.Name = "textBox_E_Clave2";
            this.textBox_E_Clave2.PasswordChar = '*';
            this.textBox_E_Clave2.Size = new System.Drawing.Size(233, 20);
            this.textBox_E_Clave2.TabIndex = 5;
            this.textBox_E_Clave2.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Usuario";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Repetir clave";
            // 
            // button_E_Guardar
            // 
            this.button_E_Guardar.Location = new System.Drawing.Point(213, 225);
            this.button_E_Guardar.Name = "button_E_Guardar";
            this.button_E_Guardar.Size = new System.Drawing.Size(103, 23);
            this.button_E_Guardar.TabIndex = 22;
            this.button_E_Guardar.Text = "Guardar Usuario";
            this.button_E_Guardar.UseVisualStyleBackColor = true;
            this.button_E_Guardar.Click += new System.EventHandler(this.button_E_Guardar_Click);
            // 
            // textBox_E_Telefono
            // 
            this.textBox_E_Telefono.Location = new System.Drawing.Point(83, 173);
            this.textBox_E_Telefono.MaxLength = 50;
            this.textBox_E_Telefono.Name = "textBox_E_Telefono";
            this.textBox_E_Telefono.Size = new System.Drawing.Size(233, 20);
            this.textBox_E_Telefono.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Tel. Fijo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Nivel";
            // 
            // textBox_E_Clave
            // 
            this.textBox_E_Clave.Location = new System.Drawing.Point(83, 93);
            this.textBox_E_Clave.MaxLength = 300;
            this.textBox_E_Clave.Name = "textBox_E_Clave";
            this.textBox_E_Clave.PasswordChar = '*';
            this.textBox_E_Clave.Size = new System.Drawing.Size(233, 20);
            this.textBox_E_Clave.TabIndex = 4;
            this.textBox_E_Clave.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Clave";
            // 
            // textBox_E_Apellido
            // 
            this.textBox_E_Apellido.Location = new System.Drawing.Point(83, 39);
            this.textBox_E_Apellido.MaxLength = 100;
            this.textBox_E_Apellido.Name = "textBox_E_Apellido";
            this.textBox_E_Apellido.ReadOnly = true;
            this.textBox_E_Apellido.Size = new System.Drawing.Size(233, 20);
            this.textBox_E_Apellido.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Apellido";
            // 
            // textBox_E_Nombre
            // 
            this.textBox_E_Nombre.Location = new System.Drawing.Point(83, 13);
            this.textBox_E_Nombre.MaxLength = 100;
            this.textBox_E_Nombre.Name = "textBox_E_Nombre";
            this.textBox_E_Nombre.ReadOnly = true;
            this.textBox_E_Nombre.Size = new System.Drawing.Size(233, 20);
            this.textBox_E_Nombre.TabIndex = 1;
            this.textBox_E_Nombre.Enter += new System.EventHandler(this.Llena_Campos);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nombre";
            // 
            // Form_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 299);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Usuarios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Usuarios";
            this.tabControl.ResumeLayout(false);
            this.tabPage_Buscar.ResumeLayout(false);
            this.tabPage_Buscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.tabPage_Agregar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_Editar.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_Buscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton toolStripButton_Eliminar;
        private System.Windows.Forms.ToolStripButton toolStripButton_Editar;
        private System.Windows.Forms.ToolStripButton toolStripButton_Nuevo;
        private System.Windows.Forms.TabPage tabPage_Agregar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_A_Celular;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.TextBox textBox_A_Usuario;
        private System.Windows.Forms.TextBox textBox_A_Clave2;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_A_Guardar;
        private System.Windows.Forms.TextBox textBox_A_Telefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_A_Clave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_A_Apellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_A_Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_Editar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_E_Celular;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_E_Usuario;
        private System.Windows.Forms.TextBox textBox_E_Clave2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_E_Guardar;
        private System.Windows.Forms.TextBox textBox_E_Telefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_E_Clave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_E_Apellido;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_E_Nombre;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_E_ID;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ComboBox comboBox_A_Nivel;
        private System.Windows.Forms.ComboBox comboBox_E_Nivel;
    }
}