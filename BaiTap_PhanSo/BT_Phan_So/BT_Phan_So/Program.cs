using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Phan_So
{
    public class PhanSo
    {
        //Thuoc tinh
        private int tu;
        private int mau;

        //Phuong thuc
        public void SetPhanSo(int a, int b)
        {
            tu = a;
            mau = b;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            PhanSo PS;
            PS.SetPhanSo(1, 2);
        }
    }

}
