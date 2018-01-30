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
    public partial class AdminNewResearcher : Form
    {
        Controller controllerObj = new Controller();
        public AdminNewResearcher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBoxNAMe.Text;
            string college = textBoxCollege.Text;
            string Start = Startdate.Value.ToString("yyyy-MM-dd");
            string end = endDate.Value.ToString("yyyy-MM-dd");


             controllerObj.InsertResearcher(name, college, Start, end);
           
            textBoxCollege.Clear();
            textBoxNAMe.Clear();
        }
    }
}
