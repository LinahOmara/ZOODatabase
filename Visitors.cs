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
    public partial class Visitors : Form
    {
        public Visitors()
        {
            InitializeComponent();
        }

        private void callRestAndCafee_Click(object sender, EventArgs e)
        {
            Restauranrs_and_cafee R = new Restauranrs_and_cafee();
            R.Show();
        }

        private void callAnimal_Click(object sender, EventArgs e)
        {
            VisitorAnimals A = new VisitorAnimals();
            A.Show();
        }

        private void callShows_Click(object sender, EventArgs e)
        {
            VisitorShows S = new VisitorShows();
            S.Show();
        }

        private void callTickets_Click(object sender, EventArgs e)
        {
            VisitorTickets T = new VisitorTickets();
            T.Show();
        }

        private void callFeedback_Click(object sender, EventArgs e)
        {
            VisitorFeedBack F = new VisitorFeedBack();
            F.Show();
        }

        private void callLostOrFound_Click(object sender, EventArgs e)
        {
            Lost_and_Found L = new Lost_and_Found();
            L.Show();
        }

       
    }
}
