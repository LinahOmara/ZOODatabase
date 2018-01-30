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
    public partial class Restauranrs_and_cafee : Form
    {
        public Restauranrs_and_cafee()
        {
            InitializeComponent();
            Controller controllerObj = new Controller();

            DataTable dt = controllerObj.returnRestandCafee();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}
