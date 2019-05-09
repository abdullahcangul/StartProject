
using StartProject.Entity;
using StartProject.Entity.ErrorModel;
using StartProject.Repository.EntityFramework;
using StartProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Service
{
    public class EmployeeManager:ManagerBase<Employee>
    {
        private Repository<Employee> repo = new Repository<Employee>();

        public ServiceResult<Employee> EmployeeAdd(Employee employee)
        {
            ServiceResult<Employee> resultService = new ServiceResult<Employee>();
            Employee employee2 = repo.Find(x => x.email == employee.email);
           if(employee2 != null)
            {
                resultService.Errors.Add("Email adresi zaten kayitli");
                return resultService;
            }
            if (repo.Insert(employee) > 0)
            {
                resultService.result = employee;
                return resultService;
            }
            resultService.Errors.Add("bir hata olustu");
            return resultService;
        }

    }
}
