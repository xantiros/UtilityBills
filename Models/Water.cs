using MongoDB.Bson;
using System;
using System.Xml.Serialization;

namespace UtilityBills.Models
{
    [XmlInclude(typeof(Utility))]
    public class Water : Utility
    {
        protected Water()
        {
        }
        public Water(DateTime date, double value, double amount, double unitprice, double totalprice) 
            : base(date, value, amount, unitprice, totalprice)
        {
        }
        public Water(int id, DateTime date, double value, double amount, double unitprice, double totalprice) 
            : base(id, date, value, amount, unitprice, totalprice)
        {
        }
    }
}
