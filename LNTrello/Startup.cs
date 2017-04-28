using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(LNTrello.Startup))]
namespace LNTrello
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            BootStrapper.Initialize();
        }
    }
}
