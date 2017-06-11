using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2014150654.MVC.Startup))]
namespace _2014150654.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
