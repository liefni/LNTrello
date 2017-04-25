using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LNTrello.Startup))]
namespace LNTrello
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
