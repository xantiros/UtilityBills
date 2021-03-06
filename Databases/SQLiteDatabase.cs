﻿using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using UtilityBills.Interfaces;
using UtilityBills.Models;

namespace UtilityBills.Databases
{
    class SQLiteDatabase : IDatabase
    {
        public IDbConnection SQLiteConnection { get; private set; }

        public void ConnectToDatabase()
        {
            //using (IDbConnection con = new SQLiteConnection("Data Source=UtilitiesDB.db"))
            //{
            //}
            SQLiteConnection = new SQLiteConnection(LoadConnectionString());
            //SQLiteConnection.Open();
        }
        public List<Utility> GetUtilities(string utility)
        {
            var Utility = SQLiteConnection.Query<Utility>($"select * from {utility}", new DynamicParameters());
            return Utility.ToList();
        }
        public void SaveToDatabase(Utility utility)
        {
            SQLiteConnection.Execute($"insert into {utility.GetType().Name} (date, value, amount, unitprice, totalprice) values (@date, @value, @amount, @unitprice, @totalprice)", utility);
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
