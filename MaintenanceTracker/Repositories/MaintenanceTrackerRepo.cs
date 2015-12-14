using MaintenanceTracker.Classes;
using MaintenanceTracker.DataModels;

namespace MaintenanceTracker.Repositories
{
	public class MaintenanceTrackerRepo
	{
		public Car CreateCar(Car car)
		{
			using ( var context = new MaintenanceTrackerContext() )
			{
				context.Cars.Add( car );
				context.SaveChanges();

				return car; // needed? The reference was passed, so adding the ID was a side effect... :-(
			}
		}
	}
}