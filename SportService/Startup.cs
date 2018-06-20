
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(SportService.Startup))]

namespace SportService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
