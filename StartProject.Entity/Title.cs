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
    [Table("Titles")]
    public class Title:BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("İsim"), Column("first_name"),
    StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string name { get; set; }
        [DisplayName("Açıklama"),
StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string description { get; set; }

        //public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
