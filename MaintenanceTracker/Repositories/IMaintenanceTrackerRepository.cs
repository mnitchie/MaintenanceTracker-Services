using MaintenanceTracker.Models;

namespace MaintenanceTracker.Repositories
{
	public interface IMaintenanceTrackerRepository
	{
		void CreateCar( Car car );
	}
}
