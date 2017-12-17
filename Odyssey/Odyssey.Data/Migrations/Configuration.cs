namespace Odyssey.Data.Migrations
{
    using Odyssey.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Odyssey.Data.OdysseyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Odyssey.Data.OdysseyContext";
        }

        protected override void Seed(Odyssey.Data.OdysseyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Locations.AddOrUpdate(
                new Location { LocationCode = "99D4fB3DB1563C87", LocationName = "Grand Central Station", LocationType = LocationType.TrainStation },
                new Location { LocationCode = "DA2CDFC0158B37C3", LocationName = "Heathrow Airport", LocationType = LocationType.Airport }
                );

            context.OperatingCompanies.AddOrUpdate(
                new OperatingCompany { OperatingCompanyName = "Airline" },
                new OperatingCompany { OperatingCompanyName = "Shipping Company" },
                new OperatingCompany { OperatingCompanyName = "Train Operating Company" }
                );
        }
    }
}
