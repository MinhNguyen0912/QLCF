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

namespace QLCF
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tk = txtTK.Text;
            string mk = txtMK.Text;
            if (txtTK.Text.Trim().Length == 0 && txtMK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else if (txtTK.Text.Trim().Length == 0 && txtMK.Text.Trim().Length > 0)
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
            }
            else if (txtTK.Text.Trim().Length > 0 && txtMK.Text.Trim().Length == 0)
            {

                MessageBox.Show("Vui lòng nhập mật khẩu!");
            }
            else
            {
                checklogin(tk, mk);
            }
        }
        private void checklogin(string tk, string mk)
        {
            var user = QLCFDB.db.Account.Where(u => u.UserName.Equals(tk.Trim())).ToList();

            if (user.Count() > 0)
            {
                if (user[0].PassWord.Equals(mk))
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    var account = QLCFDB.db.Account.FirstOrDefault(p => p.UserName == tk);
                    account.status = 1;
                    QLCFDB.db.SaveChanges();
                    this.Hide();
                    FQuanLyBan fMain = new FQuanLyBan();
                    fMain.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng!");
                }
            }
            else
            {
                MessageBox.Show("Không tồn tại tài khoản trong hệ thống!");
            }


        }
  

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
