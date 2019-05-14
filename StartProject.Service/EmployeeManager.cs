
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
        ServiceResult<Employee> resultService = new ServiceResult<Employee>();

        public ServiceResult<Employee> EmployeeAdd(Employee employee)
        {
            
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

        public ServiceResult<Employee> AktiflikKontrol(int id)
        {
            //en son bir tane admin olsun
            if (repo.List(x => x.isActive == true).Count() > 0)
            {
                Employee employee = repo.Find(x => x.ID == id);
                employee.isActive = Convert.ToBoolean(employee.isActive) ? false : true;
                if(repo.Update(employee)>0)
                {
                    resultService.result = employee;
                    return resultService;
                }
                resultService.Errors.Add("Hata Olustu");
                return resultService;
            }
            resultService.Errors.Add("En Az bir tane yetkili kullanıcı bulunmalı");
            return resultService;
        }

    }
}
