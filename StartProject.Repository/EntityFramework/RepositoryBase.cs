using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Repository.EntityFramework
{
    public class RepositoryBase
    {
        //  protected static DatabaseContext context;
        public  DatabaseContext context;
        protected static object _lockSync = new object();

        protected RepositoryBase()
        {
            // CreateContext();
            context = new DatabaseContext();
        }

        //private static void CreateContext()
        //{
        //    if (context == null)
        //    {
        //        lock (_lockSync)
        //        {
        //            if (context == null)
        //            {
        //                context = new DatabaseContext();
        //            }
        //        }

        //    }
        //}
        
    }
}
