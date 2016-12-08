using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PreStartBackend.Startup))]

namespace PreStartBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}