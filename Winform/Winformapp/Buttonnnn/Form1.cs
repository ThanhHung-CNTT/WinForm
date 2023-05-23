using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buttonnnn
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setting the properties of lable
            lblText.AutoSize = true;
            lblText.Text = "Do you want to submit this project?";
            lblText.Font = new Font("French Script MT", 18);

            //Setting the properties of Button
            btnSubmit.Text = "Submit";
            btnSubmit.AutoSize = true;
            btnSubmit.BackColor = Color.LightBlue;
            btnSubmit.Padding = new Padding(6);
            btnSubmit.Font = new Font("French Script MT", 18);

            //Create and setting the properties of lable

            btnCancel.Text = "Submit";
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.LightPink;
            btnCancel.Padding = new Padding(6);
            btnCancel.Font = new Font("French Script MT", 18);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
