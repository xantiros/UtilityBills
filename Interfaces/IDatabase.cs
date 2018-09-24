using System.Collections.Generic;
using UtilityBills.Models;

namespace UtilityBills.Interfaces
{
    public interface IDatabase
    {
        void ConnectToDatabase();
        List<Water> GetWaterList();
        void SaveToDatabase();
    }
}
