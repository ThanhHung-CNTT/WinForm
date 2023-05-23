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
    public partial class fTaiKhoan : Form
    {
        SqlConnection connect = ClassConnection.connect;
        SqlCommand command;
        public DataTable DanhSachTaiKhoan()
        {
            return DataProvider.Instance.ExecuteQuery("select * from taikhoan");
        }
        public fTaiKhoan()
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
        BindingSource danhsachTaiKhoan = new BindingSource();

        private void fTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadTaiKhoan();
            dtgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TaiKhoanBinding();
            ThemDanhSachTaiKhoanVaoComboBox();
        }

        void LoadTaiKhoan()
        {
            dtgvTaiKhoan.DataSource = danhsachTaiKhoan;
            danhsachTaiKhoan.DataSource = DanhSachTaiKhoan();
        }

        void TaiKhoanBinding()
        {
            cbMaNhanVien.DataBindings.Add(new Binding("text", dtgvTaiKhoan.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txtTenDangNhap.DataBindings.Add(new Binding("text", dtgvTaiKhoan.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never));
            txtMatKhau.DataBindings.Add(new Binding("text", dtgvTaiKhoan.DataSource, "MatKhau", true, DataSourceUpdateMode.Never));
        }

        void ThemDanhSachTaiKhoanVaoComboBox()
        {
            cbMaNhanVien.DataSource = DanhSachTaiKhoan();
            cbMaNhanVien.DisplayMember = "MaNV";
            cbMaNhanVien.ValueMember = "MaNV";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var cmd = new SqlCommand("INSERT INTO TAIKHOAN (MaNV, TenDangNhap, MatKhau) VALUES (@MaNV,@TenDangNhap,@MatKhau)"))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaNV", Convert.ToInt32(cbMaNhanVien.Text));
                cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    connect.Close();
                    LoadTaiKhoan();

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
            using (var cmd = new SqlCommand("UPDATE TAIKHOAN SET TenDangNhap= @TenDangNhap, MatKhau= @MatKhau WHERE MaNV= @MaNV"))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaNV", Convert.ToInt32(cbMaNhanVien.Text));
                cmd.Parameters.AddWithValue("@TenDangNhap", txtTenDangNhap.Text);
                cmd.Parameters.AddWithValue("@MatKhau", txtMatKhau.Text);
                connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    connect.Close();
                    LoadTaiKhoan();

                }
                else
                {
                    MessageBox.Show("Chim cút !!");
                    connect.Close();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (var cmd = new SqlCommand("DELETE FROM TAIKHOAN WHERE MaNV = @MaNV;"))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaNV", Convert.ToInt32(cbMaNhanVien.Text));
                connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã xóa");
                    connect.Close();
                    LoadTaiKhoan();
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
            cbMaNhanVien.SelectedItem = null;
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }
    }
}
