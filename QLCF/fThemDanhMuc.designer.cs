namespace QLCF
{
    partial class fThemDanhMuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThemDanhMuc));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btThemDanhMuc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Nhóm:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox1.Location = new System.Drawing.Point(143, 53);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 29);
            this.textBox1.TabIndex = 1;
            // 
            // btThemDanhMuc
            // 
            this.btThemDanhMuc.BackColor = System.Drawing.Color.Transparent;
            this.btThemDanhMuc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btThemDanhMuc.BackgroundImage")));
            this.btThemDanhMuc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btThemDanhMuc.FlatAppearance.BorderSize = 0;
            this.btThemDanhMuc.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btThemDanhMuc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btThemDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThemDanhMuc.Location = new System.Drawing.Point(236, 126);
            this.btThemDanhMuc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btThemDanhMuc.Name = "btThemDanhMuc";
            this.btThemDanhMuc.Size = new System.Drawing.Size(68, 55);
            this.btThemDanhMuc.TabIndex = 2;
            this.btThemDanhMuc.UseVisualStyleBackColor = false;
            this.btThemDanhMuc.Click += new System.EventHandler(this.btThemDanhMuc_Click);
            // 
            // fThemDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(352, 222);
            this.Controls.Add(this.btThemDanhMuc);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fThemDanhMuc";
            this.Text = "Thêm Danh Mục";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btThemDanhMuc;
    }
}