using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm_BTL.DAO;
using WinForm_BTL.DTO;

namespace WinForm_BTL
{
    public partial class fDangNhap : Form
    {
        TaiKhoanDAO daoTaiKhoan = new TaiKhoanDAO();
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.TenDangNhap = Convert.ToInt32(txtTenDangNhap.Text);
            tk.MatKhau = txtMatKhau.Text;
            if(daoTaiKhoan.ExitUser(tk))
            {
                MessageBox.Show("Dang nhap thanh cong!");
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Dang nhap that bai!");
            }
        }

        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
