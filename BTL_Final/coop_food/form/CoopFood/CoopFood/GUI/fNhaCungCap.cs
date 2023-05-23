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
    public partial class fNhaCungCap : Form
    {
        public fNhaCungCap()
        {
            InitializeComponent();
            InitFromDefault();
        }

        private async void InitFromDefault()
        {
            await LoadNhaCungCap();

            dtgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            NhaCungCapBinding();
        }

        private async Task LoadNhaCungCap(string keySearch = null) => dtgvNCC.DataSource = await NhaCungCapDAO.Instance.DanhSachNhaCungCap(keySearch);

        void NhaCungCapBinding()
        {
            txtMaNCC.DataBindings.Add(new Binding("Text", dtgvNCC.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            txtTenNCC.DataBindings.Add(new Binding("Text", dtgvNCC.DataSource, "TenNCC", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dtgvNCC.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dtgvNCC.DataSource, "SDT", true, DataSourceUpdateMode.Never));
        }

        private async void btnTao_Click(object sender, EventArgs e)
        {
            var maNCC = (await NhaCungCapDAO.Instance.DanhSachNhaCungCap(null)).Max(m => m.MaNCC) + 1;

            txtMaNCC.Text = maNCC.ToString();
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            var result = new Result();

            try
            {
                var supplier = new NhaCungCap()
                {
                    MaNCC = Int32.Parse(txtMaNCC.Text),
                    TenNCC = txtTenNCC.Text,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSoDienThoai.Text
                };

                if ((await NhaCungCapDAO.Instance.DanhSachNhaCungCap(null)).Find(x => x.MaNCC == supplier.MaNCC) == null)
                    result = NhaCungCapDAO.Instance.ThemNhaCungCap(supplier);
                else
                    result = NhaCungCapDAO.Instance.SuaNhaCungCap(supplier);

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
                    int maNCC = Int32.Parse(txtMaNCC.Text);

                    AfterCommit(NhaCungCapDAO.Instance.XoaNhaCungCap(maNCC));
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
                _ = LoadNhaCungCap();
            }
            else if (result.IsSuccessed == false)
                MessageBoxUtil.ShowMessageBox(result.Message, MessageBoxType.Error);
        }

        private async void btnTimKiem_Click(object sender, EventArgs e) => await LoadNhaCungCap(txtTimKiem.Text);

        private void dtgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvNCC.Rows[e.RowIndex];

                txtMaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txtTenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SDT"].Value.ToString();
            }
        }
    }
}
