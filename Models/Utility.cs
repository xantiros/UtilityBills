using System;

namespace UtilityBills
{
    public class Utility
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public Utility()
        {
        }
        public Utility(int id, double value, DateTime date)
        {
            Id = id;
            Value = value;
            Date = date;
        }
    }
}
