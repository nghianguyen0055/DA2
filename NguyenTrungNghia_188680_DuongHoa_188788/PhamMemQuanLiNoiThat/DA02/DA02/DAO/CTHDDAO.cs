using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DAO
{
    public class CTHDDAO
    {
        private static CTHDDAO instace;

        public static CTHDDAO Instace
        {
            get { if (instace == null) instace = new CTHDDAO(); return instace; }
            private set { instace = value; }
        }
        private CTHDDAO() { }


        public void themCTHD(string macthd, string mahd, string masp, int soluong, int dongia, int thanhtien)
        {
            string query = "exec THEMCTHD @MACTHD , @MAHD , @MASP , @SOLUONG , @DONGIA , @THANHTIEN ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { macthd, mahd, masp, soluong, dongia, thanhtien });
        }
        public void suaCTHD(string macthd, string mahd, string masp, int soluong, int dongia, int thanhtien)
        {
            string query = "EXEC SUACTHD @MACTHD , @MAHD , @MASP , @SOLUONG , @DONGIA , @THANHTIEN ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { macthd, mahd, masp, soluong, dongia, thanhtien });
        }
        public void xoaCTHD(string macthd)
        {
            string query = "exec XOACTHD @MACTHD ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { macthd });
        }



    }
}
