using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace CoopFood.DAO
{
    public class DonViDAO
    {
        private static DonViDAO instance;

        public static DonViDAO Instance
        {
            get { if (instance == null) instance = new DonViDAO(); return instance; }
            set { instance = value; }
        }

        private DonViDAO() { }

        public DataTable DanhSachDonVi() => DataProvider.Instance.ExecuteQuery("SELECT * FROM DONVITINH");
       
        public void ThemDanhSachDonViVaoComboBox(ComboBox cbDonVi)
        {
            cbDonVi.DataSource = DonViDAO.Instance.DanhSachDonVi();
            cbDonVi.DisplayMember = "TenDV";
            cbDonVi.ValueMember = "MaDVT";
        }
    }
}
