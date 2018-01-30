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
    
    public partial class AdminRestCafe : Form
    {

        Controller controllerObj = new Controller();
        
        public AdminRestCafe()
        {
            InitializeComponent();
             DataTable dt = controllerObj.ShowRestCafee();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.RentedRest();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.NotRentedRest();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }


    }
}
