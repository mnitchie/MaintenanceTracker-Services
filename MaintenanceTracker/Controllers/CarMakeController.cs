using EdmundsApiSDK;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MaintenanceTracker.Controllers
{
	public class CarMakeController : ApiController
	{

		private IEdmunds _edmundsRepository;

		public CarMakeController(IEdmunds edmundsRepository)
		{
			this._edmundsRepository = edmundsRepository;
		}

		[HttpGet]
		public async Task<IEnumerable<Make>> GetMakes()
		{
			return await _edmundsRepository.GetMakes();
		}
	}
}
