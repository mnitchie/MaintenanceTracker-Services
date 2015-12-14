using System.Web.Http;
namespace MaintenanceTracker.Controllers
{
	public class CarController : ApiController
	{
		[HttpPost]
		public IHttpActionResult CreateCar(Car car)
		{
			return Ok(car);
		}
	}
}
