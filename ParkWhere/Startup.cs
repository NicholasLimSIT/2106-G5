using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParkWhere.Startup))]
namespace ParkWhere
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
