using MaintenanceTracker.Models;
using System.Collections.Generic;

namespace MaintenanceTracker.Repositories
{
	public interface IMaintenanceTrackerRepository
	{
		void CreateCar( Car car );
		IEnumerable<Car> FindAllCars();
	}
}
