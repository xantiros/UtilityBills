using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using UtilityBills.Models;
using System.Linq;
using UtilityBills.Interfaces;
using UtilityBills.Databases;

namespace UtilityBills
{
    public partial class Form1 : Form
    {
        Utilities Uti = new Utilities();
        
        //List<Water> waterList = new List<Water>();

        public IDatabase db = GetDatabas();

        public Form1()
        {
            InitializeComponent();

            db.ConnectToDatabase();

            //db.GetWaterList(Uti.WaterList);
            Uti.WaterList = db.GetWaterList();
            //XmlConnect();

            //MongoDBConnect();

            foreach (var item in Uti.WaterList)
            {
                dataGridView1.Rows.Add(item.Date.ToString("dd/MM/yyyy"), item.Value, item.Amount, item.Price);
            }

        }

        private static IDatabase GetDatabas()
        {
            return new MongoDatabase();
        }

        private void CalculateWater()
        {

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

            var last_value = Uti.WaterList.Count;
            vUsed = vValue - Uti.WaterList[last_value-1].Value;

            vPrice = vUsed * vPriceM3;
            lbResult.Text = vUsed.ToString();

            dataGridView1.Rows.Add(dateTimePicker1.Value.ToString("dd/MM/yyyy"), vValue.ToString(), vUsed.ToString(), vPrice);

            Water water1 = new Water(dateTimePicker1.Value, vValue, vUsed, vPrice);
            //XmlAdd(water1);
            //MongoAdd(water1);

            foreach (var item in Uti.WaterList)
            {
                dataGridView1.Rows.Add(item.Date.ToString("dd/MM/yyyy"), item.Value, item.Amount, item.Price);
            }
        }
    }
}
