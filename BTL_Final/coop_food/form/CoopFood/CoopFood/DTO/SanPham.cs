using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string TenDV { get; set; }
        public string TenLSP { get; set; }
        public string TenNCC { get; set; }
        public int SoLuong { get; set; }
        public DateTime NSX { get; set; }
        public DateTime HSD { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal KhuyenMai { get; set; }
        public int MaDVT { get; set; }
        public int MaLSP { get; set; }
        public int MaNCC { get; set; }
    }

    public class SanPhamReq
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int MaDVT { get; set; }
        public int MaLSP { get; set; }
        public int MaNCC { get; set; }
        public int SoLuong { get; set; }
        public DateTime NSX { get; set; }
        public DateTime HSD { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal KhuyenMai { get; set; }
    }

    public class SanPhamMN
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal KhuyenMai { get; set; }
    }
}
