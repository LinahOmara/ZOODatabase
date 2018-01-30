using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZOO_Application
{
    public partial class AdminResearchers : Form
    {
        Controller controllerObj = new Controller();
        public AdminResearchers()
        {
            InitializeComponent();
            DataTable dt = controllerObj.ShowResearchers();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminNewResearcher NR = new AdminNewResearcher();
            NR.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminNewResearch nr = new AdminNewResearch();
            nr.Show();
        }
    }
}
