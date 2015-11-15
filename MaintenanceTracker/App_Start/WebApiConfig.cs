using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace MaintenanceTracker
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API routes
			config.MapHttpAttributeRoutes();

			// Camel-case JSON
			var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;
			jsonSettings.Formatting = Formatting.Indented;
			jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			// Set up routes
			config.Routes.MapHttpRoute(
				name: "CarMake",
				routeTemplate: "api/carMakes",
				defaults: new { controller = "CarMake"}
			);
		}
	}
}
