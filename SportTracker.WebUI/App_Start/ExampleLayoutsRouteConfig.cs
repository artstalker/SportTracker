using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using NavigationRoutes;


namespace BootstrapMvcSample
{
    public class ExampleLayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapNavigationRoute<HomeController>("Home", c => c.Index());

				//routes.MapNavigationRoute<ExampleLayoutsController>("Example Layouts", c => c.Starter())
				//		.AddChildRoute<ExampleLayoutsController>("Marketing", c => c.Marketing())
				//		.AddChildRoute<ExampleLayoutsController>("Fluid", c => c.Fluid())
				//		.AddChildRoute<ExampleLayoutsController>("Sign In", c => c.SignIn())
				//	 ;
				routes.MapNavigationRoute<HomeController>("Training", c => c.Training());
				routes.MapNavigationRoute<HomeController>("Statistics", c => c.Statistic());
				routes.MapNavigationRoute<HomeController>("Friends", c => c.Friends());
				routes.MapNavigationRoute<HomeController>("Calendar", c => c.Calendar());
				routes.MapNavigationRoute<HomeController>("Competitions", c => c.Competitions());
        }
    }
}
