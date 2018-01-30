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
    public partial class VisitorShows : Form
    {
        public VisitorShows()
        {
            InitializeComponent();
            Controller controllerObj = new Controller();

            DataTable dt = controllerObj.returnShows();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}
