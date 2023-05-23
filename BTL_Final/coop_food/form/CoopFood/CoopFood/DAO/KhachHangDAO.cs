using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoopFood.DTO;

namespace CoopFood.DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            set { instance = value; }
        }

        private KhachHangDAO() { }

        public async Task<List<KhachHang>> DanhSachKhachHang(string tenKH)
        {
            string sql = string.IsNullOrWhiteSpace(tenKH) ? "SELECT * FROM KHACHHANG" : $"SELECT * FROM KHACHHANG where TenKH like '%{tenKH}%'";

            return await DataProvider.Instance.SqlQueryAsync<KhachHang>(sql);
        }

        public Result ThemKhachHang(KhachHang customer)
        {
            string querry = string.Format("INSERT INTO KHACHHANG (MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy) VALUES ({0}, N'{1}', N'{2}', '{3}', N'{4}', '{5}', {6})", customer.MaKH, customer.TenKH, customer.GioiTinh, customer.NgaySinh, customer.DiaChi, customer.SDT, customer.TichLuy);
            var result = DataProvider.Instance.ExecuteNonQuery(querry);

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Thêm mới thành công" : "Thêm mới thất bại. Vui lòng thử lại sau."
            };
        }

        public Result SuaKhachHang(KhachHang customer)
        {
            string querry = string.Format("UPDATE KHACHHANG set TenKH = N'{0}', GioiTinh = N'{1}', NgaySinh = '{2}', DiaChi = '{3}', SDT = {4}, TichLuy = {5} WHERE MaKH = {6}; ", customer.TenKH, customer.GioiTinh, customer.NgaySinh, customer.DiaChi, customer.SDT, customer.TichLuy, customer.MaKH);
            var result = DataProvider.Instance.ExecuteNonQuery(querry);

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Sửa thành công" : "Sửa thất bại. Vui lòng thử lại sau."
            };
        }

        public Result XoaKhachHang(int MaKH)
        {
            var result = DataProvider.Instance.ExecuteNonQuery($"DELETE FROM KHACHHANG WHERE MaKH = {MaKH}");

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Xoá thành công" : "Xoá thất bại. Vui lòng thử lại sau."
            };
        }

        public async void ThemDanhSachKhachHangVaoComboBox(ComboBox cb)
        {
            cb.DataSource = await KhachHangDAO.Instance.DanhSachKhachHang(null);
            cb.DisplayMember = "TenKH";
            cb.ValueMember = "MaKH";
        }
    }
}
