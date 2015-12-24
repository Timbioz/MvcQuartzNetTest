using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcQuartzNetTest.Startup))]
namespace MvcQuartzNetTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
