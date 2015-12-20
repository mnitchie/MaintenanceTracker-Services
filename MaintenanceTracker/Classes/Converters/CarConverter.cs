using MaintenanceTracker.Models;
using MaintenanceTracker.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceTracker.Classes.Converters
{
	public class CarConverter
	{
		public CarDTO Convert(Car car)
		{
			return new CarDTO {
				Id = car.Id,
				Year = car.Year,
				Make = car.Make,
				Model = car.Model,
				Name = car.Name,
				Vin = car.Vin
			};
		}

		public IEnumerable<CarDTO> Convert(IEnumerable<Car> cars)
		{
			return cars.Select( c => Convert( c ) );
		}

		public Car Convert(CarDTO car)
		{
			return new Car {
				Id = car.Id,
				Year = car.Year,
				CarMakeId = car.Make.Id,
				Make = new CarMake {
					Id = car.Make.Id,
					Name = car.Make.Name
				},
				CarModelId = car.Model.Id,
				Model = new CarModel {
					Id = car.Model.Id,
					Name = car.Model.Name
				},
				Name = car.Name,
				Vin = car.Vin
			};
		}

		public IEnumerable<Car> Convert(IEnumerable<CarDTO> cars)
		{
			return cars.Select( c => Convert( c ) );
		}
	}
}