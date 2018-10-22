using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApp_NoAuth.Startup))]
namespace WebApp_NoAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
