using EdmundsApiSDK;
using MaintenanceTracker.Models;
using System.Linq;
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
		public async Task<IHttpActionResult> GetModels( [FromUri] string make, [FromUri] string year = null )
		{
			var edmundsModels = await _edmundsRepository.GetModelsByMake( make, year );
			var models = edmundsModels.Select(em => new CarModel {
				Id = em.NiceName,
				Name = em.Name
			} );

			return Ok( models );
		}
	}
}
