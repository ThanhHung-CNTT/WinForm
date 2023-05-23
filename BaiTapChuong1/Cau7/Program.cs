using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Cau 7: hien thi va tinh tong n so le \nNhap n = ");
            int n, Tong = 0;
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Cac so le tu 1->n: ");
            for (int i = 0; i <= n; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write("{0}  ", i);
                    Tong += i;
                }
            }
            Console.Write("\nTong cac so le = {0}", Tong);
            Console.ReadKey();
        }
    }
}
