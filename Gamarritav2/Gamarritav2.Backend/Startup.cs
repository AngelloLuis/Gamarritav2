using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gamarritav2.Backend.Startup))]
namespace Gamarritav2.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
