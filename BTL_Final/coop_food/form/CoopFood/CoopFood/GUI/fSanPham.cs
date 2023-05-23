using CoopFood.DAO;
using CoopFood.DTO;
using CoopFood.Enumerates;
using CoopFood.Utills;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoopFood
{
    public partial class fSanPham : Form
    {
        public fSanPham()
        {
            InitializeComponent();

            InitFromDefault();
        }

        private async void InitFromDefault()
        {
            await LoadSanPham();

            dtgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SanPhamBinding();

            NhaCungCapDAO.Instance.ThemDanhSachNhaCungCapVaoComboBox(cbMaNCC);
            
            LoaiSanPhamDAO.Instance.ThemDanhSachLoaiSPVaoComboBox(cbMaLoaiSanPham);

            DonViDAO.Instance.ThemDanhSachDonViVaoComboBox(cbDonVi);
        }

        private async Task LoadSanPham(string keySearch = null) => dtgvSanPham.DataSource = await SanPhamDAO.Instance.DanhSachSanPham(keySearch);

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

        private async void btnTao_Click(object sender, EventArgs e)
        {
            var maSp = (await SanPhamDAO.Instance.DanhSachSanPham(null)).Max(m => m.MaSP) + 1;

            txtMaSanPham.Text = maSp.ToString();
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

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            var result = new Result();

            try
            {
                var product = new SanPhamReq()
                {
                    MaSP = Int32.Parse(txtMaSanPham.Text),
                    TenSP = txtTenSanPham.Text,
                    MaDVT = Int32.Parse(cbDonVi.SelectedValue.ToString()),
                    MaLSP = Int32.Parse(cbMaLoaiSanPham.SelectedValue.ToString()),
                    MaNCC = Int32.Parse(cbMaNCC.SelectedValue.ToString()),
                    SoLuong = !string.IsNullOrWhiteSpace(txtSoLuong.Text) ? Int32.Parse(txtSoLuong.Text) : 0,
                    NSX = dtpNSX.Value,
                    HSD = dtpHSD.Value,
                    NgayNhap = dtpNgayNhap.Value,
                    GiaNhap = !string.IsNullOrWhiteSpace(txtGiaNhap.Text) ? decimal.Parse(txtGiaNhap.Text) : 0,
                    GiaBan = !string.IsNullOrWhiteSpace(txtGiaBan.Text) ? decimal.Parse(txtGiaBan.Text) : 0
                };

                if ((await SanPhamDAO.Instance.DanhSachSanPham(null)).Find(x => x.MaSP == product.MaSP) == null)
                    result = SanPhamDAO.Instance.ThemSanPham(product);
                else
                    result = SanPhamDAO.Instance.SuaSanPham(product);

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
                    int MaSP = Int32.Parse(txtMaSanPham.Text);

                    AfterCommit(SanPhamDAO.Instance.XoaSanPham(MaSP));
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
                _ =LoadSanPham();
            }
            else if (result.IsSuccessed == false)
                MessageBoxUtil.ShowMessageBox(result.Message, MessageBoxType.Error);
        }

        private async void btnTimKiem_Click(object sender, EventArgs e) => await LoadSanPham(txtTimKiem.Text);

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvSanPham.Rows[e.RowIndex];

                txtMaSanPham.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSanPham.Text = row.Cells["TenSP"].Value.ToString();

                cbDonVi.SelectedValue = int.Parse(row.Cells["MaDVT"].Value.ToString());
                cbDonVi.SelectedText = row.Cells["TenDV"].Value.ToString();

                cbMaLoaiSanPham.SelectedValue = int.Parse(row.Cells["MaLSP"].Value.ToString());
                cbMaLoaiSanPham.SelectedText = row.Cells["TenLSP"].Value.ToString();

                cbMaNCC.SelectedValue = int.Parse(row.Cells["MaNCC"].Value.ToString());
                cbMaNCC.SelectedText = row.Cells["TenNCC"].Value.ToString();

                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                dtpNSX.Value = DateTime.Parse(row.Cells["NSX"].Value.ToString());
                dtpHSD.Value = DateTime.Parse(row.Cells["HSD"].Value.ToString());
                dtpNgayNhap.Value = DateTime.Parse(row.Cells["NgayNhap"].Value.ToString());
                txtGiaNhap.Text = row.Cells["GiaNhap"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
            }
        }
    }
}
