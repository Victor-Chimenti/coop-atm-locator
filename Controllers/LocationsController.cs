﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using coop_atm_locator.Models;



namespace coop_atm_locator.Controllers
{
    public class LocationsController : Controller
    {
        private readonly atmLocator_flatContext _context;

        public LocationsController(atmLocator_flatContext context)
        {
            _context = context;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locations.ToListAsync());
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.Name == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReferenceId,Name,Address,City,County,State,PostalCode,Country,Phone,Fax,WebAddress,Latitude,Longitude,Hours,RetailOutlet,RestrictedAccess,AcceptDeposit,AcceptCash,EnvelopeRequired,OnMilitaryBase,OnPremise,Surcharge,Access,AccessNotes,InstallationType,HandicapAccess,LocationType,HoursMonOpen,HoursMonClose,HoursTueOpen,HoursTueClose,HoursWedOpen,HoursWedClose,HoursThuOpen,HoursThuClose,HoursFriOpen,HoursFriClose,HoursSatOpen,HoursSatClose,HoursSunOpen,HoursSunClose,HoursDtmonOpen,HoursDtmonClose,HoursDttueOpen,HoursDttueClose,HoursDtwedOpen,HoursDtwedClose,HoursDtthuOpen,HoursDtthuClose,HoursDtfriOpen,HoursDtfriClose,HoursDtsatOpen,HoursDtsatClose,HoursDtsunOpen,HoursDtsunClose,Cashless,DriveThruOnly,LimitedTransactions,MilitaryIdRequired,SelfServiceDevice,SelfServiceOnly")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations.FindAsync(id);
            if (locations == null)
            {
                return NotFound();
            }
            return View(locations);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ReferenceId,Name,Address,City,County,State,PostalCode,Country,Phone,Fax,WebAddress,Latitude,Longitude,Hours,RetailOutlet,RestrictedAccess,AcceptDeposit,AcceptCash,EnvelopeRequired,OnMilitaryBase,OnPremise,Surcharge,Access,AccessNotes,InstallationType,HandicapAccess,LocationType,HoursMonOpen,HoursMonClose,HoursTueOpen,HoursTueClose,HoursWedOpen,HoursWedClose,HoursThuOpen,HoursThuClose,HoursFriOpen,HoursFriClose,HoursSatOpen,HoursSatClose,HoursSunOpen,HoursSunClose,HoursDtmonOpen,HoursDtmonClose,HoursDttueOpen,HoursDttueClose,HoursDtwedOpen,HoursDtwedClose,HoursDtthuOpen,HoursDtthuClose,HoursDtfriOpen,HoursDtfriClose,HoursDtsatOpen,HoursDtsatClose,HoursDtsunOpen,HoursDtsunClose,Cashless,DriveThruOnly,LimitedTransactions,MilitaryIdRequired,SelfServiceDevice,SelfServiceOnly")] Locations locations)
        {
            if (id != locations.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationsExists(locations.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locations = await _context.Locations
                .FirstOrDefaultAsync(m => m.Name == id);
            if (locations == null)
            {
                return NotFound();
            }

            return View(locations);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var locations = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(locations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationsExists(string id)
        {
            return _context.Locations.Any(e => e.Name == id);
        }
    }
}
