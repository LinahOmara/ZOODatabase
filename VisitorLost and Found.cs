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
    public partial class Lost_and_Found : Form
    {
        public Lost_and_Found()
        {
            InitializeComponent();
            Controller controllerObj = new Controller();

            DataTable dt = controllerObj.returnLostandFound();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
