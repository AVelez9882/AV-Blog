using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AV_Blog.Startup))]
namespace AV_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
