using System;
using System.Collections.Generic;
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

        public async Task<List<NhanVien>> DanhSachNhanVien(string tenNV)
        {
            string sql = "SELECT nv.*, cv.TenCV FROM NHANVIEN nv JOIN CHUCVU cv ON nv.MaCV = cv.MaCV {0}";
            sql = string.IsNullOrWhiteSpace(tenNV) ? String.Format(sql, string.Empty) : String.Format(sql, $"where nv.TenNV like N'%{tenNV}%'");

            return await DataProvider.Instance.SqlQueryAsync<NhanVien>(sql);
        }

        public Result ThemNhanVien(NhanVien employee)
        {
            string querry = string.Format("INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MucLuong, MaCV) VALUES ({0}, N'{1}', N'{2}', '{3}', N'{4}', '{5}', '{6}', '{7}', '{8}', {9}, {10});", employee.MaNV, employee.TenNV, employee.GioiTinh, employee.NgaySinh, employee.DiaChi, employee.CMND, employee.Email, employee.SDT, employee.NgayVaoLam, employee.MucLuong, employee.MaCV);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Thêm mới thành công" : "Thêm mới thất bại. Vui lòng thử lại sau."
            };
        }

        public Result SuaNhanVien(NhanVien employee)
        {
            string querry = string.Format("UPDATE NHANVIEN set TenNV = N'{0}', GioiTinh = N'{1}', NgaySinh = N'{2}', DiaChi = N'{3}', CMND = '{4}', Email = '{5}', SDT = '{6}', NgayVaoLam = N'{7}', MucLuong = {8} MaCV = {9} WHERE MaNV = {10};", employee.TenNV, employee.GioiTinh, employee.NgaySinh, employee.DiaChi, employee.CMND, employee.Email, employee.SDT, employee.NgayVaoLam, employee.MucLuong, employee.MaCV, employee.MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Sửa thành công" : "Sửa thất bại. Vui lòng thử lại sau."
            };
        }

        public Result XoaNhanVien(int MaNV)
        {
            string querry = string.Format("DELETE FROM NHANVIEN WHERE MaNV = {0};", MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Xoá thành công" : "Xoá thất bại. Vui lòng thử lại sau."
            };
        }
 
        public async void ThemDanhSachNhanvienVaoComboBox(ComboBox cb)
        {
            cb.DataSource = await NhanVienDAO.Instance.DanhSachNhanVien(null);
            cb.DisplayMember = "TenNV";
            cb.ValueMember = "MaNV";
        }

        public async Task<List<ThongKeLuongNhanVien>> LayDuLieuLuongNhanVien() => await DataProvider.Instance.SqlQueryAsync<ThongKeLuongNhanVien>("select NgayVaoLam, MucLuong from NHANVIEN");
    }
}
