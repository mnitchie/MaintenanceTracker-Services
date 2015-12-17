using EdmundsApiSDK;
using MaintenanceTracker.Models;
using MaintenanceTracker.Models.DTO;
using MaintenanceTracker.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace MaintenanceTracker.Controllers
{
	public class CarController : ApiController
	{
		private IEdmunds _edmundsRepository;
		private IMaintenanceTrackerRepository _maintenanceTrackerRepository;

		public CarController(IEdmunds edmundsRepository, IMaintenanceTrackerRepository maintenanceTrackerRepository)
		{
			_edmundsRepository = edmundsRepository;
			_maintenanceTrackerRepository = maintenanceTrackerRepository;
		}

		[HttpGet]
		public IHttpActionResult GetCar([FromUri] long id)
		{

			var car = new Car {
				Year = "1994",
				
			};
			//repo.CreateCar( car );
			return Ok(car);
		}

		[HttpPost]
		public async Task<IHttpActionResult> CreateCar(CarDTO carDto)
		{
			var edmundsMake = await _edmundsRepository.GetMakeByNiceName( carDto.Make );
			var edmundsModel = edmundsMake.models.Single( m => m.NiceName == carDto.Model );

			Car car = new Car {
				Year = carDto.Year,
				CarMakeNiceName = carDto.Make,
				Make = new CarMake {
					NiceName = edmundsMake.NiceName,
					Name = edmundsMake.Name
				},
				CarModelNiceName = carDto.Model,
				Model = new CarModel {
					NiceName = edmundsModel.NiceName,
					Name = edmundsModel.Name
				}
			};

			_maintenanceTrackerRepository.CreateCar( car );

			//Car car = new Car {
			//	Year = car
			//}
			// Create a full "Car" object from CarDTO
			// Save it to the DB
			// The "Car" now has an ID
			// Convert it to a sideloading car DTO
			// Return it

			carDto.Id = car.Id;
			return Ok(carDto);
		}
	}
}
