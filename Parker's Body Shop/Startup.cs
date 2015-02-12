using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parker_s_Body_Shop.Startup))]
namespace Parker_s_Body_Shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
