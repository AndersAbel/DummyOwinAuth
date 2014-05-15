using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleMvcApp.Startup))]
namespace SampleMvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
