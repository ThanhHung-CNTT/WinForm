using CoopFood.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopFood.DAO
{
    public class NhaCungCapDAO
    {
        private static NhaCungCapDAO instance;

        public static NhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return instance; }
            set { instance = value; }
        }

        private NhaCungCapDAO() { }

        public async Task<List<NhaCungCap>> DanhSachNhaCungCap(string tenNCC)
        {
            string sql = string.IsNullOrWhiteSpace(tenNCC) ? "SELECT * FROM nhacungcap" : $"SELECT * FROM nhacungcap where TenNCC like '%{tenNCC}%'";

            return await DataProvider.Instance.SqlQueryAsync<NhaCungCap>(sql);
        }

        public Result ThemNhaCungCap(NhaCungCap supplier)
        {
            string query = string.Format("INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SDT) VALUES ({0}, N'{1}', N'{2}', '{3}');", supplier.MaNCC, supplier.TenNCC, supplier.DiaChi, supplier.SDT);

            var result = DataProvider.Instance.ExecuteNonQuery(query);

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Thêm mới thành công" : "Thêm mới thất bại. Vui lòng thử lại sau."
            };
        }

        public Result SuaNhaCungCap(NhaCungCap supplier)
        {
            string query = string.Format("UPDATE NHACUNGCAP set TenNCC = N'{0}' ,DiaChi = N'{1}' ,SDT = '{2}' WHERE MaNCC = {3};", supplier.TenNCC, supplier.DiaChi, supplier.SDT, supplier.MaNCC);

            var result = DataProvider.Instance.ExecuteNonQuery(query);

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Sửa thành công" : "Sửa thất bại. Vui lòng thử lại sau."
            };
        }

        public Result XoaNhaCungCap(int maNCC)
        {
            var result = DataProvider.Instance.ExecuteNonQuery($"DELETE FROM NHACUNGCAP WHERE MaNCC = {maNCC};");

            return new Result()
            {
                IsSuccessed = result > 0,
                Message = result > 0 ? "Xoá thành công" : "Xoá thất bại. Vui lòng thử lại sau."
            };
        }

        public async void ThemDanhSachNhaCungCapVaoComboBox(ComboBox cb)
        {
            cb.DataSource = await NhaCungCapDAO.Instance.DanhSachNhaCungCap(null);
            cb.DisplayMember = "TenNCC";
            cb.ValueMember = "MaNCC";
        }
    }
}