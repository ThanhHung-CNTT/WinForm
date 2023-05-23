using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class NhaCungCap
    {

        public NhaCungCap(int maNCC, string tenNCC, string sDT, string diaChi)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SDT = sDT;
            DiaChi = diaChi;
        }

        private int maNCC;
        private string tenNCC;
        private string sDT;
        private string diaChi;

        public int MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        public NhaCungCap(DataRow row)
        {
            MaNCC = (int)row["MaNCC"];
            TenNCC = row["tenNCC"].ToString();
            SDT = row["SDT"].ToString();
            DiaChi = row["DiaChi"].ToString();
        }
    }
}
