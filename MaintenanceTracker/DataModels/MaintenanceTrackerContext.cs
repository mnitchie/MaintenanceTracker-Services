using MaintenanceTracker.Models;
using System.Data.Entity;

namespace MaintenanceTracker.DataModels
{
	public class MaintenanceTrackerContext : DbContext
	{
		public DbSet<Car> Cars { get; set; }
		public DbSet<CarMake> Makes { get; set; }
		public DbSet<CarModel> Models { get; set; }
	}
}