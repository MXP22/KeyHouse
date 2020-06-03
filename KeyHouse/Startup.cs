using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KeyHouse.StartupOwin))]

namespace KeyHouse
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
