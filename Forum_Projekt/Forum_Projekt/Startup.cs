using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Forum_Projekt.Startup))]
namespace Forum_Projekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
