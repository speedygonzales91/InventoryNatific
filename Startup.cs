using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventoryNatific.Startup))]
namespace InventoryNatific
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
