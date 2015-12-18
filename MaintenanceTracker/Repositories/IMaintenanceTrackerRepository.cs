using MaintenanceTracker.Models;
using System.Collections.Generic;

namespace MaintenanceTracker.Repositories
{
	public interface IMaintenanceTrackerRepository
	{
		Car CreateCar( Car car );
		IEnumerable<Car> FindAllCars();
	}
}
