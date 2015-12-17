using MaintenanceTracker.Classes;
using MaintenanceTracker.Classes.DTO;
using MaintenanceTracker.Repositories;
using System.Web.Http;
namespace MaintenanceTracker.Controllers
{
	public class CarController : ApiController
	{
		[HttpGet]
		public IHttpActionResult GetCar([FromUri] long id)
		{
			var repo = new MaintenanceTrackerRepo();

			var car = new Car {
				Year = "1994",
				
			};
			repo.CreateCar( car );
			return Ok(car);
		}

		[HttpPost]
		public IHttpActionResult CreateCar(CarDTO car)
		{
			return Ok(car);
		}
	}
}
