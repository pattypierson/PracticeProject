using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeProject.Web.Startup))]
namespace PracticeProject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
