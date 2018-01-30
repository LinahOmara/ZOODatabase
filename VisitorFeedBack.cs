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
    public partial class VisitorFeedBack : Form
    {

        Controller controllerObj = new Controller();

        public VisitorFeedBack()
        {
            InitializeComponent();       
        }

       
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
           string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
           string feedback = textBox2.Text;
           textBox2.Clear();

           controllerObj.VisitorFeedback(date, feedback);

        }

        
    }
}
