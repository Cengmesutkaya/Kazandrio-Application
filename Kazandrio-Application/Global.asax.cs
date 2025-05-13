using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentScheduler;
using Kazandrio_Application.Jobs;

namespace Kazandrio_Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var registry = new Registry();

            // İşin ne sıklıkla çalışacağını belirtiyoruz (örneğin her gün saat 12'de)
            //registry.Schedule<AppiumTestJob>().ToRunEvery(1).Days().At(12, 0); // Her gün 12'de çalışacak
            registry.Schedule<AppiumTestJob>().ToRunNow(); // Her gün 12'de çalışacak

            // FluentScheduler'ı başlatıyoruz
            JobManager.Initialize(registry);
        }
    }
}
