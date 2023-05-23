using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap1
{
    internal class CongNhan : CanBo
    {
        protected float bac;

        public CongNhan() : base() { }
     
        public CongNhan(int bac)
        {
            this.bac = bac;
        }

        public float Bac
        {
            get { return bac; }
            set { bac = value; }
        }

        public void nhapCongNhan()
        {
            base.nhapCanBo();
            Console.Write("Nhap bac: ");
            bac = float.Parse(Console.ReadLine());
        }

        public void xuatCongNhan()
        {
            base.xuatCanBo();
            Console.WriteLine("Bac: {0}", bac);
        }

    }
}
