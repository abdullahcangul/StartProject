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
    public class CustomerManager:ManagerBase<Customer>
    {
        private Repository<Customer> repo = new Repository<Customer>();
        private ServiceResult<Customer> resultService = new ServiceResult<Customer>();

        public ServiceResult<Customer> CustomerAdd(Customer customer)
        {
            ServiceResult<Customer> resultService = new ServiceResult<Customer>();
            Customer customer2 = repo.Find(x => x.email == customer.email);
            if (customer2 != null)
            {
                resultService.Errors.Add("Email adresi zaten kayitli");
                return resultService;
            }
            if (repo.Insert(customer) > 0)
            {
                resultService.result = customer;
                return resultService;
            }
            resultService.Errors.Add("bir hata olustu");
            return resultService;
        }
        public ServiceResult<Customer> DeleteCustomer(Customer obj)
        {
            ProjectManager projectManager = new ProjectManager();
            Customer customer = repo.Find(x=>x.ID== obj.ID);
            if (customer!=null)
            {
                if (projectManager.List(x=>x.CustomerID== obj.ID).Count()>0)
                {
                    resultService.Errors.Add("Müsteriye ait proje oldugundan silinmiyor");
                    return resultService;
                }
                resultService.result = obj;
                repo.Delete(customer);
                return resultService;
            }
            resultService.Errors.Add("Müşteri bulunamadı");
            return resultService;
        }
    }
}
