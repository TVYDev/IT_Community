using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommunityWeb.Startup))]
namespace CommunityWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
