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

namespace winform_sql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //2

            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=LAPTOP-6EA8ABAQ\SQLEXPRESS;Initial Catalog=DemoDB_Winform;User ID=sa; Password=123456";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql, Output = "";
            //3

            sql = "Select TutorialID, TutorialName from DemoTable";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "\n";
            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=LAPTOP-6EA8ABAQ\SQLEXPRESS;Initial Catalog=DemoDB_Winform;User ID=sa; Password=123456";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "Insert into DemoTable (TutorialID, TutorialName) values(3,'"+"VB.Net"+"')";
            command = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            MessageBox.Show("Insert thanh cong !!");
            command.Dispose();
            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=LAPTOP-6EA8ABAQ\SQLEXPRESS;Initial Catalog=DemoDB_Winform;User ID=sa; Password=123456";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "Update DemoTable set TutorialName='" + "VB.Net Complete" + "'where TutorialID=3";
            command = new SqlCommand(sql, cnn);
            adapter.UpdateCommand = new SqlCommand(sql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            MessageBox.Show("Update thanh cong cac du lieu co ID =3");
            command.Dispose();
            cnn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source=LAPTOP-6EA8ABAQ\SQLEXPRESS;Initial Catalog=DemoDB_Winform;User ID=sa; Password=123456";
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "Delete DemoTable where TutorialID=3";
            command = new SqlCommand(sql, cnn);
            adapter.DeleteCommand = new SqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();
            MessageBox.Show("Xoa Thanh Cong :))");
            command.Dispose();
            cnn.Close();
        }
    }
}
