using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilityBills
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double vWynik, vToo, vFrom, vM3;
            //Check if the thextbox is empty
            if (string.IsNullOrEmpty(tbToo.Text) || string.IsNullOrEmpty(tbFrom.Text) || string.IsNullOrEmpty(tbPriceM3.Text))
                return;
            //Check if the textbox contain only numbers
            if (!double.TryParse(tbToo.Text, out vToo) || !double.TryParse(tbFrom.Text, out vFrom) || !double.TryParse(tbPriceM3.Text, out vM3))
                return;

            //double wynik = (double.Parse(tbToo.Text) - double.Parse(tbFrom.Text))
            //    * double.Parse(tbPriceM3.Text);
            vWynik = (vToo - vFrom) * vM3;

            lbResult.Text = vWynik.ToString();

            dataGridView1.Rows.Add(dateTimePicker1.Value.ToString("dd/mm/yyyy"), vWynik.ToString());
        }
    }
}
