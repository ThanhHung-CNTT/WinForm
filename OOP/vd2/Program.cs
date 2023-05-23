using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vd2
{
    abstract class Shape
    {
        public abstract int tinhDientich();
    }
    class HinhChuNhat : Shape
    {
        private int chieu_dai;
        private int chieu_rong;
        public HinhChuNhat(int a = 0, int b = 0)
        {
            chieu_dai = a;
            chieu_rong = b;
        }
        public override int tinhDienTich()
        {
            Console.WriteLine("Dien tich hinhb chu nhat:");
            return (chieu_dai * chieu_rong);
        }
    }
    public class TestCshape
    {
        static void Main(string[] arge)
        {
            Console.WriteLine("Tinh da hinh trong C#");
            Console.WriteLine("Vi du minh hoa Da hinh dong");
            Console.WriteLine("________________________");

            HinhChuNhat r = new HinhChuNhat(10, 7);
            double a = r.tinhDienTich();
            Console.WriteLine("Dien tich: {0}", a);
            Console.ReadKey();
        }
    }
}
