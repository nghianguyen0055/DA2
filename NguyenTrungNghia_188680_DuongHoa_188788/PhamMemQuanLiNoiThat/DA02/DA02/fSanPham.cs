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
    public partial class fSanPham : Form
    {
        public fSanPham()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            string query = "select*from sanpham";
            dgvSanpham.DataSource = DataProvider.Instance.ExecuteQuery(query);
            loadloai();
            loadmaNCC();
            reset();
        }
        void reset()
        {
            string query = "SANPHAM_TUTANGIDDD";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            txtMaSP.Text = dt.Rows[0][0].ToString();
            txtTenSP.Clear();
            txtsoluong.Clear();
            txtDongia.Clear();
            cbbNSX.Text = "";
            cbbMaloai.Text = "";
            txttimkiem.Clear();
            txtDVT.Clear();
            txtBaohanh.Clear();
            txtChatlieu.Clear();
            txtAnh.Clear();
            ptbAnh.Image = null;
        }
        void loadmaNCC()
        {
            List<NSX> listncc = NSXDAO.Instance.layncc();
            cbbNSX.DataSource = listncc;
            cbbNSX.DisplayMember = "tennsx";
            cbbNSX.ValueMember = "mansx";
        }
        void loadloai()
        {
            List<Loai> listloai = LoaiDAO.Instance.layloai();
            cbbMaloai.DataSource = listloai;
            cbbMaloai.DisplayMember = "tenloai";
            cbbMaloai.ValueMember = "maloai";
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset();
            load();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select * from sanpham where masp like '%" + txttimkiem.Text.Trim() + "%'";
            dgvSanpham.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))

                e.Handled = true;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return;
            }
            if (txtDongia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDongia.Focus();
                return;
            }
            if (txtsoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Focus();
                return;
            }
            if (txtBaohanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập bảo hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBaohanh.Focus();
                return;
            }
            if (txtDVT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVT.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh sản Phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnADD.Focus();
                return;
            }

            string masp = txtMaSP.Text;
            string tensp = txtTenSP.Text;
            string ml = cbbMaloai.SelectedValue.ToString();
            string mansx = cbbNSX.SelectedValue.ToString();
            int soluong = Convert.ToInt32(txtsoluong.Text);
            int gia = Convert.ToInt32(txtDongia.Text);
            string baohanh = txtBaohanh.Text;
            string chatlieu = txtChatlieu.Text;
            string dvt = txtDVT.Text;
            string anh = txtAnh.Text;
            SanPhamDAO.Instance.themSP(masp, tensp, ml, gia, anh, baohanh, mansx, chatlieu, soluong, dvt);
            reset();
            load();
        }

        private void dgvSanpham_Click(object sender, EventArgs e)
        {

            txtMaSP.Text = dgvSanpham.CurrentRow.Cells["masp"].Value.ToString();
            cbbMaloai.Text = dgvSanpham.CurrentRow.Cells["maloai"].Value.ToString();
            cbbNSX.Text = dgvSanpham.CurrentRow.Cells["mansx"].Value.ToString();
            txtDongia.Text = dgvSanpham.CurrentRow.Cells["dongia"].Value.ToString();
            txtsoluong.Text = dgvSanpham.CurrentRow.Cells["soluong"].Value.ToString();
            txtTenSP.Text = dgvSanpham.CurrentRow.Cells["tensp"].Value.ToString();
            txtBaohanh.Text = dgvSanpham.CurrentRow.Cells["baohanh"].Value.ToString();
            txtDVT.Text = dgvSanpham.CurrentRow.Cells["dvt"].Value.ToString();
            txtChatlieu.Text = dgvSanpham.CurrentRow.Cells["chatlieu"].Value.ToString();
            string query = "SELECT AnhSP FROM SANPHAM WHERE MaSP=N'" + txtMaSP.Text + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            txtAnh.Text = dt.Rows[0][0].ToString();
            ptbAnh.Image = Image.FromFile(txtAnh.Text);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSP.Focus();
                return;
            }
            string masp = txtMaSP.Text;
            string tensp = txtTenSP.Text;
            string ml = cbbMaloai.SelectedValue.ToString();
            string mansx = cbbNSX.SelectedValue.ToString();
            int soluong = Convert.ToInt32(txtsoluong.Text);
            int gia = Convert.ToInt32(txtDongia.Text);
            string baohanh = txtBaohanh.Text;
            string chatlieu = txtChatlieu.Text;
            string dvt = txtDVT.Text;
            string anh = txtAnh.Text;
            SanPhamDAO.Instance.suaSP(masp, tensp, ml, gia, anh, baohanh, mansx, chatlieu, soluong, dvt);
            MessageBox.Show("Sửa Thành Công!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            load();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSP.Focus();
                return;
            }
            string masp = txtMaSP.Text;
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SanPhamDAO.Instance.xoaSP(masp);
                reset();
                load();
            }
        }

        private void btntimten_Click(object sender, EventArgs e)
        {
            string query = "select * from sanpham where tensp like N'%" + txttimkiem.Text.Trim() + "%'";
            dgvSanpham.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
