using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using TestingSystem.DataProvider.DataContext;
using TestingSystem.Website.Util;

namespace TestingSystem.Website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            Database.SetInitializer(new TestInitializer());
            
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
