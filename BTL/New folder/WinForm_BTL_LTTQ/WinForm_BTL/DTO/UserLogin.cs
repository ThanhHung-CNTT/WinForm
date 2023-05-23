using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_BTL.DTO
{
    class UserLogin
    {
        private static int _TenDangNhap;
        private static string _MatKhau = "";
        private static int _MaNV;
        private static int _PhanQuyen;

        public static int TenDangNhap
        {
            get { return UserLogin._TenDangNhap; }
            set { UserLogin._TenDangNhap = value; }
        }
        public static string MatKhau
        {
            get { return UserLogin._MatKhau; }
            set { UserLogin._MatKhau = value; }
        }
        public static int MaNV
        {
            get { return UserLogin._MaNV; }
            set { UserLogin._MaNV = value; }
        }
        public static int QuyenDangNhap
        {
            get { return UserLogin._PhanQuyen; }
            set
            {
                UserLogin._PhanQuyen = value;
            }
        }
    }
}
