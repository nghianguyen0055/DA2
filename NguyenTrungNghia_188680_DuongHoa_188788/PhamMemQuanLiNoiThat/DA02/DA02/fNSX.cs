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
    public partial class fNSX : Form
    {
        public fNSX()
        {
            InitializeComponent();
            loaddata();
        }
        void loaddata()
        {
            string query = "select*from nhasx";
            dgvNSX.DataSource = DataProvider.Instance.ExecuteQuery(query);
            reset();
            txtTenNSX.Focus();
        }
        void reset()
        {
            string qr = "NHASX_TUTANGID";
            DataTable dt = DataProvider.Instance.ExecuteQuery(qr);
            txtMaNSX.Text = dt.Rows[0][0].ToString();
            txtTenNSX.Text = "";
            txtDiaChi.Text = "";
            txtSdt.Text = "";
            txttimkiem.Clear();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset();
            loaddata();
            txtTenNSX.Focus();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select *from nhaSX where maNSX like '%" + txttimkiem.Text.Trim() + "%'";
            dgvNSX.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void dgvNSX_Click(object sender, EventArgs e)
        {
            txtMaNSX.Text = dgvNSX.CurrentRow.Cells["manSX"].Value.ToString();
            txtTenNSX.Text = dgvNSX.CurrentRow.Cells["tennSX"].Value.ToString();
            txtDiaChi.Text = dgvNSX.CurrentRow.Cells["diachi"].Value.ToString();
            txtSdt.Text = dgvNSX.CurrentRow.Cells["sdt"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenNSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Nhà Cung Cấp!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNSX.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ nhà cung cấp!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (txtSdt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại nhà cung cấp!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return;
            }
            string maNSX = txtMaNSX.Text;
            string tenNSX = txtTenNSX.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSdt.Text;
            NSXDAO.Instance.themNSX(maNSX, tenNSX, diachi, sdt);
            // MessageBox.Show("Thêm thành công!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenNSX.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNSX.Focus();
                return;
            }
            string mansx = txtMaNSX.Text;
            string tennsx = txtTenNSX.Text;
            string diachi = txtDiaChi.Text;
            string sdt = txtSdt.Text;
            NSXDAO.Instance.suaNSX(mansx, tennsx, diachi, sdt);
            MessageBox.Show("Sửa thành công!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            loaddata();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            if (txtTenNSX.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNSX.Focus();
                return;
            }
            string mansx = txtMaNSX.Text;
            NSXDAO.Instance.xoaNSX(mansx);
            MessageBox.Show("Xóa thành công!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            loaddata();
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))

                e.Handled = true;
        }
    }
}
