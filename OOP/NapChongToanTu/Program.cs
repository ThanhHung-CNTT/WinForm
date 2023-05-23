using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapChongToanTu
{
    internal class Nap_chong_toan_tu
    {
        class Box
        {
            private double chieu_dai;
            private double chieu_rong;
            private double chieu_cao;

            public double tinhTheTich()
            {
                return chieu_dai * chieu_rong * chieu_cao;
            }
        }

        public void setChieuDai(double len)
        {
            chieu_dai = len;
        }

        public void setChieuRong(double bre)
        {
            chieu_rong = bre;
        }

        public void setChieuCao(double hei)
        {
            chieu_cao = hei;
        }
        //nap chong toan tu + de cong hai doi tuong Box

        public static Box operator +(Box b, Box c)
        {
            Box box = new Box();
            box.chieu_dai = b.chieu_dai + c.chieu_dai;
            box.chieu_rong = b.chieu_rong + c.chieu_rong;
            box.chieu_cao = b.chieu_cao + c.chieu_cao;
            return box;
        }
    }

    public class TestCsharp
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Nap chong toan tu trong C#");
            Console.WriteLine("Vi du mih hoa nap chong toan tu");
            Console.WriteLine("_______________________");
            //Tao cac doi tuong Box1, Box2 va Box3
            Box Box1 = new Box();
            Box Box2 = new Box();
            Box Box3 = new Box();
            double the_tich = 0.0;

            //nhap thong tin Box1
            Box1.setChieuDai(6.0);
            Box1.setChieuRong(7.0);
            Box1.setCHieuCao(5.0);

            //nhap thong tin Box2
            Box2.setChieuDai(12.0);
            Box2.setChieuRong(13.0);
            Box2.setChieuCao(10.0);

            //tinh va hien thi the tich Box1
            the_tich = Box1.tinhTheTich();
            Console.WriteLine("The tich cua Box1 la: {0}", the_tich);

            //tinh vaf hien thi the tich Box2
            the_tich = Box2.tinhTheTich();
            Console.WriteLine("The tich cua Box2 la: {0}", the_tich);

            //con hai doi tuong
            Box3 = Box1 + Box2;

            //tinh va hien thi Box3
            the_tich = Box3.tinhTheTich();
            Console.WriteLine("The tich cua Box3 la: {0}", the_tich);

            Console.ReadKey();
        }
    }
}
