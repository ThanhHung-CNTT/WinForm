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
        private int maNV;
        private string tenNV;
        private string gioiTinh;
        private string ngaySinh;
        private string diaChi;
        private string cMND;
        private string email;
        private string sDT;
        private string ngayVaoLam;
        private int maCV;

        public NhanVien(int maNV, string tenNV, string gioiTinh, string ngaySinh, string diaChi, string cMND, string email, string sDT, string ngayVaoLam, int maCV)
        {
            MaNV = maNV;
            TenNV = tenNV;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            CMND = cMND;
            Email = email;
            SDT = sDT;
            NgayVaoLam = ngayVaoLam;
            MaCV = maCV;
        }

        public NhanVien(DataRow row)
        {
            MaNV = (int)row["MaNV"];
            TenNV = row["TenNV"].ToString();
            GioiTinh = row["GioiTinh"].ToString();
            NgaySinh = row["NgaySinh"].ToString();
            DiaChi = row["DiaChi"].ToString();
            CMND = row["CMND"].ToString();
            Email = row["Email"].ToString();
            SDT = row["SDT"].ToString();
            NgayVaoLam = row["NgayVaoLam"].ToString();
            MaCV = (int)row["MaCV"];
        }

        public int MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string CMND { get => cMND; set => cMND = value; }
        public string Email { get => email; set => email = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public int MaCV { get => maCV; set => maCV = value; }
    }
}
