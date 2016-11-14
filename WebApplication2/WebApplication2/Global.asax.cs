using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication2.IoC;
using WebApplication2.Models.Identity;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            Database.SetInitializer(new ApplicationDBInitializer());
        }
    }
}
