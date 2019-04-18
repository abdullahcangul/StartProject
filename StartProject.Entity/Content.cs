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
    [Table("Contents")]
    public class Content:BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("Mesaj"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(300, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string message { get; set; }

        public bool isCustomer { get; set; }

        
        public Process Process { get; set; }
    }
}
