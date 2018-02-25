namespace WinGallery.Web.Infrastructure.Filters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;

    public class SetLanguageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var lang = string.Empty;

            if (filterContext.HttpContext.Request.Cookies.AllKeys.Contains("lang"))
            {
                lang = filterContext.HttpContext.Request.Cookies["lang"].Value;
            }
            else
            {
                lang = filterContext.HttpContext.Request.UserLanguages[0];
                var cookieLang = new HttpCookie("lang");
                cookieLang.Value = lang;
                cookieLang.Expires = DateTime.UtcNow.AddYears(1);
                filterContext.HttpContext.Response.Cookies.Add(cookieLang);
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

            base.OnActionExecuting(filterContext);
        }
    }
}