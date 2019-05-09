using StartProject.Api.Models;
using StartProject.Service;
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

        [Route("api/info")]
        public IHttpActionResult GetDashboard()
        {
            CustomerManager customerManager = new CustomerManager();
            EmployeeManager employeeManager = new EmployeeManager();
            ProcessManager processManager = new ProcessManager();
            ContentManager contentManager = new ContentManager();
            ProjectManager projectManager = new ProjectManager();
            InformationModel info = new InformationModel();

            info.customerCount = customerManager.List().Count();
            info.employeeCount = employeeManager.List().Count();
            info.processCount = processManager.List().Count();
            info.contentCount = contentManager.List().Count();
            info.projectCount = projectManager.List().Count();

            return Ok(info);
        }
    }


}
