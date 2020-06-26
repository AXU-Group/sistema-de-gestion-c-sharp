namespace SG
{
    partial class MDIParentPadre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParentPadre));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.Sesion_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Login_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.Salir_toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.Ver_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturador_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Stock_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Proveedores_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.StatusBar_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Herramientas_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Opciones_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ventanas_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cascada_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Vertical_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Horizontal_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem27 = new System.Windows.Forms.ToolStripMenuItem();
            this.Ayuda_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Contenido_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Indice_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Buscar_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.Sobre_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_TextEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sesion_toolStripMenuItem,
            this.Ver_toolStripMenuItem,
            this.Herramientas_toolStripMenuItem,
            this.Ventanas_toolStripMenuItem,
            this.Ayuda_toolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.Ventanas_toolStripMenuItem;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip.Size = new System.Drawing.Size(310, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "MenuStrip";
            // 
            // Sesion_toolStripMenuItem
            // 
            this.Sesion_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Login_ToolStripMenuItem,
            this.toolStripSeparator12,
            this.Salir_toolStripMenuItem9});
            this.Sesion_toolStripMenuItem.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.Sesion_toolStripMenuItem.Name = "Sesion_toolStripMenuItem";
            this.Sesion_toolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.Sesion_toolStripMenuItem.Text = "&Sesion";
            // 
            // Login_ToolStripMenuItem
            // 
            this.Login_ToolStripMenuItem.Image = global::SG.Properties.Resources.key;
            this.Login_ToolStripMenuItem.Name = "Login_ToolStripMenuItem";
            this.Login_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.Login_ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.Login_ToolStripMenuItem.Text = "&Cerrar sesión";
            this.Login_ToolStripMenuItem.Click += new System.EventHandler(this.Login_toolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(172, 6);
            // 
            // Salir_toolStripMenuItem9
            // 
            this.Salir_toolStripMenuItem9.Name = "Salir_toolStripMenuItem9";
            this.Salir_toolStripMenuItem9.Size = new System.Drawing.Size(175, 22);
            this.Salir_toolStripMenuItem9.Text = "&Salir";
            this.Salir_toolStripMenuItem9.Click += new System.EventHandler(this.Salir_toolsStripMenuItem_Click);
            // 
            // Ver_toolStripMenuItem
            // 
            this.Ver_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.facturador_ToolStripMenuItem,
            this.Stock_ToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.Proveedores_ToolStripMenuItem,
            this.cajaToolStripMenuItem,
            this.toolStripSeparator17,
            this.StatusBar_toolStripMenuItem});
            this.Ver_toolStripMenuItem.Name = "Ver_toolStripMenuItem";
            this.Ver_toolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.Ver_toolStripMenuItem.Text = "&Ver";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.Usuarios_ToolStripMenuItem_Click);
            // 
            // facturador_ToolStripMenuItem
            // 
            this.facturador_ToolStripMenuItem.Name = "facturador_ToolStripMenuItem";
            this.facturador_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.facturador_ToolStripMenuItem.Text = "&Facturador";
            this.facturador_ToolStripMenuItem.Click += new System.EventHandler(this.Facturador_ToolStripMenuItem_Click);
            // 
            // Stock_ToolStripMenuItem
            // 
            this.Stock_ToolStripMenuItem.Name = "Stock_ToolStripMenuItem";
            this.Stock_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Stock_ToolStripMenuItem.Text = "&Articulos";
            this.Stock_ToolStripMenuItem.Click += new System.EventHandler(this.Stock_ToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clientesToolStripMenuItem.Text = "&Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.Clientes_ToolStripMenuItem_Click);
            // 
            // Proveedores_ToolStripMenuItem
            // 
            this.Proveedores_ToolStripMenuItem.Name = "Proveedores_ToolStripMenuItem";
            this.Proveedores_ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.Proveedores_ToolStripMenuItem.Text = "&Proveedores";
            this.Proveedores_ToolStripMenuItem.Click += new System.EventHandler(this.Proveedores_ToolStripMenuItem_Click_1);
            // 
            // cajaToolStripMenuItem
            // 
            this.cajaToolStripMenuItem.Name = "cajaToolStripMenuItem";
            this.cajaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cajaToolStripMenuItem.Text = "Caja";
            this.cajaToolStripMenuItem.Click += new System.EventHandler(this.Caja_ToolStripMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(149, 6);
            // 
            // StatusBar_toolStripMenuItem
            // 
            this.StatusBar_toolStripMenuItem.Checked = true;
            this.StatusBar_toolStripMenuItem.CheckOnClick = true;
            this.StatusBar_toolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StatusBar_toolStripMenuItem.Name = "StatusBar_toolStripMenuItem";
            this.StatusBar_toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.StatusBar_toolStripMenuItem.Text = "S&tatus Bar";
            this.StatusBar_toolStripMenuItem.Click += new System.EventHandler(this.StatusBar_toolStripMenuItem_Click);
            // 
            // Herramientas_toolStripMenuItem
            // 
            this.Herramientas_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Opciones_toolStripMenuItem,
            this.mantenimientoToolStripMenuItem});
            this.Herramientas_toolStripMenuItem.Name = "Herramientas_toolStripMenuItem";
            this.Herramientas_toolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.Herramientas_toolStripMenuItem.Text = "&Herramientas";
            // 
            // Opciones_toolStripMenuItem
            // 
            this.Opciones_toolStripMenuItem.Name = "Opciones_toolStripMenuItem";
            this.Opciones_toolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.Opciones_toolStripMenuItem.Text = "&Opciones";
            this.Opciones_toolStripMenuItem.Click += new System.EventHandler(this.Opciones_ToolStripMenuItem_Click);
            // 
            // mantenimientoToolStripMenuItem
            // 
            this.mantenimientoToolStripMenuItem.Enabled = false;
            this.mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            this.mantenimientoToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.mantenimientoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.mantenimientoToolStripMenuItem.Text = "&Mantenimiento";
            this.mantenimientoToolStripMenuItem.Visible = false;
            this.mantenimientoToolStripMenuItem.Click += new System.EventHandler(this.Mantenimiento_ToolStripMenuItem_Click);
            // 
            // Ventanas_toolStripMenuItem
            // 
            this.Ventanas_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cascada_toolStripMenuItem,
            this.Vertical_toolStripMenuItem,
            this.Horizontal_toolStripMenuItem,
            this.toolStripMenuItem27});
            this.Ventanas_toolStripMenuItem.Name = "Ventanas_toolStripMenuItem";
            this.Ventanas_toolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.Ventanas_toolStripMenuItem.Text = "V&entanas";
            // 
            // Cascada_toolStripMenuItem
            // 
            this.Cascada_toolStripMenuItem.Name = "Cascada_toolStripMenuItem";
            this.Cascada_toolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.Cascada_toolStripMenuItem.Text = "&Cascada";
            this.Cascada_toolStripMenuItem.Click += new System.EventHandler(this.Cascada_toolStripMenuItem_Click);
            // 
            // Vertical_toolStripMenuItem
            // 
            this.Vertical_toolStripMenuItem.Name = "Vertical_toolStripMenuItem";
            this.Vertical_toolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.Vertical_toolStripMenuItem.Text = "&Vertical";
            this.Vertical_toolStripMenuItem.Click += new System.EventHandler(this.Vertical_toolStripMenuItem_Click);
            // 
            // Horizontal_toolStripMenuItem
            // 
            this.Horizontal_toolStripMenuItem.Name = "Horizontal_toolStripMenuItem";
            this.Horizontal_toolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.Horizontal_toolStripMenuItem.Text = "&Horizontal";
            this.Horizontal_toolStripMenuItem.Click += new System.EventHandler(this.Horizontal_toolStripMenuItem_Click);
            // 
            // toolStripMenuItem27
            // 
            this.toolStripMenuItem27.Name = "toolStripMenuItem27";
            this.toolStripMenuItem27.Size = new System.Drawing.Size(137, 22);
            this.toolStripMenuItem27.Text = "C&errar Todas";
            this.toolStripMenuItem27.Click += new System.EventHandler(this.CerrarTodo_toolStripMenuItem_Click);
            // 
            // Ayuda_toolStripMenuItem
            // 
            this.Ayuda_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Contenido_toolStripMenuItem,
            this.Indice_toolStripMenuItem,
            this.Buscar_toolStripMenuItem,
            this.toolStripSeparator15,
            this.Sobre_toolStripMenuItem});
            this.Ayuda_toolStripMenuItem.Name = "Ayuda_toolStripMenuItem";
            this.Ayuda_toolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.Ayuda_toolStripMenuItem.Text = "&Ayuda";
            // 
            // Contenido_toolStripMenuItem
            // 
            this.Contenido_toolStripMenuItem.Name = "Contenido_toolStripMenuItem";
            this.Contenido_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.Contenido_toolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.Contenido_toolStripMenuItem.Text = "&Contenido";
            // 
            // Indice_toolStripMenuItem
            // 
            this.Indice_toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Indice_toolStripMenuItem.Image")));
            this.Indice_toolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.Indice_toolStripMenuItem.Name = "Indice_toolStripMenuItem";
            this.Indice_toolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.Indice_toolStripMenuItem.Text = "&Indice";
            // 
            // Buscar_toolStripMenuItem
            // 
            this.Buscar_toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Buscar_toolStripMenuItem.Image")));
            this.Buscar_toolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.Buscar_toolStripMenuItem.Name = "Buscar_toolStripMenuItem";
            this.Buscar_toolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.Buscar_toolStripMenuItem.Text = "&Buscar";
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(164, 6);
            // 
            // Sobre_toolStripMenuItem
            // 
            this.Sobre_toolStripMenuItem.Name = "Sobre_toolStripMenuItem";
            this.Sobre_toolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.Sobre_toolStripMenuItem.Text = "&Sobre.. ...";
            this.Sobre_toolStripMenuItem.Click += new System.EventHandler(this.Sobre_ToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_TextEstado,
            this.toolStripStatusLabel_Status,
            this.toolStripStatusLabel_Usuario,
            this.toolStripStatus_Usuario});
            this.statusStrip.Location = new System.Drawing.Point(0, 288);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(310, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel_TextEstado
            // 
            this.toolStripStatusLabel_TextEstado.Name = "toolStripStatusLabel_TextEstado";
            this.toolStripStatusLabel_TextEstado.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel_TextEstado.Text = "Estado";
            // 
            // toolStripStatusLabel_Status
            // 
            this.toolStripStatusLabel_Status.Name = "toolStripStatusLabel_Status";
            this.toolStripStatusLabel_Status.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel_Status.Text = ".";
            // 
            // toolStripStatusLabel_Usuario
            // 
            this.toolStripStatusLabel_Usuario.Name = "toolStripStatusLabel_Usuario";
            this.toolStripStatusLabel_Usuario.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel_Usuario.Text = "Usuario:";
            // 
            // toolStripStatus_Usuario
            // 
            this.toolStripStatus_Usuario.Name = "toolStripStatus_Usuario";
            this.toolStripStatus_Usuario.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatus_Usuario.Text = "x";
            // 
            // MDIParentPadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(310, 310);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(310, 310);
            this.Name = "MDIParentPadre";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vizsla";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIParentPadre_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MDIParentPadre_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MDIParentPadre_KeyPress);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStripMenuItem Sesion_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Login_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem Salir_toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem Ver_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatusBar_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Herramientas_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Opciones_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Ventanas_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Cascada_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Vertical_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Horizontal_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem27;
        private System.Windows.Forms.ToolStripMenuItem Ayuda_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Contenido_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Indice_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Buscar_toolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripMenuItem Sobre_toolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem Proveedores_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturador_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Stock_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Usuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_TextEstado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Usuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Status;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
    }
}



