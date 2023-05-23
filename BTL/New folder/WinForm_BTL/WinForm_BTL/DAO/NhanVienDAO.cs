using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_BTL.DAO
{
    public class NhanVienDao
    {
        private static NhanVienDao instance;

        public static NhanVienDao Instance
        {
            get { if (instance == null) instance = new NhanVienDao(); return instance; }
            set { instance = value; }
        }
        private NhanVienDao() { }

        public DataTable DanhSachNhanVien()
        {
            return DataProvider.Instance.ExecuteQuery("select * from nhanvien");
        }
        public bool ThemNhanVien(int maNV, string tenNV, string GioiTinh, string NgaySinh, string diachi, string CMND, string email, string SDT, string ngayvaolam, int MaCV)
        {
            string query = string.Format("INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MaCV) VALUES ({0}, N'{1}', N'{2}', {3},N'{4}', N{5}, N{6}, {7},N{8}, {9});", maNV, tenNV, GioiTinh, NgaySinh, diachi, CMND, email, SDT, ngayvaolam, MaCV);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool SuaNhanVien(int maNV, string tenNV, string GioiTinh, string NgaySinh, string diachi, string CMND, string email, string SDT, string ngayvaolam, int MaCV)
        {
            string query = string.Format("UPDATE NHANVIEN set TenNV = N'{0}' ,GioiTinh = N'{1}', NgaySinh= {2},DiaChi = N'{3}', CMND= {4}, Email= {5},SDT = {6}, NgayVaoLam = {7}, MaCV = {8} WHERE MaVN = {9};", tenNV, GioiTinh, NgaySinh, diachi, CMND, email, SDT, ngayvaolam, MaCV, maNV);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool XoaNhanVien(int maNV)
        {
            string query = string.Format("DELETE FROM NHANVIEN WHERE MaNV = {0};", maNV);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
