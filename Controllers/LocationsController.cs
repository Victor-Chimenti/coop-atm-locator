using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using coop_atm_locator.Models;
using coop_atm_locator.Backend;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace coop_atm_locator.Controllers
{
    public class LocationsController : Controller
    {
        private readonly atmLocator_flatContext _context;
        private LocationsBackend backend;

        public LocationsController(atmLocator_flatContext context, LocationsBackend backend = null)
        {
            _context = context;

            // Fork to allow for mocking out backend
            if (backend != null)
            {
                this.backend = backend;
            }
            else
            {
                this.backend = new LocationsBackend(_context);
            }
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            /*return View(await _context.Locations.ToListAsync());*/

            var cleanResults = await GetCleanViewModel();

            return View(cleanResults);
        }

        [Produces("application/json")]
        public async Task<JsonResult> CardJson()
        {

            var cleanResults = await GetCleanViewModel();

            // get the user's location values in the session cookie
            var Latitude = Request.Cookies["latitude"];
            var Longitude = Request.Cookies["longitude"];

            // if the user blocks cookies then use the tukwila headquarters as default coordinates
            if (string.IsNullOrEmpty(Latitude))
            {
                Latitude = "47.490209";
            }
            if (string.IsNullOrEmpty(Longitude))
            {
                Longitude = "-122.272126";
            }

            // create a new latlng object from the assigned location values
            var point = new PositionModel(Latitude, Longitude);

            // create and object that can pass the user location along with the list of atms to the ajax via json
            var data = new
            {
                point,
                cleanResults.CleanLocationList
            };

            return new JsonResult(data);
        }



        public async Task<CleanLocationViewModel> GetCleanViewModel()
        {
            // get the raw un-parsed values from the locations model
            var dirtyResults = await backend.IndexAsync().ConfigureAwait(false);
            // get the parsed values to eliminate undefined values after processing in the CleanLocationModel
            var cleanResults = new CleanLocationViewModel(dirtyResults);

            // get the user's location values in the session cookie
            var Latitude = Request.Cookies["latitude"];
            var Longitude = Request.Cookies["longitude"];

            // if the user blocks cookies then use the tukwila headquarters as default coordinates
            if (string.IsNullOrEmpty(Latitude))
            {
                Latitude = "47.490209";
            }
            if (string.IsNullOrEmpty(Longitude))
            {
                Longitude = "-122.272126";
            }

            // create a new latlng object from the assigned location values
            var point = new PositionModel(Latitude, Longitude);

            // assign user coordinates from the latlng object
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            Point userPoint = geometryFactory.CreatePoint(new Coordinate(point.Lat, point.Lng));

            // update distance value based on user coordinates and reset geometry factory to null before sending
            foreach (var value in cleanResults.CleanLocationList)
            {
                value.MyPoint = geometryFactory.CreatePoint(new Coordinate(value.Position.Lat, value.Position.Lng));
                value.MyDistance = value.MyPoint.Distance(userPoint);
                value.MyPoint = null;
            }

            // sort the clean results list by distance and reduce by range
            cleanResults.CleanLocationList = cleanResults.CleanLocationList.OrderBy(x => x.MyDistance).ToList().GetRange(0, 512);


            return cleanResults;
        }

        /* // GET: Locations/Details/5
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
         }*/

        private bool LocationsExists(string id)
        {
            return _context.Locations.Any(e => e.Name == id);
        }
    }
}
