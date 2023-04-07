using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLCF
{
    public partial class fAddAccount : Form
    {
        public fAddAccount()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTK.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 ||
                 textBox1.Text.Trim().Length == 0 || comboBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {

                var account = QLCFDB.db.Account.Select(p => p.UserName).ToList();
                for (int i = 0; i < account.Count; i++) 
                {
                    if (txtTK.Text.Trim() == account[i].ToString())
                    {
                        MessageBox.Show("Tài khoản đã tồn tại, vui lòng chọn tài khoản khác ","Thông báo");
                    }
                    else
                    {
                        AddAccount();
                    }
                    return;


                }

            }
            button1.FlatAppearance.BorderSize = 0;
            void AddAccount()
            {

                if (comboBox1.Text == "Admin")
                {
                    Account ac = new Account() { UserName = txtTK.Text.Trim(), DisplayName = textBox2.Text.Trim(), PassWord = textBox1.Text.Trim(), Type = 1 };
                    QLCFDB.db.Account.Add(ac);
                    QLCFDB.db.SaveChanges();
                    MessageBox.Show("Thêm tài khoản thành công");
                }
                if (comboBox1.Text == "Staff")
                {
                    Account ac = new Account() { UserName = txtTK.Text.Trim(), DisplayName = textBox2.Text.Trim(), PassWord = textBox1.Text.Trim(), Type = 0 };
                    QLCFDB.db.Account.Add(ac);
                    QLCFDB.db.SaveChanges();
                    MessageBox.Show("Thêm tài khoản thành công");
                }

            }

        }
    }
}

