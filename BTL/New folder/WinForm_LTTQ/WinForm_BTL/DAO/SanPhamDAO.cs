using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_BTL.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return instance; }
            set { instance = value; }
        }
        private SanPhamDAO() { }

        public DataTable DanhSachSanPham()
        {
            return DataProvider.Instance.ExecuteQuery("select * from sanpham");
        }
        public DataTable DanhSachLoaiSanPham()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT DISTINCT LoaiSP FROM SANPHAM");
        }
    }
}
