using CoopFood.DTO;
using System;
using System.Windows.Forms;

namespace CoopFood
{
    public partial class fTrangChu : Form
    {
        public LoginRes _loginRes;

        public fTrangChu()
        {
            InitializeComponent();
            _loginRes = Form1._instanceForm1._loginRes;

            SetFormByPermission();
        }

        private void SetFormByPermission()
        {
            lbTenForm.Visible = true;
            lbTenForm.Text = "Trang Chủ";
            container(new fTrangChuShadow());

            if (_loginRes.PhanQuyen == "Nhân viên")
            {
                btnTaiKhoan.Visible = false;
                btnQuanLyTaiKhoan.Visible = false;
                btnNhanVien.Visible = false;
            }
        }

        private void fTrangChu_Load(object sender, EventArgs e) => guna2ShadowFormNhanVien.SetShadowForm(this);   

        private void container(object _form)
        {
            if (Panel_Container.Controls.Count > 0) Panel_Container.Controls.Clear();

            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            Panel_Container.Controls.Add(fm);
            Panel_Container.Tag = fm;
            fm.Show();
        }
        private void guna2BtnNhanVien_Click(object sender, EventArgs e)
        {
            lbTenForm.Visible = true;
            lbTenForm.Text = "Nhân Viên";
            container(new fNhanVien());
        }
        private void guna2BtnQuanLy_Click(object sender, EventArgs e)
        {
            lbTenForm.Visible = true;
            lbTenForm.Text = "Quản Lý Tài Khoản";
            container(new fQuanLy());
        }

        private void guna2BtnXuatHoaDon_Click(object sender, EventArgs e)
        {
            lbTenForm.Visible = true;
            lbTenForm.Text = "Xuất Hoá Đơn";
            container(new fXuatHoaDon());
        }

        private void guna2BtnNhaCungCap_Click(object sender, EventArgs e)
        {
            lbTenForm.Visible = true;
            lbTenForm.Text = "Nhà Cung Cấp";
            container(new fNhaCungCap());
        }

        private void guna2BtnSanPham_Click(object sender, EventArgs e)
        {
            lbTenForm.Visible = true;
            lbTenForm.Text = "Sản Phẩm";
            container(new fSanPham());
        }

        private void guna2BtnKhachHang_Click(object sender, EventArgs e)
        {
            lbTenForm.Visible = true;
            lbTenForm.Text = "Khách Hàng";
            container(new fKhachHang());
        }


        private void guna2BtnTaiKhoan_Click(object sender, EventArgs e)
        {
            if (guna2PnShowMenu.Visible == false)
            {
                guna2PnShowMenu.Visible = true;
            }
            else
            {
                guna2PnShowMenu.Visible = false;
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2BtnTrangChu_Click(object sender, EventArgs e)
        {
            lbTenForm.Visible = true;
            lbTenForm.Text = "Trang Chủ";
            container(new fTrangChuShadow());
        }

        

        private void guna2BtnThongKe_Click_1(object sender, EventArgs e)
        {
            lbTenForm.Visible = true;
            lbTenForm.Text = "Thống Kê";
            container(new fThongKe());
        }

        private void btnDangXuat_Click(object sender, EventArgs e) => this.Close();
    }
}
