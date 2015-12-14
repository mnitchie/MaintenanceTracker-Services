using MaintenanceTracker.Classes;
using System;
using System.Web.Http;
namespace MaintenanceTracker.Controllers
{
	public class CarController : ApiController
	{
		[HttpGet]
		public IHttpActionResult GetCar([FromUri] Guid id)
		{
			return Ok(new Car {
				Id = Guid.NewGuid(),
				Year = "1994"
			});
		}

		[HttpPost]
		public IHttpActionResult CreateCar(Car car)
		{
			return Ok(car);
		}
	}
}
