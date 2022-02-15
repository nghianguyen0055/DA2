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
    public partial class fNhapHang : Form
    {
        public fNhapHang()
        {
            InitializeComponent();
            loaddata();
        }
        void loaddata()
        {
            string query = "select*from NhapHang";
            dgvNhapHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
            loadmanv();
            loadsp();
            reset();
        }
        void reset()
        {
            string query = "exec NHAPHANG_TUTANGID";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            txtMaNH.Text = dt.Rows[0][0].ToString();
            cbbNV.Text = "";
            cbbSP.Text = "";
            txtDongia.Text = "0";
            txttimkiem.Clear();
            txtDiachi.Clear();
            dtpkNgayNhap.Value = DateTime.Now;
            txtTongtien.Text = "0";
            nmrSoluong.Value = 0;
        }
        void loadmanv()
        {
            List<NhanVien> listnv = NhanVienDAO.Instance.laynv();
            cbbNV.DataSource = listnv;
            cbbNV.DisplayMember = "tennv";
            cbbNV.ValueMember = "manv";
        }
        void loadsp()
        {
            List<SanPham> listsp = SanPhamDAO.Instance.laysp();
            cbbSP.DataSource = listsp;
            cbbSP.DisplayMember = "tensp";
            cbbSP.ValueMember = "masp";
        }

        private void dgvNhapHang_Click(object sender, EventArgs e)
        {
            txtMaNH.Text = dgvNhapHang.CurrentRow.Cells["maNH"].Value.ToString();
            cbbNV.Text = dgvNhapHang.CurrentRow.Cells["manv"].Value.ToString();
            cbbSP.Text = dgvNhapHang.CurrentRow.Cells["masp"].Value.ToString();
            txtTongtien.Text = dgvNhapHang.CurrentRow.Cells["tongtien"].Value.ToString();
            txtDiachi.Text = dgvNhapHang.CurrentRow.Cells["diachi"].Value.ToString();
            txtDongia.Text = dgvNhapHang.CurrentRow.Cells["gia"].Value.ToString();
            dtpkNgayNhap.Text = dgvNhapHang.CurrentRow.Cells["ngaynhap"].Value.ToString();
            nmrSoluong.Text = dgvNhapHang.CurrentRow.Cells["soluong"].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select*from NhapHang where manh like '%" + txttimkiem.Text.Trim() + "%'";
            dgvNhapHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void nmrSoluong_ValueChanged(object sender, EventArgs e)
        {
            int sl = (int)nmrSoluong.Value;
            if (sl > 0)
            {
                int sll = (int)nmrSoluong.Value;
                int gia = Convert.ToInt32(txtDongia.Text);
                int tong = sll * gia;
                txtTongtien.Text = tong.ToString();
            }
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))

                e.Handled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (txtDongia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongia.Focus();
                return;
            }
            string manh = txtMaNH.Text;
            string manv = cbbNV.SelectedValue.ToString();
            string masp = cbbSP.SelectedValue.ToString();
            int soluong = (int)nmrSoluong.Value;
            DateTime ngaynhap = dtpkNgayNhap.Value;
            string diachi = txtDiachi.Text;
            int gia = Convert.ToInt32(txtDongia.Text);
            int tongtien = Convert.ToInt32(txtTongtien.Text);
            NhapHangDAO.Instance.themNH(manh, manv, masp, soluong, ngaynhap, diachi, gia, tongtien);
            reset();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            string mahdn = txtMaNH.Text;
            string manv = cbbNV.SelectedValue.ToString();
            string masp = cbbSP.SelectedValue.ToString();
            int soluong = (int)nmrSoluong.Value;
            DateTime ngaynhap = dtpkNgayNhap.Value;
            string diachi = txtDiachi.Text;
            int gia = Convert.ToInt32(txtDongia.Text);
            int tongtien = Convert.ToInt32(txtTongtien.Text);
            NhapHangDAO.Instance.suaNH(mahdn, manv, masp, soluong, ngaynhap, diachi, gia, tongtien);
            MessageBox.Show("Sửa thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            loaddata();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }
            string manh = txtMaNH.Text;
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NhapHangDAO.Instance.xoaNH(manh);
                reset();
                loaddata();
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset();
            loaddata();
        }
    }
}
