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
                        CarMakeId = c.String(nullable: false, maxLength: 128),
                        CarModelId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarMakes", t => t.CarMakeId, cascadeDelete: true)
                .ForeignKey("dbo.CarModels", t => t.CarModelId, cascadeDelete: true)
                .Index(t => t.CarMakeId)
                .Index(t => t.CarModelId);
            
            CreateTable(
                "dbo.CarMakes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarModelId", "dbo.CarModels");
            DropForeignKey("dbo.Cars", "CarMakeId", "dbo.CarMakes");
            DropIndex("dbo.Cars", new[] { "CarModelId" });
            DropIndex("dbo.Cars", new[] { "CarMakeId" });
            DropTable("dbo.CarModels");
            DropTable("dbo.CarMakes");
            DropTable("dbo.Cars");
        }
    }
}
