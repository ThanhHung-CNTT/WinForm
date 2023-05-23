using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_BTL.DTO;

namespace WinForm_BTL.DAO
{
    class TaiKhoanDAO
    {
        private static TaiKhoanDAO _daoTaiKhoan;
        public static TaiKhoanDAO daoTaiKhoan
        {
            get { if (_daoTaiKhoan == null) _daoTaiKhoan = new TaiKhoanDAO(); return _daoTaiKhoan; }
            set { _daoTaiKhoan = value; }
        }

        public TaiKhoanDAO() { }

        public DataTable DanhSachTaiKhoan()
        {
            return DataProvider.Instance.ExecuteQuery("select * from TAIKHOAN");
        }

        public bool ExitUser(TaiKhoan tk)
        {
            string sql = "select * from TAIKHOAN where TenDangNhap='" + tk.TenDangNhap + "' and MatKhau='" + tk.MatKhau + "'";
            if(DataProvider.Instance.ExecuteQuery(sql).Rows.Count > 0)
            {
                UserLogin.TenDangNhap = Convert.ToInt32(DataProvider.Instance.ExecuteQuery(sql).Rows[0]["TenDangNhap"].ToString());
                UserLogin.MatKhau = DataProvider.Instance.ExecuteQuery(sql).Rows[0]["MatKhau"].ToString();
                UserLogin.MaNV = Convert.ToInt32(DataProvider.Instance.ExecuteQuery(sql).Rows[0]["MaNV"].ToString());
                UserLogin.QuyenDangNhap = Convert.ToString(DataProvider.Instance.ExecuteQuery(sql).Rows[0]["PhanQuyen"].ToString());
                SqlHelper.getQuyenDangNhap = UserLogin.QuyenDangNhap;
                return true;
            }
            else
                return false;
        }
    }
}
