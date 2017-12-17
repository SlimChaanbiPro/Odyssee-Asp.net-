namespace Odyssey.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        DateBecameCustomer = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Journeys",
                c => new
                    {
                        JourneyId = c.Int(nullable: false, identity: true),
                        OriginLocationCode = c.String(nullable: false, maxLength: 128),
                        DestinationLocationCode = c.String(nullable: false, maxLength: 128),
                        OperatingCompanyId = c.Int(nullable: false),
                        StartDateAndTime = c.DateTime(nullable: false),
                        EndDateAndTime = c.DateTime(nullable: false),
                        OtherDetails = c.String(),
                        FlightNumber = c.String(),
                        NameOfTheBoat = c.String(),
                        PortOfRegistration = c.String(),
                        JourneyType = c.Int(),
                    })
                .PrimaryKey(t => t.JourneyId)
                .ForeignKey("dbo.Locations", t => t.DestinationLocationCode)
                .ForeignKey("dbo.OperatingCompanies", t => t.OperatingCompanyId)
                .ForeignKey("dbo.Locations", t => t.OriginLocationCode)
                .Index(t => t.OriginLocationCode)
                .Index(t => t.DestinationLocationCode)
                .Index(t => t.OperatingCompanyId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationCode = c.String(nullable: false, maxLength: 128),
                        LocationName = c.String(),
                        LocationType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationCode);
            
            CreateTable(
                "dbo.OperatingCompanies",
                c => new
                    {
                        OperatingCompanyId = c.Int(nullable: false, identity: true),
                        OperatingCompanyName = c.String(),
                        OperatingCompanyDetails = c.String(),
                    })
                .PrimaryKey(t => t.OperatingCompanyId);
            
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        Cutomer = c.Int(nullable: false),
                        Journey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cutomer, t.Journey })
                .ForeignKey("dbo.Journeys", t => t.Cutomer, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Journey, cascadeDelete: true)
                .Index(t => t.Cutomer)
                .Index(t => t.Journey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Journeys", "OriginLocationCode", "dbo.Locations");
            DropForeignKey("dbo.Journeys", "OperatingCompanyId", "dbo.OperatingCompanies");
            DropForeignKey("dbo.Journeys", "DestinationLocationCode", "dbo.Locations");
            DropForeignKey("dbo.Travels", "Journey", "dbo.Customers");
            DropForeignKey("dbo.Travels", "Cutomer", "dbo.Journeys");
            DropIndex("dbo.Travels", new[] { "Journey" });
            DropIndex("dbo.Travels", new[] { "Cutomer" });
            DropIndex("dbo.Journeys", new[] { "OperatingCompanyId" });
            DropIndex("dbo.Journeys", new[] { "DestinationLocationCode" });
            DropIndex("dbo.Journeys", new[] { "OriginLocationCode" });
            DropTable("dbo.Travels");
            DropTable("dbo.OperatingCompanies");
            DropTable("dbo.Locations");
            DropTable("dbo.Journeys");
            DropTable("dbo.Customers");
        }
    }
}
