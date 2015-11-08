using System.Web.Mvc;

namespace MaintenanceTracker.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return File( "~/Controllers/index.html", "text/html");
		}
	}
}