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
    public partial class fKhachHang : Form
    {
        public fKhachHang()
        {
            InitializeComponent();
            loaddata();
        }
        void loaddata()
        {
            string query = "select* from khachhang";
            dgvKH.DataSource = DataProvider.Instance.ExecuteQuery(query);
            txtTenKH.Focus();
            resetvalues();
            //ktra();
        }
        void resetvalues()
        {
            string qrr = "exec khachhang_TUTANGID ";
            DataTable dt = DataProvider.Instance.ExecuteQuery(qrr);
            txtMaKH.Text = dt.Rows[0][0].ToString();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSdt.Clear();
            chkGioiTinh.Checked = false;
            txttimkiem.Clear();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            resetvalues();
            loaddata();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select * from khachhang where makh like'%" + txttimkiem.Text.Trim() + "%'";
            dgvKH.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gt;
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (txtSdt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return;
            }
            if (chkGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";

            string tenkh = txtTenKH.Text;
            string makh = txtMaKH.Text;
            string gioitinh = gt;
            string diachi = txtDiaChi.Text;
            string sdt = txtSdt.Text;
            KhachHangDAO.Instance.insertKH(makh, tenkh, gioitinh, diachi, sdt);
            //MessageBox.Show("Thêm thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            resetvalues();
            loaddata();
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))

                e.Handled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt;
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (chkGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            string tenkh = txtTenKH.Text;
            string makh = txtMaKH.Text;
            string gioitinh = gt;
            string diachi = txtDiaChi.Text;
            string sdt = txtSdt.Text;
            KhachHangDAO.Instance.editKH(makh, tenkh, gioitinh, diachi, sdt);
            MessageBox.Show("Sửa thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            resetvalues();
            loaddata();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            string makh = txtMaKH.Text;
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KhachHangDAO.Instance.deleteKH(makh);
                resetvalues();
                loaddata();
            }
        }

        private void dgvKH_Click(object sender, EventArgs e)
        {
            if (dgvKH.CurrentRow.Cells["GIOITINH"].Value.ToString() == "NAM" || dgvKH.CurrentRow.Cells["GIOITINH"].Value.ToString() == "Nam")
                chkGioiTinh.Checked = true;
            else
                chkGioiTinh.Checked = false;
            txtMaKH.Text = dgvKH.CurrentRow.Cells["MAKH"].Value.ToString();
            txtTenKH.Text = dgvKH.CurrentRow.Cells["TENKH"].Value.ToString();
            txtDiaChi.Text = dgvKH.CurrentRow.Cells["DIACHI"].Value.ToString();
            txtSdt.Text = dgvKH.CurrentRow.Cells["SDT"].Value.ToString();
        }

        private void btntimten_Click(object sender, EventArgs e)
        {
            string query = "select * from khachhang where tenkh like N'%" + txttimkiem.Text.Trim() + "%'";
            dgvKH.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
