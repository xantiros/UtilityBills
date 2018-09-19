using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UtilityBills.Models;

namespace UtilityBills
{
    public partial class Form1 : Form
    {
        List<Water> waterList = new List<Water>();

        public Form1()
        {
            InitializeComponent();

            //first 
            DateTime dateTime = new DateTime(2014, 5, 5);
            waterList.Add(new Water(1, 10, dateTime));
            dataGridView1.Rows.Add(waterList[0].Date.ToString("dd/MM/yyyy"), waterList[0].Value, null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double vUsed, vValue, vPriceM3, vPrice;
            //Check if the thextbox is empty
            if (string.IsNullOrEmpty(tbValue.Text) || string.IsNullOrEmpty(tbPriceM3.Text))
                return;
            //Check if the textbox contain only numbers
            if (!double.TryParse(tbValue.Text, out vValue) || !double.TryParse(tbPriceM3.Text, out vPriceM3))
                return;

            var last_value = waterList.Count;
            vUsed = vValue - waterList[last_value-1].Value;

            Water water1 = new Water(10, vValue, dateTimePicker1.Value);
            waterList.Add(water1);

            vPrice = vUsed * vPriceM3;
            lbResult.Text = vUsed.ToString();

            dataGridView1.Rows.Add(dateTimePicker1.Value.ToString("dd/MM/yyyy"), vValue.ToString(), vUsed.ToString(), vPrice);
        }
    }
}
