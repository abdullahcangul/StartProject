using StartProject.Entity;
using StartProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

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

        public IHttpActionResult PutEmployee(Employee employee)
        {
            ModelState.Remove("createdAt");
            ModelState.Remove("createdBy");
            ModelState.Remove("updatedAt");
            ModelState.Remove("updatedBy");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
                Employee employee2 = employeeManager.Find(x => x.ID == employee.ID);
                employee2.name = employee.name;
                employee2.email = employee.email;
                employee2.isActive = employee.isActive;
                employee2.surname = employee.surname;
                employee2.password = employee.password;

                employeeManager.Update(employee);
                return Ok(employee);
           
            
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
