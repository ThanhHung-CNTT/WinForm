using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_Ke_Thua_Interface
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

    public interface ChiPhiSon
    {
        int tinhChiPhi(int dien_tich);
    }

    class HinhChuNhat: Shape, ChiPhiSon
    {
        public int tinhDienTich()
        {
            return chieu_cao * chieu_rong;
        }
        public int tinhChiPhi(int dien_tich)
        {
            return dien_tich * 70;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tinh ke thua trong C#");
            Console.WriteLine("Vi du minh hoa da ke thua");
            Console.WriteLine("-----------------------------");
            //Tao doi tuong hinh chu nhat
            HinhChuNhat hcn = new HinhChuNhat();
            int dien_tich;
            hcn.setChieuRong(5);
            hcn.setChieuCao(7);
            dien_tich = hcn.tinhDienTich();

            //in dien tich va chi phi.
            Console.WriteLine("Tong dien tich: {0}", hcn.tinhDienTich());
            Console.WriteLine("Tong chi phi son: {0}", hcn.tinhChiPhi(dien_tich));
            Console.ReadLine();
        }
    }
}
