using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coop_atm_locator.Models
{
    public class CleanLocationViewModel
    {
        public List<CleanLocationModel> CleanLocationList = new List<CleanLocationModel>();

        public CleanLocationViewModel(List<Locations> data)
        {
            foreach (var item in data)
            {
                CleanLocationList.Add(new CleanLocationModel(item));
            }
        }
    }
}
