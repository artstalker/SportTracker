using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using SportTracker.Domain;
using SportTracker.Domain.SampleData;
using SportTracker.WebUI.App_Start;
using SportTracker.WebUI.Infrastructure;

namespace SportTracker.WebUI
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			DependencyResolver.SetResolver(new NinjectDependencyResolver());

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
			BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);

			//WebSecurityInitializer.Instance.EnsureInitialize();
			Database.SetInitializer(new EntitiesContextInitializer());


			//Database.SetInitializer(new MigrateDatabaseToLatestVersion<ModelSportTrackerContainer, SportTracker.Domain.Migrations.Configuration>());
			AuthConfig.RegisterAuth();
		}
	}
}