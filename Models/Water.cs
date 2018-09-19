using System;
using System.Xml.Serialization;

namespace UtilityBills.Models
{
    [XmlInclude(typeof(Utility))]
    public class Water : Utility
    {
        public Water()
        {
        }

        public Water(int id, DateTime date, double value, double amount, double price) : base(id, date, value, amount, price)
        {
        }
    }
}
