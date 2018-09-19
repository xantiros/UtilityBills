using System;

namespace UtilityBills
{
    public class Utility
    {
        public int Id { get; private set; }
        public double Value { get; private set; }
        public DateTime Date { get; private set; }

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
