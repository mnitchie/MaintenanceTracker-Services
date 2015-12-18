using MaintenanceTracker.Models;
using MaintenanceTracker.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceTracker.Classes.Converters
{
	public class CarConverter
	{
		public SideLoadingCarDTO Convert(Car car)
		{
			return new SideLoadingCarDTO {
				Car = new CarDTO {
					Id = car.Id,
					Year = car.Year,
					Make = car.CarMakeNiceName,
					Model = car.CarModelNiceName,
				},
				Make = car.Make,
				Model = car.Model
			};
		}

		public IEnumerable<SideLoadingCarDTO> Convert(IEnumerable<Car> cars)
		{
			return cars.Select( c => Convert( c ) );
		}
	}
}