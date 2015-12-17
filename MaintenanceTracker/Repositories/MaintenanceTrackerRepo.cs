using MaintenanceTracker.DataModels;
using MaintenanceTracker.Models;

namespace MaintenanceTracker.Repositories
{
	public class MaintenanceTrackerRepository : IMaintenanceTrackerRepository
	{
		public void CreateCar(Car car)
		{
			using ( var context = new MaintenanceTrackerContext() )
			{
				context.Cars.Add( car );
				context.SaveChanges();
			}
		}
	}
}