using coop_atm_locator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coop_atm_locator.Controllers;

namespace coop_atm_locator.Backend
{
    public class LocationsBackend
    {
        private DatabaseHelper db;
        //private int TakeSize;
        //private int TakeIndex;
        //private PositionModel point;

        public LocationsBackend(atmLocator_flatContext context)
        {
            db = new DatabaseHelper(context);
        }

        public virtual async Task<List<Locations>> IndexAsync()
        {

            var locations_list = await db.ReadMultipleRecordsAsync().ConfigureAwait(false); // Select * join all tables

            return locations_list;
        }
    }
}
