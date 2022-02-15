
namespace DA02
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.MnLoai = new System.Windows.Forms.ToolStripMenuItem();
            this.MnNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.MnSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.MnKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.MnNSX = new System.Windows.Forms.ToolStripMenuItem();
            this.MnNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.MnHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnthongke = new System.Windows.Forms.ToolStripMenuItem();
            this.MnKho = new System.Windows.Forms.ToolStripMenuItem();
            this.mnTaikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.MnDoiMK = new System.Windows.Forms.ToolStripMenuItem();
            this.MnXemTK = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hỗTrợToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnDanhMuc,
            this.mnthongke,
            this.MnKho,
            this.mnTaikhoan,
            this.hỗTrợToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(933, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MnDanhMuc
            // 
            this.MnDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnLoai,
            this.MnNhanVien,
            this.MnSanPham,
            this.MnKhachHang,
            this.MnNSX,
            this.MnNhapHang,
            this.MnHoaDon});
            this.MnDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnDanhMuc.ForeColor = System.Drawing.Color.Sienna;
            this.MnDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("MnDanhMuc.Image")));
            this.MnDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnDanhMuc.Name = "MnDanhMuc";
            this.MnDanhMuc.Size = new System.Drawing.Size(99, 21);
            this.MnDanhMuc.Text = "Danh Mục";
            // 
            // MnLoai
            // 
            this.MnLoai.ForeColor = System.Drawing.Color.Peru;
            this.MnLoai.Image = ((System.Drawing.Image)(resources.GetObject("MnLoai.Image")));
            this.MnLoai.Name = "MnLoai";
            this.MnLoai.Size = new System.Drawing.Size(160, 22);
            this.MnLoai.Text = "Loại ";
            this.MnLoai.Click += new System.EventHandler(this.MnLoai_Click);
            // 
            // MnNhanVien
            // 
            this.MnNhanVien.ForeColor = System.Drawing.Color.Peru;
            this.MnNhanVien.Image = ((System.Drawing.Image)(resources.GetObject("MnNhanVien.Image")));
            this.MnNhanVien.Name = "MnNhanVien";
            this.MnNhanVien.Size = new System.Drawing.Size(160, 22);
            this.MnNhanVien.Text = "Nhân Viên";
            this.MnNhanVien.Click += new System.EventHandler(this.MnNhanVien_Click);
            // 
            // MnSanPham
            // 
            this.MnSanPham.ForeColor = System.Drawing.Color.Peru;
            this.MnSanPham.Image = ((System.Drawing.Image)(resources.GetObject("MnSanPham.Image")));
            this.MnSanPham.Name = "MnSanPham";
            this.MnSanPham.Size = new System.Drawing.Size(160, 22);
            this.MnSanPham.Text = "Sản Phẩm";
            this.MnSanPham.Click += new System.EventHandler(this.MnSanPham_Click);
            // 
            // MnKhachHang
            // 
            this.MnKhachHang.ForeColor = System.Drawing.Color.Peru;
            this.MnKhachHang.Image = ((System.Drawing.Image)(resources.GetObject("MnKhachHang.Image")));
            this.MnKhachHang.Name = "MnKhachHang";
            this.MnKhachHang.Size = new System.Drawing.Size(160, 22);
            this.MnKhachHang.Text = "Khách Hàng";
            this.MnKhachHang.Click += new System.EventHandler(this.MnKhachHang_Click);
            // 
            // MnNSX
            // 
            this.MnNSX.ForeColor = System.Drawing.Color.Peru;
            this.MnNSX.Image = ((System.Drawing.Image)(resources.GetObject("MnNSX.Image")));
            this.MnNSX.Name = "MnNSX";
            this.MnNSX.Size = new System.Drawing.Size(160, 22);
            this.MnNSX.Text = "Nhà Sản Xuất";
            this.MnNSX.Click += new System.EventHandler(this.MnNSX_Click);
            // 
            // MnNhapHang
            // 
            this.MnNhapHang.ForeColor = System.Drawing.Color.Peru;
            this.MnNhapHang.Image = ((System.Drawing.Image)(resources.GetObject("MnNhapHang.Image")));
            this.MnNhapHang.Name = "MnNhapHang";
            this.MnNhapHang.Size = new System.Drawing.Size(160, 22);
            this.MnNhapHang.Text = "Nhập Hàng";
            this.MnNhapHang.Click += new System.EventHandler(this.MnNhapHang_Click);
            // 
            // MnHoaDon
            // 
            this.MnHoaDon.ForeColor = System.Drawing.Color.Peru;
            this.MnHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("MnHoaDon.Image")));
            this.MnHoaDon.Name = "MnHoaDon";
            this.MnHoaDon.Size = new System.Drawing.Size(160, 22);
            this.MnHoaDon.Text = "Hóa Đơn";
            this.MnHoaDon.Click += new System.EventHandler(this.MnHoaDon_Click);
            // 
            // mnthongke
            // 
            this.mnthongke.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnthongke.ForeColor = System.Drawing.Color.Sienna;
            this.mnthongke.Image = ((System.Drawing.Image)(resources.GetObject("mnthongke.Image")));
            this.mnthongke.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnthongke.Name = "mnthongke";
            this.mnthongke.Size = new System.Drawing.Size(95, 21);
            this.mnthongke.Text = "Thống Kê";
            this.mnthongke.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // MnKho
            // 
            this.MnKho.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MnKho.ForeColor = System.Drawing.Color.Sienna;
            this.MnKho.Image = ((System.Drawing.Image)(resources.GetObject("MnKho.Image")));
            this.MnKho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MnKho.Name = "MnKho";
            this.MnKho.Size = new System.Drawing.Size(92, 21);
            this.MnKho.Text = "Xem Kho";
            this.MnKho.Click += new System.EventHandler(this.MnKho_Click);
            // 
            // mnTaikhoan
            // 
            this.mnTaikhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnDoiMK,
            this.MnXemTK,
            this.đăngXuấtToolStripMenuItem});
            this.mnTaikhoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnTaikhoan.ForeColor = System.Drawing.Color.Sienna;
            this.mnTaikhoan.Image = ((System.Drawing.Image)(resources.GetObject("mnTaikhoan.Image")));
            this.mnTaikhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnTaikhoan.Name = "mnTaikhoan";
            this.mnTaikhoan.Size = new System.Drawing.Size(97, 21);
            this.mnTaikhoan.Text = "Tài Khoản";
            // 
            // MnDoiMK
            // 
            this.MnDoiMK.ForeColor = System.Drawing.Color.Peru;
            this.MnDoiMK.Image = ((System.Drawing.Image)(resources.GetObject("MnDoiMK.Image")));
            this.MnDoiMK.Name = "MnDoiMK";
            this.MnDoiMK.Size = new System.Drawing.Size(194, 22);
            this.MnDoiMK.Text = "Đổi Mật Khẩu";
            this.MnDoiMK.Click += new System.EventHandler(this.MnDoiMK_Click);
            // 
            // MnXemTK
            // 
            this.MnXemTK.ForeColor = System.Drawing.Color.Peru;
            this.MnXemTK.Image = ((System.Drawing.Image)(resources.GetObject("MnXemTK.Image")));
            this.MnXemTK.Name = "MnXemTK";
            this.MnXemTK.Size = new System.Drawing.Size(194, 22);
            this.MnXemTK.Text = "Xem Các Tài Khoản";
            this.MnXemTK.Click += new System.EventHandler(this.MnXemTK_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.ForeColor = System.Drawing.Color.Peru;
            this.đăngXuấtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("đăngXuấtToolStripMenuItem.Image")));
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // hỗTrợToolStripMenuItem
            // 
            this.hỗTrợToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hỗTrợToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.hỗTrợToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hỗTrợToolStripMenuItem.Image")));
            this.hỗTrợToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hỗTrợToolStripMenuItem.Name = "hỗTrợToolStripMenuItem";
            this.hỗTrợToolStripMenuItem.Size = new System.Drawing.Size(78, 21);
            this.hỗTrợToolStripMenuItem.Text = "Hỗ Trợ";
            this.hỗTrợToolStripMenuItem.Click += new System.EventHandler(this.hỗTrợToolStripMenuItem_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(933, 591);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.SaddleBrown;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Cửa Hàng Nội Thất";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem MnLoai;
        private System.Windows.Forms.ToolStripMenuItem MnNhanVien;
        private System.Windows.Forms.ToolStripMenuItem MnSanPham;
        private System.Windows.Forms.ToolStripMenuItem MnKhachHang;
        private System.Windows.Forms.ToolStripMenuItem MnNSX;
        private System.Windows.Forms.ToolStripMenuItem MnNhapHang;
        private System.Windows.Forms.ToolStripMenuItem MnHoaDon;
        private System.Windows.Forms.ToolStripMenuItem mnthongke;
        private System.Windows.Forms.ToolStripMenuItem MnKho;
        private System.Windows.Forms.ToolStripMenuItem mnTaikhoan;
        private System.Windows.Forms.ToolStripMenuItem hỗTrợToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MnDoiMK;
        private System.Windows.Forms.ToolStripMenuItem MnXemTK;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
    }
}