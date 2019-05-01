using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(StartProject.Api.Startup))]

namespace StartProject.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
            {
            app.UseCors(CorsOptions.AllowAll);
            HttpConfiguration configuration = new HttpConfiguration();

            
            Configure(app);
                WebApiConfig.Register(configuration);
                app.UseWebApi(configuration);
                


        }
        private void Configure(IAppBuilder app)
            {
            
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
                {
               
            TokenEndpointPath = new Microsoft.Owin.PathString("/api/getToken"),//Token istek adresi
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),//Token gecerlilik zamanı   
                    AllowInsecureHttp = true,
                    Provider = new AuthorizationServerProvider(),
                   
                };
                app.UseOAuthAuthorizationServer(options);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
                
            }
        
    }
}
