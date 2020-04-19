﻿using coop_atm_locator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coop_atm_locator.Backend
{
    public interface IDatabaseHelper
    {
        public Task<List<Locations>> ReadMultipleRecordsAsync();
    }
}
