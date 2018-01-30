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
    
    
    public partial class AdminMedicine : Form
    {
        Controller controllerObj = new Controller();

        public AdminMedicine()
        {
            InitializeComponent();
            DataTable dt = controllerObj.ShowMEdicines();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.ShowMEdicinesNeedToBuy();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}
