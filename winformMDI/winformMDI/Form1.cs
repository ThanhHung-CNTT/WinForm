using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformMDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ban da chon menuitem1");
        }

        private void menuItem2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ban da chon menuitem2");
        }
    }
}
