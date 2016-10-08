namespace SoftwareEngineeringP1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10716_CreateConnection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Flights");
        }
    }
}
