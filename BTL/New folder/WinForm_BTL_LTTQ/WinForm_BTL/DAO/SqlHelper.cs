using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_BTL.DAO
{
    class SqlHelper
    {
        public static int getQuyenDangNhap;
        public static string connectionString = @"Data Source=DESKTOP-IMEC2IP\SQLEXPRESS01;Initial Catalog=COOP_FOOD;Integrated Security=True";
        public static SqlConnection cnn;
    }
}
