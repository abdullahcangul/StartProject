using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject.Entity
{
    [Table("Projects")]
    public class Project:BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("Adi"),
StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string name { get; set; }
        [DisplayName("Açiklama"),
StringLength(500, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string description { get; set; }
      
        
        public virtual List<Process> Processes { get; set; }
    
        public int? CustomerID { get; set; }
     
        public int? EmployeeID { get; set; }

        public  Customer Customer { get; set; }
        public  Employee Employee { get; set; }
    }
}
