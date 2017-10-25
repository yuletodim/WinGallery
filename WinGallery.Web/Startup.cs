using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WinGallery.Web.Startup))]
namespace WinGallery.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
