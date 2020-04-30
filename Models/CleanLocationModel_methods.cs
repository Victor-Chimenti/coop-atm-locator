using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coop_atm_locator.Models
{
    public partial class CleanLocationModel
    {
        public CleanLocationModel(Locations data)
        {
            // assign locations model attributes
            if (data != null)
            {
                if (!string.IsNullOrEmpty(data.ReferenceId))
                {
                    ReferenceId = data.ReferenceId;
                }
                if (!string.IsNullOrEmpty(data.Name))
                {
                    Name = data.Name;
                }
                if (!string.IsNullOrEmpty(data.LocationType))
                {
                    LocationType = LocationTypeEnumHelper.StringToEnum(data.LocationType);
                    LocationTypeCode = LocationType.ToTitle();
                }
                if (!string.IsNullOrEmpty(data.Address))
                {
                    Address = data.Address;
                }
                if (!string.IsNullOrEmpty(data.City))
                {
                    City = data.City;
                }
                if (!string.IsNullOrEmpty(data.PostalCode))
                {
                    PostalCode = data.PostalCode;
                }
                if (!string.IsNullOrEmpty(data.State))
                {
                    State = StateEnumHelper.StringToEnum(data.State);
                    StateTitle = State.ToTitle();
                }
                if (!string.IsNullOrEmpty(data.RetailOutlet))
                {
                    RetailOutlet = data.RetailOutlet;
                }
                if (!string.IsNullOrEmpty(data.Hours))
                {
                    Hours = data.Hours;
                }
                if (!string.IsNullOrEmpty(data.Phone))
                {
                    Phone = data.Phone;
                }



                if (!string.IsNullOrEmpty(data.WebAddress))
                {
                    var protocol = "http";
                    var secureProtocol = "https://";
                    var commercialDomain = ".com";
                    var netDomain = ".net";
                    var nonProfitDomain = ".org";
                    if (data.WebAddress.Contains(commercialDomain) || data.WebAddress.Contains(netDomain) || data.WebAddress.Contains(nonProfitDomain))
                    {
                        if (!data.WebAddress.Contains(protocol))
                        {
                            WebAddress = secureProtocol + data.WebAddress;
                        }
                        else
                        {
                            WebAddress = data.WebAddress;
                        }

                    }
                }





                if (!string.IsNullOrEmpty(data.HandicapAccess))
                {
                    HandicapAccess = BoolEnumHelper.StringToEnum(data.HandicapAccess);
                }
                if (!string.IsNullOrEmpty(data.Surcharge))
                {
                    Surcharge = BoolEnumHelper.StringToEnum(data.Surcharge);
                }
                if (!string.IsNullOrEmpty(data.DriveThruOnly))
                {
                    DriveThruOnly = BoolEnumHelper.StringToEnum(data.DriveThruOnly);
                }
                if (!string.IsNullOrEmpty(data.RestrictedAccess))
                {
                    RestrictedAccess = BoolEnumHelper.StringToEnum(data.RestrictedAccess);
                }
                if (!string.IsNullOrEmpty(data.AcceptDeposit))
                {
                    AcceptDeposit = BoolEnumHelper.StringToEnum(data.AcceptDeposit);
                }
                if (!string.IsNullOrEmpty(data.AcceptCash))
                {
                    AcceptCash = BoolEnumHelper.StringToEnum(data.AcceptCash);
                }
                if (!string.IsNullOrEmpty(data.Cashless))
                {
                    Cashless = BoolEnumHelper.StringToEnum(data.Cashless);
                }
                if (!string.IsNullOrEmpty(data.SelfServiceDevice))
                {
                    SelfServiceOnly = BoolEnumHelper.StringToEnum(data.SelfServiceDevice);
                }
                if (!string.IsNullOrEmpty(data.SelfServiceOnly))
                {
                    SelfServiceOnly = BoolEnumHelper.StringToEnum(data.SelfServiceOnly);
                }
                if (!string.IsNullOrEmpty(data.OnMilitaryBase))
                {
                    OnMilitaryBase = BoolEnumHelper.StringToEnum(data.OnMilitaryBase);
                }
                if (!string.IsNullOrEmpty(data.MilitaryIdRequired))
                {
                    MilitaryIdRequired = BoolEnumHelper.StringToEnum(data.MilitaryIdRequired);
                }
                if (!string.IsNullOrEmpty(data.InstallationType))
                {
                    InstallationType = data.InstallationType;
                }
                if (!string.IsNullOrEmpty(data.AccessNotes))
                {
                    AccessNotes = data.AccessNotes;
                }





                if (!data.Latitude.Equals(null))
                {
                    Latitude = data.Latitude;
                }
                if (!data.Longitude.Equals(null))
                {
                    Longitude = data.Longitude;
                }



                // create a lat lng object for google map
                if ((!Latitude.Equals(null)) && (!Longitude.Equals(null)))
                {
                    Position = new PositionModel(Latitude, Longitude);
                }
            }


            // call builder functions
            SubTitleDisplay = GetSubTitleDisplayStrings();
            ListBlockDisplay = GetListDisplayStrings();
            FooterBlockQuoteDisplay = GetFooterBlockQuoteDisplayStrings();
        }
    }
}
