using StartProject.Entity;
using StartProject.Entity.ErrorModel;
using StartProject.Repository.EntityFramework;
using StartProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Service
{
    public class DepartmantManager: ManagerBase<Departmant>
    {
        Repository<Departmant> repository = new Repository<Departmant>();
        EmployeeManager employeeManager = new EmployeeManager();
        ServiceResult<Departmant> resultService = new ServiceResult<Departmant>();
        public ServiceResult<Departmant> DeleteBy(int id)
        {
            List<Employee> employees = employeeManager.List(x => x.TitleID == id);
            if (employees.Count() > 0)
            {
                resultService.Errors.Add("departmanın  çalısanı bulundugu için silinemiyor");
                return resultService;
            }
            Departmant departmant = repository.Find(x => x.ID == id);
            if (departmant != null)
            {
                repository.Delete(departmant);
                resultService.result = departmant;
                return resultService;
            }
            resultService.Errors.Add("departman bulunamadı");
            return resultService;
        }
    }
}
