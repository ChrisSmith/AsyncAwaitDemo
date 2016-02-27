using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrontEnd_45.Startup))]
namespace FrontEnd_45
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
