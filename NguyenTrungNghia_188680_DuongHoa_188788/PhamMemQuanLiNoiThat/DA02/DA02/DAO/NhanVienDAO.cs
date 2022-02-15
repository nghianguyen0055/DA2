using DA02.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DAO
{
    public class NhanVienDAO
    {

        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set { instance = value; }
        }
        private NhanVienDAO() { }
        public void themNV(string manv, string tennv, string gioitinh, DateTime ngaysinh, string diachi, string sdt, string ANH)
        {
            string query = "THEMNV @MANV , @TENNV , @GIOITINH , @NGAYSINH , @DIACHI , @SDT , @ANH";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv, tennv, gioitinh, ngaysinh, diachi, sdt, ANH });
        }
        public void suaNV(string manv, string tennv, string gioitinh, DateTime ngaysinh,  string diachi, string sdt, string anh)
        {
            string qr = "EDITNV @MANV , @TENNV , @GIOITINH , @NGAYSINH , @DIACHI , @SDT , @ANH ";
            DataProvider.Instance.ExecuteNonQuery(qr, new object[] { manv, tennv, gioitinh, ngaysinh, diachi, sdt, anh });
        }
        public void xoaNV(string manv)
        {
            string query = "DELETENV @MANV ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { manv });
        }



        public List<NhanVien> laynv()
        {
            List<NhanVien> ls = new List<NhanVien>();
            string query = "select*from nhanvien";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                NhanVien nhanvien = new NhanVien(item);
                ls.Add(nhanvien);
            }
            return ls;
        }
    }
}
