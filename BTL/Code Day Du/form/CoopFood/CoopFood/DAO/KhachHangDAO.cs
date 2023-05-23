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
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            set { instance = value; }
        }

        private KhachHangDAO() { }

        public DataTable DanhSachKhachHang()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM KHACHHANG");
        }
        public List<KhachHang> KhachHangList()
        {
            List<KhachHang> list = new List<KhachHang>();

            DataTable data = DanhSachKhachHang();

            foreach (DataRow item in data.Rows)
            {
                KhachHang kh = new KhachHang(item);
                list.Add(kh);
            }
            return list;
        }
        public bool ThemKhachHang(int MaKH, string TenKH, string GioiTinh, string NgaySinh, string DiaChi, string SDT, int TichLuy)
        {
            string querry = string.Format("INSERT INTO KHACHHANG (MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy) VALUES ({0}, N'{1}', N'{2}', '{3}', N'{4}', '{5}', {6})", MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public bool SuaKhachHang(int MaKH, string TenKH, string NgaySinh, string GioiTinh, string DiaChi, string SDT, int TichLuy)
        {
            string querry = string.Format("UPDATE KHACHHANG set TenKH = N'{0}', GioiTinh = N'{1}', NgaySinh = '{2}', DiaChi = '{3}', SDT = {4}, TichLuy = {5} WHERE MaKH = {6}; ", TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy, MaKH);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public bool XoaKhachHang(int MaKH)
        {
            string querry = string.Format("DELETE FROM KHACHHANG WHERE MaKH = {0};", MaKH);
            int result = DataProvider.Instance.ExecuteNonQuery(querry);
            return result > 0;
        }
        public DataTable TimKiemKHTheoTen(string TenKH)
        {
            string query = string.Format("SELECT * FROM khachhang WHERE dbo.fuConvertToUnsign1(TenKH) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", TenKH);

            DataTable danhsach = DataProvider.Instance.ExecuteQuery(query);

            return danhsach;
        }
    }
}
