using MaintenanceTracker.EdmundsAPI;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MaintenanceTracker.Controllers
{
	public class CarMakeController : ApiController
	{

		private ICarMakeRepository _carMakeRepository;

		public CarMakeController(ICarMakeRepository carMakeRepository)
		{
			this._carMakeRepository = carMakeRepository;
		}

		[HttpGet]
		public async Task<IEnumerable<Make>> GetMakes()
		{
			return await _carMakeRepository.GetAllMakes();
		}
	}
}
