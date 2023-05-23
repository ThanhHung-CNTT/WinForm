using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Data_Report_SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=LAPTOP-6EA8ABAQ\SQLEXPRESS; Initial Catalog= RDLC; Integrated Security=True; User=sa; Password=123456";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Student", cnn);
            DataTable dt = new DataTable("DataSetStudentDataset");
            da.Fill(dt);
            ReportDataSource rds = new ReportDataSource("DataSetStudentDataset",dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            cnn.Close();
        }
    }
}
