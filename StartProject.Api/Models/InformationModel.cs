using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartProject.Api.Models
{
    public class InformationModel
    {
        public int customerCount { get; set; }
        public int employeeCount { get; set; }
        public int projectCount { get; set; }
        public int contentCount { get; set; }
        public int processCount { get; set; }
    }
}