using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DTO
{
   public class HoaDon
    {
        public HoaDon(string mahd, string manv, string makh, DateTime? ngayhd, string trangthai, int? tongtien, string tenKH,int giamgia)
        {
            this.Mahd = mahd;
            this.Manv = manv;
            this.Makh = makh;
            this.Ngayhd = ngayhd;
            this.Trangthai = trangthai;
            this.Tongtien = tongtien;
            this.Tenkh = tenKH;
            this.Giamgia = giamgia;
        }

        public HoaDon(DataRow row)
        {
            this.Mahd = row["mahd"].ToString();
            this.Manv = row["manv"].ToString();
            this.Makh = row["makh"].ToString();
            this.Ngayhd = (DateTime?)row["ngayban"];
            this.Trangthai = row["trangthai"].ToString();
            this.Tongtien = (int?)row["TONGTIEN"];
            this.Tenkh = row["tenkh"].ToString();
            this.Giamgia = (int)row["giamgia"];
        }





        private string mahd;
        private string manv;
        private string makh;
        private DateTime? ngayhd;
        private string trangthai;
        private int? tongtien;
        private string tenkh;
        private int giamgia;

        public string Mahd { get => mahd; set => mahd = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Makh { get => makh; set => makh = value; }
        public DateTime? Ngayhd { get => ngayhd; set => ngayhd = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public int? Tongtien { get => tongtien; set => tongtien = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public int Giamgia { get => giamgia; set => giamgia = value; }
    }
}
