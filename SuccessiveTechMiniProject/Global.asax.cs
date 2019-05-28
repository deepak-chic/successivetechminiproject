﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace SuccessiveTechMiniProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Register Dependency
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IWebApiHelper<Person>, WebApIHelper<Person>>();            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            

        }
    }
}
