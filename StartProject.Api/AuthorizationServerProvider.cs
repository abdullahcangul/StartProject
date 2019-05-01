using Microsoft.Owin.Security.OAuth;
using StartProject.Entity;
using StartProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;

namespace StartProject.Api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            Employee employee=employeeManager.Find(x => x.email == context.UserName && x.password == context.Password);
            TitleManager titleManager = new TitleManager();
            Title title = titleManager.Find(x => x.ID == employee.TitleID);

            if (employee!=null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", employee.email));
                identity.AddClaim(new Claim("role", title.name));
                identity.AddClaim(new Claim("clientId",employee.ID.ToString()));
              
                context.Validated(identity);
                
            }
            else
            {
                context.SetError("Oturum Hatası", "Kullanıcı adı sifre hatalı");
            }
        }
    }
}