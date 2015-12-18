using MaintenanceTracker.DataModels;
using MaintenanceTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceTracker.Repositories
{
	public class MaintenanceTrackerRepository : IMaintenanceTrackerRepository
	{
		public IEnumerable<Car> FindAllCars()
		{
			using (var context = new MaintenanceTrackerContext() )
			{
				return context.Cars.Include( "Make" ).Include( "Model" ).ToList();
			}
		}

		public void CreateCar(Car car)
		{
			using ( var context = new MaintenanceTrackerContext() )
			{
				if ( context.Makes.Find( car.CarMakeNiceName ) != null )
				{
					car.Make = null; // this feels icky. side effects...
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