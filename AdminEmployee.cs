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
    public partial class AdminEmployee : Form
    {
        Controller controllerObj = new Controller();
        public AdminEmployee()
        {
            InitializeComponent();
            DataTable dt = controllerObj.ShowEmployees();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            DataTable dt1 = controllerObj.EmplJob();
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "Job";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int AID;
            bool res = int.TryParse(Employeeid.Text, out AID);
            bool res1 = int.TryParse(newsalary.Text, out AID);
            if (res == true && res1 == true)
            {
                if (Int32.Parse(newsalary.Text) < 500) MessageBox.Show("Minimum Salary = 500 "); 
                else {
                DataTable checkValidID = controllerObj.EIDExist(Int32.Parse(Employeeid.Text));
                if (checkValidID != null)
                {
                    controllerObj.updateSalry(Int32.Parse(Employeeid.Text), Int32.Parse(newsalary.Text));
                    Employeeid.Clear();
                    newsalary.Clear();
                }
                else   MessageBox.Show("Invalid Employee ID, please insert another ID. ");
                }
            }
            else MessageBox.Show("Invalid ID or Salary ");
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable d = controllerObj.ShowEmployeesByJob(comboBox1.Text);
            dataGridView1.DataSource = d;
            dataGridView1.Refresh();
        }
    }
}
