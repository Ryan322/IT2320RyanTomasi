using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebIndividual.Startup))]
namespace WebIndividual
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
