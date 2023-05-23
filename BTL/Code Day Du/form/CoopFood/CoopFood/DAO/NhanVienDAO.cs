using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using CoopFood.DTO;

namespace CoopFood.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            set { instance = value; }
        }
        private NhanVienDAO() { }

        public DataTable DanhSachNhanVien()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM NHANVIEN");
        }
        public bool ThemNhanVien(int MaNV, string TenNV, string GioiTinh, string NgaySinh, string DiaChi, string CMND, string Email, string SDT, string NgayVaoLam, int MaCV)
        {
            string querry = string.Format("INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MaCV) VALUES ({0}, N'{1}', N'{2}', '{3}', N'{4}', '{5}', '{6}', '{7}', '{8}', {9});", MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MaCV);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public bool SuaNhanVien(int MaNV, string TenNV, string GioiTinh, string NgaySinh, string DiaChi, string CMND, string Email, string SDT, string NgayVaoLam, int MaCV)
        {
            string querry = string.Format("UPDATE NHANVIEN set TenNV = N'{0}', GioiTinh = N'{1}', NgaySinh = N'{2}', DiaChi = N'{3}', CMND = '{4}', Email = '{5}', SDT = '{6}', NgayVaoLam = N'{7}', MaCV = {8} WHERE MaNV = {9};", TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MaCV, MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public bool XoaNhanVien(int MaNV)
        {
            string querry = string.Format("DELETE FROM NHANVIEN WHERE MaNV = {0};", MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public List<NhanVien> NhanVienList()
        {
            List<NhanVien> list = new List<NhanVien>();

            DataTable data = DanhSachNhanVien();

            foreach (DataRow item in data.Rows)
            {
                NhanVien nv = new NhanVien(item);
                list.Add(nv);
            }
            return list;
        }
        public DataTable TimKiemNVTheoTen(string TenNV)
        {
            string query = string.Format("SELECT * FROM nhanvien WHERE dbo.fuConvertToUnsign1(TenNV) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenNV);

            DataTable danhsach = DataProvider.Instance.ExecuteQuery(query);

            return danhsach;
        }
        public int LayMaCV(string TenCV)
        {
            string query = string.Format("SELECT macv FROM chucvu WHERE TenCV = N'{0}' " , TenCV);

            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);

            string MaCV = DataProvider.Instance.convertDataTableToString(dataTable);

            return Int32.Parse(MaCV);
        }
    }
}
