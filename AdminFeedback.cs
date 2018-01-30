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
    public partial class AdminFeedback : Form
    {
        Controller controllerObj = new Controller();
        public AdminFeedback()
        {
            InitializeComponent();
            DataTable dt = controllerObj.ShowFeedback();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}
