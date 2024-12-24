namespace proje_deneme1
{
    partial class izinleri_göster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(izinleri_göster));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvIzinler = new System.Windows.Forms.DataGridView();
            this.btnKabul = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzinler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIzinler
            // 
            this.dgvIzinler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzinler.Location = new System.Drawing.Point(62, 292);
            this.dgvIzinler.Name = "dgvIzinler";
            this.dgvIzinler.Size = new System.Drawing.Size(553, 151);
            this.dgvIzinler.TabIndex = 0;
            // 
            // btnKabul
            // 
            this.btnKabul.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnKabul.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKabul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.btnKabul.Location = new System.Drawing.Point(239, 474);
            this.btnKabul.Name = "btnKabul";
            this.btnKabul.Size = new System.Drawing.Size(88, 32);
            this.btnKabul.TabIndex = 1;
            this.btnKabul.Text = "ONAY";
            this.btnKabul.UseVisualStyleBackColor = false;
            this.btnKabul.Click += new System.EventHandler(this.btnKabul_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.btnRed.Location = new System.Drawing.Point(366, 474);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(88, 32);
            this.btnRed.TabIndex = 2;
            this.btnRed.Text = "RED";
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(63, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 7);
            this.panel2.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.label1.Location = new System.Drawing.Point(58, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(635, 140);
            this.label1.TabIndex = 23;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox5.Location = new System.Drawing.Point(211, 24);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(494, 29);
            this.textBox5.TabIndex = 21;
            this.textBox5.Text = "R  M  D | İZİN ONAY/RED ";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(12, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(11, 531);
            this.panel6.TabIndex = 25;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(12, 524);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(635, 7);
            this.panel7.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(729, 63);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 485);
            this.panel3.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(43)))));
            this.label9.Location = new System.Drawing.Point(698, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 52);
            this.label9.TabIndex = 28;
            this.label9.Text = "⮨";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // izinleri_göster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(131)))), ((int)(((byte)(131)))));
            this.ClientSize = new System.Drawing.Size(749, 540);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvIzinler);
            this.Controls.Add(this.btnRed);
            this.Controls.Add(this.btnKabul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "izinleri_göster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "izinleri_göster";
            this.Load += new System.EventHandler(this.izinleri_göster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzinler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvIzinler;
        private System.Windows.Forms.Button btnKabul;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label9;
    }
}