using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap1
{
    internal class KySu : CanBo
    {
        protected string nganhDaoTao;

        public KySu()
        {

        }

        public KySu(string nganhDaoTao)
        {
            this.nganhDaoTao = nganhDaoTao;
        }

        public string Bac
        {
            get { return nganhDaoTao; }
            set { nganhDaoTao = value; }
        }

        public void nhapKySu()
        {
            nhapCanBo();
            Console.Write("Nhap nganh dao tao: ");
            nganhDaoTao = Console.ReadLine();
        }

        public void xuatKySu()
        {
            xuatCanBo();
            Console.WriteLine("Nganh dao tao: {0}", nganhDaoTao);
        }
    }
}
