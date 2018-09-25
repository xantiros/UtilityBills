using System.Collections.Generic;

namespace UtilityBills.Models
{
    public class Utilities
    {
        public List<Water> WaterList { get; protected set; }

        public Utilities()
        {
        }
        public  Utilities(List<Water> waterlist)
        {
            WaterList = waterlist;
        }
        public void SetWaterList(List<Water> waterlist)
        {
            //add some validation? 
            WaterList = waterlist;
        }
    }
}
