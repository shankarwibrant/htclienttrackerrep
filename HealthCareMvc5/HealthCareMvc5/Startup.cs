using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthCareMvc5.Startup))]
namespace HealthCareMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
