using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Odyssey.Web.Startup))]
namespace Odyssey.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
