using System.ComponentModel.DataAnnotations;

namespace MaintenanceTracker.Classes
{
	public class Car
	{
		public long Id { get; set; }
		[Required]
		public string Year { get; set; }
		[Required]
		public string CarMakeNiceName { get; set; }
		public CarMake Make { get; set; }
		[Required]
		public string CarModelNiceName { get; set; }
		public CarModel Model { get; set; }
	}
}