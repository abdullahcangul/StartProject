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
    public class ContentManager:ManagerBase<Content>
    {
        //private Repository<Content> repo = new Repository<Content>();
        //private ProcessManager processManager = new ProcessManager();

        //private ServiceResult<Content> resultService = new ServiceResult<Content>();

        //public   ServiceResult<Content> UpdateBy(Content obj)
        //{
        //    Content content=repo.Find(x => x.ID == obj.ID);
        //    if (content != null)
        //    {
        //        content.isCustomer = obj.isCustomer;
        //        content.message = obj.message;
        //        content.ProcessID = obj.ProcessID;
        //        if (repo.Update(content) > 0)
        //        {
        //            resultService.result=content;
        //            return resultService;
        //        }
        //        resultService.Errors.Add("içerik güncellenemedi");
        //        return resultService;
        //    }
        //    resultService.Errors.Add("mesaj bulunamadı");
        //    return resultService;

        //}

    }
}
