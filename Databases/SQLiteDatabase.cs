using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using UtilityBills.Interfaces;
using UtilityBills.Models;

namespace UtilityBills.Databases
{
    class SQLiteDatabase : IDatabase
    {
        public void ConnectToDatabase()
        {
            using (IDbConnection con = new SQLiteConnection("Data Source=UtilitiesDB.db"))
            {

            }
        }

        public List<Water> GetWaterList()
        {
            throw new System.NotImplementedException();
        }

        public void SaveToDatabase()
        {
            throw new System.NotImplementedException();
        }

        public void SaveToDatabase(Water water)
        {
            throw new System.NotImplementedException();
        }
    }
}
