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
    public partial class AdminAnimals : Form
    {
        Controller controllerObj = new Controller();

        public AdminAnimals()
        {
            InitializeComponent();
          //  Controller controllerObj = new Controller();

            DataTable dt = controllerObj.ShowAnimals();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            DataTable data = controllerObj.animalcol();
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "name";
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable data2 = controllerObj.SearchAnimal(comboBox1.Text);
            comboBox2.DataSource = data2;
            comboBox2.DisplayMember = comboBox1.Text;
        
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string columntxt = comboBox1.Text;
            string searchtxt = comboBox2.Text;

            DataTable SelectedTable = controllerObj.selectedanimalcol(columntxt, searchtxt);
            if (SelectedTable == null) { MessageBox.Show("No data available , try to change your search conditions "); }
            else
            {
                comboBox2.DataSource = SelectedTable;
                comboBox2.DisplayMember = comboBox1.Text;
                dataGridView1.DataSource = SelectedTable;
                dataGridView1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminNewAnimal a = new AdminNewAnimal();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete 


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
