using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cau 8: Tinh giai thua");

            int a, giai_thua = 1;
            Console.Write("Nhap so a = ");
            a = Convert.ToInt32(Console.ReadLine());
            int b = a;
            while (true)
            {
                if (a == 0 || a == 1)
                {
                    giai_thua = 1;
                    break;
                }
                else if (a < 0)
                {
                    Console.WriteLine("So a phai lon hon hoac bang 0. Yeu cau nhap lai\n");
                    a = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                else
                {
                    while (a > 0)
                    {
                        giai_thua = giai_thua * a;
                        a--;
                    }
                    break;
                }

            }
            Console.WriteLine("{0}! = {1}", b, giai_thua);
            Console.ReadKey();
        }
    }
}
