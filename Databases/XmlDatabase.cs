using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UtilityBills.Interfaces;
using UtilityBills.Models;

namespace UtilityBills.Databases
{
    public class XmlDatabase : IDatabase
    {
        public void ConnectToDatabase()
        {
            //tu nie ma sie gdzie polaczyc
        }

        public void SaveToDatabase()
        {
            throw new System.NotImplementedException();
        }
        private void XmlAdd(List<Water> waterList, Water water)
        {
            waterList.Add(water);
            XmlSerializer xs = new XmlSerializer(typeof(List<Water>));
            TextWriter tw = new StreamWriter(@"C:\Users\bklima\source\repos\UtilityBills\water.xml");
            xs.Serialize(tw, waterList);
            tw.Close();
        }

        public List<Water> GetWaterList()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Water>));
            using (var sr = new StreamReader(@"C:\Users\bklima\source\repos\UtilityBills\water.xml"))
            {
               return (List<Water>)xs.Deserialize(sr);
            }

            //foreach (var item in waterList)
            //{
            //    //dataGridView1.Rows.Add(item.Date.ToString("dd/MM/yyyy"), item.Value, item.Amount, item.Price);
            //}

            //first
            //DateTime dateTime = new DateTime(2014, 5, 5);
            //waterList.Add(new Water(1, dateTime, 10, 0, 0));
            //dataGridView1.Rows.Add(waterList[0].Date.ToString("dd/MM/yyyy"), waterList[0].Value, null, null);
        }

        public void SaveToDatabase(Water water)
        {
            throw new System.NotImplementedException();
        }
    }
}
