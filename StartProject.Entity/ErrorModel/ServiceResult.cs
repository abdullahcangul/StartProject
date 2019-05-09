using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Entity.ErrorModel
{
    public class ServiceResult<T> where T:class
    {
        public List<String> Errors { get; set; }
        public T result { get; set; }
    }
}
