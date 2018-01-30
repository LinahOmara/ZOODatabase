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
    public partial class VisitorTickets : Form
    {
        public VisitorTickets()
        {
            InitializeComponent();
            Controller controllerObj = new Controller();
            
            DataTable dt = controllerObj.returnTickets();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
