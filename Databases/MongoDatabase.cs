using MongoDB.Driver;
using System;
using System.Collections.Generic;
using UtilityBills.Interfaces;
using UtilityBills.Models;

namespace UtilityBills.Databases
{
    public class MongoDatabase : IDatabase
    {
        public IMongoDatabase Db { get; private set; }

        public void ConnectToDatabase()
        {
            var client = new MongoClient();
            Db = client.GetDatabase("UtilitiesDB");
        }
        public List<Water> GetWaterList()
        {
            //var collection = db.GetCollection<Water>("Water");
            //var coll = db.GetCollection<Water>("Water").AsQueryable();
            //var resultDoc = collection.Find(new BsonDocument()).ToList();
            return Db.GetCollection<Water>("Water").AsQueryable().ToList();

            //foreach (var item in waterList)
            //{
            //    dataGridView1.Rows.Add(item.Date.ToString("dd/MM/yyyy"), item.Value, item.Amount, item.Price);
            //}
        }

        public void SaveToDatabase()
        {
            throw new NotImplementedException();
        }
        private void MongoAdd(Water water)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("UtilitiesDB");
            var collection = db.GetCollection<Water>("Water");
            collection.InsertOne(water);
        }
    }
}
