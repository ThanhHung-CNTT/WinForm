using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CoopFood.DAO
{
    public class ChucVuDAO
    {
        private static ChucVuDAO instance;

        public static ChucVuDAO Instance
        {
            get { if (instance == null) instance = new ChucVuDAO(); return instance; }
            set { instance = value; }
        }
        private ChucVuDAO() { }

        public DataTable DanhSachChucVu()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM CHUCVU");
        }

        public void ThemDanhSachChucVuVaoComboBox(ComboBox cb)
        {
            cb.DataSource = ChucVuDAO.Instance.DanhSachChucVu();
            cb.DisplayMember = "TenCV";
            cb.ValueMember = "MaCV";
        }
    }
}
