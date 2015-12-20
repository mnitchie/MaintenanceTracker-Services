namespace MaintenanceTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnameandvintocar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Name", c => c.String());
            AddColumn("dbo.Cars", "Vin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Vin");
            DropColumn("dbo.Cars", "Name");
        }
    }
}
