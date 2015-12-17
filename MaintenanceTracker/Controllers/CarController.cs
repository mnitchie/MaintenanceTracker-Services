using MaintenanceTracker.Models;
using MaintenanceTracker.Models.DTO;
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
			// Create a full "Car" object from CarDTO
			// Save it to the DB
			// The "Car" now has an ID
			// Convert it to a sideloading car DTO
			// Return it
			return Ok(car);
		}
	}
}
