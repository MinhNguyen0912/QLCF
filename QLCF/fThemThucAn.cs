using QLCF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DuAN
{
    public partial class fThemThucAn : Form
    {
        public fThemThucAn()
        {
            InitializeComponent();
            nmGiaMon.Controls[0].Visible = false;
        }

        private void BTthemthucan_Click(object sender, EventArgs e)
        {
           string TenFood = txtTenMon.Text.Trim().ToLower();
           string DanhMuc = cbbDanhMuc.Text.Trim().ToLower();
            if (txtTenMon.Text.Trim().Length == 0 && cbbDanhMuc.Text.Trim().ToLower().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập thông tin món ăn!");
            }
            else if(txtTenMon.Text.Trim().Length == 0 && cbbDanhMuc.Text.Trim().ToLower().Length > 0)
            {
                MessageBox.Show("Vui lòng nhập tên thức ăn!");
            }
            else if (txtTenMon.Text.Trim().Length > 0 && cbbDanhMuc.Text.Trim().ToLower().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục thức ăn!");
            }
            else
            {
                checkFood(TenFood,DanhMuc);
            }

        }
        public void checkFood(string TenFood, string DanhMuc)
        {
            var db = QLCFDB.db;
            Food DoAn = new Food();
            DoAn.name = txtTenMon.Text.Trim().ToLower();
            DoAn.price = Convert.ToDouble(Math.Round(nmGiaMon.Value, 0));
            var IdDanhMuc = db.FoodCategory.Where(c => c.name == cbbDanhMuc.Text).Select(c => c.id).FirstOrDefault();
            DoAn.idCategory = IdDanhMuc;
            var cc = db.Food.Select(c => c).ToList();
            for (int i = 0; i < cc.Count; i++)
            {
                if (cc[i].name != txtTenMon.Text.Trim().ToLower())
                {
                    QLCFDB.db.Food.Add(DoAn);
                    QLCFDB.db.SaveChanges();
                    MessageBox.Show("Đã Thêm Món Thành Công", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Món Này Đã Có Trong Menu", "Thông Báo", MessageBoxButtons.OK);
                }
                return;
            }
        }
        private void cbbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BTthemthucan_MouseHover(object sender, EventArgs e)
        {

        }
        public void ListDanhMuc()
        {
            var db = QLCFDB.db;
            var Danhmuc = (from dm in db.FoodCategory select new { dm.name, dm.id }).ToList();
            foreach (var item in Danhmuc)
            {
                cbbDanhMuc.Items.Add(item.name);
            }
        }
        private void sThemThucAn_Load(object sender, EventArgs e)
        {
            ListDanhMuc();
        }

        private void nmGiaMon_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
