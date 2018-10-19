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
        double vUsed, vPrice, vValue, vPriceM3;

        public IDatabase db = GetDatabas();

        public Form1()
        {
            InitializeComponent();

            db.ConnectToDatabase();

            Uti.SetWaterList(db.GetWaterList()); // Uti.WaterList = db.GetWaterList();

            //show list
            foreach (var item in Uti.WaterList)
            {
                dataGridView1.Rows.Add(item.Date.ToString("dd/MM/yyyy"), item.Value, item.Amount, item.Price);
            }

        }

        private static IDatabase GetDatabas()
        {
            return new SQLiteDatabase();
            //return new MongoDatabase();
            //return new XmlDatabase(); //xml nie serializuje prywatnych i protested pól
            //sterowanie - wybór bazy 
            //if (/*some way to tell if should use MySql*/)
            //    return new MySQLDatabase();
        }

        private void CalculateWater()
        {
            var last_value = Uti.WaterList.Count;
            vUsed = vValue - Uti.WaterList[last_value - 1].Value;

            vPrice = vUsed * vPriceM3;
            lbResult.Text = vUsed.ToString();

            var water = new Water(Convert.ToInt32($"{dateTimePicker1.Value.Year}{dateTimePicker1.Value.Month}{dateTimePicker1.Value.Day}"), 
                dateTimePicker1.Value, vValue, vUsed, vPrice);
            Uti.WaterList.Add(water);

            db.SaveToDatabase(water);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            
            //Check if the thextbox is empty
            if (string.IsNullOrEmpty(tbValue.Text) || string.IsNullOrEmpty(tbPriceM3.Text))
                return;
            //Check if the textbox contain only numbers
            if (!double.TryParse(tbValue.Text, out vValue) || !double.TryParse(tbPriceM3.Text, out vPriceM3))
                return;

            CalculateWater();

            //show
            dataGridView1.Rows.Add(dateTimePicker1.Value.ToString("dd/MM/yyyy"), vValue.ToString(), vUsed.ToString(), vPrice);
        }
    }
}
