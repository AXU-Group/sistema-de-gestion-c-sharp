namespace SG
{
    partial class Form_Caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Caja));
            this.comboBox_C_TipoFactura = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_C_Fecha = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_F_TOTAL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_C_CondVenta = new System.Windows.Forms.ComboBox();
            this.comboBox_C_Vendedor = new System.Windows.Forms.ComboBox();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_C_TipoFactura
            // 
            this.comboBox_C_TipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_C_TipoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_C_TipoFactura.FormattingEnabled = true;
            this.comboBox_C_TipoFactura.Items.AddRange(new object[] {
            "",
            "A",
            "B",
            "C",
            "Ticket",
            "Remito",
            "MovStock",
            "NC",
            "NP",
            "Presupuesto"});
            this.comboBox_C_TipoFactura.Location = new System.Drawing.Point(688, 13);
            this.comboBox_C_TipoFactura.Name = "comboBox_C_TipoFactura";
            this.comboBox_C_TipoFactura.Size = new System.Drawing.Size(157, 21);
            this.comboBox_C_TipoFactura.TabIndex = 3;
            this.comboBox_C_TipoFactura.SelectionChangeCommitted += new System.EventHandler(this.calculoCaja);
            // 
            // dateTimePicker_C_Fecha
            // 
            this.dateTimePicker_C_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_C_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_C_Fecha.Location = new System.Drawing.Point(521, 13);
            this.dateTimePicker_C_Fecha.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker_C_Fecha.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker_C_Fecha.Name = "dateTimePicker_C_Fecha";
            this.dateTimePicker_C_Fecha.RightToLeftLayout = true;
            this.dateTimePicker_C_Fecha.Size = new System.Drawing.Size(86, 20);
            this.dateTimePicker_C_Fecha.TabIndex = 4;
            this.dateTimePicker_C_Fecha.TabStop = false;
            this.dateTimePicker_C_Fecha.Value = new System.DateTime(2014, 7, 6, 0, 0, 0, 0);
            this.dateTimePicker_C_Fecha.ValueChanged += new System.EventHandler(this.calculoCaja);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView1);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.comboBox_C_CondVenta);
            this.groupBox5.Controls.Add(this.comboBox_C_TipoFactura);
            this.groupBox5.Controls.Add(this.dateTimePicker_C_Fecha);
            this.groupBox5.Controls.Add(this.comboBox_C_Vendedor);
            this.groupBox5.Location = new System.Drawing.Point(3, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(854, 436);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 40);
            this.dataGridView1.MaximumSize = new System.Drawing.Size(836, 337);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(836, 337);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(836, 337);
            this.dataGridView1.TabIndex = 93;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(612, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Comprobante";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label_F_TOTAL);
            this.panel1.Location = new System.Drawing.Point(691, 383);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 42);
            this.panel1.TabIndex = 92;
            // 
            // label_F_TOTAL
            // 
            this.label_F_TOTAL.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_F_TOTAL.ForeColor = System.Drawing.Color.Lime;
            this.label_F_TOTAL.Location = new System.Drawing.Point(3, 9);
            this.label_F_TOTAL.Name = "label_F_TOTAL";
            this.label_F_TOTAL.Size = new System.Drawing.Size(151, 22);
            this.label_F_TOTAL.TabIndex = 1;
            this.label_F_TOTAL.Text = "0.00";
            this.label_F_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Fecha";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(611, 393);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 24);
            this.label24.TabIndex = 91;
            this.label24.Text = "TOTAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Condicion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Vendedor / Caja";
            // 
            // comboBox_C_CondVenta
            // 
            this.comboBox_C_CondVenta.FormattingEnabled = true;
            this.comboBox_C_CondVenta.Items.AddRange(new object[] {
            "",
            "Contado",
            "Cuenta Corriente",
            "1 pago - Tarjeta de Debito",
            "3 pagos - Tarjeta de Debito",
            "6 pagos - Tarjeta de Debito",
            "1 pago - Tarjeta de Credito",
            "3 pagos- Tarjeta de Credito",
            "6 pagos - Tarjeta de Credito",
            "12 pagos - Tarjeta de Credito"});
            this.comboBox_C_CondVenta.Location = new System.Drawing.Point(317, 12);
            this.comboBox_C_CondVenta.Name = "comboBox_C_CondVenta";
            this.comboBox_C_CondVenta.Size = new System.Drawing.Size(157, 21);
            this.comboBox_C_CondVenta.TabIndex = 85;
            this.comboBox_C_CondVenta.SelectionChangeCommitted += new System.EventHandler(this.calculoCaja);
            // 
            // comboBox_C_Vendedor
            // 
            this.comboBox_C_Vendedor.Location = new System.Drawing.Point(97, 12);
            this.comboBox_C_Vendedor.Name = "comboBox_C_Vendedor";
            this.comboBox_C_Vendedor.Size = new System.Drawing.Size(157, 21);
            this.comboBox_C_Vendedor.TabIndex = 7;
            this.comboBox_C_Vendedor.SelectionChangeCommitted += new System.EventHandler(this.calculoCaja);
            // 
            // Form_Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 441);
            this.Controls.Add(this.groupBox5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Caja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.Form_Caja_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_C_TipoFactura;
        private System.Windows.Forms.DateTimePicker dateTimePicker_C_Fecha;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_F_TOTAL;
        private System.Windows.Forms.ComboBox comboBox_C_Vendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_C_CondVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}