using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaintenanceTracker.EdmundsAPI
{
	public interface ICarMakeRepository
	{
		Task<IEnumerable<Make>> GetAllMakes();
	}
}
