using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S3_WebApplication.Startup))]
namespace S3_WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
