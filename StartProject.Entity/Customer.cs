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
    [Table("Customers")]
    public class Customer:BaseEntity
    {
        public Customer()
        {
            Projects = new List<Project>();
        }
        
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("Firma ismi"), Column("company_name"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string name { get; set; }

        [DisplayName("E-Posta"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string email { get; set; }

        [DisplayName("Yetkili"), 
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string competnent { get; set; }
        [DisplayName("Url"),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string url { get; set; }
        [DisplayName("Açıklama"),
            StringLength(500, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string description { get; set; }


        
        public int? EmployeeID { get; set; }
        public  Employee Employee { get; set; }
        
        public  List<Project> Projects { get; set; }
    }
}
