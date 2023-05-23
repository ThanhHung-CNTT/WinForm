using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Cau 6: Nhap mot so va sau do in bang nhan cua so do\nNhap so = ");
            int a;
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nBang nhan cua {0} la:", a);
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("\t{0} x {1} = {2}", a, i, (a * i));
            }
            Console.Read();
        }
    }
}
