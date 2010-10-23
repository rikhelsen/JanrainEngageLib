using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Engage.Web.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Engage.Signout", // Route name
                "EngageAuthentication/SignOut", // URL with parameters
                new {controller = "EngageAuthentication", action = "SignOut"} // Parameter defaults
                );

            routes.MapRoute(
                "Engage.HandleResponse", // Route name
                "EngageAuthentication/HandleResponse", // URL with parameters
                new {controller = "EngageAuthentication", action = "HandleResponse"} // Parameter defaults
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}