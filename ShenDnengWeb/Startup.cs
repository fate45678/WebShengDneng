using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShenDnengWeb.Startup))]
namespace ShenDnengWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
