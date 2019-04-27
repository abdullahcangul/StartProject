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
    [Table("Processes")]
    public class Process:BaseEntity
    {
        public Process()
        {
            Contents = new List<Content>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("Öncelik"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string priority { get; set; }

        [DisplayName("Durumu"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string status { get; set; }
        public DateTime? projectedFinishDate { get; set; }

        
        public int? EmployeeID { get; set; }
        
        public int? ProjectID { get; set; }

        public  Employee Employee { get; set; }
        public  Project Project { get; set; }
        public  List<Content> Contents { get; set; }



    }
}
