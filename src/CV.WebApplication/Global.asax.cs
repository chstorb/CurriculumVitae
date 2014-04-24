using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CV.WebApplication
{
    using CV.WebApplication.Models;
    using System.Data.Entity.Infrastructure.Interception;
    using System.IO;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // :STC: Begin
            AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
#if DEBUG
            DbInterception.Add(new CustomDbCommandInterceptor());
            DbInterception.Add(new TransientErrorDbCommandInterceptor());
#endif
            // :STC End
        }
    }
}
