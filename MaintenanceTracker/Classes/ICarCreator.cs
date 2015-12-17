using MaintenanceTracker.Models;
using MaintenanceTracker.Models.DTO;

namespace MaintenanceTracker.Classes
{
	interface ICarCreator
	{
		Car CreateCar( CarDTO carDto );
	}
}
