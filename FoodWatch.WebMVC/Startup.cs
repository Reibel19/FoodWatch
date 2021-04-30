using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodWatch.WebMVC.Startup))]
namespace FoodWatch.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
