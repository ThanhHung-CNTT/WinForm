using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public string TenNV { get; set; }
        public string TenKH { get; set; }
        public string TenSP { get; set; }
        public int SoLuongBan { get; set; }
        public string TenDVT { get; set; }
        public decimal GiaBan { get; set; }
        public decimal TongTien { get; set; }
        public DateTime NgayMua { get; set; }
        public int MaNV { get; set; }
        public int MaKH { get; set; }
        public int MaSP { get; set; }
    }

    public class HoaDonRes
    {
        public int MaHD { get; set; }
        public int MaNV { get; set; }
        public int MaKH { get; set; }
        public int MaSP { get; set; }
        public DateTime NgayMua { get; set; }
        public decimal TongTien { get; set; }
    }
}
