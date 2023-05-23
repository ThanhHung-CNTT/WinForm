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
        private int maHD;
        private int maMV;
        private int maKH;
        private string ngayMua;
        private long tongTien;

        public HoaDon(int maHD, int maMV, int maKH, string ngayMua, long tongTien)
        {
            MaHD = maHD;
            MaMV = maMV;
            MaKH = maKH;
            NgayMua = ngayMua;
            TongTien = tongTien;
        }
        public HoaDon(DataRow row)
        {
            MaHD = (int)row["MaHD"];
            MaMV = (int)row["MaMV"];
            MaKH = (int)row["MaKH"];
            NgayMua = row["NgayMua"].ToString();
            TongTien = (long)row["TongTien"];
        }

        public int MaHD { get => maHD; set => maHD = value; }
        public int MaMV { get => maMV; set => maMV = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public string NgayMua { get => ngayMua; set => ngayMua = value; }
        public long TongTien { get => tongTien; set => tongTien = value; }
    }
}
