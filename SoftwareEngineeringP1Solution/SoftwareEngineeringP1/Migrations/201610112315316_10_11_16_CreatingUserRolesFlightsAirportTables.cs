namespace SoftwareEngineeringP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10_11_16_CreatingUserRolesFlightsAirportTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Altitude = c.Double(nullable: false),
                        TimezoneOffset = c.Double(nullable: false),
                        DST = c.String(),
                        Timezone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartureTime = c.DateTime(nullable: false),
                        ArrivalTime = c.DateTime(nullable: false),
                        SourceAirportId = c.Int(nullable: false),
                        DestinationAirportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airports", t => t.DestinationAirportId)
                .ForeignKey("dbo.Airports", t => t.SourceAirportId)
                .Index(t => t.SourceAirportId)
                .Index(t => t.DestinationAirportId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Salt = c.String(),
                        Hash = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Flights", "SourceAirportId", "dbo.Airports");
            DropForeignKey("dbo.Flights", "DestinationAirportId", "dbo.Airports");
            DropIndex("dbo.Roles", new[] { "User_Id" });
            DropIndex("dbo.Flights", new[] { "DestinationAirportId" });
            DropIndex("dbo.Flights", new[] { "SourceAirportId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Flights");
            DropTable("dbo.Airports");
        }
    }
}
