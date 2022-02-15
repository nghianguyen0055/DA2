using DA02.DAO;
using DA02.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA02
{
    public partial class fdoiMK : Form
    {

        private account loginacccount;
        public account Loginacccount { get => loginacccount; set => loginacccount = value; }
        public fdoiMK(account acc)
        {
            InitializeComponent();
            loginacccount = acc;
            changeaccount(loginacccount);
        }
        void changeaccount(account acc)
        {
            txtUserName.Text = loginacccount.UserName;
        }

        private void btnDoiMk_Click(object sender, EventArgs e)
        {
            if (txtMkcu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMkcu.Focus();
                return;
            }
            if (txtMKmoi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMKmoi.Focus();
                return;
            }
            if (txtNhapLai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại mât khẩu!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLai.Focus();
                return;
            }
            updateaccount();
            reset();
        }
        void updateaccount()
        {
            string username = txtUserName.Text;
            string pass = txtMkcu.Text;
            string newpass = txtMKmoi.Text;
            string nhaplai = txtNhapLai.Text;
            if (!newpass.Equals(nhaplai))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!!!", "Thông Báo");
            }
            else
            {
                if (accountDAO.Instance.updateaccount(username, pass, newpass))
                {
                    MessageBox.Show("Đổi thành công!!!", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("vui lòng điền đúng mật khẩu");
                }
            }
        }
        void reset()
        {
            txtMkcu.Clear();
            txtMKmoi.Clear();
            txtNhapLai.Clear();
        }

    }
}
