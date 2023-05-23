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
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM SANPHAM");
        }
        public List<SanPham> SanPhamList()
        {
            List<SanPham> list = new List<SanPham>();

            DataTable data = DanhSachSanPham();

            foreach (DataRow item in data.Rows)
            {
                SanPham sp = new SanPham(item);
                list.Add(sp);
            }
            return list;
        }

        public bool ThemSanPham(int MaSP, string TenSP, int MaDVT, int MaLSP, int MaNCC, int SoLuong, string NSX, string HSD, string NgayNhap, float GiaNhap, float GiaBan)
        {
            string query = string.Format("INSERT INTO SANPHAM (MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan) VALUES ({0}, N'{1}', {2}, {3}, {4}, '{5}', N'{6}', N'{7}', N'{8}', {9}, {10});", MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool SuaSanPham(int MaSP, string TenSP, int MaDVT, int MaLSP, int MaNCC, int SoLuong, string NSX, string HSD, string NgayNhap, float GiaNhap, float GiaBan)
        {
            string query = string.Format("UPDATE SanPham set TenSP = N'{1}', MaDVT = {2} MaLSP = {3}, MaNCC = {4}, SoLuong = {5}, NSX = N'{6}', HSD = N'{7}', NgayNhap = N'{8}', GiaNhap = {9}, GiaBan = {10}  WHERE MaSP = {0};", MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaNhap, GiaBan);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool XoaSanPham(int MaSP)
        {
            string query = string.Format("DELETE FROM SanPham WHERE MaSP = {0};", MaSP);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public void ThemDanhSachMaSanPhamVaoComboBox(ComboBox cb)
        {
            cb.DataSource = SanPhamDAO.Instance.DanhSachSanPham();
            cb.DisplayMember = "MaSP";
            cb.ValueMember = "MaSP";
        }
        public DataTable TimKiemSPTheoTen(string TenSP)
        {
            string query = string.Format("SELECT * FROM sanpham WHERE dbo.fuConvertToUnsign1(TenSP) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenSP);

            DataTable danhsach = DataProvider.Instance.ExecuteQuery(query);

            return danhsach;
        }
    }
}
