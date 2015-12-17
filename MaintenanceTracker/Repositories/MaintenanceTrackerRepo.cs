using MaintenanceTracker.Models;
using MaintenanceTracker.DataModels;

namespace MaintenanceTracker.Repositories
{
	public class MaintenanceTrackerRepo
	{
		public void CreateCar(Car car)
		{
			using ( var context = new MaintenanceTrackerContext() )
			{
				var newCar = new Car {
					Year = car.Year,

				};
				//context.Cars.Add( car );
				context.SaveChanges();
			}
		}
	}
}