using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap1
{
    class NhanVienPhucVu : CanBo
    {
        protected string congViec;

        public NhanVienPhucVu() : base() { }

        public NhanVienPhucVu(string congViec)
        {
            this.congViec = congViec;
        }
        public string CongViec
        {
            get { return congViec; }
            set { congViec = value; }
        }

        public void nhapNhanVienPhucVu()
        {
            base.nhapCanBo();
            Console.Write("Nhap cong viec: ");
            congViec = Console.ReadLine();
        }

        public void xuatNhanVienPhucVu()
        {
            base.xuatCanBo();
            Console.WriteLine("Cong viec: {0}", congViec);
        }
    }
}
