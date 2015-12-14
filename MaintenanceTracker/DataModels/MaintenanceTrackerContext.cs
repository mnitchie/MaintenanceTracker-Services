using MaintenanceTracker.Classes;
using System.Data.Entity;

namespace MaintenanceTracker.DataModels
{
	public class MaintenanceTrackerContext : DbContext
	{
		public DbSet<Car> Cars { get; set; }
	}
}