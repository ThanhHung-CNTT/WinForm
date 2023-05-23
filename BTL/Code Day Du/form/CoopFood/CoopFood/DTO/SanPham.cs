using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class SanPham
    {
        private int maSP;
        private string tenSP;
        private int maDVT;
        private int maLSP;
        private int maNCC;
        private int soLuong;
        private string nSX;
        private string hSD;
        private string ngayNhap;
        private float giaNhap;
        private float giaBan;
        private float khuyenMai;

        public SanPham(int maSP, string tenSP, int maDVT, int maLSP, int maNCC, int soLuong, string nSX, string hSD, string ngayNhap, float giaNhap, float giaBan, float khuyenMai)
        {
            MaSP = maSP;
            TenSP = tenSP;
            MaDVT = maDVT;
            MaLSP = maLSP;
            MaNCC = maNCC;
            SoLuong = soLuong;
            NSX = nSX;
            HSD = hSD;
            NgayNhap = ngayNhap;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            KhuyenMai = khuyenMai;
        }

        public SanPham(DataRow row)
        {
            MaSP = (int)row["MaSP"];
            TenSP = row["TenSP"].ToString();
            MaDVT = (int)row["MaDVT"];
            MaLSP = (int)row["MaLSP"];
            MaNCC = (int)row["MaNCC"];
            SoLuong = (int)row["SoLuong"];
            NSX = row["NSX"].ToString();
            HSD = row["HSD"].ToString();
            NgayNhap = row["NgayNhap"].ToString();
            GiaBan = Convert.ToSingle(row["GiaBan"]);
            GiaNhap = Convert.ToSingle(row["GiaNhap"]); 
            KhuyenMai = Convert.ToSingle(row["KhuyetMai"]); 
        }

        public int MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int MaDVT { get => maDVT; set => maDVT = value; }
        public int MaLSP { get => maLSP; set => maLSP = value; }
        public int MaNCC { get => maNCC; set => maNCC = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string NSX { get => nSX; set => nSX = value; }
        public string HSD { get => hSD; set => hSD = value; }
        public string NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public float GiaNhap { get => giaNhap; set => giaNhap = value; }
        public float GiaBan { get => giaBan; set => giaBan = value; }
        public float KhuyenMai { get => khuyenMai; set => khuyenMai = value; }
    }
}
