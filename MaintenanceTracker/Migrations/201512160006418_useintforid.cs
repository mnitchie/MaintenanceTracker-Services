namespace MaintenanceTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useintforid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cars");
            AlterColumn("dbo.Cars", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cars", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Cars");
            AlterColumn("dbo.Cars", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Cars", "Id");
        }
    }
}
