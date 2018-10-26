using System.Collections.Generic;
using UtilityBills.Models;

namespace UtilityBills.Interfaces
{
    public interface IDatabase
    {
        void ConnectToDatabase();
        List<Utility> GetUtilities(string utility);
        void SaveToDatabase(Utility utility);
    }
}
