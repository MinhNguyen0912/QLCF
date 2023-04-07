namespace QLCF
{
    partial class FQuanLyBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FQuanLyBan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpTableList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btAddFood = new System.Windows.Forms.Button();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCategories = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.cbChangeTable = new System.Windows.Forms.ComboBox();
            this.btDiscount = new System.Windows.Forms.Button();
            this.btChangeTable = new System.Windows.Forms.Button();
            this.txtSumBill = new System.Windows.Forms.TextBox();
            this.btPayBill = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhảoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaThôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.flpTableList);
            this.panel1.Location = new System.Drawing.Point(7, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 474);
            this.panel1.TabIndex = 0;
            // 
            // flpTableList
            // 
            this.flpTableList.AutoScroll = true;
            this.flpTableList.BackColor = System.Drawing.Color.Transparent;
            this.flpTableList.Location = new System.Drawing.Point(0, -1);
            this.flpTableList.Name = "flpTableList";
            this.flpTableList.Size = new System.Drawing.Size(418, 491);
            this.flpTableList.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btAddFood);
            this.panel2.Controls.Add(this.cbFood);
            this.panel2.Controls.Add(this.cbCategories);
            this.panel2.Location = new System.Drawing.Point(431, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(407, 69);
            this.panel2.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(342, 45);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 3;
            // 
            // btAddFood
            // 
            this.btAddFood.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btAddFood.BackgroundImage")));
            this.btAddFood.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddFood.FlatAppearance.BorderSize = 0;
            this.btAddFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAddFood.Location = new System.Drawing.Point(260, 10);
            this.btAddFood.Name = "btAddFood";
            this.btAddFood.Size = new System.Drawing.Size(50, 50);
            this.btAddFood.TabIndex = 2;
            this.btAddFood.UseVisualStyleBackColor = true;
            this.btAddFood.Click += new System.EventHandler(this.btAddFood_Click);
            // 
            // cbFood
            // 
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(3, 45);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(233, 21);
            this.cbFood.TabIndex = 1;
            // 
            // cbCategories
            // 
            this.cbCategories.FormattingEnabled = true;
            this.cbCategories.Location = new System.Drawing.Point(3, 4);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(233, 21);
            this.cbCategories.TabIndex = 0;
            this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.numericUpDown2);
            this.panel3.Controls.Add(this.cbChangeTable);
            this.panel3.Controls.Add(this.btDiscount);
            this.panel3.Controls.Add(this.btChangeTable);
            this.panel3.Controls.Add(this.txtSumBill);
            this.panel3.Controls.Add(this.btPayBill);
            this.panel3.Location = new System.Drawing.Point(431, 439);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(407, 85);
            this.panel3.TabIndex = 2;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(123, 57);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(52, 20);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // cbChangeTable
            // 
            this.cbChangeTable.FormattingEnabled = true;
            this.cbChangeTable.Location = new System.Drawing.Point(33, 56);
            this.cbChangeTable.Name = "cbChangeTable";
            this.cbChangeTable.Size = new System.Drawing.Size(52, 21);
            this.cbChangeTable.TabIndex = 7;
            // 
            // btDiscount
            // 
            this.btDiscount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btDiscount.BackgroundImage")));
            this.btDiscount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btDiscount.FlatAppearance.BorderSize = 0;
            this.btDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDiscount.Location = new System.Drawing.Point(123, 0);
            this.btDiscount.Name = "btDiscount";
            this.btDiscount.Size = new System.Drawing.Size(52, 47);
            this.btDiscount.TabIndex = 6;
            this.btDiscount.UseVisualStyleBackColor = true;
            this.btDiscount.Click += new System.EventHandler(this.btDiscount_Click);
            // 
            // btChangeTable
            // 
            this.btChangeTable.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btChangeTable.BackgroundImage")));
            this.btChangeTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btChangeTable.FlatAppearance.BorderSize = 0;
            this.btChangeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btChangeTable.Location = new System.Drawing.Point(33, 0);
            this.btChangeTable.Name = "btChangeTable";
            this.btChangeTable.Size = new System.Drawing.Size(52, 47);
            this.btChangeTable.TabIndex = 5;
            this.btChangeTable.UseVisualStyleBackColor = true;
            this.btChangeTable.Click += new System.EventHandler(this.btChangeTable_Click);
            // 
            // txtSumBill
            // 
            this.txtSumBill.Enabled = false;
            this.txtSumBill.Location = new System.Drawing.Point(221, 8);
            this.txtSumBill.Multiline = true;
            this.txtSumBill.Name = "txtSumBill";
            this.txtSumBill.Size = new System.Drawing.Size(100, 69);
            this.txtSumBill.TabIndex = 4;
            // 
            // btPayBill
            // 
            this.btPayBill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btPayBill.BackgroundImage")));
            this.btPayBill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPayBill.FlatAppearance.BorderSize = 0;
            this.btPayBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPayBill.Location = new System.Drawing.Point(327, 12);
            this.btPayBill.Name = "btPayBill";
            this.btPayBill.Size = new System.Drawing.Size(77, 57);
            this.btPayBill.TabIndex = 3;
            this.btPayBill.UseVisualStyleBackColor = true;
            this.btPayBill.Click += new System.EventHandler(this.btPayBill_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvBill);
            this.panel4.Location = new System.Drawing.Point(431, 108);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(407, 325);
            this.panel4.TabIndex = 3;
            // 
            // dgvBill
            // 
            this.dgvBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Location = new System.Drawing.Point(0, 0);
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.Size = new System.Drawing.Size(406, 324);
            this.dgvBill.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhảoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhảoToolStripMenuItem
            // 
            this.thôngTinTàiKhảoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửaThôngTinTàiKhoảnToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhảoToolStripMenuItem.Name = "thôngTinTàiKhảoToolStripMenuItem";
            this.thôngTinTàiKhảoToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.thôngTinTàiKhảoToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // sửaThôngTinTàiKhoảnToolStripMenuItem
            // 
            this.sửaThôngTinTàiKhoảnToolStripMenuItem.Name = "sửaThôngTinTàiKhoảnToolStripMenuItem";
            this.sửaThôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.sửaThôngTinTàiKhoảnToolStripMenuItem.Text = "Sửa thông tin tài khoản";
            this.sửaThôngTinTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.sửaThôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.đăngXuấtToolStripMenuItem.Text = "đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(493, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(717, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // FQuanLyBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(850, 536);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FQuanLyBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý quán Cafe";
            this.Load += new System.EventHandler(this.FMenuChinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpTableList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btAddFood;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategories;
        private System.Windows.Forms.TextBox txtSumBill;
        private System.Windows.Forms.Button btPayBill;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhảoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.ComboBox cbChangeTable;
        private System.Windows.Forms.Button btDiscount;
        private System.Windows.Forms.Button btChangeTable;
        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.ToolStripMenuItem sửaThôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
    }
}

