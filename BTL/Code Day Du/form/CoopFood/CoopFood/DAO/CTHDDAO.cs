using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.DAO
{
    public class CTHDDAO
    {
        private static CTHDDAO instance;

        public static CTHDDAO Instance
        {
            get { if (instance == null) instance = new CTHDDAO(); return instance; }
            set { instance = value; }
        }

        private CTHDDAO() { }

        public DataTable DanhSachCTHD(int MaHD)
        {
            string query = string.Format("select * from ct_hd where mahd = {0}", MaHD);

            DataTable dt = DataProvider.Instance.ExecuteQuery(query);

            return dt;
        }
    }
}
