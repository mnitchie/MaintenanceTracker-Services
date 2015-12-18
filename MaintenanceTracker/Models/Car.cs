using System.ComponentModel.DataAnnotations;

namespace MaintenanceTracker.Models
{
	public class Car
	{
		public long Id { get; set; }
		[Required]
		public string Year { get; set; }
		[Required]
		public string CarMakeId { get; set; }
		public CarMake Make { get; set; }
		[Required]
		public string CarModelId { get; set; }
		public CarModel Model { get; set; }
	}
}