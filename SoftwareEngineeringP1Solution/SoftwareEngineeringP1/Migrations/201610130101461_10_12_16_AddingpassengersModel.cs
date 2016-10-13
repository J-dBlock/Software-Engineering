namespace SoftwareEngineeringP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10_12_16_AddingpassengersModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.FlightId)
                .Index(t => t.FlightId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Passengers", "FlightId", "dbo.Flights");
            DropIndex("dbo.Passengers", new[] { "FlightId" });
            DropTable("dbo.Passengers");
        }
    }
}
