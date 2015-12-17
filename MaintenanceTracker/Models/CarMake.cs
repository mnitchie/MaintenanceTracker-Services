using System.ComponentModel.DataAnnotations;

namespace MaintenanceTracker.Models
{
	public class CarMake
	{
		[Key]
		public string NiceName { get; set; }
		public string Name { get; set; }
	}
}