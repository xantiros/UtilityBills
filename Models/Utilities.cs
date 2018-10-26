using System.Collections.Generic;

namespace UtilityBills.Models
{
    public class Utilities
    {
        public List<Utility> WaterList { get; protected set; }

        public List<Utility> GasList { get; protected set; }

        public Utilities()
        {
        }
        public Utilities(List<Utility> waterList)
        {
            WaterList = waterList;
        }
        public void SeWaterList(List<Utility> waterList)
        {
            //add some validation? 
            WaterList = waterList;
        }
        public void SetGasList(List<Utility> gasList)
        {
            //add some validation? 
            GasList = gasList;
        }
    }
}
