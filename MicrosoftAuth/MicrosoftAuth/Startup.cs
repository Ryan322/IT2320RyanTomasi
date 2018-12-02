using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MicrosoftAuth.Startup))]
namespace MicrosoftAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
