using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCF
{
    public partial class fQuanLyKho : Form
    {
        public fQuanLyKho()
        {
            InitializeComponent();
            LoadData();
        }

        #region METHOD
        void LoadData()
        {
            LoadBill();
            LoadFood();
            LoadAccount();
            LoadCategory();
            LoadTableFood();
            displayDateTimePicker();
        }
        void displayDateTimePicker() // Thời gian hiển thị mặc định là cách 1 tháng
        {
            DateTime today = DateTime.Now;
            dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadBill()
        {
            DateTime fromDate = DateTime.Parse(dtpFromDate.Value.ToShortDateString());
            DateTime toDate = DateTime.Parse(dtpToDate.Value.ToShortDateString());
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                dgvBill.DataSource = null;
                return;
            }
            if (QLCFDB.db.Bill.ToList().Count > 0)
            {

                dgvBill.DataSource = QLCFDB.db.Bill.Where(p => p.DateCheckIn >= fromDate && (p.DateCheckOut <= toDate) || p.DateCheckOut == null).Select(p => new
                {
                    id = p.id,
                    Ten_ban = p.TableFood.name,
                    Ngay_vao = p.DateCheckIn,
                    Ngay_ra = p.DateCheckOut,
                    Trang_thai = p.status == 1 ? "Chưa thanh toán" : "Đã thanh toán",
                    Giam_gia = p.Discount + "%",
                    Tong_hoa_dpn = p.BillInfo.Sum(c => c.Food.price * c.count),
                    Tien_thu_khach = p.BillInfo.Sum(c => c.Food.price * c.count) * (100 - p.Discount) / 100
                }).ToList();

            }

        }
        void LoadFood()
        {
            dgvFood.DataSource = QLCFDB.db.Food.Select(c => new
            {
                ID = c.id,
                Tên = c.name,
                DanhMục = c.FoodCategory.name,
                Giá = c.price
            }).ToList();
            cbFoodCategory.DataSource = QLCFDB.db.FoodCategory.Select(c => c.name).ToList();
        }
        void ShowFood()
        {
            txbFoodID.DataBindings.Clear();
            txbFoodName.DataBindings.Clear();
            txbFoodPrice.DataBindings.Clear();
            cbFoodCategory.DataBindings.Clear();
            cbFoodCategory.DataSource = QLCFDB.db.FoodCategory.Select(c => c.name).ToList();

            txbFoodID.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "id"));
            txbFoodName.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Tên"));
            txbFoodPrice.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "Giá"));
            cbFoodCategory.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "DanhMục"));

            cbStatusFood.Text = QLCFDB.db.Food.Where(p => p.id.ToString() == txbFoodID.Text).ToList()[0].status == 1 ? "Bán" : "Dừng bán";
        }
        void LoadCategory()
        {
            dgvCategory.DataSource = QLCFDB.db.FoodCategory.Select(c => new
            {
                id = c.id,
                name = c.name
            }).ToList();
        }
        void ShowCategory()
        {
            txbCategoryID.DataBindings.Clear();
            txbCategoryName.DataBindings.Clear();
            txbCategoryID.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "id"));
            txbCategoryName.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "name"));
        }
        void LoadTableFood()
        {
            dgvTableFood.DataSource = QLCFDB.db.TableFood.ToList();
        }
        void ShowTableFood()
        {
            txbTableID.DataBindings.Clear();
            txbTableName.DataBindings.Clear();
            cbTableFoodStatus.DataBindings.Clear();
            txbTableID.DataBindings.Add(new Binding("Text", dgvTableFood.DataSource, "id"));
            txbTableName.DataBindings.Add(new Binding("Text", dgvTableFood.DataSource, "name"));
            cbTableFoodStatus.DataBindings.Add(new Binding("Text", dgvTableFood.DataSource, "status"));
        }
        void LoadAccount()
        {
            dgvAccount.DataSource = QLCFDB.db.Account.Select(c => new
            {
                UserName = c.UserName,
                DisplayName = c.DisplayName,
                AccountType = c.Type == 1 ? "ADMIN" : "STAFF",
                Status = c.status == 0 ? "On" : "Off"
            }).ToList();
        }
        void ShowAccount()
        {
            txbUserName.DataBindings.Clear();
            txbDisplayName.DataBindings.Clear();
            cbAccountType.DataBindings.Clear();
            txbUserName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "username"));
            txbDisplayName.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "displayname"));
            //cbAccountType.DataBindings.Add(new Binding("Text", dgvAccount.DataSource, "accounttype"));
            cbAccountType.Text = dgvAccount.SelectedCells[0].OwningRow.Cells["AccountType"].Value.ToString() == "0" ? "STAFF" : "ADMIN";
        }

        #endregion

        #region EVENTS
        #region Food
        private void btnSearchFood_Click(object sender, EventArgs e)
        {

        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (txbFoodName.Text != "" && txbFoodPrice.Text != "" && cbFoodCategory.Text != "")
            {
                if (QLCFDB.db.Food.Where(p => p.id.ToString() == txbFoodID.Text).ToList()[0].name.ToLower() != txbFoodName.Text.ToLower())
                {
                    QLCFDB.db.Food.Add(new Food()
                    {
                        name = txbFoodName.Text,
                        idCategory = QLCFDB.db.FoodCategory.Where(p => p.name == cbFoodCategory.Text).ToList()[0].id,
                        price = double.Parse(txbFoodPrice.Text),
                        status = 1
                    }); ;
                    QLCFDB.db.SaveChanges();
                    MessageBox.Show("Tạo món mới thành công!");
                }
                else
                    MessageBox.Show("Món đã tồn tại");
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }

        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if (txbFoodID.Text != string.Empty)
            {
                foreach (var f in QLCFDB.db.Food.ToList())
                {
                    QLCFDB.db.Food.Where(p => p.id.ToString() == txbFoodID.Text).ToList()[0].name = txbFoodName.Text;
                    QLCFDB.db.Food.Where(p => p.id.ToString() == txbFoodID.Text).ToList()[0].price = double.Parse(txbFoodPrice.Text);
                    QLCFDB.db.Food.Where(p => p.id.ToString() == txbFoodID.Text).ToList()[0].idCategory = QLCFDB.db.FoodCategory.Where(p => p.name == cbFoodCategory.Text).ToList()[0].id;
                    QLCFDB.db.Food.Where(p => p.id.ToString() == txbFoodID.Text).ToList()[0].status = cbStatusFood.Text == "Bán" ? 1 : 0;
                    QLCFDB.db.SaveChanges();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFood();
                    return;
                }

            }
            else
                MessageBox.Show("Chọn món cần sửa");
        }
        private void btnStopFood_Click(object sender, EventArgs e)
        {
            if (txbFoodID.Text != string.Empty)
            {
                if (MessageBox.Show("Bạn có chắc muốn dừng kinh doanh sản phẩm này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    QLCFDB.db.Food.Where(p => p.id.ToString() == txbFoodID.Text).ToList()[0].status = 0;
                    QLCFDB.db.SaveChanges();
                    MessageBox.Show("Sản phẩm đã được dừng bán");
                    LoadFood();
                }
            }
            else
                MessageBox.Show("Chọn món muốn dừng bán");
        }
        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadFood();
            ShowFood();
        }
        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowFood();
        }
        #endregion

        #region Bills
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = DateTime.Parse(dtpFromDate.Value.ToShortDateString());
            DateTime dateTo = DateTime.Parse(dtpToDate.Value.ToShortDateString());

            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Vui lòng chọn lại thời gian\n( Ngày bắt đầu phải nhỏ hơn ngày kết thúc )", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvBill.Rows.Count != 0)
            {
                Double totalPrice = double.Parse(QLCFDB.db.Bill.Where(p => p.DateCheckIn >= dateFrom && (p.DateCheckOut <= dateTo || p.DateCheckOut == null)).Sum(p => p.BillInfo.Sum(i => i.Food.price * i.count) * (100 - p.Discount) / 100).ToString());

                var billUnpaid = QLCFDB.db.Bill.Where(p => p.DateCheckIn >= dateFrom && p.DateCheckOut <= dateTo && (p.DateCheckOut <= dateTo || p.DateCheckOut == null) && p.status == 1);
                double unpaid = 0;

                if (billUnpaid != null)
                {
                    unpaid = double.Parse(QLCFDB.db.Bill.Where(p => p.DateCheckIn >= dateFrom && p.DateCheckOut <= dateTo && (p.DateCheckOut <= dateTo || p.DateCheckOut == null) && p.status == 1).Sum(p => p.BillInfo.Sum(i => i.Food.price * i.count) * (100 - p.Discount) / 100).ToString());
                }

                MessageBox.Show("Tổng doanh thu: " + totalPrice.ToString("c") + "\nTổng tiền chưa trả: " + unpaid.ToString("c") + "\nTổng tiền đã thu: " + (totalPrice - unpaid).ToString("c"));

            }
            else
                MessageBox.Show("Không có hóa đơn nào", "Thông báo");

        }
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            LoadBill();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            LoadBill();
        }
        #endregion

        #region Category
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (txbCategoryID.Text != string.Empty || txbCategoryName.Text != string.Empty)
            {
                if (QLCFDB.db.FoodCategory.Where(p => p.id.ToString() == txbCategoryID.Text).ToList()[0].name.ToLower() != txbCategoryName.Text.ToLower())
                {
                    FoodCategory fc = new FoodCategory()
                    {
                        name = txbCategoryName.Text
                    };
                    QLCFDB.db.FoodCategory.Add(fc);
                    QLCFDB.db.SaveChanges();
                    MessageBox.Show("Thêm danh mục thành công");
                    LoadCategory();
                }
                else
                    MessageBox.Show("Danh mục đã tồn tại");
            }
            else
                MessageBox.Show("Nhập đầy đủ thông tin");
        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (txbCategoryID.Text != "")
            {
                int tmpCategoryID = int.Parse(txbCategoryID.Text);
                QLCFDB.db.FoodCategory.Where(p => p.id == tmpCategoryID).ToList()[0].name = txbCategoryName.Text;
                QLCFDB.db.SaveChanges();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategory();
            }
            else
                MessageBox.Show("Chọn danh mục cần sửa");
        }
        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadCategory();
            ShowCategory();
        }
        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowCategory();
        }
        #endregion

        #region TableFood
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn tạo thêm 1 bàn mới", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QLCFDB.db.TableFood.Add(new TableFood
                {
                    name = "Bàn " + (QLCFDB.db.TableFood.Count() + 1).ToString(),
                    status = "Trống"
                });
                QLCFDB.db.SaveChanges();
                LoadTableFood();
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (txbTableID.Text != String.Empty)
            {
                TableFood tf = QLCFDB.db.TableFood.Find(int.Parse(txbTableID.Text));
                tf.name = txbTableName.Text;
                tf.status = cbTableFoodStatus.Text;
                QLCFDB.db.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
                LoadTableFood();
            }
            else
                MessageBox.Show("Vui lòng nhập thông tin cần sửa");
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (txbTableID.Text != "")
            {
                QLCFDB.db.TableFood.Remove(QLCFDB.db.TableFood.Find(int.Parse(txbTableID.Text)));
                QLCFDB.db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadTableFood();
            }
            else
                MessageBox.Show("Vui lòng chọn bàn muốn xóa");
        }
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadTableFood();
            ShowTableFood();
        }
        private void dgvTableFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowTableFood();
        }
        #endregion

        #region Account
        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowAccount();
        }
        private void btnAddAcount_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text != string.Empty)
            {

                foreach (var c in QLCFDB.db.Account.ToList())
                {
                    if (c.UserName.ToLower() == txbUserName.Text.ToLower())
                    {
                        MessageBox.Show("Tài khoản đã tồn tại !");
                    }
                    else
                    {
                        QLCFDB.db.Account.Add(new Account() {UserName = txbUserName.Text, DisplayName = txbDisplayName.Text, PassWord = "1", Type = cbAccountType.Text.ToLower() == "ADMIN" ? 1 : 0, status = 0 });
                        QLCFDB.db.SaveChanges();
                        LoadAccount();
                        MessageBox.Show("Thêm tài khoản thành công!");
                    }
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
        }

        private void btnEditAcount_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text != "")
            {
                QLCFDB.db.Account.Where(p => p.UserName == txbUserName.Text).ToList()[0].DisplayName = txbDisplayName.Text;
                QLCFDB.db.Account.Where(p => p.UserName == txbUserName.Text).ToList()[0].Type = cbAccountType.Text == "ADMIN" ? 1 : 0;
                QLCFDB.db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                LoadAccount();
            }
            else
                MessageBox.Show("Chọn tài khoản muốn sửa");
        }

        private void btnDeleteAcount_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text != "")
            {
                QLCFDB.db.Account.Remove(QLCFDB.db.Account.Find(txbUserName.Text));
                QLCFDB.db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadAccount();
            }
            else
                MessageBox.Show("Chọn tài khoản muốn xóa");
        }

        private void btnShowAcount_Click(object sender, EventArgs e)
        {
            LoadAccount();
            ShowAccount();
        }

        private void btnRePass_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text != string.Empty)
            {
                if (MessageBox.Show("Bạn có chắc muốn đặt lại mật khẩu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    QLCFDB.db.Account.Where(c => c.UserName.ToLower() == txbUserName.Text.ToLower()).ToList()[0].PassWord = "1";
                    QLCFDB.db.SaveChanges();
                    LoadAccount();
                    MessageBox.Show("Mật khẩu đã được đặt lại là '1' ");
                }
            }
            else
                MessageBox.Show("Chọn tài khoản muốn đặt lại mật khẩu");
        }
        #endregion
        #endregion

        #region Trash
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }









        #endregion


    }
}


