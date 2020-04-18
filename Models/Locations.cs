using System;
using System.Collections.Generic;

namespace coop_atm_locator.Models
{
    public partial class Locations
    {
        public string ReferenceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WebAddress { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Hours { get; set; }
        public string RetailOutlet { get; set; }
        public string RestrictedAccess { get; set; }
        public string AcceptDeposit { get; set; }
        public string AcceptCash { get; set; }
        public string EnvelopeRequired { get; set; }
        public string OnMilitaryBase { get; set; }
        public string OnPremise { get; set; }
        public string Surcharge { get; set; }
        public string Access { get; set; }
        public string AccessNotes { get; set; }
        public string InstallationType { get; set; }
        public string HandicapAccess { get; set; }
        public string LocationType { get; set; }
        public string HoursMonOpen { get; set; }
        public string HoursMonClose { get; set; }
        public string HoursTueOpen { get; set; }
        public string HoursTueClose { get; set; }
        public string HoursWedOpen { get; set; }
        public string HoursWedClose { get; set; }
        public string HoursThuOpen { get; set; }
        public string HoursThuClose { get; set; }
        public string HoursFriOpen { get; set; }
        public string HoursFriClose { get; set; }
        public string HoursSatOpen { get; set; }
        public string HoursSatClose { get; set; }
        public string HoursSunOpen { get; set; }
        public string HoursSunClose { get; set; }
        public string HoursDtmonOpen { get; set; }
        public string HoursDtmonClose { get; set; }
        public string HoursDttueOpen { get; set; }
        public string HoursDttueClose { get; set; }
        public string HoursDtwedOpen { get; set; }
        public string HoursDtwedClose { get; set; }
        public string HoursDtthuOpen { get; set; }
        public string HoursDtthuClose { get; set; }
        public string HoursDtfriOpen { get; set; }
        public string HoursDtfriClose { get; set; }
        public string HoursDtsatOpen { get; set; }
        public string HoursDtsatClose { get; set; }
        public string HoursDtsunOpen { get; set; }
        public string HoursDtsunClose { get; set; }
        public string Cashless { get; set; }
        public string DriveThruOnly { get; set; }
        public string LimitedTransactions { get; set; }
        public string MilitaryIdRequired { get; set; }
        public string SelfServiceDevice { get; set; }
        public string SelfServiceOnly { get; set; }
    }
}
