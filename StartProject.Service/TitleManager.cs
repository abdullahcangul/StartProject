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
    public class TitleManager:ManagerBase<Title>
    {
        Repository<Title> repository = new Repository<Title>();
        EmployeeManager employeeManager = new EmployeeManager();
        ServiceResult<Title> resultService = new ServiceResult<Title>();
        public ServiceResult<Title> DeleteBy(int id)
        {
          List<Employee> employees= employeeManager.List(x=>x.TitleID==id);
            if (employees.Count()>0)
            {
                 resultService.Errors.Add("unvan'lı  çalısan bulundugu için silinemiyor");
                return resultService;
            }
            Title title=repository.Find(x => x.ID == id);
            if (title!=null)
            {
                repository.Delete(title);
                resultService.result = title;
                return resultService;
            }
            resultService.Errors.Add("unvan bulunamadı");
            return resultService;
        }
    }
}
