using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevMeetups.Startup))]
namespace DevMeetups
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
