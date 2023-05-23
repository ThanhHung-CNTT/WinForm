using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_BTL.DAO;

namespace WinForm_BTL
{
    public partial class fSanPham : Form
    {
        public fSanPham()
        {
            InitializeComponent();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {

        }
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            fHoaDon f = new fHoaDon();
            f.Show();
            this.Hide();
        }

        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {
            fChiTietHoaDon f = new fChiTietHoaDon();
            f.Show();
            this.Hide();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            fNhaCungCap f = new fNhaCungCap();
            f.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            fKhachHang f = new fKhachHang();
            f.Show();
            this.Hide();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            fNhanVien f = new fNhanVien();
            f.Show();
            this.Hide();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            fThongKe f = new fThongKe();
            f.Show();
            this.Hide();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            fTaiKhoan f = new fTaiKhoan();
            f.Show();
            this.Hide();
        }
        BindingSource danhsachSanPham = new BindingSource();

        private void fSanPham_Load(object sender, EventArgs e)
        {
            dtgvSanPham.DataSource = danhsachSanPham;
            danhsachSanPham.DataSource = SanPhamDAO.Instance.DanhSachSanPham();

            dtgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SanPhamBinding();
        }
        void SanPhamBinding()
        {
            txtMaSanPham.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "MaSP",true,DataSourceUpdateMode.Never));
            txtTenSanPham.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "TenSP", true, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
            txtGiaBan.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "GiaBan", true, DataSourceUpdateMode.Never));
            txtGiaNhap.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "GiaNhap", true, DataSourceUpdateMode.Never));
            dtpNSX.DataBindings.Add(new Binding("Value", dtgvSanPham.DataSource, "NSX", true, DataSourceUpdateMode.Never));
        }

        void ThemDanhSachLoaiSanPhamVaoComboBox(ComboBox cb)
        {
            //cb.DataSource = SanPhamDAO.Instance.DanhSachLoaiSanPham;
            //cb.DisplayMember = "Name";
        }
    }
}
