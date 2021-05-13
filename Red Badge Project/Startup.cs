using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Red_Badge_Project.Startup))]
namespace Red_Badge_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
