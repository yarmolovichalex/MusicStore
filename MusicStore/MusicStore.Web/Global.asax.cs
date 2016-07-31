using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using MusicStore.Logic.Utils;

namespace MusicStore.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Initer.Init(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
        }
    }
}
