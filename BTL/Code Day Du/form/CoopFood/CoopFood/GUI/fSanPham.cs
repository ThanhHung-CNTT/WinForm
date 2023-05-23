using CoopFood.DAO;
using CoopFood.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopFood
{
    public partial class fSanPham : Form
    {
        public fSanPham()
        {
            InitializeComponent();
        }
        BindingSource danhsachSanPham = new BindingSource();

        private void fSanPham_Load(object sender, EventArgs e)
        {
            LoadSanPham();

            dtgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SanPhamBinding();
            NhaCungCapDAO.Instance.ThemDanhSachNhaCungCapVaoComboBox(cbMaNCC);
            LoaiSanPhamDAO.Instance.ThemDanhSachLoaiSPVaoComboBox(cbMaLoaiSanPham);
            DonViDAO.Instance.ThemDanhSachDonViVaoComboBox(cbDonVi);
        }

        void LoadSanPham()
        {
            dtgvSanPham.DataSource = danhsachSanPham;
            danhsachSanPham.DataSource = SanPhamDAO.Instance.DanhSachSanPham();
        }

        void SanPhamBinding()
        {
            txtMaSanPham.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "MaSP", true, DataSourceUpdateMode.Never));
            txtTenSanPham.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "TenSP", true, DataSourceUpdateMode.Never));
            cbDonVi.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "MaDVT", true, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
            txtGiaBan.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "GiaBan", true, DataSourceUpdateMode.Never));
            txtGiaNhap.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "GiaNhap", true, DataSourceUpdateMode.Never));
            dtpNSX.DataBindings.Add(new Binding("Value", dtgvSanPham.DataSource, "NSX", true, DataSourceUpdateMode.Never));
            dtpHSD.DataBindings.Add(new Binding("Value", dtgvSanPham.DataSource, "HSD", true, DataSourceUpdateMode.Never));
            dtpNgayNhap.DataBindings.Add(new Binding("Value", dtgvSanPham.DataSource, "NgayNhap", true, DataSourceUpdateMode.Never));
            cbMaNCC.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            cbMaLoaiSanPham.DataBindings.Add(new Binding("Text", dtgvSanPham.DataSource, "MaLSP", true, DataSourceUpdateMode.Never));
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            List<SanPham> list = SanPhamDAO.Instance.SanPhamList();
            int STT = list.Count;
            int MaSP = list[STT - 1].MaSP + 1;
            txtMaSanPham.Text = MaSP.ToString();
            txtTenSanPham.Text = "";
            cbDonVi.Text = "";
            cbMaLoaiSanPham.Text = "";
            cbMaNCC.Text = "";
            txtSoLuong.Text = "";
            dtpNSX.Value = DateTime.Now;
            dtpHSD.Value = DateTime.Now;
            dtpNgayNhap.Value = DateTime.Now;
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
        }
        public bool VongLapSua()
        {
            List<SanPham> list = SanPhamDAO.Instance.SanPhamList();
            int MaSP = Int32.Parse(txtMaSanPham.Text);
            string TenSP = txtTenSanPham.Text;
            int MaDVT = Int32.Parse(cbDonVi.Text);
            int MaLSP = Int32.Parse(cbMaLoaiSanPham.Text);
            int MaNCC = Int32.Parse(cbMaNCC.Text);
            int SoLuong = Int32.Parse(txtSoLuong.Text);
            string NSX = dtpNSX.Value.ToString();
            string HSD = dtpHSD.Value.ToString();
            string NgayNhap = dtpNgayNhap.Value.ToString();
            float GiaNhap = float.Parse(txtGiaNhap.Text);
            float GiaBan = float.Parse(txtGiaBan.Text);
            foreach (int item in list.Select(ncc => ncc.MaNCC))
            {
                if (item == MaSP)
                {
                    if (SanPhamDAO.Instance.SuaSanPham(MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaBan, GiaNhap))
                    {
                        MessageBox.Show("Sửa thành công");
                        LoadSanPham();
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
            int MaSP = Int32.Parse(txtMaSanPham.Text);
            string TenSP = txtTenSanPham.Text;
            int MaDVT = Int32.Parse(cbDonVi.Text);
            int MaLSP = Int32.Parse(cbMaLoaiSanPham.Text);
            int MaNCC = Int32.Parse(cbMaNCC.Text);
            int SoLuong = Int32.Parse(txtSoLuong.Text);
            string NSX = dtpNSX.Value.ToString();
            string HSD = dtpHSD.Value.ToString();
            string NgayNhap = dtpNgayNhap.Value.ToString();
            float GiaNhap = float.Parse(txtGiaNhap.Text);
            float GiaBan = float.Parse(txtGiaBan.Text);
            if (VongLapSua())
            {
                if (SanPhamDAO.Instance.ThemSanPham(MaSP, TenSP, MaDVT, MaLSP, MaNCC, SoLuong, NSX, HSD, NgayNhap, GiaBan, GiaNhap))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadSanPham();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaSP = Int32.Parse(txtMaSanPham.Text);

            if (SanPhamDAO.Instance.XoaSanPham(MaSP))
            {
                MessageBox.Show("Xóa thành công");
                LoadSanPham();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            danhsachSanPham.DataSource = SanPhamDAO.Instance.TimKiemSPTheoTen(txtTimKiem.Text);
        }
    }
}
