using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab03.Startup))]
namespace Lab03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
