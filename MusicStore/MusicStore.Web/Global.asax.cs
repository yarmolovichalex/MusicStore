using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using MusicStore.Logic.Utils;

namespace MusicStore.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Initer.Init(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
        }
    }
}
