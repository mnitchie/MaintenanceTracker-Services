using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MaintenanceTracker
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);

			// Added because Visual Studio told me to after I added an MVC5 controller.
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes( RouteTable.Routes );
			FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
			BundleConfig.RegisterBundles( BundleTable.Bundles );
		}
	}
}
