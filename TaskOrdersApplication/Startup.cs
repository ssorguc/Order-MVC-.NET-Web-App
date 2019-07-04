using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskOrdersApplication.Startup))]
namespace TaskOrdersApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
