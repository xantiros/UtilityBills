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

        public Water(int id, double value, DateTime date) : base(id, value, date)
        {
        }
    }
}
