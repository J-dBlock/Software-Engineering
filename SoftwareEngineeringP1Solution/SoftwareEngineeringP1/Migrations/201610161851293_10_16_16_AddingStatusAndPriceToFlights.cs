namespace SoftwareEngineeringP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10_16_16_AddingStatusAndPriceToFlights : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Flights", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "Price");
            DropColumn("dbo.Flights", "Status");
        }
    }
}
