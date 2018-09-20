using MongoDB.Bson;
using System;

namespace UtilityBills
{
    public class Utility
    {
        //powinno byc private ale serializacja nie działa
        public ObjectId Id { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }

        public Utility()
        {
        }
        public Utility(DateTime date, double value, double amount, double price)
        {
            Date = date;
            Value = value;
            Amount = amount;
            Price = price;
        }
        public Utility(ObjectId id, DateTime date, double value, double amount, double price)
        {
            Id = id;
            Date = date;
            Value = value;
            Amount = amount;
            Price = price;
        }
    }
}
