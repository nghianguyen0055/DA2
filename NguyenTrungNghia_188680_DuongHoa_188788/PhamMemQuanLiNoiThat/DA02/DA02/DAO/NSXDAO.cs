using DA02.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DAO
{
   public class NSXDAO
    {
        private static NSXDAO instance;

        public static NSXDAO Instance
        {
            get { if (instance == null) instance = new NSXDAO(); return instance; }
            private set { instance = value; }
        }
        private NSXDAO() { }

        public void themNSX(string mansx, string tennsx, string diachi, string sdt)
        {
            string query = "THEMNSX @MANSX , @TENNSX , @DIACHI , @SDT ";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { mansx, tennsx, diachi, sdt });
        }
        public void suaNSX(string maNSX, string tenNSX, string diachi, string sdt)
        {
            string qr = "EDITNSX @MANSX , @TENNSX , @DIACHI , @SDT ";
            DataProvider.Instance.ExecuteNonQuery(qr, new object[] { maNSX, tenNSX, diachi, sdt });
        }
        public void xoaNSX(string mansx)
        {
            string qr = "DELETENSX @MANSX";
            DataProvider.Instance.ExecuteNonQuery(qr, new object[] { mansx });
        }
        public List<NSX> layncc()
        {
            List<NSX> ls = new List<NSX>();
            string query = "select*from nhaSX";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                NSX nsx = new NSX(item);
                ls.Add(nsx);
            }
            return ls;
        }
        
    }
}
