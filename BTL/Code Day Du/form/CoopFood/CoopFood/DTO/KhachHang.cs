using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class KhachHang
    {
        private int maKH;
        private string tenKH;
        private string gioiTinh;
        private string ngaySinh;
        private string diaChi;
        private string sDT;
        private string tichLuy;

        public KhachHang(int maKH, string tenKH, string gioiTinh, string ngaySinh, string diaChi, string sDT, string tichLuy)
        {
            MaKH = maKH;
            TenKH = tenKH;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SDT = sDT;
            TichLuy = tichLuy;
        }

        public KhachHang(DataRow row)
        {
            MaKH = (int)row["MaKH"];
            TenKH = row["TenKH"].ToString();
            GioiTinh = row["GioiTinh"].ToString();
            NgaySinh = row["NgaySinh"].ToString();
            SDT = row["SDT"].ToString();
            DiaChi = row["DiaChi"].ToString();
            TichLuy = row["TichLuy"].ToString();
        }

        public int MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string TichLuy { get => tichLuy; set => tichLuy = value; }
    }
}
