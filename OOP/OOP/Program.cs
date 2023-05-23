using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Shape
    {
        protected int chieu_rong;
        protected int chieu_cao;

        public void setChieuRong(int w)
        {
            chieu_rong = w;
        }
        public void setChieuCao(int h) 
        {
            chieu_cao = h;
        }
    }

    class Rectangle: Shape
    {
        public int tinhDienTich()
        {
            return chieu_cao * chieu_rong;
        }
    }
    class TestCsharp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tinh ke thua trong C#");
            Console.WriteLine("--------------------------\n");

            //Tao doi tuong hinh chu nhat
            Rectangle hcn = new Rectangle();

            hcn.setChieuRong(5);
            hcn.setChieuCao(7);

            //in dien tich cua doi tuong
            Console.WriteLine("Dien tich hinh chu nhat: {0}", hcn.tinhDienTich());
            Console.ReadKey();
        }
    }
}
