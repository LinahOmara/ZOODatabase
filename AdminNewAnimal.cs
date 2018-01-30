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
    public partial class AdminNewAnimal : Form
    {
        Controller controllerObj = new Controller();
        public AdminNewAnimal()
        {
            InitializeComponent();
            DataTable Trainerdt = controllerObj.getT_ID();
            comboBox1.DataSource = Trainerdt;
            comboBox1.DisplayMember = "T_ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int AD;
            bool res = int.TryParse(AID.Text, out AD);
            if (Int32.Parse(visitFrom.Text) >= 9 && Int32.Parse(visitFrom.Text) <= 17 && Int32.Parse(VisitTo.Text) <= 18 && Int32.Parse(VisitTo.Text) >= 9)
            {
                if (res == true)
                {
                    DataTable checkValidID = controllerObj.AIDExist(Int32.Parse(AID.Text));
                    if (checkValidID == null)
                    {
                        string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                        controllerObj.InsertAnimal(name.Text, date, Int32.Parse(AID.Text), GKind.Text, spkind.Text, Int32.Parse(visitFrom.Text), Int32.Parse(VisitTo.Text), Int32.Parse(comboBox1.Text), Ftype.Text, Int32.Parse(Ftime.Text), Int32.Parse(FAmount.Text));

                    }

                    else MessageBox.Show(" Animal ID already used , please insert another ID. ");


                }
                else MessageBox.Show("Invalid Animal ID, please insert another ID. ");
            }
            else MessageBox.Show("Max visiting time from 9 to 18");
        }
    }
}
