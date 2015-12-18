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
				if ( context.Makes.Find( car.CarMakeNiceName ) != null )
				{
					car.Make = null;
				}

				if ( context.Models.Find( car.CarModelNiceName ) != null )
				{
					car.Model = null;
				}
				context.Cars.Add( car );
				context.SaveChanges();
			}
		}
	}
}