using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MvcQuartzNetTest.Models;
using MvcQuartzNetTest.Scheduler;

namespace MvcQuartzNetTest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var db = new DataDbContext())
            {
                db.Database.Initialize(false);
            }

            AutofacConfig.ConfigureContainer();

            //var cont = ContainerInstanceProvider.GetContainerInstance();

            DefaultScheduler.Start();
        }
    }
}
