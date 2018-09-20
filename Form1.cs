using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using UtilityBills.Models;
using MongoDB.Driver.Linq;
using System.Linq;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace UtilityBills
{
    public partial class Form1 : Form
    {
        List<Water> waterList = new List<Water>();

        public Form1()
        {
            InitializeComponent();

            //XmlConnect();

            MongoDBConnect();

        }

        private void MongoDBConnect()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("UtilitiesDB");

            //var collection = db.GetCollection<Water>("Water");
            //var coll = db.GetCollection<Water>("Water").AsQueryable();
            //var resultDoc = collection.Find(new BsonDocument()).ToList();
            waterList = db.GetCollection<Water>("Water").AsQueryable().ToList();
 
            foreach (var item in waterList)
            {
                dataGridView1.Rows.Add(item.Id, item.Date.ToString("dd/MM/yyyy"), item.Value, null);
            }

        }

        private void XmlConnect()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Water>));
            using (var sr = new StreamReader(@"C:\Users\bklima\source\repos\UtilityBills\water.xml"))
            {
                waterList = (List<Water>)xs.Deserialize(sr);
            }
            foreach (var item in waterList)
            {
                dataGridView1.Rows.Add(item.Id, item.Date.ToString("dd/MM/yyyy"), item.Value, null);
            }

            //first
            //DateTime dateTime = new DateTime(2014, 5, 5);
            //waterList.Add(new Water(1, dateTime, 10, 0, 0));
            //dataGridView1.Rows.Add(waterList[0].Date.ToString("dd/MM/yyyy"), waterList[0].Value, null, null);
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

            vPrice = vUsed * vPriceM3;
            lbResult.Text = vUsed.ToString();

            dataGridView1.Rows.Add(dateTimePicker1.Value.ToString("dd/MM/yyyy"), vValue.ToString(), vUsed.ToString(), vPrice);

            //Water water1 = new Water("5ba389e6d42a63cd58fdaf06", dateTimePicker1.Value, vValue, vUsed, vPrice);
           // waterList.Add(water1);

            XmlSerializer xs = new XmlSerializer(typeof(List<Water>));
            TextWriter tw = new StreamWriter(@"C:\Users\bklima\source\repos\UtilityBills\water.xml");
            xs.Serialize(tw, waterList);
            tw.Close();
        }
    }
}
