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
    public partial class fKhachHang : Form
    {
        SqlConnection connect = ClassConnection.connect;
        SqlCommand command;
        public DataTable DanhSachKhachHang()
        {
            return DataProvider.Instance.ExecuteQuery("select * from khachhang");
        }
        public fKhachHang()
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
        BindingSource danhsachKhachHang = new BindingSource();

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            dtgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            KhachHangBinding();
        }

        void LoadKhachHang()
        {
            dtgvKhachHang.DataSource = danhsachKhachHang;
            danhsachKhachHang.DataSource = DanhSachKhachHang();
        }
        void KhachHangBinding()
        {
            cbGioiTinh.DataBindings.Add(new Binding("text", dtgvKhachHang.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            txtMaKH.DataBindings.Add(new Binding("text", dtgvKhachHang.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            txtTenKH.DataBindings.Add(new Binding("text", dtgvKhachHang.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("text", dtgvKhachHang.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("text", dtgvKhachHang.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Value", dtgvKhachHang.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var cmd = new SqlCommand("INSERT INTO KHACHHANG (MaKH, TenKH, GioiTinh, NgaySinh, DiaChi, SDT, TichLuy) VALUES (@MaKH,@TenKH,@GioiTinh,@NgaySinh,@DiaChi,@SDT,Null)"))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaKH", Convert.ToInt32(txtMaKH.Text));
                cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", SqlDbType.DateTime);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                //cmd.Parameters.AddWithValue("@TichLuy", null);
                connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    connect.Close();
                    LoadKhachHang();

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
            using (var cmd = new SqlCommand("UPDATE KHACHHANG SET TenKH= @TenKH, GioiTinh= @GioiTinh, NgaySinh= @NgaySinh, DiaChi= @DiaChi, SDT= @SDT, TichLuy= Null WHERE MaKH = @MaKH; "))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaKH", Convert.ToInt32(txtMaKH.Text));
                cmd.Parameters.AddWithValue("@TenKH", txtTenKH.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cbGioiTinh.Text);
                cmd.Parameters.AddWithValue("@NgaySinh", SqlDbType.DateTime);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                //cmd.Parameters.AddWithValue("@TichLuy", null);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã cập nhật");
                    connect.Close();
                    LoadKhachHang();
                }
                else
                {
                    MessageBox.Show("Chim cút!");
                    connect.Close();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (var cmd = new SqlCommand("DELETE FROM KHACHHANG WHERE MaKH = @MaKH;"))
            {
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@MaKH", Convert.ToInt32(txtMaKH.Text));
                connect.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã xóa");
                    connect.Close();
                    LoadKhachHang();
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
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            cbGioiTinh.SelectedItem = null;
            txtMaKH.Clear();
            dtpNgaySinh.Text = "1/1/2022";
        }
    }
}
