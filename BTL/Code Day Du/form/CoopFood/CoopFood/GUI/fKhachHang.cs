using CoopFood.DAO;
using CoopFood.DTO;
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
    public partial class fKhachHang : Form
    {
        public fKhachHang()
        {
            InitializeComponent();
        }
        BindingSource DanhSachKhachHang = new BindingSource();
        private void fKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            dtgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            KhachHangBinding();
        }

        void LoadKhachHang()
        {
            dtgvKhachHang.DataSource = DanhSachKhachHang;
            DanhSachKhachHang.DataSource = KhachHangDAO.Instance.DanhSachKhachHang();
        }

        void KhachHangBinding()
        {
            txtMaKhachHang.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            txtTenKhachHang.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
            cbGioiTinh.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtTichLuy.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "TichLuy", true, DataSourceUpdateMode.Never));
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            List<KhachHang> list = KhachHangDAO.Instance.KhachHangList();
            int STT = list.Count;
            int MaKH = list[STT - 1].MaKH + 1;
            txtMaKhachHang.Text = MaKH.ToString();
            txtTenKhachHang.Text = "";
            cbGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtTichLuy.Text = "";
        }
        public bool VongLapSua()
        {
            List<KhachHang> list = KhachHangDAO.Instance.KhachHangList();
            int MaKH = Int32.Parse(txtMaKhachHang.Text);
            string TenKH = txtTenKhachHang.Text;
            string GioiTinh = cbGioiTinh.Text;
            string NgaySinh = dtpNgaySinh.Value.ToString();
            string DiaChi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;
            int TichLuy = Int32.Parse(txtTichLuy.Text);
            foreach (int item in list.Select(kh => kh.MaKH))
            {
                if (item == MaKH)
                {
                    if (KhachHangDAO.Instance.SuaKhachHang(MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy))
                    {
                        MessageBox.Show("Sửa thành công");
                        LoadKhachHang();
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            int MaKH = Int32.Parse(txtMaKhachHang.Text);
            string TenKH = txtTenKhachHang.Text;
            string GioiTinh = cbGioiTinh.Text;
            string NgaySinh = dtpNgaySinh.Value.ToString();
            string DiaChi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;
            int TichLuy = Int32.Parse(txtTichLuy.Text);
            if (VongLapSua())
            {
                if (KhachHangDAO.Instance.ThemKhachHang(MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaKH = Int32.Parse(txtMaKhachHang.Text);

            if (KhachHangDAO.Instance.XoaKhachHang(MaKH))
            {
                MessageBox.Show("Xóa thành công");
                LoadKhachHang();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang.DataSource = KhachHangDAO.Instance.TimKiemKHTheoTen(txtTimKiem.Text);
        }
    }
}
