using EdmundsApiSDK;
using MaintenanceTracker.Models;
using MaintenanceTracker.Models.DTO;
using MaintenanceTracker.Repositories;
using System;
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
		public IHttpActionResult GetCars()
		{
			var cars = _maintenanceTrackerRepository.FindAllCars();
			return Ok( cars );
		}

		[HttpGet]
		public IHttpActionResult GetCar([FromUri] long id)
		{

			//var car = new Car {
			//	Year = "1994",

			//};
			////repo.CreateCar( car );
			//return Ok(car);
			throw new NotImplementedException();
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

			car = _maintenanceTrackerRepository.CreateCar( car );
			
			carDto.Id = car.Id;
			return Ok(carDto);
		}
	}
}
