using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DTO
{
   public class NhanVien
    {
        public NhanVien(string manv, string tennv, string gioitinh, DateTime ngaysinh,  string diachi, string sdt, string anh)
        {
            this.Manv = manv;
            this.Tennv = tennv;
            this.Gioitinh = gioitinh;
            this.Ngaysinh = ngaysinh;
            this.Diachi = diachi;
            this.Sdt = sdt;
            this.Anh = anh;
        }


        public NhanVien(DataRow row)
        {
            this.Manv = row["manv"].ToString();
            this.Tennv = row["tennv"].ToString();
            this.Gioitinh = row["gioitinh"].ToString();
            this.Ngaysinh = (DateTime)row["ngaysinh"];
            this.Diachi = row["diachi"].ToString();
            this.Sdt = row["sdt"].ToString();
            this.Anh = row["anhnv"].ToString();
        }



        private string manv;
        private string tennv;
        private string gioitinh;
        private DateTime ngaysinh;
        private string diachi;
        private string sdt;
        private string anh;


        public string Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Anh { get => anh; set => anh = value; }
    }
}
