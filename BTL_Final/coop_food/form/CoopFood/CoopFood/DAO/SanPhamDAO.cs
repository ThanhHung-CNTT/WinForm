using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoopFood.DTO;

namespace CoopFood.DAO
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

        public async Task<List<SanPham>> DanhSachSanPham(string tenSP) 
        {
            string sql = @"SELECT sp.*, lsp.TenLSP, ncc.TenNCC, dvt.TenDV FROM SANPHAM sp 
            join LOAISANPHAM lsp ON sp.MaLSP = lsp.MaLSP
            join NHACUNGCAP ncc ON sp.MaNCC = ncc.MaNCC
            join DONVITINH dvt ON sp.MaDVT = dvt.MaDVT {0}";

            sql = string.IsNullOrWhiteSpace(tenSP) ? string.Format(sql, string.Empty): string.Format(sql, $" where sp.TenSP like N'%{tenSP}%'") ;
            return await DataProvider.Instance.SqlQueryAsync<SanPham>(sql);
        }

        public async Task<SanPhamMN> LaySanPhamTheoMaSP(int maSP)
        {
            string sql = $"SELECT * FROM SANPHAM where MaSP = {maSP}";

            return (await DataProvider.Instance.SqlQueryAsync<SanPhamMN>(sql)).FirstOrDefault();
        }

        public Result ThemSanPham(SanPhamReq sanPhamReq)
        {
            string sql = @"INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan) 
                                        VALUES ({0}, N'{1}', {2}, {3}, {4}, '{5}', N'{6}', N'{7}', N'{8}', {9}, {10});";
            string query = string.Format(sql, sanPhamReq.MaSP, sanPhamReq.TenSP, sanPhamReq.MaDVT, sanPhamReq.MaLSP, sanPhamReq.MaNCC, sanPhamReq.SoLuong, sanPhamReq.NSX, sanPhamReq.HSD, sanPhamReq.NgayNhap, sanPhamReq.GiaNhap, sanPhamReq.GiaBan);

            var result = DataProvider.Instance.ExecuteNonQuery(query);

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Thêm mới thành công" : "Thêm mới thất bại. Vui lòng thử lại sau."
            };
        }

        public Result SuaSanPham(SanPhamReq sanPhamReq)
        {
            string sql = @"UPDATE SanPham SET TenSP = N'{0}', MaDVT = {1}, MaLSP = {2}, MaNCC = {3}, SoLuong = {4}, NSX = '{5}', HSD = '{6}', NgayNhap = '{7}', GiaNhap = {8}, GiaBan = {9}  WHERE MaSP = '{10}';";
            
            string query = string.Format(sql, sanPhamReq.TenSP, sanPhamReq.MaDVT, sanPhamReq.MaLSP, sanPhamReq.MaNCC, sanPhamReq.SoLuong, sanPhamReq.NSX, sanPhamReq.HSD, sanPhamReq.NgayNhap, sanPhamReq.GiaNhap, sanPhamReq.GiaBan, sanPhamReq.MaSP);

            var result = DataProvider.Instance.ExecuteNonQuery(query);

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Sửa thành công" : "Sửa thất bại. Vui lòng thử lại sau."
            };
        }

        public Result XoaSanPham(int MaSP)
        {
            var result = DataProvider.Instance.ExecuteNonQuery($"DELETE FROM SanPham WHERE MaSP = '{MaSP}'");

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Xoá thành công" : "Xoá thất bại. Vui lòng thử lại sau."
            };
        }

        public async void ThemDanhSachSanPhamVaoComboBox(ComboBox cb)
        {
            cb.DataSource = await SanPhamDAO.Instance.DanhSachSanPham(null);
            cb.DisplayMember = "TenSP";
            cb.ValueMember = "MaSP";
        }
    }
}
