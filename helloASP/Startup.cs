using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(helloASP.Startup))]
namespace helloASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
