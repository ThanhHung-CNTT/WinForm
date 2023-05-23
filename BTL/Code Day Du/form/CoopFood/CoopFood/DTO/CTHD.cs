using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class CTHD
    {
        private int maHD;
        private int maSP;
        private int soLuongBan;
        private long giaSP;

        public CTHD(int maHD, int maSP, int soLuongBan, long giaSP)
        {
            MaHD = maHD;
            MaSP = maSP;
            SoLuongBan = soLuongBan;
            GiaSP = giaSP;
        }
        public CTHD(DataRow row)
        {
            MaHD = (int)row["MaHD"];
            MaSP = (int)row["MaSP"];
            SoLuongBan = (int)row["SoLuongBan"];
            GiaSP = (long)row["GiaSP"];
        }

        public int MaHD { get => maHD; set => maHD = value; }
        public int MaSP { get => maSP; set => maSP = value; }
        public int SoLuongBan { get => soLuongBan; set => soLuongBan = value; }
        public long GiaSP { get => giaSP; set => giaSP = value; }
    }
}
