using System;

namespace UtilityBills.Models
{
    public class Gas : Utility
    {
        public Gas(DateTime date, double value, double amount, double unitprice, double totalprice) 
            : base(date, value, amount, unitprice, totalprice)
        {
        }

        public Gas(int id, DateTime date, double value, double amount, double unitprice, double totalprice) 
            : base(id, date, value, amount, unitprice, totalprice)
        {
        }

        protected Gas()
        {
        }
    }
}
