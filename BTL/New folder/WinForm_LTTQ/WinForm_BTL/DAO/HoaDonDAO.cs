using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_BTL.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            set { instance = value; }
        }
        private HoaDonDAO() { }

        public DataTable DanhSachHoaDon()
        {
            return DataProvider.Instance.ExecuteQuery("select * from hoadon");
        }
    }
}
