using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DAO
{
    public class NhapHangDAO
    {
        private static NhapHangDAO instance;

        public static NhapHangDAO Instance
        {
            get { if (instance == null) instance = new NhapHangDAO(); return instance; }
            private set { instance = value; }
        }
        private NhapHangDAO() { }

        public void themNH(string manh, string manv, string masp, int soluong, DateTime ngaynhap, string diachi, int gia, int tongtien)
        {
            string query = "exec THEMNH @MANH , @MANV , @MASP , @SOLUONG , @NGAYNHAP , @DIACHI , @GIA , @TONGTIEN ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { manh, manv, masp, soluong, ngaynhap, diachi, gia, tongtien });
        }
        public void suaNH(string manh, string manv, string masp, int soluong, DateTime ngaynhap, string diachi, int gia, int tongtien)
        {
            string query = "SUANH @MANH , @MANV , @MASP , @SOLUONG , @NGAYNHAP , @DIACHI ,  @GIA , @TONGTIEN ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { manh, manv, masp, soluong, ngaynhap, diachi, gia, tongtien });
        }
        public void xoaNH(string manh)
        {
            string query = "exec XOANH @MANH";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { manh });
        }
    }
}
