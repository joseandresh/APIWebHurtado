using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admAPIWebHurtado.Startup))]
namespace admAPIWebHurtado
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
