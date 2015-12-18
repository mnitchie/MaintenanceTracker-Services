using EdmundsApiSDK;
using MaintenanceTracker.Classes.Converters;
using MaintenanceTracker.Models;
using MaintenanceTracker.Models.DTO;
using MaintenanceTracker.Repositories;
using System.Web.Http;

namespace MaintenanceTracker.Controllers
{
	public class CarController : ApiController
	{
		private IEdmunds _edmundsRepository;
		private IMaintenanceTrackerRepository _maintenanceTrackerRepository;
		private CarConverter _carConverter;

		public CarController(IEdmunds edmundsRepository, IMaintenanceTrackerRepository maintenanceTrackerRepository)
		{
			_edmundsRepository = edmundsRepository;
			_maintenanceTrackerRepository = maintenanceTrackerRepository;
			_carConverter = new CarConverter();
		}

		[HttpGet]
		public IHttpActionResult GetCars()
		{
			var cars = _maintenanceTrackerRepository.FindAllCars();
			return Ok( _carConverter.Convert( cars ) );
		}

		[HttpGet]
		public IHttpActionResult GetCar([FromUri] long id)
		{
			var car = _maintenanceTrackerRepository.FindById( id );

			if (car == null)
			{
				return NotFound();
			}

			return Ok( _carConverter.Convert( car ) );
		}

		[HttpPost]
		public IHttpActionResult CreateCar(CarDTO carDto)
		{
			
			Car car = new Car {
				Year = carDto.Year,
				CarMakeId = carDto.Make.Id,
				Make = new CarMake {
					Id = carDto.Make.Id,
					Name = carDto.Make.Name
				},
				CarModelId = carDto.Model.Id,
				Model = new CarModel {
					Id = carDto.Model.Id,
					Name = carDto.Model.Name
				}
			};

			car = _maintenanceTrackerRepository.CreateCar( car );
			
			carDto.Id = car.Id;
			
			return Ok(carDto);
		}
	}
}
