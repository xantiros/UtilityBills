using MongoDB.Bson;
using System;

namespace UtilityBills
{
    public class Utility
    {
        //powinno byc private ale serializacja nie działa
        public int Id { get; protected set; } //rokmiesiacdzien
        public DateTime Date { get; protected set; }
        public double Value { get; protected set; }
        public double Amount { get; protected set; }
        public double Price { get; protected set; }

        protected Utility()
        {
        }
        public Utility(DateTime date, double value, double amount, double price)
        {
            Date = date;
            Value = value;
            Amount = amount;
            Price = price;
        }
        public Utility(int id, DateTime date, double value, double amount, double price)
        {
            Id = id;
            Date = date;
            Value = value;
            Amount = amount;
            Price = price;
        }
        //SetID(), SetDate(), SetValue(), SetAmount(), SetPrice()
    }
}
