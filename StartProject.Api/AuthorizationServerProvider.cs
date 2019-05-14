

using Microsoft.Owin.Security.OAuth;
using StartProject.Entity;
using StartProject.Service;
using System.Security.Claims;
using System.Threading.Tasks;
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
            CustomerManager customerManager = new CustomerManager();
            Employee employee=employeeManager.Find(x => x.email == context.UserName && x.password == context.Password);
            Customer customer = customerManager.Find(x => x.email == context.UserName && x.password == context.Password);


            
            if (employee!=null)
            {
                if (employee.isActive == false)
                {
                    context.SetError("Oturum Hatası", "Kullanıcı Pasif");
                }
                else
                {
                    TitleManager titleManager = new TitleManager();

                    Title title = titleManager.Find(x => x.ID == employee.TitleID);
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("sub", employee.email));
                    identity.AddClaim(new Claim("role", "calisan"));
                    identity.AddClaim(new Claim("clientId", employee.ID.ToString()));


                    context.Validated(identity);
                }

                
            }
            else if (customer!=null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", customer.email));
                identity.AddClaim(new Claim("role", "musteri"));
                identity.AddClaim(new Claim("clientId", customer.ID.ToString()));

                context.Validated(identity);
            }
            else
            {
                context.SetError("Oturum Hatası", "Kullanıcı adı sifre hatalı");
            }
        }
    }
}