using StartProject.Api.util;
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

        //Tüm employeeleri getirir
        public IHttpActionResult GetEmployee()
        {
            List<Employee> employee = employeeManager.List();

            if (employee.Count > 0)
            {
                return Ok(employee);
            }
            return NotFound();
        }

        public IHttpActionResult PostLogin(String email,String password)
        {
            Employee employee = employeeManager.Find(e => e.email == email && e.password == password);

            if (employee != null)
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
              //  return BadRequest(ModelState);
            }
            if (employee.profileImageFilename == null)
            {
                employee.profileImageFilename = "bos.png";
            }
            string deger = new ImageHelper().add(employee.FileName, Convert.FromBase64String(employee.fileBase64String), "");
            if (deger == "uzanti")
            {
                return BadRequest("Lütfen .jpg veya .png Yükleyiniz");
            }
            else if (deger == "boyut")
            {
                return BadRequest("Resim boyutu  büyük");
            }
            else
            {
                employee.profileImageFilename = deger;
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
            if (employee.FileName != null)
            {
               
                string deger = new ImageHelper().add(employee.FileName, Convert.FromBase64String(employee.fileBase64String), "");
                if (deger == "uzanti")
                {
                    return BadRequest("Lütfen .jpg veya .png Yükleyiniz");
                }
                else if (deger == "boyut")
                {
                    return BadRequest("Resim boyutu  büyük");
                }
                else
                {
                    employee.profileImageFilename = deger;
                }
            }
            if (employee.profileImageFilename != null)
            {
                // yeni resim başarılı eklendiyse
                if (employee2.profileImageFilename != "bos.png")
                {
                    // eski resmi sil
                    new ImageHelper().delete(employee.profileImageFilename);
                }

                // yeni resmi at
                employee2.profileImageFilename = employee.profileImageFilename;
                employee.name = employee.name;
                employee.email = employee.email;
                employee.isActive = employee.isActive;
                employee.surname = employee.surname;
                employee.password = employee.password;
            }
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
            new ImageHelper().delete(employee.profileImageFilename);

            employeeManager.Delete(employee);
            return Ok(employee);
        }
        
    }
}
