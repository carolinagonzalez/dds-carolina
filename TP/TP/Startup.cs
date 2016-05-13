using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TP.Startup))]
namespace TP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
