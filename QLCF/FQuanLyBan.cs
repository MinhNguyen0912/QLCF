
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCF
{

    public partial class FQuanLyBan : Form
    {
        //QuanLyQuanCafeEntities db = new QuanLyQuanCafeEntities();

        public FQuanLyBan()
        {
            InitializeComponent();
        }
        private void FMenuChinh_Load(object sender, EventArgs e)
        {
            label1.Text = $"Tên nhân viên: {QLCFDB.db.Account.FirstOrDefault(p => p.status == 1).DisplayName}";
            var type = QLCFDB.db.Account.FirstOrDefault(p => p.status == 1).Type == 0 ? "Quản lý" : "Nhân viên";
            label2.Text = $"Chức vụ: {type}";
            ShowTableButton();
            ShowCategories();
            ShowComboboxChangeTable();
        }
        private void ShowComboboxChangeTable()
        {
            cbChangeTable.Items.Clear();
            var db = QLCFDB.db;
            var table = db.TableFood.Select(c => c).ToList();

            foreach (var item in table)
            {
                if (item.status != "Tạm đóng" && label3.Text != item.name)
                {
                    cbChangeTable.Items.Add(item.id);
                }
            }
        }
        private void ShowTableButton()
        {
            flpTableList.Controls.Clear();
            var db = QLCFDB.db;
            var table = (from c in db.TableFood
                         select c)
                           .ToList();
            Image imgBanTrong = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), @"IMG\btn_green.jpg"));
            Image imgBanCoNGuoi = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), @"IMG\btn_red.jpg"));
            Image imgBanTamDong = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), @"IMG\btn_grey.jpg"));
            foreach (var c in table)
            {
                Button btn = new Button() { Width = 90, Height = 90 };
                btn.Font = new Font("Regular", 12);
                btn.FlatAppearance.BorderSize = 0;
                btn.Text = c.name + "\n" + c.status;

                btn.Click += Btn_Click;
                switch (c.status)
                {
                    case "Trống":
                        btn.BackgroundImage = imgBanTrong;
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case "Có người":
                        btn.BackgroundImage = imgBanCoNGuoi;
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        break;
                    case "Tạm đóng":
                        btn.BackgroundImage = imgBanTamDong;
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.Enabled = false;
                        btn.ForeColor = SystemColors.HighlightText;
                        break;
                    default:
                        break;
                }
                flpTableList.Controls.Add(btn);
            }
        }
        private void ShowCategories()
        {
            var db = QLCFDB.db;
            var product = (from c in db.FoodCategory
                           select new { c.name, c.id }).ToList();
            foreach (var item in product)
            {
                cbCategories.Items.Add(item.name);
            }
        }
        private void loadBill()
        {
            var db = QLCFDB.db;
            var idtable = int.Parse(label3.Text.Split(' ')[1]);
            dgvBill.DataSource = db.BillInfo.Where(p => p.Bill.TableFood.id == idtable && p.Bill.status == 1).Select(p => new {TenMon = p.Food.name, SoLuong = p.count, DonGia = p.Food.price, ThanhTien = p.count * p.Food.price, MaHoaDon = p.Bill.id }).ToList();

            if (dgvBill.DataSource != null)
            {
                double discount = (double)Math.Round(numericUpDown2.Value);
                double sum = 0;
                for (int i = 0; i < dgvBill.Rows.Count; i++)
                {
                    sum += double.Parse(dgvBill.Rows[i].Cells[3].Value.ToString()) * (100 - discount);
                }
                txtSumBill.Text = sum.ToString() + " VNĐ";
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var db = QLCFDB.db;
            string btntxt = btn.Text;
            string[] btnarrtxt = btntxt.Split('\n');
            string Tbname = btnarrtxt[0];

            var result1 = (from c in db.TableFood
                           where c.name == Tbname
                           select c).FirstOrDefault();

            label3.Text = result1.name;
            loadBill();
            ShowComboboxChangeTable();
        }
        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            var db = QLCFDB.db;
            var cbcategoryID = (from c in db.FoodCategory
                                where c.name.ToLower() == cbCategories.Text.ToLower()
                                select c.id).FirstOrDefault();
            var product = (from c in db.Food
                           where c.idCategory == cbcategoryID
                           select c.name).ToList();
            cbFood.DataSource = product;
        }
        private void btAddFood_Click(object sender, EventArgs e)
        {
            if (label3.Text != string.Empty && cbCategories.Text != string.Empty)
            {
                var db = QLCFDB.db;
                var table = (from c in db.TableFood where c.name == label3.Text select c).FirstOrDefault();
                if (table.status == "Trống")
                {
                    int idtb = table.id;
                    Bill bill = new Bill();
                    bill.DateCheckIn = DateTime.Now;
                    bill.idTable = idtb;
                    bill.status = 1;
                    db.Bill.Add(bill);
                    db.SaveChanges();
                    int idbill = bill.id;
                    BillInfo es = new BillInfo();
                    es.idBill = idbill;
                    var food = (from c in db.Food where c.name == cbFood.Text select c.id).FirstOrDefault();
                    es.idFood = food;
                    es.count = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
                    db.BillInfo.Add(es);

                    table.status = "Có người";
                    db.SaveChanges();
                    loadBill();
                    ShowTableButton();
                }
                else if (table.status == "Có người")
                {
                    var bill = db.Bill.Where(p => p.idTable == table.id && p.status == 1).Select(p => p.id).FirstOrDefault();
                    int c = bill;
                    BillInfo billinfo = new BillInfo();
                    billinfo.idBill = c;
                    var idfood = (from x in db.Food where x.name == cbFood.Text select x.id).FirstOrDefault();
                    var check = db.BillInfo.Where(p => p.idBill == bill).Select(p => p).ToList();
                    int count = 0;
                    for (int i = 0; i < check.Count; i++)
                    {
                        if (check[i].idFood == idfood)
                        {
                            check[i].count = check[i].count + Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
                            db.SaveChanges();
                            break;
                        }
                        else if (check[i].idFood != idfood)
                        {
                            count++;
                        }

                    }
                    if (count == check.Count)
                    {
                        billinfo.idFood = idfood;
                        billinfo.count = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
                        db.BillInfo.Add(billinfo);
                        db.SaveChanges();
                    }
                    loadBill();
                    ShowTableButton();
                }

            }
            else if (cbCategories.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (label3.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }
        private void btPayBill_Click(object sender, EventArgs e)
        {
            var db = QLCFDB.db;

            if (dgvBill.Rows.Count > 0)
            {
                List<int> check = new List<int>();
                foreach (DataGridViewRow row in dgvBill.Rows)
                { 
                    check.Add(int.Parse(row.Cells[4].Value.ToString()));
                }
                for (int i = 0; i < check.Count; i++)
                {
                    var idbill = check[i];
                    var idb = db.Bill.Where(c => c.id == idbill).ToList();
                    foreach (var item in idb)
                    {
                        item.status = 0;
                        item.DateCheckOut = DateTime.Now;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                        var idtb = db.TableFood.Where(p => p.id == item.idTable).Select(p => p).FirstOrDefault();
                        idtb.status = "Trống";
                        db.Entry(idtb).State = EntityState.Modified;
                        db.SaveChanges();
                    }                                        
                }
                MessageBox.Show("Thanh toán thành công", "Thông Báo", MessageBoxButtons.OK);
                loadBill();
                ShowTableButton();
            }
        }
        private void btDiscount_Click(object sender, EventArgs e)
        {
            var db = QLCFDB.db;
            
            if (dgvBill.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Xác nhận giảm giá", "Thông báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    List<int> check = new List<int>();
                    foreach (DataGridViewRow row in dgvBill.Rows)
                    {
                        check.Add(int.Parse(row.Cells[4].Value.ToString()));
                    }
                    foreach (var item in check)
                    {
                        var iddiscount = db.Bill.Where(c => c.id == item).FirstOrDefault();
                        iddiscount.Discount = Convert.ToDouble(Math.Round(numericUpDown2.Value, 0));
                        db.Entry(iddiscount).State = EntityState.Modified;
                        db.SaveChanges();
                    }                                                         
                }
                loadBill();
            }
            else { MessageBox.Show("Chưa có hóa đơn", "Thông báo", MessageBoxButtons.OK); }


        }
        private void btChangeTable_Click(object sender, EventArgs e)
        {
            var db = QLCFDB.db;
            if (label3.Text != string.Empty)
            {
                int idtable = int.Parse(label3.Text.Split(' ')[1]);
                var bill = db.Bill.Where(c => c.idTable == idtable && c.status == 1).Select(c => c).FirstOrDefault();
                if (bill != null)
                {
                    if (cbChangeTable.Text != string.Empty)
                    {
                        bill.idTable = Convert.ToInt32(cbChangeTable.SelectedItem.ToString());
                        db.Entry(bill).State = EntityState.Modified;
                        db.SaveChanges();
                        var NewTable = db.TableFood.Where(c => c.id == bill.idTable).Select(c => c).FirstOrDefault();
                        NewTable.status = "Có người";
                        db.Entry(NewTable).State = EntityState.Modified;
                        var OldTable = db.TableFood.Where(c => c.id == idtable).Select(c => c).FirstOrDefault();
                        OldTable.status = "Trống";
                        db.Entry(OldTable).State = EntityState.Modified;
                        db.SaveChanges();
                        loadBill();
                        ShowTableButton();
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn bàn muốn chuyển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (bill == null)
                {
                    MessageBox.Show("Bàn trống chưa có hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (label3.Text != string.Empty)
            {
                loadBill();
            }
            else
            {
                DialogResult result = MessageBox.Show("Vui lòng chọn bàn", "Thông báo", MessageBoxButtons.OK);

                if (result == DialogResult.OK)
                {
                    numericUpDown2.Value = 0;
                }
            }

        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var user = QLCFDB.db.Account.FirstOrDefault(p => p.status == 1);
            if (user.Type==1)
            {
                this.Hide();
                fAdminManager quanLyKho = new fAdminManager();
                quanLyKho.ShowDialog();
                this.Show();
                ShowTableButton();
                ShowCategories();
                ShowComboboxChangeTable();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền đăng nhập vào form này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void sửaThôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSuaTTAcc suaTTAcc = new fSuaTTAcc();
            suaTTAcc.ShowDialog();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát ko ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var user = QLCFDB.db.Account.FirstOrDefault(p => p.status == 1);
                user.status = 0;
                QLCFDB.db.SaveChanges();
                this.Close();
            }

        }

        private void thôngTinTàiKhảoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
