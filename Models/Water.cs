﻿using MongoDB.Bson;
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
        public Water(DateTime date, double value, double amount, double price) : base(date, value, amount, price)
        {
        }
        public Water(int id, DateTime date, double value, double amount, double price) : base(id, date, value, amount, price)
        {
        }
    }
}
