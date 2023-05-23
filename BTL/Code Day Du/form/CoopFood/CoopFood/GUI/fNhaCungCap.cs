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
    public partial class fNhaCungCap : Form
    {
        public fNhaCungCap()
        {
            InitializeComponent();
        }
        BindingSource danhsachNhaCungCap = new BindingSource();
        private void fNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();

            dtgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NhaCungCapBinding();
        }
        void LoadNhaCungCap()
        {
            dtgvNCC.DataSource = danhsachNhaCungCap;
            danhsachNhaCungCap.DataSource = NhaCungCapDAO.Instance.DanhSachNhaCungCap();


        }
        void NhaCungCapBinding()
        {
            txtMaNCC.DataBindings.Add(new Binding("Text", dtgvNCC.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            txtTenNCC.DataBindings.Add(new Binding("Text", dtgvNCC.DataSource, "TenNCC", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dtgvNCC.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dtgvNCC.DataSource, "SDT", true, DataSourceUpdateMode.Never));
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            List<NhaCungCap> list = NhaCungCapDAO.Instance.NhaCungCapList();
            int STT = list.Count;
            int MaNCC = list[STT - 1].MaNCC + 1;
            txtMaNCC.Text = MaNCC.ToString();
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }
        public bool VongLapSua()
        {
            List<NhaCungCap> list = NhaCungCapDAO.Instance.NhaCungCapList();
            int maNCC = Int32.Parse(txtMaNCC.Text);
            string tenNCC = txtTenNCC.Text;
            string diachi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;
            foreach (int item in list.Select(ncc => ncc.MaNCC))
            {
                if (item == maNCC)
                {
                    if (NhaCungCapDAO.Instance.SuaNhaCungCap(maNCC, tenNCC, diachi, SDT))
                    {
                        MessageBox.Show("Sửa thành công");
                        LoadNhaCungCap();
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
            int maNCC = Int32.Parse(txtMaNCC.Text);
            string tenNCC = txtTenNCC.Text;
            string diachi = txtDiaChi.Text;
            string SDT = txtSoDienThoai.Text;
            if (VongLapSua())
            {
                if (NhaCungCapDAO.Instance.ThemNhaCungCap(maNCC, tenNCC, diachi, SDT))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadNhaCungCap();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maNCC = Int32.Parse(txtMaNCC.Text);

            if (NhaCungCapDAO.Instance.XoaNhaCungCap(maNCC))
            {
                MessageBox.Show("Xóa thành công");
                LoadNhaCungCap();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            danhsachNhaCungCap.DataSource = NhaCungCapDAO.Instance.TimKiemNCCTheoTen(btnTimKiem.Text);
        }
    }
}
