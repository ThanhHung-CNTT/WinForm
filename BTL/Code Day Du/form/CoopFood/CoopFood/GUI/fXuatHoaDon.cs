using CoopFood.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopFood
{
    public partial class fXuatHoaDon : Form
    {
        public fXuatHoaDon()
        {
            InitializeComponent();
        }
        BindingSource danhsachCTHD = new BindingSource();
        BindingSource danhsachHoaDon = new BindingSource();
        private void fXuatHoaDon_Load(object sender, EventArgs e)
        {
            LoadXuatHoaDon();

            dtgvCTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NhaCungCapBinding();
        }
        void LoadXuatHoaDon()
        {
            dtgvCTHD.DataSource = danhsachCTHD;
            danhsachCTHD.DataSource = CTHDDAO.Instance.DanhSachCTHD(702);
            danhsachHoaDon.DataSource = HoaDonDAO.Instance.DanhSachHoaDon();

        }
        void NhaCungCapBinding()
        {
            dtpNgayLap.DataBindings.Add(new Binding("Value", danhsachHoaDon.DataSource,"NgayMua", true, DataSourceUpdateMode.Never));
            txtMaHoaDon.DataBindings.Add(new Binding("Text", dtgvCTHD.DataSource, "MaHD", true, DataSourceUpdateMode.Never));
            cbMaNhanVien.DataBindings.Add(new Binding("Text", danhsachHoaDon.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            //cbLoaiSanPham.DataBindings.Add(new Binding("Text", dtgvCTHD.DataSource, "MaLSP", true, DataSourceUpdateMode.Never));
            //cbTenSanPham.DataBindings.Add(new Binding("Text", dtgvCTHD.DataSource, "TenSP", true, DataSourceUpdateMode.Never));
            //cbDonVi.DataBindings.Add(new Binding("Text", dtgvCTHD.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", dtgvCTHD.DataSource, "SoLuongBan", true, DataSourceUpdateMode.Never));
            txtGiaBan.DataBindings.Add(new Binding("Text", dtgvCTHD.DataSource, "GiaSP", true, DataSourceUpdateMode.Never));
        }
    }
}
