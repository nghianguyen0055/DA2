
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA02.DAO;
using DA02.DTO;

namespace DA02.DAO
{
    public class accountDAO
    {
        private static accountDAO instance;

        public static accountDAO Instance
        {
            get { if (instance == null) instance = new accountDAO(); return instance; }
            private set { instance = value; } 
        }
        private accountDAO() { }

        public bool login (string username, string pass)
        {
            string query = "Login @USERNAMEE , @PASS";
            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] {username, pass});
            return result.Rows.Count>0;
        }
       public account GetAccountByUserName(string username)
        {
           DataTable dt = DataProvider.Instance.ExecuteQuery("SELECT *FROM Taikhoan where USERNAME  ='" + username+"'");
            foreach (DataRow item in dt.Rows)
            {
                return new account(item);
            }
            return null;
        }
       
        public bool updateaccount(string username, string pass, string newpass)
        {
            int result  = DataProvider.Instance.ExecuteNonQuery("Exec CAPNHATMATKHAU @USERNAME , @PASS , @NEWPASS ",new object[] { username , pass, newpass});
            return result > 0;
        }
    }
}
