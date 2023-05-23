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
    public partial class fThongKe : Form
    {
        public fThongKe()
        {
            InitializeComponent();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
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

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            fSanPham f = new fSanPham();
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
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            fHoaDon f = new fHoaDon();
            f.Show();
            this.Hide();
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void dtgvThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fThongKe_Load(object sender, EventArgs e)
        {
/*            string NgayGio = DateTime.Now.ToString();

            string query = string.Format("SP_BCDTTheoNgay @Ngay = {0} ", NgayGio);

            string tongtien = string.Format("SELECT SUM(TongTien) AS DOANHTHU FROM HD WHERE NgayMua = {0} ", NgayGio);

            dtgvThongKe.DataSource = DataProvider.Instance.ExecuteQuery(query);

            txtTongTien.Text = DataProvider.Instance.ExecuteQuery(tongtien).ToString();*/
        }
    }
}
