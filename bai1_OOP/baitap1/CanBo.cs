using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap1
{
    class CanBo
    {
        protected string hoTen, gioiTinh, diaChi;
        protected int namSinh;

        public CanBo()
        {

        }

        public CanBo(string hoTen, string gioiTinh, string diaChi, int namSinh)
        {
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.namSinh = namSinh;
            this.diaChi = diaChi;
        }

        public string HoTen
        {
            get { return hoTen; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { hoTen = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public int NamSinh
        {
            get { return namSinh; }
            set { namSinh = value; }
        }

        public void nhapCanBo()
        {
            Console.Write("Nhap ho ten: ");
            hoTen = Console.ReadLine();
            Console.Write("Nhap nam sinh: ");
            namSinh = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Nhap gioi tinh (nam|nu): ");
                gioiTinh = Console.ReadLine();
            }
            while (gioiTinh != "nam" && gioiTinh != "nu");
            Console.Write("Nhap dia chi: ");
            diaChi = Console.ReadLine();
        }

        public void xuatCanBo()
        {
            Console.WriteLine("Ho ten: {0}", hoTen);
            Console.WriteLine("Nam sinh: {0}", namSinh);
            Console.WriteLine("Gioi tinh: {0}", gioiTinh);
            Console.WriteLine("Dia chi: {0}", diaChi);
        }
    }
}
