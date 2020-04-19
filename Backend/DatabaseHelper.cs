using coop_atm_locator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coop_atm_locator.Backend
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private atmLocator_flatContext context;

        public DatabaseHelper(atmLocator_flatContext context)
        {
            this.context = context;
        }

        public virtual async Task<List<Locations>> ReadMultipleRecordsAsync()
        {
            var result = await context.Locations
                         .AsNoTracking()
                         .ToListAsync()
                         .ConfigureAwait(false);


            return result;
        }
    }
}
