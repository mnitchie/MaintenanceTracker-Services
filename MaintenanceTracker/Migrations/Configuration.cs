namespace MaintenanceTracker.Migrations
{
	using MaintenanceTracker.Models;
	using System;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<MaintenanceTracker.Models.MaintenanceTrackerContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(MaintenanceTracker.Models.MaintenanceTrackerContext context)
		{
			context.Cars.AddOrUpdate( x => x.Id,
				new Car() { Id = Guid.NewGuid(), Year = "2004", Make = Guid.NewGuid(), Model = Guid.NewGuid() },
				new Car() { Id = Guid.NewGuid(), Year = "2005", Make = Guid.NewGuid(), Model = Guid.NewGuid() }
			);

		//	context.Authors.AddOrUpdate( x => x.Id,
		//new Author() { Id = 1, Name = "Jane Austen" },
		//new Author() { Id = 2, Name = "Charles Dickens" },
		//new Author() { Id = 3, Name = "Miguel de Cervantes" }
		//);


			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}
	}
}
