using StartProject.Entity;
using StartProject.Repository.EntityFramework;
using StartProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Service
{
    public class ProcessManager:ManagerBase<Process>
    {
        ContentManager contentManager = new ContentManager();
        Repository<Process> repository = new Repository<Process>();
        //Delete Content Of Process
        public override int Delete(Process obj)
        {
            Process process=repository.Find(x => x.ID == obj.ID);
            if (process != null)
            {
                List<Content> contents=contentManager.List(x => x.ProcessID == obj.ID);
                if (contents.Count() > 0)
                {
                    foreach (var content in contents)
                    {
                        contentManager.Delete(content);
                    }
                }
               return repository.Delete(process);
                
            }
            return 0;
        }
    }
}
