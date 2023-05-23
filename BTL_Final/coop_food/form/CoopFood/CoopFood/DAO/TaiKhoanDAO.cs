using System.Collections.Generic;
using System.Threading.Tasks;
using CoopFood.DTO;

namespace CoopFood.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            set { instance = value; }
        }

        private TaiKhoanDAO() { }

        public async Task<List<LoginRes>> Login(string userName, string password) 
        {
            string sql = $"SELECT MaNV, PhanQuyen FROM TAIKHOAN where TenDangNhap = '{userName}' and MatKhau = '{password}'";
            return await DataProvider.Instance.SqlQueryAsync<LoginRes>(sql);
        }

        public async Task<List<TaiKhoan>> DanhSachTaiKhoan(string tenNV) 
        {
            string sql = "SELECT tk.*, nv.TenNV FROM TAIKHOAN tk inner join NHANVIEN nv ON tk.MaNV = nv.MaNV {0}";

            sql = string.IsNullOrWhiteSpace(tenNV) ? string.Format(sql, string.Empty) : string.Format(sql, $"where nv.TenNV like N'%{tenNV}%'");

            return await DataProvider.Instance.SqlQueryAsync<TaiKhoan>(sql);
        } 
     
        public Result ThemTaiKhoan(TaiKhoan acc)
        {
            string querry = string.Format("INSERT INTO TAIKHOAN (TenDangNhap, MatKhau, MaNV, PhanQuyen) VALUES ('{0}', '{1}', {2}, N'{3}')", acc.TenDangNhap, acc.MatKhau, acc.MaNV, acc.PhanQuyen);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Thêm mới thành công" : "Thêm mới thất bại. Vui lòng thử lại sau."
            };
        }

        public Result SuaTaiKhoan(TaiKhoan acc)
        {
            string querry = string.Format("UPDATE TAIKHOAN set MatKhau = '{0}', MaNV = {1}, PhanQuyen = N'{2}' WHERE TenDangNhap = '{3}';", acc.MatKhau, acc.MaNV, acc.PhanQuyen, acc.TenDangNhap);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Sửa thành công" : "Sửa thất bại. Vui lòng thử lại sau."
            };
        }

        public Result XoaTaiKhoan(string TenDangNhap)
        {
            string querry = string.Format("DELETE FROM TAIKHOAN WHERE TenDangNhap = '{0}';", TenDangNhap);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Xoá thành công" : "Xoá thất bại. Vui lòng thử lại sau."
            };
        }
    }
}