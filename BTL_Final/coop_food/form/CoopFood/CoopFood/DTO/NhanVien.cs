using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string TenCV { get; set; }
        public string DiaChi { get; set; }
        public string CMND { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public decimal MucLuong { get; set; }
        public int MaCV { get; set; }
    }
}
