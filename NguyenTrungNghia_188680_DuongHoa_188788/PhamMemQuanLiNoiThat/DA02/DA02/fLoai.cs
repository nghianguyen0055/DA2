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
    public partial class fLoai : Form
    {
        public fLoai()
        {
            InitializeComponent();
            loaddata();
        }

        void loaddata()
        {
            string query = "select*from loai";
            dgvLoai.DataSource = DataProvider.Instance.ExecuteQuery(query);
            reset();
            txttenloai.Focus();
        }
        void reset()
        {
            string qr = "exec LOAI_TUTANGID";
            DataTable dt = DataProvider.Instance.ExecuteQuery(qr);
            txtMaloai.Text = dt.Rows[0][0].ToString();
            txttenloai.Text = "";
            txttimkiem.Clear();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            reset();
            loaddata();
        }

        private void dgvLoai_Click(object sender, EventArgs e)
        {
            txtMaloai.Text = dgvLoai.CurrentRow.Cells["maloai"].Value.ToString();
            txttenloai.Text = dgvLoai.CurrentRow.Cells["tenloai"].Value.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select * from loai where maloai like '%" + txttimkiem.Text.Trim() + "%'";
            dgvLoai.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txttenloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloai.Focus();
                return;
            }
            string maloai = txtMaloai.Text;
            string tenloai = txttenloai.Text;
            LoaiDAO.Instance.insertloai(maloai, tenloai);
            //MessageBox.Show("Thêm thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txttenloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenloai.Focus();
                return;
            }
            string maloai = txtMaloai.Text;
            string tenloai = txttenloai.Text;
            LoaiDAO.Instance.editLoai(maloai, tenloai);
            MessageBox.Show("Sửa thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            loaddata();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txttenloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenloai.Focus();
                return;
            }
            string maloai = txtMaloai.Text;
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoaiDAO.Instance.deleteLoai(maloai);
                reset();
                loaddata();
            }
        }

        private void btntimten_Click(object sender, EventArgs e)
        {
            string query = "select * from loai where maloai like N'%" + txttimkiem.Text.Trim() + "%'";
            dgvLoai.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
