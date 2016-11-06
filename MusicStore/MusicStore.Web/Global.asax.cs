﻿using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MusicStore.Logic.Utils;
using MusicStore.Web.Infrastructure;

namespace MusicStore.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Initer.Init(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);

            BootstrapContainer();
        }

        protected void Application_End()
        {
            container.Dispose();
        }

        private static void BootstrapContainer()
        {
            container = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}