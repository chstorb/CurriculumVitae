using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CV.WebApplication.Startup))]
namespace CV.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
