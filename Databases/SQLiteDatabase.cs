using Dapper;
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

        public List<Water> GetWaterList()
        {
            //using (SQLiteConnection)
            //{
                var waters = SQLiteConnection.Query<Water>("select * from water", new DynamicParameters());
                return waters.ToList();
            //}

        }
        public void SaveToDatabase(Water water)
        {
            //using (SQLiteConnection)
            //{
                SQLiteConnection.Execute("insert into water (guid, date, value, amount, unitprice, totalprice) values (@guid, @date, @value, @amount, @unitprice, @totalprice)", water);
            //}

        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
