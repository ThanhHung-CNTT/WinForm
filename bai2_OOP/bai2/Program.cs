using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace bai2
{
    class TaiLieu
    {
        protected string maTL, nhaXB;
        protected int soBanPhatHanh;

        public TaiLieu() { }
        public TaiLieu(string MaTL, string NhaXB, int SoBanPhatHanh)
        {
            maTL = MaTL;
            nhaXB = NhaXB;
            soBanPhatHanh = SoBanPhatHanh;
        }
        public void Nhap_TL()
        {
            Console.WriteLine("Nhap Ma Tai Lieu:");
            maTL = Console.ReadLine();
            Console.WriteLine("Nhap Nha Xuat Ban:");
            nhaXB = Console.ReadLine();
            Console.WriteLine("Nhap So Ban Phat Hanh:");
            soBanPhatHanh = Convert.ToInt32(Console.ReadLine());
            if (soBanPhatHanh <= 0)
            {
                Console.WriteLine("ERROR: So Ban Phat Hanh Phai Lon Hon 0");
                Console.WriteLine("Nhap lai so ban phat hanh: ");
                soBanPhatHanh = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void Xuat_TL()
        {
            Console.WriteLine("Ma tai lieu: {0}", maTL);
            Console.WriteLine("NXB: {0}", nhaXB);
            Console.WriteLine("So ban phat hanh tai lieu: {0}", soBanPhatHanh);
        }
    }
    class Sach : TaiLieu
    {
        protected string tenTG;
        protected int soTrang;
        public Sach() : base() { }
        public Sach(string MaTL, string NhaXB, int SoBanPhatHanh, string TenTG, int SoTrang) : base(MaTL, NhaXB, SoBanPhatHanh)
        {
            tenTG = TenTG;
            soTrang = SoTrang;
        }

        public void Nhap_Sach()
        {
            base.Nhap_TL();
            Console.WriteLine("Nhap ten tac gia: ");
            tenTG = Console.ReadLine();
            Console.WriteLine("Nhap so trang: ");
            soTrang = Convert.ToInt32(Console.ReadLine());
            if (soTrang <= 0)
            {
                Console.WriteLine("ERROR: So Trang Khong Hop Le");
                Console.WriteLine("Nhap lai so trang: ");
                soTrang = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void Xuat_Sach()
        {
            base.Xuat_TL();
            Console.WriteLine("Ten tac gia: {0}", tenTG);
            Console.WriteLine("So trang: {0}", soTrang);
        }
    }
    class TapChi : TaiLieu
    {
        protected int soPhatHanh;
        protected int thangPhatHanh;
        public TapChi() : base() { }
        public TapChi(string MaTL, string NhaXB, int SoBanPhatHanh, int SoPhatHanh, int ThangPhatHanh) : base(MaTL, NhaXB, SoBanPhatHanh)
        {
            soPhatHanh = SoPhatHanh;
            thangPhatHanh = ThangPhatHanh;
        }
        public void Nhap_TC()
        {
            base.Nhap_TL();
            Console.WriteLine("Nhap so phat hanh: ");
            soPhatHanh = Convert.ToInt32(Console.ReadLine());
            if (soPhatHanh <= 0)
            {
                Console.WriteLine("ERROR: So phat hanh phai lon hon 0");
                Console.WriteLine("Nhap lai so phat hanh: ");
                soPhatHanh = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Nhap thang phat hanh: ");
            thangPhatHanh = Convert.ToInt32(Console.ReadLine());
            if (thangPhatHanh <= 0 || thangPhatHanh > 12)
            {
                Console.WriteLine("ERROR:Thang phat hanh Khong Hop Le");
                Console.WriteLine("Nhap thang phat hanh: ");
                thangPhatHanh = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void Xuat_TC()
        {
            base.Xuat_TL();
            Console.WriteLine("So phat hanh tap chi: {0}", soPhatHanh);
            Console.WriteLine("Thang phat hanh: {0}", thangPhatHanh);
        }
    }
    class Bao : TaiLieu
    {
        protected int ngayPhatHanh;
        public Bao() : base() { }
        public Bao(string MaTL, string NhaXB, int SoBanPhatHanh, int NgayPhatHanh) : base(MaTL, NhaXB, SoBanPhatHanh)
        {
            ngayPhatHanh = NgayPhatHanh;
        }
        public void Nhap_Bao()
        {
            base.Nhap_TL();
            Console.WriteLine("Nhap ngay phat hanh: ");
            ngayPhatHanh = Convert.ToInt32(Console.ReadLine());
            if (ngayPhatHanh <= 0 || ngayPhatHanh > 31)
            {
                Console.WriteLine("ERROR:Ngay phat hanh Khong Hop Le");
                Console.WriteLine("Nhap ngay phat hanh: ");
                ngayPhatHanh = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void Xuat_Bao()
        {
            base.Xuat_TL();
            Console.WriteLine("Thang phat hanh: {0}", ngayPhatHanh);
        }
    }
    class baitap2
    {
        static void Main(String[] arg)
        {
            List<Sach> listS = new List<Sach>();
            List<TapChi> listTC = new List<TapChi>();
            List<Bao> listB = new List<Bao>();

            bool check = true;
            bool check1 = true;
            bool check2 = true;
            while (check)
            {
                Console.WriteLine("MENU QUAN LY TAI LIEU");
                Console.WriteLine("1.Nhap thong tin ve cac tai lieu");
                Console.WriteLine("2.Hien thi thong tin cac tai lieu");
                Console.WriteLine("3.Tim kiem tai lieu theo loai");
                Console.WriteLine("e.Thoat khoi chuong trinh");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Nhap chuc nang muon thuc hien: ");
                string menu = Console.ReadLine();
                Console.Clear();
                switch (menu)
                {
                    case "1":
                        while (check1)
                        {
                            Console.Clear();
                            Console.WriteLine("MENU NHAP THONG TIN CAC TAI LIEU");
                            Console.WriteLine("1. Nhap thong tin sach");
                            Console.WriteLine("2. Nhap thong tin tap chi");
                            Console.WriteLine("3. Nhap thong tin bao");
                            Console.WriteLine("4. Quay lai MENU CHINH");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("Nhap tai lieu muon nhap: ");
                            string menu1 = Console.ReadLine();
                            switch (menu1)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Nhap so luong sach: ");
                                    int n = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < n; i++)
                                    {
                                        Console.WriteLine("Nhap sach thu {0}: ", i + 1);
                                        Sach s = new Sach();
                                        s.Nhap_Sach();
                                        listS.Add(s);
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Nhap so luong tap chi: ");
                                    int n1 = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < n1; i++)
                                    {
                                        Console.WriteLine("Nhap tap chi thu {0}: ", i + 1);
                                        TapChi s = new TapChi();
                                        s.Nhap_TC();
                                        listTC.Add(s);
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Nhap so luong bao: ");
                                    int n2 = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < n2; i++)
                                    {
                                        Console.WriteLine("Nhap bao thu {0}: ", i + 1);
                                        Bao s = new Bao();
                                        s.Nhap_Bao();
                                        listB.Add(s);
                                    }
                                    break;
                                case "4":
                                    check1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Lua chon khong hop le");
                                    Console.ReadLine();
                                    break;
                            }
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("HIEN THI THONG TIN VE CAC TAI LIEU");
                        Console.WriteLine("THONG TIN SACH");
                        for (int i = 0; i < listS.Count; i++)
                        {
                            listS[i].Xuat_Sach();
                        }
                        Console.WriteLine("THONG TIN TAP CHI");
                        for (int i = 0; i < listTC.Count; i++)
                        {
                            listTC[i].Xuat_TC();
                        }
                        Console.WriteLine("THONG TIN BAO");
                        for (int i = 0; i < listB.Count; i++)
                        {
                            listB[i].Xuat_Bao();
                        }
                        break;

                    case "3":
                        while (check2)
                        {
                            Console.Clear();
                            Console.WriteLine(" TAI LIEU BAN CAN TIM KIEM LA:");
                            Console.WriteLine("1. Tim kiem sach");
                            Console.WriteLine("2. Tim kiem tap chi");
                            Console.WriteLine("3. Tim kiem bao");
                            Console.WriteLine("4. Quay lai MENU CHINH");
                            Console.WriteLine("---------------------------");
                            string menu2 = Console.ReadLine();
                            switch (menu2)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Sach can tim kiem la: ");
                                    for (int i = 0; i < listS.Count; i++)
                                    {
                                        listS[i].Xuat_Sach();
                                    }

                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Tap chi can tim kiem la: ");
                                    for (int i = 0; i < listTC.Count; i++)
                                    {
                                        listTC[i].Xuat_TC();
                                    }
                                    break;

                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Bao can tim kiem la: ");
                                    for (int i = 0; i < listB.Count; i++)
                                    {
                                        listB[i].Xuat_Bao();
                                    }
                                    break;

                                case "4":
                                    check2 = false;
                                    break;
                                default:
                                    Console.WriteLine("Lua chon khong hop le");
                                    Console.ReadLine();
                                    break;

                            }


                        }

                        break;
                    case "e":
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long nhap lai");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}