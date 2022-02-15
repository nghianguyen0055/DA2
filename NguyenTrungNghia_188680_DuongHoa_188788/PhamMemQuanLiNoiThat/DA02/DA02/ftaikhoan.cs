using DA02.DAO;
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
    public partial class ftaikhoan : Form
    {
        public ftaikhoan()
        {
            InitializeComponent();
            loaddata();
        }
        void loaddata()
        {
            string query = "SELECT*FROM TAIKHOAN";//khi có nhiều parameter phải cách ra dấy , (dùng để add nhiều parameter)
            dgvTaikhoan.DataSource = DataProvider.Instance.ExecuteQuery(query);
            //dgv_dangnhap.DataSource = provider.ExecuteQuery(query, new object[] ("parameter"); thêm nhiều parameter
        }
        void resert()
        {
            txtUsername.Clear();
            txtPass.Clear();
            txttimkiem.Clear();
        }

        private void dgvTaikhoan_Click(object sender, EventArgs e)
        {
            txtUsername.Text = dgvTaikhoan.CurrentRow.Cells["USERNAME"].Value.ToString();
            txtPass.Text = dgvTaikhoan.CurrentRow.Cells["PASSWORD"].Value.ToString();
            if (dgvTaikhoan.CurrentRow.Cells["QUYEN"].Value.ToString() == "ADMIN")
            {
                chkQuyen.Checked = true;
            }
            else
                chkQuyen.Checked = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string q;
            if (chkQuyen.Checked == true)
            {
                q = "ADMIN";
            }
            else
                q = "USER";
            if (txtUsername.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tài khoản!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (txtPass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }
            string username = txtUsername.Text;
            string matkhau = txtPass.Text;
            string quyen = q;
            TaiKhoanDAO.Instance.themTK(username, matkhau, quyen);
            resert();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string q;
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }
            if (chkQuyen.Checked == true)
                q = "ADMIN";
            else
                q = "USER";
            string username = txtUsername.Text;
            string matkhau = txtPass.Text;
            string quyen = q;
            TaiKhoanDAO.Instance.suaTK(username, matkhau, quyen);
            MessageBox.Show("Sửa Thành Công!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            resert();
            loaddata();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            resert();
            loaddata();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }
            string username = txtUsername.Text;
            if (MessageBox.Show("Bạn có muốn xoá Tài Khoản này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TaiKhoanDAO.Instance.xoaTK(username);
                resert();
                loaddata();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select * from TaiKhoan where username like '%" + txttimkiem.Text.Trim() + "'";
            dgvTaikhoan.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
