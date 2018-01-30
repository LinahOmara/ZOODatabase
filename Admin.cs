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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void AdminAnimalsBUt_Click(object sender, EventArgs e)
        {
            AdminAnimals A = new AdminAnimals() ;
            A.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminLostFound F = new AdminLostFound();
            F.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminMedCare M = new AdminMedCare();
            M.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminMedicine M = new AdminMedicine();
            M.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminEmployee E = new AdminEmployee();
            E.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminResearchers R = new AdminResearchers();
            R.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminFeedback F = new AdminFeedback();
            F.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AdminRestCafe a = new AdminRestCafe();
            a.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminShows s = new AdminShows();
            s.Show();
        }



       
    }
}
