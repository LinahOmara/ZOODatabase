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
    public partial class VisitorAnimals : Form
    {
        public VisitorAnimals()
        {
            InitializeComponent();

            Controller controllerObj = new Controller();
            DataTable dt = controllerObj.returnAnimals();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
      
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
    }
}
