using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string TenNV { get; set; }
        public string PhanQuyen { get; set; }
        public int MaNV { get; set; }
    }

    public class LoginRes
    {
        public int MaNV { get; set; }
        public string PhanQuyen { get; set; }
    }
}
