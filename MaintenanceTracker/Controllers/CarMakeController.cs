using System.Collections.Generic;
using System.Web.Http;

namespace MaintenanceTracker.Controllers
{
	public class CarMakeController : ApiController
	{
		[HttpGet]
		public IEnumerable<string> GetMakes()
		{
			return new string[] { "value1", "value2" };
		}
	}
}
