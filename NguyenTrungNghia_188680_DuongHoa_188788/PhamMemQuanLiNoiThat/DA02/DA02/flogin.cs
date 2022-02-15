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
    public partial class flogin : Form
    {
        public flogin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn Có Muốn Thoát?","Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLogin.Text;
            string pass = txtPass.Text;
            if (Login(username, pass))
            {
                account loginAccount = accountDAO.Instance.GetAccountByUserName(username);
                MessageBox.Show("Đăng Nhập Thành Công!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fMain main = new fMain(loginAccount);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn Nhập Sai Mật Khẩu Hoặc Tài Khoản!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool Login(string username, string pass)
        {
            txtLogin.Clear();
            txtPass.Clear();
            return accountDAO.Instance.login(username, pass);
        }
    }
}
