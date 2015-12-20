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
			Car car = _carConverter.Convert( carDto );

			car = _maintenanceTrackerRepository.CreateCar( car );
			
			carDto.Id = car.Id;
			
			return Ok(carDto);
		}

		[HttpPut]
		public IHttpActionResult UpdateCar(CarDTO carDto)
		{
			Car car = _carConverter.Convert( carDto );
			_maintenanceTrackerRepository.UpdateCar( car );
			return Ok( carDto );
		}

		[HttpDelete]
		public void DeleteCar([FromUri] long id )
		{
			_maintenanceTrackerRepository.DeleteCar( id );
		}
	}
}
