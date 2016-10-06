using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SoftwareEngineeringP1.Startup))]
namespace SoftwareEngineeringP1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
