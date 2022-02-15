using DA02.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return instance; }
            private set { instance = value; }
        }
        private SanPhamDAO() { }

        public void themSP(string masp, string tensp, string maloai, int dongia, string anhsp, string  baohanh, string mansx, string  chatlieu, int soluong, string dvt)
        {
            string querey = "EXEC THEMsanpham @MASP , @TENSP , @MALOAI , @DONGIA , @ANHSP , @BAOHANH , @MANSX , @CHATLIEU , @SOLUONG , @DVT ";
            DataProvider.Instance.ExecuteNonQuery(querey, new object[] { masp, tensp, maloai, dongia, anhsp, baohanh, mansx, chatlieu, soluong, dvt });
        }
        public void suaSP(string masp, string tensp, string maloai, int dongia, string anhsp, string baohanh, string mansx, string chatlieu, int soluong, string dvt)
        {
            string query = "exec EDITSP @MASP , @TENSP , @MALOAI , @DONGIA , @ANHSP , @BAOHANH , @MANSX , @CHATLIEU , @SOLUONG , @DVT  ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { masp,  tensp, maloai,  dongia,  anhsp,  baohanh,  mansx,  chatlieu,  soluong, dvt });
        }
        public void xoaSP(string masp)
        {
            string query = "DELETESP @MASP ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { masp });
        }
        public List<SanPham> laysp()
        {
            List<SanPham> ls = new List<SanPham>();
            string query = "select*from sanpham";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                SanPham sp = new SanPham(item);
                ls.Add(sp);
            }
            return ls;
        }
    }
}
