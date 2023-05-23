using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopFood.DTO
{
    public class ThongKe
    {
    }

    public class ThongKeDoanhThu
    {
        public DateTime NgayMua { get; set; }
        public decimal TongTien { get; set; }
    }

    public class ThongKeLuongNhanVien
    {
        public DateTime NgayVaoLam { get; set; }
        public decimal MucLuong { get; set; }
    }
}
