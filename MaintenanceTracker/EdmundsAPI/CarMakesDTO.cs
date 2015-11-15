using System.Collections.Generic;

namespace MaintenanceTracker.EdmundsAPI.Obj
{
	public class CarMakesDTO
	{
		public IEnumerable<Make> Makes { get; set; }
		public int MakesCount { get; set; }
	}
}
