using System.Collections.Generic;

namespace UtilityBills.Models
{
    public class Utilities
    {
        public List<Utility> UtilityList { get; protected set; }

        public Utilities()
        {
        }
        public Utilities(List<Utility> utilityList)
        {
            UtilityList = utilityList;
        }
        public void SetUtilityList(List<Utility> utilityList)
        {
            //add some validation? 
            UtilityList = utilityList;
        }
    }
}
