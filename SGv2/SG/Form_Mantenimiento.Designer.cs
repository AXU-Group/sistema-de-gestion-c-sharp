namespace SG
{
    partial class Form_Mantenimiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Mantenimiento));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_M_sql = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_M_sqlcommand = new System.Windows.Forms.TextBox();
            this.button_M_sqlTruncate = new System.Windows.Forms.Button();
            this.button_M_sqlSelect = new System.Windows.Forms.Button();
            this.button_M_sqlDelete = new System.Windows.Forms.Button();
            this.button_M_sqlUpdate = new System.Windows.Forms.Button();
            this.button_M_sqlInsert = new System.Windows.Forms.Button();
            this.tabPage_M_result = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage_M_sql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage_M_sql);
            this.tabControl1.Controls.Add(this.tabPage_M_result);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(792, 474);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_M_sql
            // 
            this.tabPage_M_sql.Controls.Add(this.dataGridView1);
            this.tabPage_M_sql.Controls.Add(this.groupBox1);
            this.tabPage_M_sql.Location = new System.Drawing.Point(4, 25);
            this.tabPage_M_sql.Name = "tabPage_M_sql";
            this.tabPage_M_sql.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_M_sql.Size = new System.Drawing.Size(784, 445);
            this.tabPage_M_sql.TabIndex = 0;
            this.tabPage_M_sql.Text = "SQL";
            this.tabPage_M_sql.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(9, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(767, 230);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox_M_sqlcommand);
            this.groupBox1.Controls.Add(this.button_M_sqlTruncate);
            this.groupBox1.Controls.Add(this.button_M_sqlSelect);
            this.groupBox1.Controls.Add(this.button_M_sqlDelete);
            this.groupBox1.Controls.Add(this.button_M_sqlUpdate);
            this.groupBox1.Controls.Add(this.button_M_sqlInsert);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sentencia SQL";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(663, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ejecutar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_M_sqlcommand
            // 
            this.textBox_M_sqlcommand.Location = new System.Drawing.Point(7, 13);
            this.textBox_M_sqlcommand.Multiline = true;
            this.textBox_M_sqlcommand.Name = "textBox_M_sqlcommand";
            this.textBox_M_sqlcommand.Size = new System.Drawing.Size(649, 175);
            this.textBox_M_sqlcommand.TabIndex = 7;
            // 
            // button_M_sqlTruncate
            // 
            this.button_M_sqlTruncate.Location = new System.Drawing.Point(663, 131);
            this.button_M_sqlTruncate.Name = "button_M_sqlTruncate";
            this.button_M_sqlTruncate.Size = new System.Drawing.Size(98, 23);
            this.button_M_sqlTruncate.TabIndex = 6;
            this.button_M_sqlTruncate.Text = "TRUNCATE";
            this.button_M_sqlTruncate.UseVisualStyleBackColor = true;
            this.button_M_sqlTruncate.Click += new System.EventHandler(this.button_M_sqlTruncate_Click);
            // 
            // button_M_sqlSelect
            // 
            this.button_M_sqlSelect.Location = new System.Drawing.Point(662, 11);
            this.button_M_sqlSelect.Name = "button_M_sqlSelect";
            this.button_M_sqlSelect.Size = new System.Drawing.Size(99, 23);
            this.button_M_sqlSelect.TabIndex = 2;
            this.button_M_sqlSelect.Text = "SELECT";
            this.button_M_sqlSelect.UseVisualStyleBackColor = true;
            this.button_M_sqlSelect.Click += new System.EventHandler(this.button_M_sqlSelect_Click);
            // 
            // button_M_sqlDelete
            // 
            this.button_M_sqlDelete.Location = new System.Drawing.Point(663, 101);
            this.button_M_sqlDelete.Name = "button_M_sqlDelete";
            this.button_M_sqlDelete.Size = new System.Drawing.Size(98, 23);
            this.button_M_sqlDelete.TabIndex = 5;
            this.button_M_sqlDelete.Text = "DELETE";
            this.button_M_sqlDelete.UseVisualStyleBackColor = true;
            this.button_M_sqlDelete.Click += new System.EventHandler(this.button_M_sqlDelete_Click);
            // 
            // button_M_sqlUpdate
            // 
            this.button_M_sqlUpdate.Location = new System.Drawing.Point(663, 41);
            this.button_M_sqlUpdate.Name = "button_M_sqlUpdate";
            this.button_M_sqlUpdate.Size = new System.Drawing.Size(98, 23);
            this.button_M_sqlUpdate.TabIndex = 3;
            this.button_M_sqlUpdate.Text = "UPDATE";
            this.button_M_sqlUpdate.UseVisualStyleBackColor = true;
            this.button_M_sqlUpdate.Click += new System.EventHandler(this.button_M_sqlUpdate_Click);
            // 
            // button_M_sqlInsert
            // 
            this.button_M_sqlInsert.Location = new System.Drawing.Point(663, 71);
            this.button_M_sqlInsert.Name = "button_M_sqlInsert";
            this.button_M_sqlInsert.Size = new System.Drawing.Size(98, 23);
            this.button_M_sqlInsert.TabIndex = 4;
            this.button_M_sqlInsert.Text = "INSERT";
            this.button_M_sqlInsert.UseVisualStyleBackColor = true;
            this.button_M_sqlInsert.Click += new System.EventHandler(this.button_M_sqlInsert_Click);
            // 
            // tabPage_M_result
            // 
            this.tabPage_M_result.Location = new System.Drawing.Point(4, 25);
            this.tabPage_M_result.Name = "tabPage_M_result";
            this.tabPage_M_result.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_M_result.Size = new System.Drawing.Size(784, 445);
            this.tabPage_M_result.TabIndex = 1;
            this.tabPage_M_result.Text = "Resultados";
            this.tabPage_M_result.UseVisualStyleBackColor = true;
            // 
            // Form_Mantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 473);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Mantenimiento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_M_sql.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_M_sql;
        private System.Windows.Forms.TabPage tabPage_M_result;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_M_sqlcommand;
        private System.Windows.Forms.Button button_M_sqlTruncate;
        private System.Windows.Forms.Button button_M_sqlSelect;
        private System.Windows.Forms.Button button_M_sqlDelete;
        private System.Windows.Forms.Button button_M_sqlUpdate;
        private System.Windows.Forms.Button button_M_sqlInsert;
        private System.Windows.Forms.Button button1;
    }
}