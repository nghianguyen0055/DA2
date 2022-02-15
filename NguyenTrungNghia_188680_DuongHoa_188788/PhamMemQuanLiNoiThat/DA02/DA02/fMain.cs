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
    public partial class fMain : Form
    {
        private account loginAccount;

        public account LoginAccount { get => loginAccount; set => loginAccount = value; }

        public fMain(account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            phanquyen(loginAccount.Quyen);
        }
        void phanquyen(string quyen)
        {
            mnthongke.Enabled = quyen == "ADMIN" ? true : false;
            MnXemTK.Enabled = quyen == "ADMIN" ? true : false;
            mnTaikhoan.Text += " (" + loginAccount.UserName + ")";
        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MnLoai_Click(object sender, EventArgs e)
        {
            fLoai loai = new fLoai();
            loai.MdiParent = this;
            loai.Dock = DockStyle.Fill;
            loai.Show();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is MdiClient){
                    ctrl.BackgroundImageLayout = ImageLayout.Stretch;
                    ctrl.BackgroundImage = Image.FromFile("E:\\DA02\\DA02\\DA02\\Resources\\bg1.jpg");

                }
            }
        }

        private void MnNhanVien_Click(object sender, EventArgs e)
        {
            fNhanVien Nv = new fNhanVien();
            Nv.MdiParent = this;
            Nv.Dock = DockStyle.Fill;
            Nv.Show();
        }

        private void MnSanPham_Click(object sender, EventArgs e)
        {
            fSanPham SP = new fSanPham();
            SP.MdiParent = this;
            SP.Dock = DockStyle.Fill;
            SP.Show();
        }

        private void MnKhachHang_Click(object sender, EventArgs e)
        {
            fKhachHang Kh = new fKhachHang();
            Kh.MdiParent = this;
            Kh.Dock = DockStyle.Fill;
            Kh.Show();
        }

        private void MnNSX_Click(object sender, EventArgs e)
        {
            fNSX Nsx = new fNSX();
            Nsx.MdiParent = this;
            Nsx.Dock = DockStyle.Fill;
            Nsx.Show();
        }

        private void MnNhapHang_Click(object sender, EventArgs e)
        {
            fNhapHang NH = new fNhapHang();
            NH.MdiParent = this;
            NH.Dock = DockStyle.Fill;
            NH.Show();
        }

        private void MnHoaDon_Click(object sender, EventArgs e)
        {
            fHoaDon HD = new fHoaDon();
            HD.MdiParent = this;
            HD.Dock = DockStyle.Fill;
            HD.Show();
        }

        private void MnDoiMK_Click(object sender, EventArgs e)
        {
            fdoiMK DoiMk = new fdoiMK(loginAccount);
            DoiMk.MdiParent = this;
            DoiMk.Dock = DockStyle.Fill;
            DoiMk.Show();
        }

        private void MnXemTK_Click(object sender, EventArgs e)
        {
            ftaikhoan TK = new ftaikhoan();
            TK.MdiParent = this;
            TK.Dock = DockStyle.Fill;
            TK.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThongKe Tke = new fThongKe();
            Tke.MdiParent = this;
            Tke.Dock = DockStyle.Fill;
            Tke.Show();
        }

        private void MnKho_Click(object sender, EventArgs e)
        {
            fKho Kho = new fKho();
            Kho.MdiParent = this;
            Kho.Dock = DockStyle.Fill;
            Kho.Show();
        }

        private void hỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fHoTro HT = new fHoTro();
            HT.MdiParent = this;
            HT.Dock = DockStyle.Fill;
            HT.Show();
        }
    }
}
