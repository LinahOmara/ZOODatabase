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
    public partial class AdminMedCare : Form
    {
        Controller controllerObj = new Controller();

        public AdminMedCare()
        {
            InitializeComponent();

            DataTable dt = controllerObj.ShowMedCare();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.ShowSickAnimals();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int AID;
            bool res = int.TryParse(textBox1.Text, out AID);
            if (res == true)
            {
                DataTable checkValidID = controllerObj.AIDExistMC(Int32.Parse(textBox1.Text));
                if (checkValidID != null)
                {
                    string id = textBox1.Text;
                    DataTable dt = controllerObj.ShowMedCarebyID(id);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
                else MessageBox.Show("Invalid Animal ID ,or animal has no medical reports ");
               
            }
            else MessageBox.Show("Invalid Animal ID   ");
        }
    }
}
