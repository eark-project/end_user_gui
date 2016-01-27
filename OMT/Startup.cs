using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OMT.Startup))]
namespace OMT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
