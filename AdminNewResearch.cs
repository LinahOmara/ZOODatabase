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
    public partial class AdminNewResearch : Form
    {
        Controller controllerObj = new Controller();
        public AdminNewResearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int aID = Int32.Parse(A_ID.Text);
            int rID = Int32.Parse(R_ID.Text);
            string Rtitle = rtitle.Text;
            string Rtype = type.Text;
            string Rresult = result.Text;

            controllerObj.InserResearch(aID, rID,Rtitle , Rtype , Rresult);
            A_ID.Clear();
            R_ID.Clear();
            type.Clear();
            rtitle.Clear();
            result.Clear();

        }
    }
}
