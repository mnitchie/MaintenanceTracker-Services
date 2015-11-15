using System.Web.Http;
using System.Web.Http.Cors;

namespace MaintenanceTracker
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API routes
			config.MapHttpAttributeRoutes();


			/*config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);*/

			config.Routes.MapHttpRoute(
				name: "CarMake",
				routeTemplate: "api/carMakes",
				defaults: new { controller = "CarMake"}
			);
		}
	}
}
