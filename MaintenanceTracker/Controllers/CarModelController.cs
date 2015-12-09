using EdmundsApiSDK;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace MaintenanceTracker.Controllers
{
	public class CarModelController : ApiController
	{
		private IEdmunds _edmundsRepository;

		public CarModelController( IEdmunds edmundsRepository )
		{
			this._edmundsRepository = edmundsRepository;
		}

		[HttpGet]
		public async Task<IEnumerable<Model>> GetModels( [FromUri] string make, [FromUri] string year = null )
		{
			return await _edmundsRepository.GetModelsByMake( make, year );
		}
	}
}
