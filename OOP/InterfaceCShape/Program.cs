using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCShape
{
    public interface GiaoDich
    {
        //cac thanh vien cua interface

        //cac phuong thuc 
        void hienThiThongTinGiaoDich();
        double laySoLuong();
    }
    class GiaoDichHangHoa : GiaoDich
    {
        private string ma_hang_hoa;
        private string ngay;
        private double so_luong;
        public GiaoDichHangHoa()
        {
            ma_hang_hoa = " ";
            ngay = " ";
            so_luong = 0.0;
        }

        pulic GiaoDichHangHoa(string c, string d, double a)
        {
            ma_hang_hoa = c;
            ngay = d;
            so_luong = a;
        }

        public double laysoluong()
        {
            return so_luong;
        }

        pulic void hienThiThongTinGiaoDich()
        {
            Console.WriteLine("Ma hang hoa: {0}", ma_hang_hoa);
            Console.WriteLine("Ngay giao dich: {0}", ngay);
            Console.WriteLine("So luong: {0}", laysoluong());
        }
    }
    public class TestCsharp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interface trongC#");
            Console.WriteLine("Vi du minh hoa Interface");
            Console.WriteLine("_________________________");

            //tao cac doi tuong GiaoDichHangHoa
            GiaoDichHangHoa t1 = new GiaoDichHangHoa("001", "8/10/2012", 78900.00);
            GiaoDichHangHoa t2 = new GiaoDichHangHoa("002", "9/10/2012", 451900.00);
            t1.hienThiThongTinGiaoDich();
            t2.hienThiThongTinGiaoDich();

            Console.ReadKey
            }
    }
}
