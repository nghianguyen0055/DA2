using DA02.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA02
{
    public partial class fKho : Form
    {
        public fKho()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            string query = "select tensp, soluong from SANPHAM ";
            dgvKho.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = "select tensp, soluong from sanpham where tensp like N'%" + txttimkiem.Text.Trim() + "%'";
            dgvKho.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
