using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLass_Object
{
    class Rectangle
    {
        //cac bien thanh vien
        public double length;
        public double width;

        //cac phuong thuc
        public double GetArea()
        {
            return length * width;
        }

        public void Display()
        {
            Console.WriteLine("Chieu dai: {0}", length);
            Console.WriteLine("Chieu rong: {0}", width);
            Console.WriteLine("Dien tich: {0}", GetArea());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tinh dong goi C#");
            Console.WriteLine("----------------------------");

            //Tao doi tuong Rectangle
            Rectangle r = new Rectangle();
            //Thiet lap cac thuoc tinh
            r.length = 4.5;
            r.width = 3.5;
            //Goi phuong thuc
            r.Display();
            Console.ReadLine();
        }
    }
}
