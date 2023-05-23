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
    public partial class fNhanVien : Form
    {
        public fNhanVien()
        {
            InitializeComponent();
        }
        BindingSource danhSachNhanVien = new BindingSource();
        private void fNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();

            dtgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NhanVienBinding();
            ChucVuDAO.Instance.ThemDanhSachChucVuVaoComboBox(cbTenChucVu);
        }
        void LoadNhanVien()
        {
            dtgvNhanVien.DataSource = danhSachNhanVien;
            danhSachNhanVien.DataSource = NhanVienDAO.Instance.DanhSachNhanVien();
        }
        void NhanVienBinding()
        {
            txtMaNhanVien.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txtTenNhanVien.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "TenNV", true, DataSourceUpdateMode.Never));
            cbGioiTinh.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txtCMND.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "CMND", true, DataSourceUpdateMode.Never));
            txtEmail.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            dtpNgayVaoLam.DataBindings.Add(new Binding("Value", dtgvNhanVien.DataSource, "NgayVaoLam", true, DataSourceUpdateMode.Never));
            cbTenChucVu.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MaCV", true, DataSourceUpdateMode.Never));
        }
        private void btnTao_Click(object sender, EventArgs e)
        {
            List<NhanVien> list = NhanVienDAO.Instance.NhanVienList();
            int STT = list.Count;
            int MaNV = list[STT - 1].MaNV + 1;
            txtMaNhanVien.Text = MaNV.ToString();
            txtTenNhanVien.Text = "";
            cbGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtCMND.Text = "";
            txtEmail.Text = "";
            txtSoDienThoai.Text = "";
            dtpNgayVaoLam.Text = "";
            cbTenChucVu.Text = "";
        }
        public bool VongLapSua()
        {
            List<NhanVien> list = NhanVienDAO.Instance.NhanVienList();
            int MaNV = Int32.Parse(txtMaNhanVien.Text);
            string TenNV = txtTenNhanVien.Text;
            string GioiTinh = cbGioiTinh.Text;
            string NgaySinh = dtpNgaySinh.Value.ToString();
            string DiaChi = txtDiaChi.Text;
            string CMND = txtCMND.Text;
            string Email = txtEmail.Text;
            string SDT = txtSoDienThoai.Text;
            string NgayVaoLam = dtpNgayVaoLam.Value.ToString();
            string check = cbTenChucVu.ValueMember;
            int MaCV = NhanVienDAO.Instance.LayMaCV(cbTenChucVu.Text);
            foreach (int item in list.Select(nv => nv.MaNV))
            {
                if (item == MaNV)
                {
                    if (NhanVienDAO.Instance.SuaNhanVien(MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MaCV))
                    {
                        MessageBox.Show("Sửa thành công");
                        LoadNhanVien();
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
            List<NhanVien> list = NhanVienDAO.Instance.NhanVienList();
            int MaNV = Int32.Parse(txtMaNhanVien.Text);
            string TenNV = txtTenNhanVien.Text;
            string GioiTinh = cbGioiTinh.Text;
            string NgaySinh = dtpNgaySinh.Value.ToString();
            string DiaChi = txtDiaChi.Text;
            string CMND = txtCMND.Text;
            string Email = txtEmail.Text;
            string SDT = txtSoDienThoai.Text;
            string NgayVaoLam = dtpNgayVaoLam.Value.ToString();
            string check = cbTenChucVu.ValueMember;
            int MaCV = NhanVienDAO.Instance.LayMaCV(cbTenChucVu.Text);
            if (VongLapSua())
            {
                if (NhanVienDAO.Instance.ThemNhanVien(MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MaCV))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadNhanVien();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaNV = Int32.Parse(txtMaNhanVien.Text);

            if (NhanVienDAO.Instance.XoaNhanVien(MaNV))
            {
                MessageBox.Show("Xóa thành công");
                LoadNhanVien();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            danhSachNhanVien.DataSource = NhanVienDAO.Instance.TimKiemNVTheoTen(txtTimKiem.Text);
        }
    
    }
}
