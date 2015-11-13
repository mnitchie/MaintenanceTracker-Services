using System.Web.Mvc;

namespace MaintenanceTracker.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}