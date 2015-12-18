using EdmundsApiSDK;
using MaintenanceTracker.Classes.Converters;
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
