using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArenaAlbionuPoradnik.Startup))]
namespace ArenaAlbionuPoradnik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
