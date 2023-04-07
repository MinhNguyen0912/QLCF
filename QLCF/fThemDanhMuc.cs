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
    public partial class fThemDanhMuc : Form
    {
        public fThemDanhMuc()
        {
            InitializeComponent();
        }

        private void btThemDanhMuc_Click(object sender, EventArgs e)
        {
            string DanhMuc = textBox1.Text.Trim().ToLower();
            if(textBox1.Text.Trim().ToLower().Length == 0)
            {
                MessageBox.Show("Mời Bạn Nhập Tên Danh Mục Muốn Thêm!");
            }
            else
            {
                var dm = QLCFDB.db.FoodCategory.Select(t => t).ToList();
                for (int j = 0; j < dm.Count; j++)
                {
                    if (dm[j].name != textBox1.Text.Trim().ToLower())
                    {
                        QLCFDB.db.FoodCategory.Add(new FoodCategory { name = textBox1.Text.Trim().ToLower()});
                        MessageBox.Show("Danh Mục Đã Được Thêm");
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Danh Mục Đã Tồn Tại");
                        break;
                    }
                    return;
                }

            }
            QLCFDB.db.SaveChanges();
        }
        //public void checkdanhmuc(string DanhMuc)
        //{
        //    var dm = QLCFDB.db.FoodCategories.Select(t => t).ToList();
        //    for (int j = 0; j < dm.Count; j++)
        //    {
        //        if (dm[j].name != textBox1.Text.Trim().ToLower())
        //        {
        //            QLCFDB.db.FoodCategories.Add(new FoodCategory { name = textBox1.Text.Trim().ToLower() });
        //            QLCFDB.db.SaveChanges();
        //            MessageBox.Show("Danh Mục Đã Được Thêm");
        //            break;
        //        }
        //        else 
        //        {
        //            MessageBox.Show("Danh Mục Đã Tồn Tại");
        //            break;
        //        }
        //    }
        //}
    }
}
