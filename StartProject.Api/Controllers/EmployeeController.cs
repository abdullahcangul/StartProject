using StartProject.Entity;
using StartProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StartProject.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeManager employeeManager = new EmployeeManager();

        public IHttpActionResult GetEmployee()
        {
            List<Employee> employee = employeeManager.List();

            if (employee.Count > 0)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = employeeManager.Find(x => x.ID == id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            employeeManager.Insert(employee);

            return CreatedAtRoute("DefaultApi", new { id = employee.ID }, employee);
        }

        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.ID)
            {
                return BadRequest();
            }

            employeeManager.Update(employee);

            return Ok();
        }

        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = employeeManager.Find(x => x.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            employeeManager.Delete(employee);
            return Ok(employee);
        }
    }
}
