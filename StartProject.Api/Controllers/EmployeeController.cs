using StartProject.Api.util;
using StartProject.Entity;
using StartProject.Entity.ErrorModel;
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
    //[Authorize]
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
                return BadRequest(ModelState);
            }
            if (employee == null)
            {
                return BadRequest();
            }
            if (employee.profileImageFilename == null)
            {
                employee.profileImageFilename = "user_boy.png";
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
            ServiceResult<Employee> serviceResult= employeeManager.EmployeeAdd(employee);
            if (serviceResult.Errors.Count>0)
            {
                return BadRequest(serviceResult.Errors[0]);
            }
            return CreatedAtRoute("DefaultApi", new { id = employee.ID }, serviceResult.result);
        }

        public IHttpActionResult PutEmployee(Employee employee)
        {

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
                if (employee2.profileImageFilename != "user_boy.png")
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

        //admin ve aktif pasif yapma
        [HttpGet]
        [Route("api/employee/aktifet/{id}")]
        public IHttpActionResult AktifEt(int id)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            if (employeeManager.List(x=>x.isActive==true).Count() > 0)
            {
                Employee employee = employeeManager.Find(x => x.ID == id); 
                employee.isActive = Convert.ToBoolean(employee.isActive) ? false : true;
                employeeManager.Update(employee);
                if (employee.isActive == true)
                {
                   return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            else
            {
              return  BadRequest("En az Bir yetkili hesap olmalı");
            }
        }

    }
}
