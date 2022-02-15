using DA02.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DAO
{
    public class HDDAO
    {

        private static HDDAO instance;

        public static HDDAO Instance
        {
            get { if (instance == null) instance = new HDDAO(); return instance; }
            private set { instance = value; }
        }
        private HDDAO() { }

        public List<HoaDon> layhd()
        {
            List<HoaDon> ls = new List<HoaDon>();
            string query = "select*from hoadon";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                HoaDon hd = new HoaDon(item);
                ls.Add(hd);
            }
            return ls;
        }
        public void themHD(string mahd, string manv, string makh, DateTime ngayban, string trangthai, int tongtien, int giamgia, string tenkh)
        {
            string query = "exec THEMHD @MAHD , @MANV , @MAKH , @NGAYBAN , @TRANGTHAI , @TONGTIEN , @GIAMGIA , @TENKH";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd, manv, makh, ngayban, trangthai, tongtien, giamgia, tenkh });
        }
        public void suaHD(string mahd, string manv, string makh, DateTime ngayban, string trangthai, int tongtien, int giamgia, string tenkh)
        {
            string query = "exec SUAHD @MAHD , @MANV , @MAKH , @NGAYBAN , @TRANGTHAI , @TONGTIEN , @GIAMGIA , @TENKH ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd, manv, makh, ngayban, trangthai, tongtien, giamgia, tenkh });
        }
        public void xoaHD(string mahd)
        {
            string query = "exec XOAHD @MAHD ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd });
        }
        public void ThanhToan(string mahd, int tongtien, string trangthai)
        {
            string query = "exec THANHTOAN @MAHD , @TONGTIEN , @TRANGTHAI  ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { mahd, tongtien, trangthai });
        }
        public void capnhatsoluong(string masp, int soluongmoi)
        {
            string querry = "exec UPDATETHEMSP @MASP , @SOLUONGMOI ";
            DataProvider.Instance.ExecuteQuery(querry, new object[] { masp, soluongmoi });
        }
        public void capnhatxoasoluong(string masp, int soluongmoi)
        {
            string query = "exec UPDATExoasp @MASP , @SOLUONGMOI ";
            DataProvider.Instance.ExecuteQuery(query, new object[] { masp, soluongmoi });
        }
        public DataTable thongke(DateTime tungay, DateTime denngay)
        {
            return DataProvider.Instance.ExecuteQuery("exec THONGKE @TUNGAY , @DENNGAY ", new object[] { tungay, denngay });
        }
        public DataTable INthongke(DateTime tungay, DateTime denngay)
        {
            return DataProvider.Instance.ExecuteQuery("exec inthongke @TUNGAY , @DENNGAY ", new object[] { tungay, denngay });
        }
    }
}
