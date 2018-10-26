using MongoDB.Bson;
using System;

namespace UtilityBills
{
    public class Utility
    {
        //powinno byc private ale serializacja nie działa
        public int Id { get; protected set; } //rokmiesiacdzien ewentualnie Guid
        public Guid Guid { get; protected set; }
        public DateTime Date { get; protected set; }
        public double Value { get; protected set; }
        public double Amount { get; protected set; }
        public double UnitPrice { get; protected set; }
        public double TotalPrice { get; protected set; }

        protected Utility()
        {
        }
        public Utility(DateTime date, double value, double amount, double unitprice, double totalprice)
        {
            Guid = Guid.NewGuid();
            Date = date;
            Value = value;
            Amount = amount;
            UnitPrice = unitprice;
            TotalPrice = totalprice;
        }
        public Utility(int id, DateTime date, double value, double amount, double unitprice, double totalprice)
        {
            Id = id;
            Guid = Guid.NewGuid();
            Date = date;
            Value = value;
            Amount = amount;
            UnitPrice = unitprice;
            TotalPrice = totalprice;
        }
        //SetID(), SetDate(), SetValue(), SetAmount(), SetPrice()
    }
}
