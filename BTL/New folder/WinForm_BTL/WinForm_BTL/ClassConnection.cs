using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_BTL
{
    class ClassConnection
    {
        public static SqlConnection connect = new SqlConnection(@"Data Source=LAPTOP-6EA8ABAQ\SQLEXPRESS;Initial Catalog=COOP_FOOD;User ID=sa;Password=123456");
    }
}
