using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class TaiKhoan
    {
        private string tenDangNhap;
        private string matKhau;
        private int maNV;
        private string phanQuyen;

        public TaiKhoan(string tenDangNhap, string matKhau, int maNV, string phanQuyen)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            MaNV = maNV;
            PhanQuyen = phanQuyen;
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public string PhanQuyen { get => phanQuyen; set => phanQuyen = value; }
    }
}
