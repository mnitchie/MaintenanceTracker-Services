using EdmundsApiSDK;
using MaintenanceTracker.Models;
using MaintenanceTracker.Models.DTO;
using System;

namespace MaintenanceTracker.Classes
{
	public class EdmundsCarCreator : ICarCreator
	{

		private IEdmunds _edmundsRepository;

		public Car CreateCar( CarDTO carDto )
		{
			throw new NotImplementedException();
		}
	}
}