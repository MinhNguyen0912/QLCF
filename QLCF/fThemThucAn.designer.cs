namespace DuAN
{
    partial class fThemThucAn
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.cbbDanhMuc = new System.Windows.Forms.ComboBox();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.BTthemthucan = new System.Windows.Forms.Button();
            this.nmGiaMon = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaMon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(37, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Món:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(37, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giá Món:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(37, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Danh Mục:";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // cbbDanhMuc
            // 
            this.cbbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDanhMuc.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbDanhMuc.FormattingEnabled = true;
            this.cbbDanhMuc.Location = new System.Drawing.Point(179, 147);
            this.cbbDanhMuc.Name = "cbbDanhMuc";
            this.cbbDanhMuc.Size = new System.Drawing.Size(255, 35);
            this.cbbDanhMuc.TabIndex = 3;
            this.cbbDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbbDanhMuc_SelectedIndexChanged);
            // 
            // txtTenMon
            // 
            this.txtTenMon.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenMon.Location = new System.Drawing.Point(179, 37);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(255, 34);
            this.txtTenMon.TabIndex = 4;
            // 
            // BTthemthucan
            // 
            this.BTthemthucan.BackColor = System.Drawing.Color.Transparent;
            this.BTthemthucan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTthemthucan.FlatAppearance.BorderSize = 0;
            this.BTthemthucan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTthemthucan.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.BTthemthucan.ForeColor = System.Drawing.Color.Gainsboro;
            this.BTthemthucan.Location = new System.Drawing.Point(327, 211);
            this.BTthemthucan.Name = "BTthemthucan";
            this.BTthemthucan.Size = new System.Drawing.Size(107, 62);
            this.BTthemthucan.TabIndex = 5;
            this.BTthemthucan.UseVisualStyleBackColor = false;
            this.BTthemthucan.Click += new System.EventHandler(this.BTthemthucan_Click);
            this.BTthemthucan.MouseHover += new System.EventHandler(this.BTthemthucan_MouseHover);
            // 
            // nmGiaMon
            // 
            this.nmGiaMon.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nmGiaMon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nmGiaMon.Location = new System.Drawing.Point(179, 89);
            this.nmGiaMon.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmGiaMon.Name = "nmGiaMon";
            this.nmGiaMon.Size = new System.Drawing.Size(255, 34);
            this.nmGiaMon.TabIndex = 6;
            this.nmGiaMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nmGiaMon.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.nmGiaMon.ValueChanged += new System.EventHandler(this.nmGiaMon_ValueChanged);
            // 
            // fThemThucAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(486, 287);
            this.Controls.Add(this.nmGiaMon);
            this.Controls.Add(this.BTthemthucan);
            this.Controls.Add(this.txtTenMon);
            this.Controls.Add(this.cbbDanhMuc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "fThemThucAn";
            this.Text = "Thêm Thức Ăn";
            this.Load += new System.EventHandler(this.sThemThucAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmGiaMon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.ComboBox cbbDanhMuc;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Button BTthemthucan;
        private System.Windows.Forms.NumericUpDown nmGiaMon;
    }
}