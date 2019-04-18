using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Entity
{
    [Table("Employees")]
    public class Employee:BaseEntity
    {
        
        [ForeignKey("User")]
        public int ID { get; set; }


        public int titleId { get; set; }

        public User User { get; set; }
        public List<Title> Titles { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Project> Projects { get; set; }
        public List<Process> Processes { get; set; }
    }
}
