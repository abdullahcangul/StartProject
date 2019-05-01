using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StartProject.Api.Controllers
{
    [Authorize]
    public class AuthorizationController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(UserInfoMethod.CurrentUser());
        }
    }
}
