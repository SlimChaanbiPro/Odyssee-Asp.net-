using Odyssey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Data
{
    public class OdysseyContextInitializer : DropCreateDatabaseIfModelChanges<OdysseyContext>
    {
        protected override void Seed(OdysseyContext context)
        {

            var locations = new List<Location>
            {
                new Location{LocationCode="99D4fB3DB1563C87",LocationName="Grand Central Station",LocationType=LocationType.TrainStation},
                new Location{LocationCode="DA2CDFC0158B37C3",LocationName="Heathrow Airport",LocationType=LocationType.Airport},
            };

            var operatingCompanies = new List<OperatingCompany> 
            { 
                new OperatingCompany{ OperatingCompanyName="Airline"},
                new OperatingCompany{ OperatingCompanyName="Shipping Company"},
                new OperatingCompany{ OperatingCompanyName="Train Operating Company"},
            };

            context.Locations.AddRange(locations);
            context.OperatingCompanies.AddRange(operatingCompanies);
            context.SaveChanges();
        }
    }
}
