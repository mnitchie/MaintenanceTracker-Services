namespace MaintenanceTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Year = c.String(nullable: false),
                        CarMakeNiceName = c.String(nullable: false, maxLength: 128),
                        CarModelNiceName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarMakes", t => t.CarMakeNiceName, cascadeDelete: true)
                .ForeignKey("dbo.CarModels", t => t.CarModelNiceName, cascadeDelete: true)
                .Index(t => t.CarMakeNiceName)
                .Index(t => t.CarModelNiceName);
            
            CreateTable(
                "dbo.CarMakes",
                c => new
                    {
                        NiceName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NiceName);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        NiceName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NiceName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarModelNiceName", "dbo.CarModels");
            DropForeignKey("dbo.Cars", "CarMakeNiceName", "dbo.CarMakes");
            DropIndex("dbo.Cars", new[] { "CarModelNiceName" });
            DropIndex("dbo.Cars", new[] { "CarMakeNiceName" });
            DropTable("dbo.CarModels");
            DropTable("dbo.CarMakes");
            DropTable("dbo.Cars");
        }
    }
}
