using EdmundsApiSDK;
using MaintenanceTracker.Models;
using System.Linq;
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
		public async Task<IHttpActionResult> GetMakes([FromUri] string year = null)
		{
			var edmundsMakes = await _edmundsRepository.GetMakes( year );
			var makes = edmundsMakes.Select( em => new CarMake {
				Id = em.NiceName,
				Name = em.Name
			} );

			return Ok( makes );
		}
	}
}
