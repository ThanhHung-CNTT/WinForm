using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WinForm_BTL.DAO;

namespace WinForm_BTL
{
    public partial class fNhanVien : Form
    {
        SqlConnection connect = ClassConnection.connect;
        SqlCommand command;
        public fNhanVien()
        {
            InitializeComponent();
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
        BindingSource danhsachNhanVien = new BindingSource();
        
        private void fNhanVien_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            dtgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NhanVienBinding();
            ThemDanhSachNhanVienVaoComboBox();
        }
        void LoadNhanVien() {
            dtgvNhanVien.DataSource = danhsachNhanVien;
            danhsachNhanVien.DataSource = NhanVienDao.Instance.DanhSachNhanVien();
        }
        void NhanVienBinding() {
            txtTenNhanVien.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "TenNV", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtEmail.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txtCMND.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "CMND", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            cbGioiTinh.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            cbMaCV.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MaCV", true, DataSourceUpdateMode.Never));
            cbMaNhanVien.DataBindings.Add(new Binding("Text", dtgvNhanVien.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Value", dtgvNhanVien.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            dtpNgayVaoLam.DataBindings.Add(new Binding("Value", dtgvNhanVien.DataSource, "NgayVaoLam", true, DataSourceUpdateMode.Never));
        }
        void ThemDanhSachNhanVienVaoComboBox()
        {
            cbMaNhanVien.DataSource = NhanVienDao.Instance.DanhSachNhanVien();
            cbMaNhanVien.DisplayMember = "MaNV";
            cbMaNhanVien.ValueMember = "MaNV";
            cbGioiTinh.DataSource = NhanVienDao.Instance.DanhSachNhanVien();
            cbGioiTinh.DisplayMember = "GioiTinh";
            cbGioiTinh.ValueMember = "GioiTinh";
            cbMaCV.DataSource = NhanVienDao.Instance.DanhSachNhanVien();
            cbMaCV.DisplayMember = "MaCV";
            cbMaCV.ValueMember = "MaCV";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var cmd = new SqlCommand("INSERT INTO NHANVIEN (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, CMND, Email, SDT, NgayVaoLam, MaCV) VALUES (@MaNV,@TenNV,@GioiTinh,@NgaySinh,@DiaChi,@CMND,@Email,@SDT,@NgayVaoLam,@MaCV)"))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaNV", Convert.ToInt32(cbMaNhanVien.Text));
                cmd.Parameters.AddWithValue("@TenNV", txtTenNhanVien.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", SqlDbType.DateTime);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text );
                cmd.Parameters.AddWithValue("@SDT", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@NgayVaoLam", SqlDbType.DateTime);
                cmd.Parameters.AddWithValue("@MaCV", Convert.ToInt32(cbMaCV.Text));
                connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    connect.Close();
                    LoadNhanVien();
                    
                }
                else
                {
                    MessageBox.Show("Chim cút !!");
                    connect.Close();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (var cmd = new SqlCommand("UPDATE NHANVIEN set TenNV= @TenNV, GioiTinh= @GioiTinh, NgaySinh= @NgaySinh, DiaChi= @DiaChi, CMND= @CMND, Email= @Email,SDT= @SDT, NgayVaoLam= @NgayVaoLam, MaCV= @MaCV WHERE MaNV = @MaNV; "))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaNV", Convert.ToInt32(cbMaNhanVien.Text));
                cmd.Parameters.AddWithValue("@TenNV", txtTenNhanVien.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", SqlDbType.DateTime);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@NgayVaoLam", SqlDbType.DateTime);
                cmd.Parameters.AddWithValue("@MaCV", Convert.ToInt32(cbMaCV.Text));
                connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã cập nhật");
                    connect.Close();
                    LoadNhanVien();
                }
                else
                {
                    MessageBox.Show("Chim cút!");
                    connect.Close();
                }
                connect.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (var cmd = new SqlCommand("DELETE FROM NHANVIEN WHERE MaNV = @MaNV;"))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaNV", Convert.ToInt32(cbMaNhanVien.Text));
                connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã xóa");
                    connect.Close();
                    LoadNhanVien();
                }
                else
                {
                    MessageBox.Show("Chim cút!");
                }
                connect.Close();
            }
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            txtTenNhanVien.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtCMND.Clear();
            txtDiaChi.Clear();
            cbGioiTinh.SelectedItem = null;
            cbMaCV.SelectedItem = null;
            cbMaNhanVien.SelectedItem = null;
            dtpNgaySinh.Text = "1/1/2022";
            dtpNgayVaoLam.Text = "1/1/2022";
        }
    }
}
