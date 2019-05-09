

using System;
using System.Linq;
using System.Security.Claims;

namespace StartProject.Api
{
    internal class UserInfoMethod
    {
        internal static UserInfo CurrentUser()
        {
            var claims = ClaimsPrincipal.Current.Identities.First().Claims;


            var result = new UserInfo()
            {
                userName = claims.First(x => x.Type == "sub").Value,
                role = claims.First(x => x.Type == "role").Value,
                clientId = Convert.ToInt32(claims.First(x => x.Type == "clientId").Value)
            };
            return result;
        }
    }
}