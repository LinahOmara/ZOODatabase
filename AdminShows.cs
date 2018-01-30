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
    public partial class AdminShows : Form
    {
        Controller controllerObj = new Controller();
        public AdminShows()
        {
            InitializeComponent();
            DataTable dt = controllerObj.ShowShows();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            DataTable dt2 = controllerObj.ShowShows();
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "Title";
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "Title";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.ShowsbyTitle(comboBox1.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int AD;
            bool res = int.TryParse(AID.Text, out AD);
            if (res == true)
            {
                DataTable checkValidID = controllerObj.AIDExist(Int32.Parse(AID.Text));
                if (checkValidID != null)
                {
                    controllerObj.InsertAniShow(Int32.Parse(AID.Text), comboBox2.Text);
                    AID.Clear();
                }

                else MessageBox.Show(" AID Animal ID, please insert another ID. ");
            }
            else MessageBox.Show(" AID Animal ID, please insert another ID. ");
        }
    }
}
