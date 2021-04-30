using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KaspiShop.Startup))]
namespace KaspiShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
