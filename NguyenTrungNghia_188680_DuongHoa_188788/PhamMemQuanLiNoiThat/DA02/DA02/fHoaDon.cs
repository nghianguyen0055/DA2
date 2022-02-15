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
using COMExcel = Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace DA02
{
    public partial class fHoaDon : Form
    {
        public fHoaDon()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            string query = "select*from hoadon";
            dgvHoaDon.DataSource = DataProvider.Instance.ExecuteQuery(query);
            string queryy = "select* from cthd";
            dgvCTHD.DataSource = DataProvider.Instance.ExecuteQuery(queryy);
            cbbNV.Focus();
            loadmanv();
            loadkh();
            loadhoadon();
            loadsanpham();
            ktra();
            reset();
        }
        void reset()
        {
            string query = "exec HOADON_TUTANGID";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            txtMahd.Text = dt.Rows[0][0].ToString();
            string qr = "exec HOADONCT_TUTANGID";
            DataTable dtt = DataProvider.Instance.ExecuteQuery(qr);
            txtCTHD.Text = dtt.Rows[0][0].ToString();
            txtDonGia.Text = "0";
            nmrSoluong.Value = 0;
            txtThanhTien.Text = "0";
            nmrGiamGia.Value = 0;
            txtKH.Text = "";
            cbbNV.Text = "";
            dtpkNgay.Value = DateTime.Now;
            txtTongtien.Text = "0";
            txttimkiem.Clear();
            cbbTen.Text = "";
        }
        void loadmanv()
        {
            List<NhanVien> listnv = NhanVienDAO.Instance.laynv();
            cbbNV.DataSource = listnv;
            cbbNV.DisplayMember = "manv";
            cbbNV.ValueMember = "manv";
        }
        void loadkh()
        {
            List<KhachHang> listkh = KhachHangDAO.Instance.laykh();
            cbbTen.DataSource = listkh;
            cbbTen.DisplayMember = "makh";
            cbbTen.ValueMember = "makh";
        }
        void loadhoadon()
        {
            List<HoaDon> listhd = HDDAO.Instance.layhd();
            cbbMahd.DataSource = listhd;
            cbbMahd.DisplayMember = "mahd";
            cbbMahd.ValueMember = "mahd";
        }
        void loadsanpham()
        {
            List<SanPham> listspp = SanPhamDAO.Instance.laysp();
            cbbSP.DataSource = listspp;
            cbbSP.DisplayMember = "tensp";
            cbbSP.ValueMember = "masp";
        }
        void loadcthd()
        {
            string queryy = "select* from cthd where mahd = '" + cbbMahd.SelectedValue.ToString() + "'";
            dgvCTHD.DataSource = DataProvider.Instance.ExecuteQuery(queryy);
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            btnThenCTHD.Enabled = true;
            chkTT.Checked = false;
            reset();
            txtThanhTien.Text = "0";
            load();
        }
        void ktra()
        {
            if (chkTT.Checked == true)
            {
                btnThanhtoan.Enabled = false;
                btnThenCTHD.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnSuaCTHD.Enabled = false;
                btnIn.Enabled = true;
                btnXoaCTHD.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
                btnThanhtoan.Enabled = true;
                btnThenCTHD.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnSuaCTHD.Enabled = true;
                btnIn.Enabled = false;
                btnXoaCTHD.Enabled = true;
            }
        }

        private void cbbTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select tenkh from khachhang where makh = '" + cbbTen.SelectedValue.ToString() + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            try
            {
                txtKH.Text = dt.Rows[0][0].ToString();
            }
            catch
            {
                return;
            }
        }

        private void cbbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select dongia from sanpham where masp = '" + cbbSP.SelectedValue.ToString() + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            try {
                txtDonGia.Text = dt.Rows[0][0].ToString();
            } catch
            {
                return;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select*from hoadon where mahd like '%" + txttimkiem.Text.Trim() + "%'";
            dgvHoaDon.DataSource = DataProvider.Instance.ExecuteQuery(query);
    }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tt;
            if (chkTT.Checked == true)
            {
                tt = "Đã Thanh Toán";
            }
            else
            {
                tt = "Chưa Thanh Toán";
            }
            string mahd = txtMahd.Text;
            string manv = cbbNV.SelectedValue.ToString();
            string makh = cbbTen.SelectedValue.ToString();
            int giamgia = (int)nmrGiamGia.Value;
            DateTime ngayban = dtpkNgay.Value;
            string tenkh = txtKH.Text;
            string trangthai = tt;
            int tongtien = Convert.ToInt32(txtTongtien.Text);
            HDDAO.Instance.themHD(mahd, manv, makh, ngayban, trangthai, tongtien, giamgia, tenkh);
            reset();
            load();
        }
        private void dgvHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow.Cells["trangthai"].Value.ToString() == "Đã Thanh Toán")
                chkTT.Checked = true;
            else
                chkTT.Checked = false;
            txtMahd.Text = dgvHoaDon.CurrentRow.Cells["mahd"].Value.ToString();
            txtKH.Text = dgvHoaDon.CurrentRow.Cells["tenkh"].Value.ToString();
            cbbTen.Text = dgvHoaDon.CurrentRow.Cells["makh"].Value.ToString();
            cbbNV.Text = dgvHoaDon.CurrentRow.Cells["manv"].Value.ToString();
            dtpkNgay.Text = dgvHoaDon.CurrentRow.Cells["ngayban"].Value.ToString();
            txtTongtien.Text = dgvHoaDon.CurrentRow.Cells["tongtien"].Value.ToString();
            nmrGiamGia.Text = dgvHoaDon.CurrentRow.Cells["giamgia"].Value.ToString();
            string query = "select*from cthd where mahd='" + txtMahd.Text + "'";
            dgvCTHD.DataSource = DataProvider.Instance.ExecuteQuery(query);
            ktra();
            cbbMahd.Text = txtMahd.Text;
            string mahd = cbbMahd.SelectedValue.ToString();
            string queryy = "select dbo.tongtienHD('" + cbbMahd.SelectedValue.ToString() + "')";
            int tong = (int)DataProvider.Instance.ExecuteScalar(queryy, new object[] { mahd });
            int giamgia = (int)nmrGiamGia.Value;
            int tongcong = tong - (tong / 100) * giamgia;
            txtTongtien.Text = tongcong.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tt;
            if (chkTT.Checked == true)
            {
                tt = "Đã Thanh Toán";
            }
            else
            {
                tt = "Chưa Thanh Toán";
            }
            if (cbbTen.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbTen.Focus();
                return;
            }
            string mahd = txtMahd.Text;
            string manv = cbbNV.SelectedValue.ToString();
            string makh = cbbTen.SelectedValue.ToString();
            int giamgia = (int)nmrGiamGia.Value;
            DateTime ngayban = dtpkNgay.Value;
            string tenkh = txtKH.Text;
            string trangthai = tt;
            int tongtien = Convert.ToInt32(txtTongtien.Text);
            HDDAO.Instance.suaHD(mahd, manv, makh, ngayban, trangthai, tongtien, giamgia, tenkh);
            MessageBox.Show("Sửa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reset();
            load();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cbbTen.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbTen.Focus();
                return;
            }
            string mahd = txtMahd.Text;
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HDDAO.Instance.xoaHD(mahd);
                reset();
                load();
            }
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {

            if (chkTT.Checked == false)
            {
                string mahd = txtMahd.Text;
                int tong = Convert.ToInt32(txtTongtien.Text);
                string tt;
                chkTT.Checked = true;
                tt = "Đã Thanh Toán";
                string trangthai = tt;
                if (MessageBox.Show("Bạn có muốn thanh toán hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HDDAO.Instance.ThanhToan(mahd, tong, trangthai);
                    reset();
                    load();
                }
            }
        }

        private void btnThenCTHD_Click(object sender, EventArgs e)
        {
            string query = "select soluong from sanpham where masp ='" + cbbSP.SelectedValue.ToString() + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            int soluongg = Convert.ToInt32(dt.Rows[0][0].ToString());
            int sl = (int)nmrSoluong.Value;
            if (sl > soluongg)
            {
                MessageBox.Show("Số Lượng Chỉ Còn: " + soluongg, "Thông Báo!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nmrSoluong.Maximum = soluongg;
            }
            else
            {
                string macthd = txtCTHD.Text;
                string mahd = cbbMahd.SelectedValue.ToString();
                string masp = cbbSP.SelectedValue.ToString();
                int soluong = (int)nmrSoluong.Value;
                int dongia = Convert.ToInt32(txtDonGia.Text);
                int thanhtien = Convert.ToInt32(txtThanhTien.Text);
                CTHDDAO.Instace.themCTHD(macthd, mahd, masp, soluong, dongia, thanhtien);
                HDDAO.Instance.capnhatsoluong(masp, soluong);
                resetcthd();
                loadcthd();
            }
        }
        void resetcthd()
        {
            string qr = "exec HOADONCT_TUTANGID";
            DataTable dtt = DataProvider.Instance.ExecuteQuery(qr);
            txtCTHD.Text = dtt.Rows[0][0].ToString();
            cbbMahd.Text = txtMahd.Text;
            cbbSP.Text = "";
            nmrSoluong.Value = 0;
            txtDonGia.Text = "";
            txtThanhTien.Text = "0";
        }

        private void btnSuaCTHD_Click(object sender, EventArgs e)
        {
           
            string macthd = txtCTHD.Text;
            string mahd = cbbMahd.SelectedValue.ToString();
            string masp = cbbSP.SelectedValue.ToString();
            int soluong = (int)nmrSoluong.Value;
            int dongia = Convert.ToInt32(txtDonGia.Text);
            int thanhtien = Convert.ToInt32(txtThanhTien.Text);
            CTHDDAO.Instace.suaCTHD(macthd, mahd, masp, soluong, dongia, thanhtien);
            MessageBox.Show("Sửa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            resetcthd();
            loadcthd();
        }

        private void btnXoaCTHD_Click(object sender, EventArgs e)
        {
            if (cbbMahd.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbMahd.Focus();
                return;
            }
            string macthd = txtCTHD.Text;
            int soluong = (int)nmrSoluong.Value;
            string masp = cbbSP.SelectedValue.ToString();
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CTHDDAO.Instace.xoaCTHD(macthd);
                HDDAO.Instance.capnhatxoasoluong(masp, soluong);
                resetcthd();
                loadcthd();
            }
        }

        private void dgvCTHD_Click(object sender, EventArgs e)
        {
            txtCTHD.Text = dgvCTHD.CurrentRow.Cells["macthd"].Value.ToString();
            cbbMahd.Text = dgvCTHD.CurrentRow.Cells["mahdd"].Value.ToString();
            cbbSP.Text = dgvCTHD.CurrentRow.Cells["masp"].Value.ToString();
            txtDonGia.Text = dgvCTHD.CurrentRow.Cells["dongia"].Value.ToString();
            nmrSoluong.Text = dgvCTHD.CurrentRow.Cells["soluong"].Value.ToString();
            txtThanhTien.Text = dgvCTHD.CurrentRow.Cells["thanhtien"].Value.ToString();
        }

        private void nmrSoluong_ValueChanged(object sender, EventArgs e)
        {
            int sll = Convert.ToInt32(nmrSoluong.Value);
            if (sll > 0)
            {
                int sl = (int)(nmrSoluong.Value);
                int dongia = Convert.ToInt32(txtDonGia.Text);
                int tong = sl * dongia;
                txtThanhTien.Text = tong.ToString();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (txtKH.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn cần in!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtKH.Focus();
                return;
            }
            //khởi động excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //trong 1 ctrinh excel có nhiều workbook
            COMExcel.Worksheet exSheet; //trong 1 workbook có nhiều worksheet
            COMExcel.Range exRange;
            string query;
            int hang = 0, cot = 0;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            //định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //XANH DA TRỜI
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Cửa Hàng Tin03";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Ninh Kiều - Cần Thơ";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (84)343745238";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            query = "select MAHD, NGAYBAN, TONGTIEN, KHACHHANG.TENKH, KHACHHANG.DIACHI, KHACHHANG.SDT, TENNV, BAOHANH FROM HOADON, KHACHHANG, NHANVIEN, SANPHAM WHERE HOADON.MAKH = KHACHHANG.MAKH AND HOADON.MANV = NHANVIEN.MANV AND MAHD = '" + txtMahd.Text + "'";
            DataTable dthd = DataProvider.Instance.ExecuteQuery(query);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = dthd.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = dthd.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = dthd.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = dthd.Rows[0][5].ToString();
            exRange.Range["B10:B10"].MergeCells = true;
            exRange.Range["B10:B10"].Value = "Bảo Hành:";
            exRange.Range["C10:E10"].MergeCells = true;
            exRange.Range["C10:E10"].Value = dthd.Rows[0][7].ToString();
            //Lấy thông tin các mặt hàng
            string queryy = "select TENSP, CTHD.SOLUONG, SANPHAM.DONGIA, GIAMGIA, THANHTIEN FROM SANPHAM, HOADON, CTHD WHERE  SANPHAM.MASP=CTHD.MASP AND HOADON.MAHD=CTHD.MAHD AND HOADON.MAHD ='" + txtMahd.Text + "'";
            DataTable cthd = DataProvider.Instance.ExecuteQuery(queryy);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["B11:B11"].ColumnWidth = 30;
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < cthd.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < cthd.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = cthd.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = cthd.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = dthd.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            DateTime d = Convert.ToDateTime(dthd.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "CẦN THƠ, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = dthd.Rows[0][6];
            exSheet.Name = "Hóa đơn";
            exApp.Visible = true;
        }
    }
}
