using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DTO
{
    public class SanPham
    {
        public SanPham(string masp, string tensp, string maloai, int dongia, string anhsp, string baohanh, string mansx, string chatlieu, int soluong, string dvt)
        {
            this.Masp = masp;
            this.Tensp = tensp;
            this.Mansx = mansx;
            this.Maloai = maloai;
            this.Gia = gia;
            this.Soluong = soluong;
            this.Baohanh = baohanh;
            this.Chatlieu = chatlieu;
            this.Anh = anh;
            this.Dvt = dvt;
        }
        public SanPham(DataRow row)
        {
            this.Masp = row["masp"].ToString();
            this.Tensp = row["tensp"].ToString();
            this.Mansx = row["mansx"].ToString();
            this.Maloai = row["maloai"].ToString();
            this.Gia = (int)row["dongia"];
            this.Soluong = (int)row["soluong"];
            this.Baohanh = row["baohanh"].ToString();
            this.Chatlieu = row["chatlieu"].ToString();
            this.Anh = row["anhsp"].ToString();
            this.Dvt = row["dvt"].ToString();
        }





        private string masp;
        private string tensp;
        private string mansx;
        private string maloai;
        private int gia;
        private int soluong;
        private string baohanh;
        private string dvt;
        private string chatlieu;
        private string anh;

        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Mansx { get => mansx; set => mansx = value; }
        public string Maloai { get => maloai; set => maloai = value; }
        public int Gia { get => gia; set => gia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public string Baohanh { get => baohanh; set => baohanh = value; }
        public string Dvt { get => dvt; set => dvt = value; }
        public string Chatlieu { get => chatlieu; set => chatlieu = value; }
        public string Anh { get => anh; set => anh = value; }
    }
}
