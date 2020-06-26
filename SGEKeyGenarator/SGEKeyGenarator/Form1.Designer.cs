namespace SGEKeyGenarator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_MES = new System.Windows.Forms.TextBox();
            this.textBox_ANIO = new System.Windows.Forms.TextBox();
            this.textBox_KEY = new System.Windows.Forms.TextBox();
            this.button_Gen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_KeyUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_MES
            // 
            this.textBox_MES.Location = new System.Drawing.Point(83, 74);
            this.textBox_MES.Name = "textBox_MES";
            this.textBox_MES.Size = new System.Drawing.Size(55, 20);
            this.textBox_MES.TabIndex = 0;
            // 
            // textBox_ANIO
            // 
            this.textBox_ANIO.Location = new System.Drawing.Point(144, 74);
            this.textBox_ANIO.Name = "textBox_ANIO";
            this.textBox_ANIO.Size = new System.Drawing.Size(57, 20);
            this.textBox_ANIO.TabIndex = 1;
            // 
            // textBox_KEY
            // 
            this.textBox_KEY.Location = new System.Drawing.Point(12, 158);
            this.textBox_KEY.Name = "textBox_KEY";
            this.textBox_KEY.Size = new System.Drawing.Size(268, 20);
            this.textBox_KEY.TabIndex = 2;
            // 
            // button_Gen
            // 
            this.button_Gen.BackColor = System.Drawing.Color.White;
            this.button_Gen.Location = new System.Drawing.Point(207, 74);
            this.button_Gen.Name = "button_Gen";
            this.button_Gen.Size = new System.Drawing.Size(75, 23);
            this.button_Gen.TabIndex = 3;
            this.button_Gen.Text = "Generar";
            this.button_Gen.UseVisualStyleBackColor = false;
            this.button_Gen.Click += new System.EventHandler(this.button_Gen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(84, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(144, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Año";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Key Generada";
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.White;
            this.button_Close.Location = new System.Drawing.Point(107, 187);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 7;
            this.button_Close.Text = "Cerrar";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::SGEKeyGenarator.Properties.Resources.bracBN;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(84, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 39);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ingresar el Mes 01-12 y el año de la forma 1991.";
            // 
            // textBox_KeyUser
            // 
            this.textBox_KeyUser.Location = new System.Drawing.Point(12, 116);
            this.textBox_KeyUser.Name = "textBox_KeyUser";
            this.textBox_KeyUser.Size = new System.Drawing.Size(268, 20);
            this.textBox_KeyUser.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Key Usuario";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SGEKeyGenarator.Properties.Resources.sg_cuadrado;
            this.ClientSize = new System.Drawing.Size(292, 221);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_KeyUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Gen);
            this.Controls.Add(this.textBox_KEY);
            this.Controls.Add(this.textBox_ANIO);
            this.Controls.Add(this.textBox_MES);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vizsla POS - Key Generator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_MES;
        private System.Windows.Forms.TextBox textBox_ANIO;
        private System.Windows.Forms.TextBox textBox_KEY;
        private System.Windows.Forms.Button button_Gen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_KeyUser;
        private System.Windows.Forms.Label label5;
    }
}

