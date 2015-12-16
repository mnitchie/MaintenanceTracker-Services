using MaintenanceTracker.Classes;
using MaintenanceTracker.DataModels;

namespace MaintenanceTracker.Repositories
{
	public class MaintenanceTrackerRepo
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