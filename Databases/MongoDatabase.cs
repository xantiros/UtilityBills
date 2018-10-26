using MongoDB.Driver;
using System.Collections.Generic;
using UtilityBills.Interfaces;
using UtilityBills.Models;
using System.Linq;

namespace UtilityBills.Databases
{
    public class MongoDatabase : IDatabase
    {
        public IMongoDatabase Db { get; private set; }

        public MongoClient Client { get; private set; }

        public IMongoCollection<Water> Collection { get; private set; }

        public void ConnectToDatabase()
        {
            Client = new MongoClient();
            Db = Client.GetDatabase("UtilitiesDB");
        }
        public List<Water> GetWaterList()
        {
            //var collection = db.GetCollection<Water>("Water");
            //var coll = db.GetCollection<Water>("Water").AsQueryable();
            //var resultDoc = collection.Find(new BsonDocument()).ToList();
            //return Db.GetCollection<Water>("Water").AsQueryable().ToList();

            Collection = Db.GetCollection<Water>("Water");

            return Collection.AsQueryable()
                .Select(x => new Water(x.Date, x.Value, x.Amount, x.UnitPrice, x.TotalPrice)).ToList();

            //Id = x.Id, //pobiera _id i wywala błąd trzebaby było zmienić nazwe z Id na np Idd...

            //foreach (var item in waterList)
            //{
            //    dataGridView1.Rows.Add(item.Date.ToString("dd/MM/yyyy"), item.Value, item.Amount, item.Price);
            //}
        }

        public void SaveToDatabase(Water water)
        {
            //var client = new MongoClient();
            //var db = Client.GetDatabase("UtilitiesDB");
            //var collection = Db.GetCollection<Water>("Water");
            Collection.InsertOne(water);
        }
    }
}
