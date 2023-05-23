using CoopFood.DAO;
using CoopFood.DTO;
using CoopFood.Enumerates;
using CoopFood.Utills;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopFood
{
    public partial class fQuanLy : Form
    {
        public fQuanLy()
        {
            InitializeComponent();

            InitFromDefault();
        }

        private async void InitFromDefault()
        {
            await LoadTaiKhoan();

            dtgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SanPhamBinding();

            NhanVienDAO.Instance.ThemDanhSachNhanvienVaoComboBox(cbTennhanvien);
        }

        private async Task LoadTaiKhoan(string tenNV = null) => dtgvTaiKhoan.DataSource = await TaiKhoanDAO.Instance.DanhSachTaiKhoan(tenNV);
        
        void SanPhamBinding()
        {
            txtTenDangNhap.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never));
            txtMatKhau.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "MatKhau", true, DataSourceUpdateMode.Never));
            cbTennhanvien.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            cbPhanQuyen.DataBindings.Add(new Binding("Text", dtgvTaiKhoan.DataSource, "PhanQuyen", true, DataSourceUpdateMode.Never));
        }

        private async void btnTao_Click(object sender, EventArgs e)
        {
            AutoFillTenDangNhap();

            txtMatKhau.Text = "";
            cbTennhanvien.Text = "";
            cbPhanQuyen.Text = "";
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            var result = new Result();

            try
            {
                var acc = new TaiKhoan()
                {
                    TenDangNhap = txtTenDangNhap.Text,
                    MatKhau = txtMatKhau.Text,
                    MaNV = int.Parse(cbTennhanvien.SelectedValue.ToString()),
                    PhanQuyen = cbPhanQuyen.Text
                };

                if ((await TaiKhoanDAO.Instance.DanhSachTaiKhoan(null)).Find(x => x.TenDangNhap == acc.TenDangNhap) == null)
                    result = TaiKhoanDAO.Instance.ThemTaiKhoan(acc);
                else
                    result = TaiKhoanDAO.Instance.SuaTaiKhoan(acc);

                AfterCommit(result);
            }
            catch
            {
                MessageBoxUtil.ShowMessageBox("Hệ thống tạm thời gián đoạn. Vui lòng thử lại sau", MessageBoxType.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    AfterCommit(TaiKhoanDAO.Instance.XoaTaiKhoan(txtTenDangNhap.Text));
                }
            }
            catch
            {
                MessageBoxUtil.ShowMessageBox("Hệ thống tạm thời gián đoạn. Vui lòng thử lại sau", MessageBoxType.Error);
            }
        }

        private void AfterCommit(Result result)
        {
            if (result.IsSuccessed)
            {
                MessageBoxUtil.ShowMessageBox(result.Message, MessageBoxType.Information);
                _ = LoadTaiKhoan();
            }
            else if (result.IsSuccessed == false)
                MessageBoxUtil.ShowMessageBox(result.Message, MessageBoxType.Error);
        }

        private async void btnTimKiem_Click(object sender, EventArgs e) => await LoadTaiKhoan(txtTimKiem.Text);

        private void cbPhanQuyen_SelectedValueChanged(object sender, EventArgs e) => AutoFillTenDangNhap();

        private void cbTennhanvien_SelectedValueChanged(object sender, EventArgs e) => AutoFillTenDangNhap();

        private void AutoFillTenDangNhap()
        {
            if (cbPhanQuyen.Text == "Quản lý")
                txtTenDangNhap.Text = "QL" + cbTennhanvien.SelectedValue;
            else
                txtTenDangNhap.Text = "NV" + cbTennhanvien.SelectedValue;
        }

        private void dtgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dtgvTaiKhoan.Rows[e.RowIndex];

            txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
            txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();

            cbTennhanvien.SelectedValue = int.Parse(row.Cells["MaNV"].Value.ToString());
            cbTennhanvien.SelectedText = row.Cells["TenNV"].Value.ToString();

            cbPhanQuyen.Text = row.Cells["PhanQuyen"].Value.ToString();
        }
    }
}
