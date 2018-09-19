using System;

namespace UtilityBills.Models
{
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
