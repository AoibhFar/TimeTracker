using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using Owin;

[assembly: OwinStartupAttribute(typeof(timeTracker.Web.Startup))]
namespace timeTracker.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            app.MapSignalR();
        }
    }
}
