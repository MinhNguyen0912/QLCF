using QLCF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCF
{
    public partial class fSuaTTAcc : Form
    {
        public fSuaTTAcc()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("IMG/bg.jpg");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void fSuaTTAcc_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        public void HienThi()
        {
            var stt = QLCFDB.db.Account.Select(p => p).ToList();
            for (int i = 0; i < stt.Count; i++)
            {
                if (stt[i].status == 1)
                {
                    txtTenTk.Text = stt[i].UserName;
                    txtTenHienThi.Text = stt[i].DisplayName;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MKcu = txtMK.Text.Trim().ToLower();
            string MKmoi = txtMkmoi.Text.Trim().ToLower();
            string NhapLai = txtNhapLai.Text.Trim().ToLower();
            if (txtMK.Text.Trim().Length == 0 && txtMkmoi.Text.Trim().ToLower().Length == 0 && txtNhapLai.Text.Trim().ToLower().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else if (txtMK.Text.Trim().Length == 0 && txtMkmoi.Text.Trim().ToLower().Length > 0 && txtNhapLai.Text.Trim().ToLower().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!");
            }
            else if (txtMK.Text.Trim().Length == 0 && txtMkmoi.Text.Trim().ToLower().Length > 0 && txtNhapLai.Text.Trim().ToLower().Length > 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!");
            }
            else if (txtMK.Text.Trim().Length > 0 && txtMkmoi.Text.Trim().ToLower().Length == 0 && txtNhapLai.Text.Trim().ToLower().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
            }
            else if (txtMK.Text.Trim().Length > 0 && txtMkmoi.Text.Trim().ToLower().Length > 0 && txtNhapLai.Text.Trim().ToLower().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu mới!");
            }
            else
            {
                checkacc(MKcu, MKmoi, NhapLai);
            }
        }
        public void checkacc(string MKcu, string MKmoi, string NhapLai)
        {
            var stt = QLCFDB.db.Account.Select(n => n).ToList();
            for (int i = 0; i < stt.Count; i++)
            {
                if (stt[i].status == 1)
                {
                    if (stt[i].PassWord == txtMK.Text.Trim().ToLower())
                    {
                        if (txtMkmoi.Text.Trim().ToLower() == txtNhapLai.Text.Trim().ToLower())
                        {
                            var account = stt.FirstOrDefault(p => p.PassWord == MKcu);
                            account.PassWord = txtMkmoi.Text.Trim().ToLower();
                            QLCFDB.db.SaveChanges();
                            MessageBox.Show("Đổi mật khẩu thành công");
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu mới không giống nhau!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng. Mời Nhập lại");
                    }
                }

            }
        }
    }
}
