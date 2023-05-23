using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CoopFood.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;
        private static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            set { instance = value; }
        }
        private TaiKhoanDAO() { }
        public DataTable DanhSachTaiKhoan()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM TAIKHOAN");
        }
        public bool ThemTaiKhoan(string TenDangNhap, string MatKhau, int MaNV, string PhanQuyen)
        {
            string querry = string.Format("INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES ('{0}', {1}, {2}, N'{3})", TenDangNhap, MatKhau, MaNV, PhanQuyen);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public bool SuaTaiKhoan(string TenDangNhap, string MatKhau, int MaNV, string PhanQuyen)
        {
            string querry = string.Format("UPDATE TAIKHOAN set MatKhau = {0}, MaNV = {1}, PhanQuyen = N'{2}' WHERE TenDangNhap = '{3}';", MatKhau, MaNV, PhanQuyen, TenDangNhap);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public bool XoaTaiKhoan(string TenDangNhap)
        {
            string querry = string.Format("DELETE FROM TAIKHOAN WHERE TenDangNhap = '{0}';", TenDangNhap);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
    }
}