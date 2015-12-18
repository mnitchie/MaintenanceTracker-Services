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

		public Car FindById(long id)
		{
			using (var context = new MaintenanceTrackerContext())
			{
				return context.Cars.Include("Make").Include("Model").SingleOrDefault(c => c.Id == id);
			}
		}

		public Car CreateCar(Car car)
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
				return car;
			}
		}
	}
}