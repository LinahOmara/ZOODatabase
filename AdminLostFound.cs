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
    public partial class AdminLostFound : Form
    {
        Controller controllerObj = new Controller();
        public AdminLostFound()
        {
            InitializeComponent();
          DataTable d = controllerObj.getSeqNo();
          comboBox1.DataSource = d;
          comboBox1.DisplayMember = "Seq_Num";

          comboBox2.Items.Add("Lost");
          comboBox2.Items.Add("Found");

            DataTable dt = controllerObj.ShowLostandFound();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = controllerObj.ShowLostorFound(comboBox2.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            controllerObj.ConvertToFound(Int32.Parse(comboBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controllerObj.DeleteLostFOund(Int32.Parse(comboBox1.Text));
        }







    }
}
