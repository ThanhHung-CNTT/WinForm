using CoopFood.DAO;
using CoopFood.DTO;
using CoopFood.Enumerates;
using CoopFood.Utills;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CoopFood
{
    public partial class Form1 : Form
    {
        public static Form1 _instanceForm1;
        public LoginRes _loginRes;

        public Form1()
        {
            InitializeComponent();
            _instanceForm1 = this;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkHienMatKhau.Checked)
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '*';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private async void guna2BtnLogin_Click(object sender, EventArgs e)
        {
            //var result = await TaiKhoanDAO.Instance.Login("QL201", "123456");
            var result = await TaiKhoanDAO.Instance.Login(txtUsername.Text, txtPassword.Text);
            if (result.Count > 0)
            {
                _loginRes = result.FirstOrDefault();
                fTrangChu f = new fTrangChu();
                f.Show();
            }    
            else
                MessageBoxUtil.ShowMessageBox("Tài khoản hoặc mật khẩu không chính xác. Vui lòng kiểm tra lại", MessageBoxType.Warning);
        }
    }
}
