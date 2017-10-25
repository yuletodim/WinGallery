using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WinGallery.Services.Mappings;
using WinGallery.Services.Models;
using WinGallery.Web.App_Start;

namespace WinGallery.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacConfig.RegisterAutofac();

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetAssembly(typeof(UserModel)), Assembly.GetExecutingAssembly());
        }

        // Global Error Handling
        protected void Application_Error(object sender, EventArgs e)
        {
#if !DEBUG
            var exception = this.Server.GetLastError() as HttpException;

            if (exception != null)
            {
                var httpCode = exception.GetHttpCode();
                this.Response.Redirect($"/Errors?httpErrorCode={httpCode}");
            }
#endif
        }
    }
}
