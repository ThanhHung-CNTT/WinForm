using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace Data_Report
{
    public class Student
    {
        public string StudentID { get; set; }
        public string Fullname { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public Student()
        {

        }
        public Student(string id, string name, DateTime dtBirthday, string add)
        {
            StudentID = id;
            Fullname = name;
            Birthday = dtBirthday;
            Address = add;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Student> GetTempListStudent()
        {
            List<Student> listStudent = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                Student temp = new Student();
                temp.StudentID = "CNTT0120" + i;
                temp.Fullname = "Nguyễn Văn" + i;
                temp.Birthday = new DateTime(2000, 1, 1);
                temp.Address = "Địa chỉ" + i;

                listStudent.Add(temp);
            }
            return listStudent;
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            List<Student> listStudent = GetTempListStudent();
            ReportDataSource drs = new ReportDataSource("DataSetStudent", listStudent);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(drs);
            this.reportViewer1.RefreshReport();
        }
    }
}
