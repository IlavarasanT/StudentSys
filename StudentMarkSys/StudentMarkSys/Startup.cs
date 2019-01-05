using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentMarkSys.Startup))]
namespace StudentMarkSys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
