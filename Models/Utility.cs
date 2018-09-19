using System;

namespace UtilityBills
{
    public class Utility
    {
        //powinno byc private ale serializacja nie działa
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }

        public Utility()
        {
        }
        public Utility(int id, DateTime date, double value, double amount, double price)
        {
            Id = id;
            Date = date;
            Value = value;
            Amount = amount;
            Price = price;
        }
    }
}
