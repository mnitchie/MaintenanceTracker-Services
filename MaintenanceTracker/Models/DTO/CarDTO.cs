namespace MaintenanceTracker.Models.DTO
{
	public class CarDTO
	{
		public long Id { get; set; }
		public CarMake Make { get; set; }
		public CarModel Model { get; set; }
		public string Year { get; set; }
		public string Name { get; set; }
		public string Vin { get; set; }
	}
}