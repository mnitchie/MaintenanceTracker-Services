using EdmundsApiSDK;
using MaintenanceTracker.Repositories;
using Microsoft.Practices.Unity;
using System.Configuration;
using System.Web.Http;
using Unity.WebApi;

namespace MaintenanceTracker
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();
			
			// register all your components with the container here
			// it is NOT necessary to register your controllers
			
			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<IEdmunds, Edmunds>();
			container.RegisterType<Edmunds>( new InjectionConstructor(ConfigurationManager.AppSettings[ "edmundsApiKey" ] ));

			container.RegisterType<IMaintenanceTrackerRepository, MaintenanceTrackerRepository>();

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}
