using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA02.DTO
{
    public class Loai
    {
        public Loai(string maloai, string tenloai)
        {
            this.Maloai = maloai;
            this.Tenloai = tenloai;
        }
        public Loai(DataRow row)
        {
            this.Maloai = row["MALOAI"].ToString();
            this.Tenloai = row["tenloai"].ToString();
        }



        private string maloai;

        public string Maloai { get => maloai; set => maloai = value; }
        public string Tenloai { get => tenloai; set => tenloai = value; }

        private string tenloai;
    }
}

