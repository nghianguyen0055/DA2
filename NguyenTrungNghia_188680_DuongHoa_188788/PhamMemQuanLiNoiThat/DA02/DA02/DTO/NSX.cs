using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DTO
{
    public class NSX
    {
        public NSX(string mansx, string tennsx, string diachi, string sdt)
        {
            this.MaNSX = mansx;
            this.TenNSX = tennsx;
            this.Diachi = diachi;
            this.Sdt = sdt;
        }
        public NSX(DataRow row)
        {
            this.MaNSX = row["mansx"].ToString();
            this.TenNSX = row["tennsx"].ToString();
            this.Diachi = row["diachi"].ToString();
            this.Sdt = row["sdt"].ToString();
        }
        private string mansx;
        private string tennsx;
        private string diachi;
        private string sdt;

        public string MaNSX { get => mansx; set => mansx = value; }
        public string TenNSX { get => tennsx; set => tennsx = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
