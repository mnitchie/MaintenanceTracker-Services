using MaintenanceTracker.Models;
using System.Collections.Generic;

namespace MaintenanceTracker.Repositories
{
	public interface IMaintenanceTrackerRepository
	{
		IEnumerable<Car> FindAllCars();
		Car FindById( long id );
		Car CreateCar( Car car );
	}
}
