using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeautyCare.Presentation.Startup))]
namespace BeautyCare.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
