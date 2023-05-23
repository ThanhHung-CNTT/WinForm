using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CoopFood.DAO
{
    public class LoaiSanPhamDAO
    {
        private static LoaiSanPhamDAO instance;

        public static LoaiSanPhamDAO Instance
        {
            get { if (instance == null) instance = new LoaiSanPhamDAO(); return instance; }
            set { instance = value; }
        }

        private LoaiSanPhamDAO() { }

        public DataTable DanhSachLoaiSanPham() => DataProvider.Instance.ExecuteQuery("SELECT * FROM LOAISANPHAM");

        public void ThemDanhSachLoaiSPVaoComboBox(ComboBox cb)
        {
            cb.DataSource = LoaiSanPhamDAO.Instance.DanhSachLoaiSanPham();
            cb.DisplayMember = "TenLSP";
            cb.ValueMember = "MaLSP";
        }
    }
}
