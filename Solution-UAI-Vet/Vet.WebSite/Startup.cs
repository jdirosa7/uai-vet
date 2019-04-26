using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vet.WebSite.Startup))]
namespace Vet.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
