namespace WinGallery.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using log4net;
    using Services.Mappings;
    using Services.Utils;
    using WinGallery.Web.Infrastructure.Filters;

    [SetLanguage]
    public class BaseController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected ILog Logger
        {
            get
            {
                return AppLogger.logger;
            }
        }

#if !DEBUG
        protected override void OnException(ExceptionContext filterContext)
        {
            var exception = filterContext.Exception;
            var logMessage = GetExceptionInfo(filterContext);

            logger.Error(logMessage, exception);

            this.Response.Redirect($"/errors?httpErrorCode=500");

            base.OnException(filterContext);
        }

        private static string GetExceptionInfo(ExceptionContext context)
        {
            var lines = new List<string>();

            // TODO: Check if User is empty
            lines.Add($"User: {context.HttpContext.User}");
            lines.Add($"UserAgent: {context.HttpContext.Request.UserAgent}");
            lines.Add($"UserIp: {context.HttpContext.Request.UserHostAddress}");

            return string.Join(Environment.NewLine, lines);
        }
#endif
    }
}