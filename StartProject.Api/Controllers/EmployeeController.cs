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
            if (employee2==null)
            {
                return NotFound();
            }
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
                employee2.name = employee.name;
                employee2.email = employee.email;
                employee2.surname = employee.surname;
                employee2.password = employee.password;
                employee2.DepartmantID = employee.DepartmantID;
                employee2.TitleID = employee.TitleID;
            }
            employeeManager.Update(employee2);
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
        public IHttpActionResult AktiflikKontrol(int id)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            ServiceResult<Employee> resultService= employeeManager.AktiflikKontrol(id);
            if (resultService.Errors.Count()>0)
            {
                return BadRequest(resultService.Errors[0]);
            }
            if (resultService.result.isActive == true)
            {
                return Ok(true);
            }
            else
            {
               return Ok(false);
            }
           
        }
        //ANDROİD
        [AllowAnonymous]
        [Route("api/login")]
        public IHttpActionResult PostLogin([FromBody]Login login)
        {
            TitleManager titleManager = new TitleManager();
            DepartmantManager departmantManager = new DepartmantManager();
            ProjectManager projectManager = new ProjectManager();
            ProcessManager processManager = new ProcessManager();
            ContentManager contentManager = new ContentManager();
            CustomerManager customerManager = new CustomerManager();

            Employee employee = employeeManager.Find(e => e.email == login.email && e.password == login.password);
            if (employee != null)
            {
                Title title = titleManager.Find(x => x.ID == employee.TitleID);
                employee.Title = title;
                Departmant departmant = departmantManager.Find(x => x.ID == employee.DepartmantID);
                employee.Departmant = departmant;
                List<Process> processes = processManager.List(x => x.EmployeeID == employee.ID);
                foreach (Process item in processes)
                {
                    Project project = projectManager.Find(x => x.ID == item.ProjectID);
                    Customer customer = customerManager.Find(c => c.ID == project.CustomerID);
                    project.Customer = customer;
                    item.Project = project;
                    List<Content> contents = contentManager.List(x => x.ProcessID == item.ID);
                    item.Contents = contents;
                }
                employee.Processes = processes;
                return Ok(employee);
            }
            return NotFound();
        }



    }
    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }
    }

}
