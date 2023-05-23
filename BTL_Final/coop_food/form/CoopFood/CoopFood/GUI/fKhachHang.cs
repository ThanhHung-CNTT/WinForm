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
    public partial class fKhachHang : Form
    {
        public fKhachHang()
        {
            InitializeComponent();

            InitFromDefault();
        }

        private async void InitFromDefault()
        {
            await LoadKhachHang();

            dtgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            KhachHangBinding();
        }

        private async Task LoadKhachHang(string tenKH = null) => dtgvKhachHang.DataSource = await KhachHangDAO.Instance.DanhSachKhachHang(tenKH);

        void KhachHangBinding()
        {
            txtMaKhachHang.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            txtTenKhachHang.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
            cbGioiTinh.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            txtSoDienThoai.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txtTichLuy.DataBindings.Add(new Binding("Text", dtgvKhachHang.DataSource, "TichLuy", true, DataSourceUpdateMode.Never));
        }

        private async void btnTao_Click(object sender, EventArgs e)
        {
            var maKH = (await KhachHangDAO.Instance.DanhSachKhachHang(null)).Max(m => m.MaKH) + 1;

            txtMaKhachHang.Text = maKH.ToString();
            txtTenKhachHang.Text = "";
            cbGioiTinh.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtTichLuy.Text = "";
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            var result = new Result();

            try
            {
                var customer = new KhachHang()
                {
                    MaKH = Int32.Parse(txtMaKhachHang.Text),
                    TenKH = txtTenKhachHang.Text,
                    GioiTinh = cbGioiTinh.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    DiaChi = txtDiaChi.Text,
                    SDT = txtSoDienThoai.Text,
                    TichLuy = Int32.Parse(txtTichLuy.Text)
                };

                if ((await KhachHangDAO.Instance.DanhSachKhachHang(null)).Find(x => x.MaKH == customer.MaKH) == null)
                    result = KhachHangDAO.Instance.ThemKhachHang(customer);
                else
                    result = KhachHangDAO.Instance.SuaKhachHang(customer);

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
                    int MaKH = Int32.Parse(txtMaKhachHang.Text);

                    AfterCommit(KhachHangDAO.Instance.XoaKhachHang(MaKH));
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
                _ =LoadKhachHang();
            }
            else if (result.IsSuccessed == false)
                MessageBoxUtil.ShowMessageBox(result.Message, MessageBoxType.Error);
        }

        private async void btnTimKiem_Click(object sender, EventArgs e) => await LoadKhachHang(txtTimKiem.Text);

        private void dtgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvKhachHang.Rows[e.RowIndex];

                txtMaKhachHang.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKhachHang.Text = row.Cells["TenKH"].Value.ToString();
                cbGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SDT"].Value.ToString();
                txtTichLuy.Text = row.Cells["TichLuy"].Value.ToString();
            }
        }
    }
}
