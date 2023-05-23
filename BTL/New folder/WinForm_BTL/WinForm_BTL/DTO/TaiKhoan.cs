using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_BTL.DTO
{
    class TaiKhoan
    {
        private int _TenDangNhap;
        private string _MatKhau;
        private int _MaNV;
        private int _PhanQuyen;

        public int TenDangNhap
        {
            get { return _TenDangNhap; }
            set { _TenDangNhap = value;}
        }
        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; }
        }
        public int MaNV
        {
            get { return _MaNV; }
            set { _MaNV = value; }
        }
        public int QuyenDangNhap
        {
            get { return _PhanQuyen; }
            set
            {
                _PhanQuyen = value;
            }
        }
    }
}
