using DuAN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCF
{
    public partial class fAdminManager : Form
    {
        public fAdminManager()
        {
            InitializeComponent();
            LoadAllData();

        }
        #region LoadAllData
        void LoadAllData()
        {
            loadAccount();
            loadTable();
            loadCatagory();
            loadFood();
            loadBill();
        }
        void loadAccount()
        {
            dgvUser.DataSource = QLCFDB.db.Account.ToList();

        }
        void loadTable()
        {
            dgvTable.DataSource = QLCFDB.db.TableFood.ToList();

        }
        void loadCatagory()
        {
            dgvCategory.DataSource = QLCFDB.db.FoodCategory.ToList();

        }
        void loadFood()
        {
            dgvFood.DataSource = QLCFDB.db.Food.ToList();

        }
        void loadBill()
        {
            if (QLCFDB.db.Bill.ToList().Count != 0)
            {
                DateTime dateStart = DateTime.Parse(dtpkStart.Value.ToShortDateString());
                DateTime dateEnd = DateTime.Parse(dtpkEnd.Value.ToShortDateString());
                dgvBill.DataSource = QLCFDB.db.Bill.Where(p=>p.DateCheckIn>=dateStart&&(p.DateCheckOut<= dateEnd || p.DateCheckOut==null)).Select(p => new
                {
                    MãHóaĐơn = p.id,
                    NgàyTạo = p.DateCheckIn,
                    NgàyThanhToán = p.DateCheckOut,
                    TênBàn = p.TableFood.name,
                    TrạngThái = p.status == 0 ? "Đã thanh toán" : "Chưa thanh toán",
                    TổngTiền = p.BillInfo.Sum(i => i.Food.price * i.count),
                    GiảmGiá = p.Discount+"%",
                    ThựcThu = p.BillInfo.Sum(i => i.Food.price * i.count)*(100-p.Discount)/100
                }).ToList();
            }
        }
        #endregion
        
        #region Table
        void showInfoTable()
        {
            txbIDTable.DataBindings.Clear();
            txbNameTable.DataBindings.Clear();
            cbStatusTable.DataBindings.Clear();
            txbIDTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "id"));
            txbNameTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "name"));
            cbStatusTable.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "status"));
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showInfoTable();
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            if (txbIDTable.Text!="")
            {
                TableFood tf = QLCFDB.db.TableFood.Find(int.Parse(txbIDTable.Text));
                tf.name = txbNameTable.Text;
                tf.status = cbStatusTable.Text;
                QLCFDB.db.SaveChanges();
                loadTable();
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn tạo thêm 1 bàn mới?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                QLCFDB.db.TableFood.Add(new TableFood() { name = $"Bàn {QLCFDB.db.TableFood.Count()+1}", status = "Trống" });
                QLCFDB.db.SaveChanges();
            }
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            loadTable();
            showInfoTable();
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (txbIDTable.Text!="")
            {
                QLCFDB.db.TableFood.Remove(QLCFDB.db.TableFood.Find(int.Parse(txbIDTable.Text)));
                QLCFDB.db.SaveChanges();
                loadTable();
            }
        }
        #endregion

        #region Bill
        private void btnShowBill_Click(object sender, EventArgs e)
        {
            if (dgvBill.Rows.Count!=0)
            {
                DateTime dateStart = DateTime.Parse(dtpkStart.Value.ToShortDateString());
                DateTime dateEnd = DateTime.Parse(dtpkEnd.Value.ToShortDateString());
                Double TongTienHoaDon = double.Parse(QLCFDB.db.Bill.Where(p => p.DateCheckIn >= dateStart && (p.DateCheckOut <= dateEnd || p.DateCheckOut == null)).Sum(p => p.BillInfo.Sum(i => i.Food.price * i.count) * (100 - p.Discount) / 100).ToString());
                Double TongTienDaThanhToan = double.Parse(QLCFDB.db.Bill.Where(p => p.DateCheckIn >= dateStart && (p.DateCheckOut <= dateEnd)&&p.status==0).Sum(p => p.BillInfo.Sum(i => i.Food.price * i.count) * (100 - p.Discount) / 100).ToString());
                MessageBox.Show($"Tổng tiền kiếm được: {TongTienHoaDon}\nTổng tiền đã thu về: { TongTienDaThanhToan}vnđ\nTổng tiền chưa thanh toán: {TongTienHoaDon - TongTienDaThanhToan}vnđ");

            }
        }

        private void dtpkStart_ValueChanged(object sender, EventArgs e)
        {
            loadBill();
        }

        private void dtpkEnd_ValueChanged(object sender, EventArgs e)
        {
            loadBill();
        }
        #endregion

        #region Account
        void showInfoAccount()
        {
            txbUserName.DataBindings.Clear();
            txbDisplayName.DataBindings.Clear();
            txbUserName.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "UserName"));
            txbDisplayName.DataBindings.Add(new Binding("Text", dgvUser.DataSource, "DisplayName"));
            cbTypeOfUser.Text = dgvUser.SelectedCells[0].OwningRow.Cells["Type"].Value.ToString()=="0"?"Staff":"Admin";
        }
        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showInfoAccount();
        }
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text != "")
            {
                QLCFDB.db.Account.Remove(QLCFDB.db.Account.Find(txbUserName.Text));
                QLCFDB.db.SaveChanges();
                loadAccount();
            }
        }

        private void btnShowUser_Click(object sender, EventArgs e)
        {
            loadAccount();
            showInfoAccount();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text!="")
            {
                QLCFDB.db.Account.Where(p => p.UserName == txbUserName.Text).ToList()[0].DisplayName = txbDisplayName.Text;
                QLCFDB.db.Account.Where(p => p.UserName == txbUserName.Text).ToList()[0].Type = cbTypeOfUser.Text=="Admin"?1:0;
                QLCFDB.db.SaveChanges();
                loadAccount();
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text!="")
            {
                QLCFDB.db.Account.Where(p => p.UserName == txbUserName.Text).ToList()[0].PassWord = "1";
                QLCFDB.db.SaveChanges();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            fAddAccount f = new fAddAccount();
            f.ShowDialog();
        }






        #endregion

        #region Catagory

        void showInfoCatagory()
        {
            txbIDCategory.DataBindings.Clear();
            txbNameCategory.DataBindings.Clear();
            txbIDCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "id"));
            txbNameCategory.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "name"));
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showInfoCatagory();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            fThemDanhMuc f = new fThemDanhMuc();
            f.ShowDialog();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (txbIDCategory.Text != "")
            {
                int tmpNameCatagory = int.Parse(txbIDCategory.Text);
                QLCFDB.db.FoodCategory.Where(p => p.id == tmpNameCatagory).ToList()[0].name = txbNameCategory.Text;
                QLCFDB.db.SaveChanges();
                loadCatagory();
            }
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            loadCatagory();
            showInfoCatagory();
        }




        #endregion

        #region Food


        void showFood()
        {
            txbIDFood.DataBindings.Clear();
            txbNameFood.DataBindings.Clear();
            txbPriceFood.DataBindings.Clear();
            cbFoodCategory.DataBindings.Clear();
            txbIDFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "id"));
            txbNameFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "name"));
            txbPriceFood.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "price"));
            cbFoodCategory.DataBindings.Add(new Binding("Text", dgvFood.DataSource, "idCategory"));

            cbFoodCategory.DataSource = QLCFDB.db.FoodCategory.Select(p => p.name).ToList();
            cbStatusFood.Text = QLCFDB.db.Food.Where(p => p.id.ToString() == txbIDFood.Text).ToList()[0].status == 1 ? "Bán" : "Dừng bán";
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            loadFood();
            showFood();
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (txbIDFood.Text!="")
            {
                QLCFDB.db.Food.Where(p => p.id.ToString() == txbIDFood.Text).ToList()[0].status = 0;
                QLCFDB.db.SaveChanges();
                loadFood();
            }
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            if (txbIDFood.Text!="")
            {
                try
                {
                    QLCFDB.db.Food.Where(p => p.id.ToString() == txbIDFood.Text).ToList()[0].name = txbNameFood.Text;
                    QLCFDB.db.Food.Where(p => p.id.ToString() == txbIDFood.Text).ToList()[0].price = double.Parse(txbPriceFood.Text);
                    QLCFDB.db.Food.Where(p => p.id.ToString() == txbIDFood.Text).ToList()[0].idCategory = QLCFDB.db.FoodCategory.Where(p => p.name == cbFoodCategory.Text).ToList()[0].id;
                    QLCFDB.db.Food.Where(p => p.id.ToString() == txbIDFood.Text).ToList()[0].status = cbStatusFood.Text == "Bán" ? 1 : 0;
                    QLCFDB.db.SaveChanges();
                    loadFood();
                }
                catch (Exception)
                {

                    MessageBox.Show("Vui lòng nhập lại thông tin");
                }
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            fThemThucAn f = new fThemThucAn();
            f.ShowDialog();
        }
        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showFood();
        }

        #endregion

        private void txbNameFood_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
