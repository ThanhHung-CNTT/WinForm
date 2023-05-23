using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baitap1
{
    class TestCSharp
    {
        public static void Main(string[] args)
        {
            List<CongNhan> listCN = new List<CongNhan>();
            List<KySu> listKS = new List<KySu>();
            List<NhanVienPhucVu> listNV = new List<NhanVienPhucVu>();

            bool check = true;
            bool check1 = true;
            bool check2 = true;
            while (check)
            {
                Console.WriteLine("MENU QUAN LY CAN BO");
                Console.WriteLine("1.Nhap thong tin ve cac can bo");
                Console.WriteLine("2.Hien thi thong tin cac can bo");
                Console.WriteLine("3.Tim kiem can bo theo ten");
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
                            Console.WriteLine("MENU NHAP THONG TIN CAC CAN BO");
                            Console.WriteLine("1. Nhap thong tin cong nhan");
                            Console.WriteLine("2. Nhap thong tin ky su");
                            Console.WriteLine("3. Nhap thong tin nhan vien phuc vu");
                            Console.WriteLine("4. Quay lai MENU CHINH");
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("Nhap thong tin muon nhap: ");
                            string menu1 = Console.ReadLine();
                            switch (menu1)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Nhap so luong cong nhan: ");
                                    int n = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < n; i++)
                                    {
                                        Console.WriteLine("Nhap can bo thu {0}: ", i + 1);
                                        CongNhan a = new CongNhan();
                                        a.nhapCongNhan();
                                        listCN.Add(a);
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Nhap so luong ky su: ");
                                    int n1 = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < n1; i++)
                                    {
                                        Console.WriteLine("Nhap ky su thu {0}: ", i + 1);
                                        KySu b = new KySu();
                                        b.nhapKySu();
                                        listKS.Add(b);
                                    }
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Nhap so luong nhan vien phuc vu: ");
                                    int n2 = Convert.ToInt32(Console.ReadLine());
                                    for (int i = 0; i < n2; i++)
                                    {
                                        Console.WriteLine("Nhap nhan vien thu {0}: ", i + 1);
                                        NhanVienPhucVu c = new NhanVienPhucVu();
                                        c.nhapNhanVienPhucVu();
                                        listNV.Add(c);
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
                        Console.WriteLine("HIEN THI THONG TIN VE CAC CAN BO");
                        Console.WriteLine("THONG TIN CONG NHAN");
                        for (int i = 0; i < listCN.Count; i++)
                        {
                            listCN[i].xuatCongNhan();
                        }
                        Console.WriteLine("THONG TIN KY SU");
                        for (int i = 0; i < listKS.Count; i++)
                        {
                            listKS[i].xuatKySu();
                        }
                        Console.WriteLine("THONG TIN NHAN VIEN");
                        for (int i = 0; i < listNV.Count; i++)
                        {
                            listNV[i].xuatNhanVienPhucVu();
                        }
                        break;

                    case "3":
                        while (check2)
                        {
                            Console.Clear();
                            Console.WriteLine(" CAN BO BAN CAN TIM KIEM LA:");
                            Console.WriteLine("1. Tim kiem cong nhan");
                            Console.WriteLine("2. Tim kiem ky su");
                            Console.WriteLine("3. Tim kiem nhan vien phuc vu");
                            Console.WriteLine("4. Quay lai MENU CHINH");
                            Console.WriteLine("---------------------------");
                            string menu2 = Console.ReadLine();
                            switch (menu2)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Nhap cong nhan muon tim kiem");
                                    string timKiemCN = Console.ReadLine();
                                    for (int i = 0; i < listCN.Count; i++)
                                    {
                                        if (listCN[i].HoTen == timKiemCN)
                                        {
                                            Console.WriteLine("Cong nhan can tim kiem la: ");
                                            listCN[i].xuatCongNhan();
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Khong tim thay cong nhan");
                                            Console.ReadKey();
                                        }
                                    }
                                    break;
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("Nhap ky su muon tim kiem");
                                    string timKiemKS = Console.ReadLine();
                                    for (int i = 0; i < listKS.Count; i++)
                                    {
                                        if (listKS[i].HoTen == timKiemKS)
                                        {
                                            Console.WriteLine("Ky su can tim kiem la: ");
                                            listKS[i].xuatKySu();
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Khong tim thay ky su");
                                            Console.ReadKey();
                                        }
                                    }
                                    break;

                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("Nhap nhan vien muon tim kiem");
                                    string timKiemNV = Console.ReadLine();
                                    for (int i = 0; i < listNV.Count; i++)
                                    {
                                        if (listNV[i].HoTen == timKiemNV)
                                        {
                                            Console.WriteLine("Nhan vien can tim kiem la: ");
                                            listNV[i].xuatNhanVienPhucVu();
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Khong tim thay nhan vien");
                                            Console.ReadKey();
                                        }
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