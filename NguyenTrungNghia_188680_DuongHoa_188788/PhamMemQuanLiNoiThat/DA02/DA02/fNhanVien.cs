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
    public partial class fNhanVien : Form
    {
        public fNhanVien()
        {
            InitializeComponent();
            loaddata();
        }

        void loaddata()
        {
            string query = "select*from nhanvien";
            dgvNhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query);
            txtTenNV.Focus();
            reset();
        }
        void reset()
        {
            string query = "NHANVIEN_TUTANGID";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            txtMaNV.Text = dt.Rows[0][0].ToString();
            txtTenNV.Clear();
            chkGioiTinh.Checked = false;
            txtSdt.Clear();
            txtDiaChi.Clear();
            txttimkiem.Clear();
            txtAnh.Text = "";
            ptbAnh.Image = null;
            dtpkNgaySinh.Value = DateTime.Now;
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset();
            loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string gt;
            if (chkGioiTinh.Checked == true)
            {
                gt = "Nam";
            }
            else
                gt = "Nữ";
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
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
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnADD.Focus();
                return;
            }
            string manv = txtMaNV.Text;
            string tennv = txtTenNV.Text;
            string gioitinh = gt;
            string diachi = txtDiaChi.Text;
            string sdt = txtSdt.Text;
            DateTime ngaysinh = dtpkNgaySinh.Value;
            string anh = txtAnh.Text;
            NhanVienDAO.Instance.themNV(manv, tennv, gioitinh, ngaysinh, diachi, sdt, anh);
            reset();
            loaddata();

        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow.Cells["GIOITINH"].Value.ToString() == "NAM" || dgvNhanVien.CurrentRow.Cells["GIOITINH"].Value.ToString() == "Nam")
                chkGioiTinh.Checked = true;
            else
                chkGioiTinh.Checked = false;
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["manv"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["tennv"].Value.ToString();
            txtSdt.Text = dgvNhanVien.CurrentRow.Cells["sdt"].Value.ToString();
            dtpkNgaySinh.Text = dgvNhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            string query = "SELECT AnhNV FROM NhanVien WHERE MaNV=N'" + txtMaNV.Text + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            txtAnh.Text = dt.Rows[0][0].ToString();
            ptbAnh.Image = Image.FromFile(txtAnh.Text);
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                ptbAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gt;
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            if (chkGioiTinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            string tennv = txtTenNV.Text;
            string manv = txtMaNV.Text;
            string gioitinh = gt;
            string diachi = txtDiaChi.Text;
            string sdt = txtSdt.Text;
            DateTime ngaysinh = dtpkNgaySinh.Value;
            string anh = txtAnh.Text;
            NhanVienDAO.Instance.suaNV(manv, tennv, gioitinh, ngaysinh, diachi, sdt, anh);
            MessageBox.Show("Sửa Thành Công!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            loaddata();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }
            string manv = txtMaNV.Text;
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NhanVienDAO.Instance.xoaNV(manv);
                reset();
                loaddata();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select * from nhanvien where manv like '%" + txttimkiem.Text.Trim() + "'";
            dgvNhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))

                e.Handled = true;
        }

        private void btntimten_Click(object sender, EventArgs e)
        {
            string query = "select * from nhanvien where TENNV like N'%" + txttimkiem.Text.Trim() + "'";
            dgvNhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
